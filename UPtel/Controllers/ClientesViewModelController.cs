using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UPtel.Data;
using UPtel.Models;

namespace UPtel.Controllers
{
    public class ClientesViewModelController : Controller
    {
        private readonly UPtelContext _context;
        private readonly UserManager<IdentityUser> _gestorUtilizadores;

        public ClientesViewModelController(UPtelContext context, UserManager<IdentityUser> gestorUtilizadores)
        {
            _context = context;
            _gestorUtilizadores = gestorUtilizadores;
        }

        // GET: ClientesViewModel
        public async Task<IActionResult> Index(int? id,ClientesViewModel cliente)
        {

            var userEmail = _gestorUtilizadores.GetUserName(HttpContext.User);

            Users infoCliente = await _context.Users.SingleOrDefaultAsync(x => x.Email == userEmail);
            //Contratos infoContartos = _context.Contratos.SingleOrDefault(x => x.ClienteId == infoCliente.UsersId);

            cliente = new ClientesViewModel
            {
                Id = infoCliente.UsersId,
                NomeCliente = infoCliente.Nome,
                DataNascimento = infoCliente.Data,
                CartaoCidadao = infoCliente.CartaoCidadao,
                NumeroContribuinte = infoCliente.Contribuinte,
                Morada = infoCliente.Morada,
                CodiogoPostal = infoCliente.CodigoPostal,
                ExtensaoCodigoPostal = infoCliente.CodigoPostalExt,
                Telefone = infoCliente.Telefone,
                Telemovel = infoCliente.Telemovel,
                Email = infoCliente.Email,               
            };

            return View(cliente);

        }

        // GET: ClientesViewModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesViewModel = await _context.ClientesViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientesViewModel == null)
            {
                return NotFound();
            }

            return View(clientesViewModel);
        }

        // GET: ClientesViewModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientesViewModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCliente,DataNascimento,CartaoCidadao,NumeroContribuinte,Morada,CodiogoPostal,ExtensaoCodigoPostal,Telefone,Telemovel,Email")] ClientesViewModel clientesViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientesViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientesViewModel);
        }

        // GET: ClientesViewModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesViewModel = await _context.ClientesViewModel.FindAsync(id);
            if (clientesViewModel == null)
            {
                return NotFound();
            }
            return View(clientesViewModel);
        }

        // POST: ClientesViewModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCliente,DataNascimento,CartaoCidadao,NumeroContribuinte,Morada,CodiogoPostal,ExtensaoCodigoPostal,Telefone,Telemovel,Email")] ClientesViewModel clientesViewModel)
        {
            if (id != clientesViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientesViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesViewModelExists(clientesViewModel.Id))
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
            return View(clientesViewModel);
        }

        // GET: ClientesViewModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesViewModel = await _context.ClientesViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientesViewModel == null)
            {
                return NotFound();
            }

            return View(clientesViewModel);
        }

        // POST: ClientesViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientesViewModel = await _context.ClientesViewModel.FindAsync(id);
            _context.ClientesViewModel.Remove(clientesViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesViewModelExists(int id)
        {
            return _context.ClientesViewModel.Any(e => e.Id == id);
        }
    }
}
