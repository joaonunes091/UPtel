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

        [HttpGet]
        public IActionResult MudarPassword()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult>MudarPassword(MudarPasswordViewModel model)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var user = await _gestorUtilizadores.GetUserAsync(User);
        //        if (user == null)
        //        {
        //            return RedirectToAction("Login");
        //        }
        //        var result = await _gestorUtilizadores.ChangePasswordAsync(user, model.PasswordAtual, model.PasswordNova);
        //        if(!result.Succeeded)
        //        {
        //            foreach(var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //            return View();
        //        }
        //        await _gestorUtilizadores.RefreshSignInAsync(user);
        //        return View("MudarPasswordSucesso")
        //    }
        //    return View(model);
        //}

        // GET: Clientes
        //[Authorize(Roles = "Administrador")] IMPORTANTE RETIRAR DE COMENTÁRIO QUANDO OS ROLES ESTIVEREM ATIVOS
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
        public async Task<IActionResult> DetailsCliente(int? id)
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
        public async Task<IActionResult> DetailsEmpresa(int? id)
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

       
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //GET : User/RegistoAdministrador
        public IActionResult RegistoAdministrador()
        {
            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo");
            return View();
        }
        // POST : User/RegistoAdministrador
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            CriaFotoUser(infoUsers, ficheiroFoto);
            if (!VerificaNIF(infoUsers))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }
            if (!await CriaUtilizadorAsync(infoUsers, "Administrador"))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }
            if (!ModelState.IsValid)
            {
                //ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", infoUsers.TipoId);
                return View(infoUsers);
            }

            ViewBag.Mensagem = "Administrador adicionado com sucesso";
            return View("Sucesso");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //GET : User/RegistoOperador
        public IActionResult RegistoOperador()
        {
            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo");
            return View();
        }

        // POST : User/RegistoOperador
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistoOperador(RegistoUserViewModel infoUsers)
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
         
            if (!VerificaNIF(infoUsers))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }
            if (!await CriaUtilizadorAsync(infoUsers, "Operador"))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }
           
            if (!ModelState.IsValid)
            {
                ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", infoUsers.TipoId);
                return View(infoUsers);
            }

            ViewBag.Mensagem = "Operador adicionado com sucesso";
            return View("Sucesso");
           
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //GET : User/RegistoClienteEmpresa
        public IActionResult RegistoClienteEmpresa()
        {
            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        // POST : User/RegistoClienteEmpresa

        public async Task<IActionResult> RegistoClienteEmpresa(RegistoUserViewModel infoUsers)
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
            if (!await CriaUtilizadorAsync(infoUsers, "Cliente"))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }
            if (!VerificaNIF(infoUsers))
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
        public IActionResult RegistoClienteParticular()
        {
            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo");
            return View();
        }

        // POST: User/RegistoClienteParticular
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistoClienteParticular(RegistoUserViewModel infoUsers)
        {
            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Cliente Particular");
            infoUsers.TipoId = tipo.TipoId;

            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }
            if(await VerificaEmailAsync(infoUsers))
            {
                ModelState.AddModelError("Email", "Este email já existe");
            }
            if (infoUsers.Data > DateTime.Today.AddYears(-18))
            {
                ModelState.AddModelError("DataNascimento", "Para se registar tem que ter mais de 18 anos");
            }
            if (!VerificaNIF(infoUsers))
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
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
            //ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
            return View(users);
        }

        // POST: Funcionários/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsersId,Nome,Data,CartaoCidadao,Contribuinte,Morada,CodigoPostal,Telefone,Telemovel,Email,Iban,TipoId,CodigoPostalExt,Estado,Fotografia")] Users users, IFormFile ficheiroFoto)
        {
            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Administrador");
            users.TipoId = tipo.TipoId;
            if (id != users.UsersId)
            {
                return NotFound();
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
            //ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
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
            //ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
            return View(users);
        }

        // POST: operador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOperador(int id, [Bind("UsersId,Nome,Data,CartaoCidadao,Contribuinte,Morada,CodigoPostal,Telefone,Telemovel,Email,Iban,TipoId,CodigoPostalExt,Estado,Fotografia")] Users users, IFormFile ficheiroFoto)
        {
            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Operador");
            users.TipoId = tipo.TipoId;
            if (id != users.UsersId)
            {
                return NotFound();
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
            //ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
            return View(users);
        }



        // GET: User/Edit/5
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
            return View(users);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCliente(int id, [Bind("UsersId,Nome,Data,CartaoCidadao,Contribuinte,Morada,CodigoPostal,Telefone,Telemovel,Email,TipoId,CodigoPostalExt,Estado,Fotografia")] Users users)
        {
            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Cliente Particular");
            users.TipoId = tipo.TipoId;

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
            return RedirectToAction("DetailsCliente", "Users");
        }
       
        // GET: User/Edit/5
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
            return View(users);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmpresa(int id, [Bind("UsersId,Nome,Data,Contribuinte,Morada,CodigoPostal,Telefone,Telemovel,Email,TipoId,CodigoPostalExt,Estado,Fotografia")] Users users)
        {
            var tipo = _context.UserType.SingleOrDefault(c => c.Tipo == "Cliente Empresarial");
            users.TipoId = tipo.TipoId;
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
            return RedirectToAction("DetailsEmpresa", "Users");
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
            };

            _context.Add(users);
            await _context.SaveChangesAsync();

            return true;
        }
        //------------------------------------------------------------------------------//
    }
}
