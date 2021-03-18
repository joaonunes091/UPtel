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
    [Authorize(Roles = "Operador")]
    public class OperadorViewModelController : Controller
    {
        private readonly UPtelContext _context;
        private readonly UserManager<IdentityUser> _gestorUtilizadores;


        public OperadorViewModelController(UPtelContext context, UserManager<IdentityUser> gestorUtilizadores)
        {
            _context = context;
            _gestorUtilizadores = gestorUtilizadores;
        }

        // GET: OperadorViewModel
        public async Task<IActionResult> Index(int? id, OperadorViewModel operador)
        {

            var userEmail = _gestorUtilizadores.GetUserName(HttpContext.User);
            Users infoOperador = await _context.Users.SingleOrDefaultAsync(x => x.Email == userEmail);

            operador = new OperadorViewModel
            {
                Id = infoOperador.UsersId,
                NomeCliente = infoOperador.Nome,
                DataNascimento = infoOperador.Data,
                CartaoCidadao = infoOperador.CartaoCidadao,
                NumeroContribuinte = infoOperador.Contribuinte,
                Morada = infoOperador.Morada,
                CodiogoPostal = infoOperador.CodigoPostal,
                ExtensaoCodigoPostal = infoOperador.CodigoPostalExt,
                Telefone = infoOperador.Telefone,
                Telemovel = infoOperador.Telemovel,
                Email = infoOperador.Email,
                DataRegisto=infoOperador.DataRegisto,
                DistritoNome=infoOperador.DistritoNome
            };

            return View(operador);
        }

        // GET: OperadorViewModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operadorViewModel = await _context.OperadorViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operadorViewModel == null)
            {
                return NotFound();
            }

            return View(operadorViewModel);
        }

        // GET: OperadorViewModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OperadorViewModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCliente,DataNascimento,CartaoCidadao,NumeroContribuinte,Morada,CodiogoPostal,ExtensaoCodigoPostal,Telefone,Telemovel,Email,Fotografia,DataRegisto")] OperadorViewModel operadorViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operadorViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operadorViewModel);
        }

        // GET: OperadorViewModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operadorViewModel = await _context.OperadorViewModel.FindAsync(id);
            if (operadorViewModel == null)
            {
                return NotFound();
            }
            return View(operadorViewModel);
        }

        // POST: OperadorViewModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCliente,DataNascimento,CartaoCidadao,NumeroContribuinte,Morada,CodiogoPostal,ExtensaoCodigoPostal,Telefone,Telemovel,Email,Fotografia,DataRegisto")] OperadorViewModel operadorViewModel)
        {
            if (id != operadorViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operadorViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperadorViewModelExists(operadorViewModel.Id))
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
            return View(operadorViewModel);
        }

        // GET: OperadorViewModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operadorViewModel = await _context.OperadorViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operadorViewModel == null)
            {
                return NotFound();
            }

            return View(operadorViewModel);
        }

        // POST: OperadorViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operadorViewModel = await _context.OperadorViewModel.FindAsync(id);
            _context.OperadorViewModel.Remove(operadorViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperadorViewModelExists(int id)
        {
            return _context.OperadorViewModel.Any(e => e.Id == id);
        }
    }
}
