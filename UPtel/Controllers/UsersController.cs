using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UPtel.Data;
using UPtel.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace UPtel.Controllers
{
    public class UsersController : Controller
    {

        private readonly UPtelContext _context;
        private readonly UserManager<IdentityUser> _gestorUtilizadores;

        private enum TipoDeUtilizador
        {
            Cliente = 1,
            ClienteEmpresarial = 2,
            Operador = 3,
            Administrador = 4
        }

        public UsersController(UPtelContext context, UserManager<IdentityUser> gestorUtilizadores)
        {
            _context = context;
            _gestorUtilizadores = gestorUtilizadores;
        }

        // GET: Clientes
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Users.Where(p => p.Nome.Contains(nomePesquisar) || p.Contribuinte.Contains(nomePesquisar) || p.Tipo.Tipo.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Users> users = await _context.Users.Where(p => p.Nome.Contains(nomePesquisar) || p.Contribuinte.Contains(nomePesquisar) || p.Tipo.Tipo.Contains(nomePesquisar))
                    .Include(t => t.Tipo)
                    .OrderBy(c => c.Nome)
                    .OrderBy(c => c.Contribuinte)
                    .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                    .Take(paginacao.ItemsPorPagina)
                    .ToListAsync();

            List<Users> maisAntigos = await _context.Users.OrderBy(c => c.DataRegisto).ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                Users = users,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }

        public async Task<IActionResult> MaisAntigo()
        {
            List<Users> maisAntigos = await _context.Users.Where(p => p.Tipo.Tipo.Contains("Cliente")).Include(t => t.Tipo).OrderBy(c => c.DataRegisto).ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Users = maisAntigos,
            };

            return base.View(modelo);
        }

        // GET: User/Details/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Tipo)
                .Include(u => u.DistritoNome)
                .FirstOrDefaultAsync(m => m.UsersId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DetailsCliente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Tipo)
                .Include(u => u.DistritoNome)
                .FirstOrDefaultAsync(m => m.UsersId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DetailsEmpresa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Tipo)
                .Include(u => u.DistritoNome)
                .FirstOrDefaultAsync(m => m.UsersId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        public async Task<IActionResult> DetailsClienteTopTen(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Tipo)
                .Include(u => u.DistritoNome)
                .FirstOrDefaultAsync(m => m.UsersId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DetailsEmpresaTopTen(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Tipo)
                .Include(u => u.DistritoNome)
                .FirstOrDefaultAsync(m => m.UsersId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //GET : User/RegistoAdministrador
        [Authorize(Roles = "Administrador")]
        public IActionResult RegistoAdministrador()
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito.Where(x => !x.DistritoNome.Contains("Nacional"))
                .OrderBy(x => x.DistritoNome), "DistritoId", "DistritoNome");

            return View();
        }
        // POST : User/RegistoAdministrador
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> RegistoAdministrador(RegistoUserViewModel infoUsers, IFormFile ficheiroFoto)
        {

            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Administrador");
            infoUsers.TipoId = tipo.TipoId;

            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }
            if (await VerificaEmailAsync(infoUsers))
            {
                ModelState.AddModelError("Email", "Este email já existe");
            }
            if (infoUsers.Data > DateTime.Today.AddYears(-18))
            {
                ModelState.AddModelError("DataNascimento", "Para se registar tem que ter mais de 18 anos");
            }
            if (ficheiroFoto != null)
            {
                if (ficheiroFoto.Length >= 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "Excedeu o limite máximo de 2 Mb para o tamanho da foto.");
                }
            }

            CriaFotoUser(infoUsers, ficheiroFoto);

            if (!VerificaNIF(infoUsers))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }
            if (await VerificaContribuinteAsync(infoUsers))
            {
                ModelState.AddModelError("Contribuinte", "Este contribuinte já está em uso");
            }
            if (infoUsers.CartaoCidadao != null)
            {
                if (await VerificaCCAsync(infoUsers))
                {
                    ModelState.AddModelError("CartaoCidadao", "Este número de CC já está em uso");
                }
            }
            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }
            if (!await CriaUtilizadorAsync(infoUsers, "Administrador"))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }
            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }

            ViewBag.Mensagem = "Administrador adicionado com sucesso";
            return View("Sucesso");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //GET : User/RegistoOperador
        [Authorize(Roles = "Administrador")]
        public IActionResult RegistoOperador()
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito.Where(x => !x.DistritoNome.Contains("Nacional"))
                .OrderBy(x => x.DistritoNome), "DistritoId", "DistritoNome");

            return View();
        }

        // POST : User/RegistoOperador
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> RegistoOperador(RegistoUserViewModel infoUsers, IFormFile ficheiroFoto)
        {
            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Operador");
            infoUsers.TipoId = tipo.TipoId;

            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }
            if (await VerificaEmailAsync(infoUsers))
            {
                ModelState.AddModelError("Email", "Este email já existe");
            }
            if (infoUsers.Data > DateTime.Today.AddYears(-18))
            {
                ModelState.AddModelError("DataNascimento", "Para se registar tem que ter mais de 18 anos");
            }

            if (ficheiroFoto != null)
            {
                if (ficheiroFoto.Length >= 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "Excedeu o limite máximo de 2 Mb para o tamanho da foto.");
                }
            }

            CriaFotoUser(infoUsers, ficheiroFoto);

            if (!VerificaNIF(infoUsers))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }
            if (await VerificaContribuinteAsync(infoUsers))
            {
                ModelState.AddModelError("Contribuinte", "Este contribuinte já está em uso");
            }
            if (infoUsers.CartaoCidadao != null)
            {
                if (await VerificaCCAsync(infoUsers))
                {
                    ModelState.AddModelError("CartaoCidadao", "Este número de CC já está em uso");
                }
            }
            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }
            if (!await CriaUtilizadorAsync(infoUsers, "Operador"))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }

            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }

            ViewBag.Mensagem = "Operador adicionado com sucesso";
            return View("Sucesso");

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //GET : User/RegistoClienteEmpresa
        [Authorize(Roles = "Administrador")]
        public IActionResult RegistoClienteEmpresa()
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito.Where(x => !x.DistritoNome.Contains("Nacional"))
                .OrderBy(x => x.DistritoNome), "DistritoId", "DistritoNome");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        // POST : User/RegistoClienteEmpresa
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> RegistoClienteEmpresa(RegistoUserViewModel infoUsers, IFormFile ficheiroFoto)
        {
            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Cliente Empresarial");
            infoUsers.TipoId = tipo.TipoId;

            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }
            if (await VerificaEmailAsync(infoUsers))
            {
                ModelState.AddModelError("Email", "Este email já existe");
            }

            //if (infoUsers.Data > DateTime.Today.AddYears(-18))
            //{
            //    ModelState.AddModelError("DataNascimento", "Para se registar tem que ter mais de 18 anos");
            //}
            if (ficheiroFoto != null)
            {
                if (ficheiroFoto.Length >= 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "Excedeu o limite máximo de 2 Mb para o tamanho da foto.");
                }
            }
            CriaFotoUser(infoUsers, ficheiroFoto);


            if (!VerificaNIF(infoUsers))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }
            if (await VerificaContribuinteAsync(infoUsers))
            {
                ModelState.AddModelError("Contribuinte", "Este contribuinte já está em uso");
            }
            if (infoUsers.CartaoCidadao != null)
            {
                if (await VerificaCCAsync(infoUsers))
                {
                    ModelState.AddModelError("CartaoCidadao", "Este número de CC já está em uso");
                }
            }
            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }
            if (!await CriaUtilizadorAsync(infoUsers, "Cliente"))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }
            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }

            ViewBag.Mensagem = "Cliente adicionado com sucesso";
            return View("Sucesso");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // GET: User/RegistoClienteParticular
        [Authorize(Roles = "Administrador")]
        public IActionResult RegistoClienteParticular()
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito.Where(x => !x.DistritoNome.Contains("Nacional"))
                .OrderBy(x => x.DistritoNome), "DistritoId", "DistritoNome");

            return View();
        }

        // POST: User/RegistoClienteParticular
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> RegistoClienteParticular(RegistoUserViewModel infoUsers, IFormFile ficheiroFoto)
        {
            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Cliente Particular");
            infoUsers.TipoId = tipo.TipoId;

            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }
            if (await VerificaEmailAsync(infoUsers))
            {
                ModelState.AddModelError("Email", "Este email já existe");
            }
            if (infoUsers.Data > DateTime.Today.AddYears(-18))
            {
                ModelState.AddModelError("DataNascimento", "Para se registar tem que ter mais de 18 anos");
            }
            if (ficheiroFoto != null)
            {
                if (ficheiroFoto.Length >= 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "Excedeu o limite máximo de 2 Mb para o tamanho da foto.");
                }
            }
            CriaFotoUser(infoUsers, ficheiroFoto);

            if (!VerificaNIF(infoUsers))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }
            if (await VerificaContribuinteAsync(infoUsers))
            {
                ModelState.AddModelError("Contribuinte", "Este contribuinte já está em uso");
            }
            if (infoUsers.CartaoCidadao != null)
            {
                if (await VerificaCCAsync(infoUsers))
                {
                    ModelState.AddModelError("CartaoCidadao", "Este número de CC já está em uso");
                }
            }
            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }
            if (!await CriaUtilizadorAsync(infoUsers, "Cliente"))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }

            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }

            ViewBag.Mensagem = "Cliente adicionado com sucesso";
            return View("Sucesso");
        }



        // GET: Funcionários/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente o cliente já foi eliminado.";
                return View("Erro");
            }

            ViewData["DistritoId"] = new SelectList(_context.Distrito.Where(x => !x.DistritoNome.Contains("Nacional"))
                .OrderBy(x => x.DistritoNome), "DistritoId", "DistritoNome");

            return View(users);
        }

        // POST: Funcionários/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, Users users, IFormFile ficheiroFoto)
        {
            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var user = _context.Users.AsNoTracking().SingleOrDefault(m => m.UsersId == id);
            users.DataRegisto = user.DataRegisto;

            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Administrador");
            users.TipoId = tipo.TipoId;

            if (id != users.UsersId)
            {
                return NotFound();
            }
            if (ficheiroFoto != null)
            {
                if (ficheiroFoto.Length >= 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "Excedeu o limite máximo de 2 Mb para o tamanho da foto.");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AtualizaFotoUser(users, ficheiroFoto);
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UsersId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Cliente alterado com sucesso";
                return View("Sucesso");
            }
            return View(users);
        }

        // GET: operador/Edit/5
        public async Task<IActionResult> EditOperador(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente o cliente já foi eliminado.";
                return View("Erro");
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito.Where(x => !x.DistritoNome.Contains("Nacional"))
                .OrderBy(x => x.DistritoNome), "DistritoId", "DistritoNome");

            return View(users);
        }

        // POST: operador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOperador(int id, Users users, IFormFile ficheiroFoto)
        {
            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var user = _context.Users.AsNoTracking().SingleOrDefault(m => m.UsersId == id);
            users.DataRegisto = user.DataRegisto;

            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Operador");
            users.TipoId = tipo.TipoId;
            if (id != users.UsersId)
            {
                return NotFound();
            }
            if (ficheiroFoto != null)
            {
                if (ficheiroFoto.Length >= 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "Excedeu o limite máximo de 2 Mb para o tamanho da foto.");
                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    AtualizaFotoUser(users, ficheiroFoto);
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UsersId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Cliente alterado com sucesso";
                return View("Sucesso");
            }
            return View(users);
        }



        // GET: User/Edit/5
        [Authorize(Roles = "Administrador,Cliente")]
        public async Task<IActionResult> EditCliente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente o cliente já foi eliminado.";
                return View("Erro");
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito.Where(x => !x.DistritoNome.Contains("Nacional"))
                .OrderBy(x => x.DistritoNome), "DistritoId", "DistritoNome");
            return View(users);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,Cliente")]
        public async Task<IActionResult> EditCliente(int id, Users users, IFormFile ficheiroFoto)
        {
            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var user = _context.Users.AsNoTracking().SingleOrDefault(m => m.UsersId == id);
            users.DataRegisto = user.DataRegisto;

            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Cliente Particular");
            users.TipoId = tipo.TipoId;

            if (id != users.UsersId)
            {
                return NotFound();
            }
            if (ficheiroFoto != null)
            {
                if (ficheiroFoto.Length >= 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "Excedeu o limite máximo de 2 Mb para o tamanho da foto.");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AtualizaFotoUser(users, ficheiroFoto);
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UsersId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (User.IsInRole("Administrador"))
                {
                    ViewBag.Mensagem = "Cliente alterado com sucesso";

                    return View("Sucesso");
                }
                if (User.IsInRole("Cliente"))
                {
                    ViewBag.Mensagem = "Dados Pessoais alterados com sucesso";
                    return RedirectToAction("Sucesso", "ClientesViewModel", users.UsersId);
                }
            }
            return RedirectToAction("DetailsCliente", "Users");
        }

        // GET: User/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> EditEmpresa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente o cliente já foi eliminado.";
                return View("Erro");
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito.Where(x => !x.DistritoNome.Contains("Nacional"))
                .OrderBy(x => x.DistritoNome), "DistritoId", "DistritoNome");
            return View(users);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> EditEmpresa(int id, Users users, IFormFile ficheiroFoto)
        {
            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var user = _context.Users.AsNoTracking().SingleOrDefault(m => m.UsersId == id);
            users.DataRegisto = user.DataRegisto;

            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Cliente Empresarial");
            users.TipoId = tipo.TipoId;
            if (id != users.UsersId)
            {
                return NotFound();
            }
            if (ficheiroFoto != null)
            {
                if (ficheiroFoto.Length >= 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "Excedeu o limite máximo de 2 Mb para o tamanho da foto.");
                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    AtualizaFotoUser(users, ficheiroFoto);
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UsersId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Cliente alterado com sucesso";
                return View("Sucesso");
            }
            return RedirectToAction("DetailsEmpresa", "Users");
        }

        // GET: Clientes/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Tipo)
                .FirstOrDefaultAsync(m => m.UsersId == id);
            if (users == null)
            {
                ViewBag.Mensagem = "O cliente já foi eliminado por outra pessoa.";
                return View("SucessoEliminar");
            }

            return View(users);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "O cliente foi eliminado com sucesso.";
            return View("SucessoEliminar");
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UsersId == id);
        }



        //---------------VALIDAÇÕES--------------------

        private static void CriaFotoUser(RegistoUserViewModel infoUsers, IFormFile ficheiroFoto)
        {
            if (ficheiroFoto != null && ficheiroFoto.Length > 0)
            {
                using (var ficheiroMemoria = new MemoryStream())
                {
                    ficheiroFoto.CopyTo(ficheiroMemoria);
                    infoUsers.Fotografia = ficheiroMemoria.ToArray();
                }
            }
        }

        private static void AtualizaFotoUser(Users users, IFormFile ficheiroFoto)
        {
            if (ficheiroFoto != null && ficheiroFoto.Length > 0)
            {
                using (var ficheiroMemoria = new MemoryStream())
                {
                    ficheiroFoto.CopyTo(ficheiroMemoria);
                    users.Fotografia = ficheiroMemoria.ToArray();
                }
            }
        }

        private async Task<bool> VerificaEmailAsync(RegistoUserViewModel infoUsers)
        {
            IdentityUser utilizador = await _gestorUtilizadores.FindByNameAsync(infoUsers.Email);

            if (utilizador != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> VerificaContribuinteAsync(RegistoUserViewModel infoUsers)
        {
            Users usersContribuinte = await _context.Users.FirstOrDefaultAsync(x => x.Contribuinte == infoUsers.Contribuinte);

            if (usersContribuinte == null)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> VerificaCCAsync(RegistoUserViewModel infoUsers)
        {
            Users usersCC = await _context.Users.FirstOrDefaultAsync(x => x.CartaoCidadao == infoUsers.CartaoCidadao);

            if (usersCC == null)
            {
                return false;
            }
            return true;
        }

        private bool VerificaNIF(RegistoUserViewModel infoUsers)
        {
            string nif = infoUsers.Contribuinte;
            char firstChar = nif[0];
            if (firstChar.Equals('1')
                || firstChar.Equals('2')
                || firstChar.Equals('3')
                || firstChar.Equals('5')
                || firstChar.Equals('6')
                || firstChar.Equals('8')
                || firstChar.Equals('9'))
            {
                int checkDigit = (Convert.ToInt32(firstChar.ToString()) * 9);
                for (int i = 2; i <= 8; ++i)
                {
                    checkDigit += Convert.ToInt32(nif[i - 1].ToString()) * (10 - i);
                }

                checkDigit = 11 - (checkDigit % 11);
                if (checkDigit >= 10)
                {
                    checkDigit = 0;
                }

                if (checkDigit.ToString() != nif[8].ToString())
                {
                    ModelState.AddModelError("Contribuinte", "Contribuinte Inválido, coloque novamente");
                    return false;
                }
            }
            return true;
        }


        private async Task<bool> CriaUtilizadorAsync(RegistoUserViewModel infoUsers, string role)
        {
            var utilizador = new IdentityUser(infoUsers.Email);

            IdentityResult resultado = await _gestorUtilizadores.CreateAsync(utilizador, infoUsers.Password);
            if (resultado.Succeeded)
            {
                await _gestorUtilizadores.AddToRoleAsync(utilizador, role);
            }
            else
            {
                return false;
            }

            infoUsers.DataRegisto = DateTime.Now;

            Users users = new Users
            {
                Nome = infoUsers.Nome,
                Data = infoUsers.Data,
                CartaoCidadao = infoUsers.CartaoCidadao,
                Contribuinte = infoUsers.Contribuinte,
                Morada = infoUsers.Morada,
                CodigoPostal = infoUsers.CodigoPostal,
                Telefone = infoUsers.Telefone,
                Telemovel = infoUsers.Telemovel,
                Email = infoUsers.Email,
                CodigoPostalExt = infoUsers.CodigoPostalExt,
                TipoId = infoUsers.TipoId,
                Fotografia = infoUsers.Fotografia,
                Estado = infoUsers.Estado,
                DataRegisto = infoUsers.DataRegisto,
                DistritoId = infoUsers.DistritoId
            };

            _context.Add(users);
            await _context.SaveChangesAsync();

            return true;
        }
        //------------------------------------------------------------------------------//
    }
}
