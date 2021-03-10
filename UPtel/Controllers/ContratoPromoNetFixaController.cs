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
    public class ContratoPromoNetFixaController : Controller
    {
        private readonly UPtelContext _context;

        public ContratoPromoNetFixaController(UPtelContext context)
        {
            _context = context;
        }

        // GET: ContratoPromoNetFixa
        public async Task<IActionResult> Index()
        {
            var uPtelContext = _context.ContratoPromoNetFixa.Include(c => c.Contratos).Include(c => c.PromoNetFixa);
            return View(await uPtelContext.ToListAsync());
        }

        // GET: ContratoPromoNetFixa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoNetFixa = await _context.ContratoPromoNetFixa
                .Include(c => c.Contratos)
                .Include(c => c.PromoNetFixa)
                .FirstOrDefaultAsync(m => m.ContratoPromoNetFixaId == id);
            if (contratoPromoNetFixa == null)
            {
                return NotFound();
            }

            return View(contratoPromoNetFixa);
        }

        // GET: ContratoPromoNetFixa/Create
        public IActionResult Create()
        {
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId");
            ViewData["PromoNetFixaId"] = new SelectList(_context.PromoNetFixa, "PromoNetFixaId", "PromoNetFixaId");
            return View();
        }

        // POST: ContratoPromoNetFixa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratoPromoNetFixaId,ContratoId,PromoNetFixaId,DataInicio,DataFim")] ContratoPromoNetFixa contratoPromoNetFixa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoPromoNetFixa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoNetFixa.ContratoId);
            ViewData["PromoNetFixaId"] = new SelectList(_context.PromoNetFixa, "PromoNetFixaId", "PromoNetFixaId", contratoPromoNetFixa.PromoNetFixaId);
            return View(contratoPromoNetFixa);
        }

        // GET: ContratoPromoNetFixa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoNetFixa = await _context.ContratoPromoNetFixa.FindAsync(id);
            if (contratoPromoNetFixa == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoNetFixa.ContratoId);
            ViewData["PromoNetFixaId"] = new SelectList(_context.PromoNetFixa, "PromoNetFixaId", "PromoNetFixaId", contratoPromoNetFixa.PromoNetFixaId);
            return View(contratoPromoNetFixa);
        }

        // POST: ContratoPromoNetFixa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratoPromoNetFixaId,ContratoId,PromoNetFixaId,DataInicio,DataFim")] ContratoPromoNetFixa contratoPromoNetFixa)
        {
            if (id != contratoPromoNetFixa.ContratoPromoNetFixaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoPromoNetFixa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoPromoNetFixaExists(contratoPromoNetFixa.ContratoPromoNetFixaId))
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
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoNetFixa.ContratoId);
            ViewData["PromoNetFixaId"] = new SelectList(_context.PromoNetFixa, "PromoNetFixaId", "PromoNetFixaId", contratoPromoNetFixa.PromoNetFixaId);
            return View(contratoPromoNetFixa);
        }

        // GET: ContratoPromoNetFixa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoNetFixa = await _context.ContratoPromoNetFixa
                .Include(c => c.Contratos)
                .Include(c => c.PromoNetFixa)
                .FirstOrDefaultAsync(m => m.ContratoPromoNetFixaId == id);
            if (contratoPromoNetFixa == null)
            {
                return NotFound();
            }

            return View(contratoPromoNetFixa);
        }

        // POST: ContratoPromoNetFixa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratoPromoNetFixa = await _context.ContratoPromoNetFixa.FindAsync(id);
            _context.ContratoPromoNetFixa.Remove(contratoPromoNetFixa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoPromoNetFixaExists(int id)
        {
            return _context.ContratoPromoNetFixa.Any(e => e.ContratoPromoNetFixaId == id);
        }
    }
}
