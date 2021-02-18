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
    public class ClientesController : Controller
    {
        private readonly UPtelContext _context;
        private readonly UserManager<IdentityUser> _gestorUtilizadores;
        public ClientesController(UPtelContext context, UserManager<IdentityUser> gestorUtilizadores)
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
                TotalItems = await _context.Clientes.Where(p => nomePesquisar == null || p.NomeCliente.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<Clientes> clientes = await _context.Clientes.Where(p => nomePesquisar == null || p.NomeCliente.Contains(nomePesquisar))
                    .Include(t => t.TipoCliente)
                    .OrderBy(c => c.NomeCliente)
                    .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                    .Take(paginacao.ItemsPorPagina)
                    .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                Clientes = clientes,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .Include(c => c.TipoCliente)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Registo()
        {
            ViewData["TipoClienteId"] = new SelectList(_context.TipoClientes, "TipoClienteId", "Designacao");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registo(RegistoClienteViewModel infoclientes)
        {

            IdentityUser utilizador = await _gestorUtilizadores.FindByNameAsync(infoclientes.Email);

            if (utilizador != null)
            {
                ModelState.AddModelError("Email", "Já existe uma conta com este email");
            }
            utilizador = new IdentityUser(infoclientes.Email);

            if (ModelState.IsValid)
            {
                if (infoclientes.DataNascimento > DateTime.Today.AddYears(-18))
                {
                    ModelState.AddModelError("DataNascimento", "Para se registar tem que ter mais de 18 anos");
                    return View(infoclientes);
                }
            }


            IdentityResult resultado = await _gestorUtilizadores.CreateAsync(utilizador, infoclientes.Password);
            if (!resultado.Succeeded)
            {
                ModelState.AddModelError("", "Não foi possível realizar o registo. Tente de novo mais tarde.");
            }
            else
            {
                await _gestorUtilizadores.AddToRoleAsync(utilizador, "Cliente");
            }

            if (!ModelState.IsValid)
            {

                return View("Sucesso"); //to do
            }

            


            Clientes clientes = new Clientes
            {
                NomeCliente = infoclientes.NomeCliente,
                DataNascimento = infoclientes.DataNascimento,
                CartaoCidadao = infoclientes.CartaoCidadao,
                Contribuinte = infoclientes.Contribuinte,
                Morada = infoclientes.Morada,
                CodigoPostal = infoclientes.CodigoPostal,
                Telefone = infoclientes.Telefone,
                Telemovel = infoclientes.Telemovel,
                Email = infoclientes.Email,
                Password = infoclientes.Password,
                CodigoPostalExt = infoclientes.CodigoPostalExt,
                TipoClienteId=infoclientes.TipoClienteId,
            };
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Canal adicionado com sucesso";
                return View("Sucesso");


            //return RedirectToAction(nameof(Details));
            //ViewData["TipoClienteId"] = new SelectList(_context.TipoClientes, "TipoClienteId", "Designacao", clientes.TipoClienteId);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            ViewData["TipoClienteId"] = new SelectList(_context.TipoClientes, "TipoClienteId", "Designacao", clientes.TipoClienteId);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,NomeCliente,DataNascimento,CartaoCidadao,Contribuinte,Morada,CodigoPostal,Telefone,Telemovel,Email,Password,TipoClienteId,CodigoPostalExt")] Clientes clientes)
        {
            if (id != clientes.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.ClienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoClienteId"] = new SelectList(_context.TipoClientes, "TipoClienteId", "Designacao", clientes.TipoClienteId);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .Include(c => c.TipoCliente)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }
    }
}
