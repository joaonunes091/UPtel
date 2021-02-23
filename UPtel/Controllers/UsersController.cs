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

namespace UPtel.Controllers
{
    public class UsersController : Controller
    {
        private readonly UPtelContext _context;
        private readonly UserManager<IdentityUser> _gestorUtilizadores;
        public UsersController(UPtelContext context, UserManager<IdentityUser> gestorUtilizadores)
        {
            _context = context;
            _gestorUtilizadores = gestorUtilizadores;
        }

        // GET: Clientes
        //[Authorize(Roles = "Administrador")] IMPORTANTE RETIRAR DE COMENTÁRIO QUANDO OS ROLES ESTIVEREM ATIVOS
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Users.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar) || p.Contribuinte.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<Users> users = await _context.Users.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar) || p.Contribuinte.Contains(nomePesquisar))
                    .Include(t => t.Tipo)
                    .OrderBy(c => c.Nome)
                    .OrderBy(c => c.Contribuinte)
                    .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                    .Take(paginacao.ItemsPorPagina)
                    .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                Users = users,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
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
                return NotFound();
            }

            return View(users);
        }

        // GET: User/Registo
        public IActionResult Registo()
        {
            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo");
            return View();
        }

        // POST: User/Registo
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registo(RegistoUserViewModel infoclientes)
        {

            Users users = new Users
            {
                Nome = infoclientes.Nome,
                Data = infoclientes.Data,
                CartaoCidadao = infoclientes.CartaoCidadao,
                Contribuinte = infoclientes.Contribuinte,
                Morada = infoclientes.Morada,
                CodigoPostal = infoclientes.CodigoPostal,
                Telefone = infoclientes.Telefone,
                Telemovel = infoclientes.Telemovel,
                Email = infoclientes.Email,
                //Password = infoclientes.Password,
                CodigoPostalExt = infoclientes.CodigoPostalExt,
                TipoId = infoclientes.TipoId,
            };

            IdentityUser utilizador = new IdentityUser();
            if (infoclientes.Email == null)
            {
                ModelState.AddModelError("Email", "Precisa de introduzir um email");
                ViewData["TipoClienteId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoclientes);
            }
            else
            {
                utilizador = await _gestorUtilizadores.FindByNameAsync(infoclientes.Email);
            }


            if (utilizador != null)
            {
                ModelState.AddModelError("Email", "Já existe uma conta com este email");
                ViewData["TipoClienteId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoclientes);
            }
            utilizador = new IdentityUser(infoclientes.Email);

            ////Verificador de números de contribuinte
            //IdentityUser contribuinte = new IdentityUser();
            //if (infoclientes.Contribuinte == null)
            //{
            //    ModelState.AddModelError("Contribuinte", "Precisa de introduzir um número de contribuinte");
            //    ViewData["TipoClienteId"] = new SelectList(_context.TipoClientes, "TipoClienteId", "Designacao", clientes.TipoClienteId);
            //    return View(infoclientes);
            //}
            //else
            //{
            //    contribuinte = await _gestorUtilizadores.FindByNameAsync(infoclientes.Contribuinte);
            //}


            //if (contribuinte != null)
            //{
            //    ModelState.AddModelError("Contribuinte", "Já existe uma conta com este número de contribuinte");
            //    ViewData["TipoClienteId"] = new SelectList(_context.TipoClientes, "TipoClienteId", "Designacao", clientes.TipoClienteId);
            //    return View(infoclientes);
            //}
            //contribuinte = new IdentityUser(infoclientes.Contribuinte);

            ////Verificador do CC
            //IdentityUser cc = new IdentityUser();
            //if (infoclientes.CartaoCidadao == null)
            //{
            //    ModelState.AddModelError("CartaoCidadao", "Precisa de introduzir um número de contribuinte");
            //    ViewData["TipoClienteId"] = new SelectList(_context.TipoClientes, "TipoClienteId", "Designacao", clientes.TipoClienteId);
            //    return View(infoclientes);
            //}
            //else
            //{
            //    cc = await _gestorUtilizadores.FindByNameAsync(infoclientes.Contribuinte);
            //}


            //if (cc != null)
            //{
            //    ModelState.AddModelError("CartaoCidadao", "Já existe uma conta com este número de contribuinte");
            //    ViewData["TipoClienteId"] = new SelectList(_context.TipoClientes, "TipoClienteId", "Designacao", clientes.TipoClienteId);
            //    return View(infoclientes);
            //}
            //cc = new IdentityUser(infoclientes.CartaoCidadao);


            if (infoclientes.Data > DateTime.Today.AddYears(-18))
            {
                ModelState.AddModelError("DataNascimento", "Para se registar tem que ter mais de 18 anos");
                ViewData["TipoClienteId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoclientes);
            }


            IdentityResult resultado = new IdentityResult();
            if (infoclientes.Password == null)
            {
                ModelState.AddModelError("Password", "Precisa de colocar uma password");
                ViewData["TipoClienteId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoclientes);
            }
            else
            {
                resultado = await _gestorUtilizadores.CreateAsync(utilizador, infoclientes.Password);
            }


            if (ModelState.IsValid && resultado.Succeeded)
            {
                await _gestorUtilizadores.AddToRoleAsync(utilizador, "Cliente");
            }
            else
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
                ViewData["TipoClienteId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoclientes);
            }

            _context.Add(users);



            if (infoclientes.Nome == null || infoclientes.Contribuinte == null || infoclientes.Morada == null || infoclientes.CodigoPostal == null || infoclientes.Telemovel == null || infoclientes.CodigoPostalExt == null)
            {
                return View(infoclientes);
            }
            else
            {
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Cliente adicionado com sucesso";
                return View("Sucesso");
            }

            //return RedirectToAction(nameof(Details));
            //ViewData["TipoClienteId"] = new SelectList(_context.UserType, "Tipo", users.TipoId);

        }

        // GET: User/Edit/5
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
            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
            return View(users);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsersId,Nome,Data,CartaoCidadao,Contribuinte,Morada,CodigoPostal,Telefone,Telemovel,Email,Iban,TipoId,CodigoPostalExt,Estado,Fotografia")] Users users)
        {
            if (id != users.UsersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
            return View(users);
        }

        // GET: Clientes/Delete/5
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
    }
}
