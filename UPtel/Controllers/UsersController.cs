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

        //função de registo base

        private async void RegistoBase(TipoDeUtilizador t, RegistoUserViewModel infoUsers)
        {
            IdentityUser utilizador = await _gestorUtilizadores.FindByNameAsync(infoUsers.Email);

            if (utilizador != null)
            {
                ModelState.AddModelError("Email", "Já existe uma conta com este email");
                return;
            }
            utilizador = new IdentityUser(infoUsers.Email);
            IdentityResult resultado = await _gestorUtilizadores.CreateAsync(utilizador, infoUsers.Password);

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
                Iban = infoUsers.Iban,
                TipoId = (int)infoUsers.TipoId,
            };

            _context.Add(users);
            await _context.SaveChangesAsync();
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
        public async Task<IActionResult> RegistoAdministrador(RegistoUserViewModel infoUsers)
        {
            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }

            RegistoBase(TipoDeUtilizador.Administrador, infoUsers);

            if (!ModelState.IsValid)
            {
                return View(infoUsers);
            }

            if (infoUsers.Data > DateTime.Today.AddYears(-18))
            {
                ModelState.AddModelError("DataNascimento", "Para se registar tem que ter mais de 18 anos");
                return View(infoUsers);
            }

            ViewBag.Mensagem = "Cliente adicionado com sucesso";
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
                Iban = infoUsers.Iban,
                TipoId = infoUsers.TipoId,
            };

            string nif = users.Contribuinte;
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
                    ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                    return View(infoUsers);
                }
            };

            IdentityUser utilizador = new IdentityUser();
            if (infoUsers.Email == null)
            {
                ModelState.AddModelError("Email", "Precisa de introduzir um email");
                ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoUsers);
            }
            else
            {
                utilizador = await _gestorUtilizadores.FindByNameAsync(infoUsers.Email);
            }


            if (utilizador != null)
            {
                ModelState.AddModelError("Email", "Já existe uma conta com este email");
                ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoUsers);
            }
            utilizador = new IdentityUser(infoUsers.Email);

            if (infoUsers.Data > DateTime.Today.AddYears(-18))
            {
                ModelState.AddModelError("Data", "Para se registar tem que ter mais de 18 anos");
                ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoUsers);
            }


            IdentityResult resultado = new IdentityResult();
            if (infoUsers.Password == null)
            {
                ModelState.AddModelError("Password", "Precisa de colocar uma password");
                ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoUsers);
            }
            else
            {
                resultado = await _gestorUtilizadores.CreateAsync(utilizador, infoUsers.Password);
            }


            if (infoUsers.Nome == null || infoUsers.Contribuinte == null || infoUsers.Morada == null || infoUsers.CodigoPostal == null || infoUsers.Telemovel == null || infoUsers.CodigoPostalExt == null)
            {
                ModelState.AddModelError("Contribuinte", "Contribuinte Inválido, coloque novamente");
                ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoUsers);
            }
            else
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Cliente adicionado com sucesso";
                return View("Sucesso");
            }
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
                Iban = infoUsers.Iban,
                TipoId = infoUsers.TipoId,
            };
            IdentityUser utilizador = new IdentityUser();
            if (infoUsers.Email == null)
            {
                ModelState.AddModelError("Email", "Precisa de introduzir um email");
                ViewData["TipoClienteId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoUsers);
            }
            else
            {
                utilizador = await _gestorUtilizadores.FindByNameAsync(infoUsers.Email);
            }


            if (utilizador != null)
            {
                ModelState.AddModelError("Email", "Já existe uma conta com este email");
                ViewData["TipoClienteId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoUsers);
            }
            utilizador = new IdentityUser(infoUsers.Email);

            if (infoUsers.Data > DateTime.Today.AddYears(-18))
            {
                ModelState.AddModelError("DataNascimento", "Para se registar tem que ter mais de 18 anos");
                ViewData["TipoClienteId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoUsers);
            }


            IdentityResult resultado = new IdentityResult();
            if (infoUsers.Password == null)
            {
                ModelState.AddModelError("Password", "Precisa de colocar uma password");
                ViewData["TipoClienteId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
                return View(infoUsers);
            }
            else
            {
                resultado = await _gestorUtilizadores.CreateAsync(utilizador, infoUsers.Password);
            }

            _context.Add(users);



            if (infoUsers.Nome == null || infoUsers.Contribuinte == null || infoUsers.Morada == null || infoUsers.CodigoPostal == null || infoUsers.Telemovel == null || infoUsers.CodigoPostalExt == null)
            {
                return View(infoUsers);
            }
            else
            {
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Cliente adicionado com sucesso";
                return View("Sucesso");
            }
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
            };

            _context.Add(users);
            await _context.SaveChangesAsync();

            return true;
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
            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
            return View(users);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCliente(int id, [Bind("UsersId,Nome,Data,CartaoCidadao,Contribuinte,Morada,CodigoPostal,Telefone,Telemovel,Email,TipoId,CodigoPostalExt,Estado,Fotografia")] Users users)
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
            ViewData["TipoId"] = new SelectList(_context.UserType, "TipoId", "Tipo", users.TipoId);
            return View(users);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmpresa(int id, [Bind("UsersId,Nome,Data,Contribuinte,Morada,CodigoPostal,Telefone,Telemovel,Email,TipoId,CodigoPostalExt,Estado,Fotografia")] Users users)
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
    }
}
