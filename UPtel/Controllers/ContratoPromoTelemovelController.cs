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
    public class ContratoPromoTelemovelController : Controller
    {
        private readonly UPtelContext _context;

        public ContratoPromoTelemovelController(UPtelContext context)
        {
            _context = context;
        }

        // GET: ContratoPromoTelemovel
        public async Task<IActionResult> Index()
        {
            var uPtelContext = _context.ContratoPromoTelemovel.Include(c => c.Contratos).Include(c => c.PromoTelemovel);
            return View(await uPtelContext.ToListAsync());
        }

        // GET: ContratoPromoTelemovel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoTelemovel = await _context.ContratoPromoTelemovel
                .Include(c => c.Contratos)
                .Include(c => c.PromoTelemovel)
                .FirstOrDefaultAsync(m => m.ContratoPromoTelemovelId == id);
            if (contratoPromoTelemovel == null)
            {
                return NotFound();
            }

            return View(contratoPromoTelemovel);
        }

        // GET: ContratoPromoTelemovel/Create
        public IActionResult Create()
        {
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId");
            ViewData["PromoTelemovelId"] = new SelectList(_context.PromoTelemovel, "PromoTelemovelId", "PromoTelemovelId");
            return View();
        }

        // POST: ContratoPromoTelemovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratoPromoTelemovelId,ContratoId,PromoTelemovelId,DataInicio,DataFim")] ContratoPromoTelemovel contratoPromoTelemovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoPromoTelemovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoTelemovel.ContratoId);
            ViewData["PromoTelemovelId"] = new SelectList(_context.PromoTelemovel, "PromoTelemovelId", "PromoTelemovelId", contratoPromoTelemovel.PromoTelemovelId);
            return View(contratoPromoTelemovel);
        }

        // GET: ContratoPromoTelemovel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoTelemovel = await _context.ContratoPromoTelemovel.FindAsync(id);
            if (contratoPromoTelemovel == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoTelemovel.ContratoId);
            ViewData["PromoTelemovelId"] = new SelectList(_context.PromoTelemovel, "PromoTelemovelId", "PromoTelemovelId", contratoPromoTelemovel.PromoTelemovelId);
            return View(contratoPromoTelemovel);
        }

        // POST: ContratoPromoTelemovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratoPromoTelemovelId,ContratoId,PromoTelemovelId,DataInicio,DataFim")] ContratoPromoTelemovel contratoPromoTelemovel)
        {
            if (id != contratoPromoTelemovel.ContratoPromoTelemovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoPromoTelemovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoPromoTelemovelExists(contratoPromoTelemovel.ContratoPromoTelemovelId))
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
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoTelemovel.ContratoId);
            ViewData["PromoTelemovelId"] = new SelectList(_context.PromoTelemovel, "PromoTelemovelId", "PromoTelemovelId", contratoPromoTelemovel.PromoTelemovelId);
            return View(contratoPromoTelemovel);
        }

        // GET: ContratoPromoTelemovel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoTelemovel = await _context.ContratoPromoTelemovel
                .Include(c => c.Contratos)
                .Include(c => c.PromoTelemovel)
                .FirstOrDefaultAsync(m => m.ContratoPromoTelemovelId == id);
            if (contratoPromoTelemovel == null)
            {
                return NotFound();
            }

            return View(contratoPromoTelemovel);
        }

        // POST: ContratoPromoTelemovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratoPromoTelemovel = await _context.ContratoPromoTelemovel.FindAsync(id);
            _context.ContratoPromoTelemovel.Remove(contratoPromoTelemovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoPromoTelemovelExists(int id)
        {
            return _context.ContratoPromoTelemovel.Any(e => e.ContratoPromoTelemovelId == id);
        }
    }
}
