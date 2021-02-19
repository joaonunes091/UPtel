using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UPtel.Data;
using UPtel.Models;

namespace UPtel.Controllers
{
    public class TipoClientesController : Controller
    {
        private readonly UPtelContext _context;

        public TipoClientesController(UPtelContext context)
        {
            _context = context;
        }

        // GET: TipoClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoClientes.ToListAsync());
        }

        // GET: TipoClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoClientes = await _context.TipoClientes
                .FirstOrDefaultAsync(m => m.TipoClienteId == id);
            if (tipoClientes == null)
            {
                return NotFound();
            }

            return View(tipoClientes);
        }

        // GET: TipoClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoClienteId,Designacao")] TipoClientes tipoClientes)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoClientes);
            }
            
            _context.Add(tipoClientes);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "Tipo de Cliente adicionado com sucesso";
            return View("Sucesso");
            //return RedirectToAction(nameof(Index));
        }

        // GET: TipoClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoClientes = await _context.TipoClientes.FindAsync(id);
            if (tipoClientes == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente o tipo de cliente já foi eliminado.";
                return View("Erro");
            }
            return View(tipoClientes);
        }

        // POST: TipoClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoClienteId,Designacao")] TipoClientes tipoClientes)
        {
            if (id != tipoClientes.TipoClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoClientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoClientesExists(tipoClientes.TipoClienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Tipo de cliente alterado com sucesso";
                return View("Sucesso");
            }
            return View(tipoClientes);
        }

        // GET: TipoClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoClientes = await _context.TipoClientes
                .FirstOrDefaultAsync(m => m.TipoClienteId == id);
            if (tipoClientes == null)
            {
                ViewBag.Mensagem = "O tipo de cliente já foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(tipoClientes);
        }

        // POST: TipoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoClientes = await _context.TipoClientes.FindAsync(id);
            _context.TipoClientes.Remove(tipoClientes);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "O tipo de cliente foi eliminado com sucesso.";
            return View("Sucesso");
        }

        private bool TipoClientesExists(int id)
        {
            return _context.TipoClientes.Any(e => e.TipoClienteId == id);
        }
    }
}
