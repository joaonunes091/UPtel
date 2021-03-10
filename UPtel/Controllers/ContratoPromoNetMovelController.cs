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
    public class ContratoPromoNetMovelController : Controller
    {
        private readonly UPtelContext _context;

        public ContratoPromoNetMovelController(UPtelContext context)
        {
            _context = context;
        }

        // GET: ContratoPromoNetMovel
        public async Task<IActionResult> Index()
        {
            var uPtelContext = _context.ContratoPromoNetMovel.Include(c => c.Contratos).Include(c => c.PromoNetMovel);
            return View(await uPtelContext.ToListAsync());
        }

        // GET: ContratoPromoNetMovel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoNetMovel = await _context.ContratoPromoNetMovel
                .Include(c => c.Contratos)
                .Include(c => c.PromoNetMovel)
                .FirstOrDefaultAsync(m => m.ContratoPromoNetMovelId == id);
            if (contratoPromoNetMovel == null)
            {
                return NotFound();
            }

            return View(contratoPromoNetMovel);
        }

        // GET: ContratoPromoNetMovel/Create
        public IActionResult Create()
        {
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId");
            ViewData["PromoNetMovelId"] = new SelectList(_context.PromoNetMovel, "PromoNetMovelId", "PromoNetMovelId");
            return View();
        }

        // POST: ContratoPromoNetMovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratoPromoNetMovelId,ContratoId,PromoNetMovelId,DataInicio,DataFim")] ContratoPromoNetMovel contratoPromoNetMovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoPromoNetMovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoNetMovel.ContratoId);
            ViewData["PromoNetMovelId"] = new SelectList(_context.PromoNetMovel, "PromoNetMovelId", "PromoNetMovelId", contratoPromoNetMovel.PromoNetMovelId);
            return View(contratoPromoNetMovel);
        }

        // GET: ContratoPromoNetMovel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoNetMovel = await _context.ContratoPromoNetMovel.FindAsync(id);
            if (contratoPromoNetMovel == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoNetMovel.ContratoId);
            ViewData["PromoNetMovelId"] = new SelectList(_context.PromoNetMovel, "PromoNetMovelId", "PromoNetMovelId", contratoPromoNetMovel.PromoNetMovelId);
            return View(contratoPromoNetMovel);
        }

        // POST: ContratoPromoNetMovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratoPromoNetMovelId,ContratoId,PromoNetMovelId,DataInicio,DataFim")] ContratoPromoNetMovel contratoPromoNetMovel)
        {
            if (id != contratoPromoNetMovel.ContratoPromoNetMovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoPromoNetMovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoPromoNetMovelExists(contratoPromoNetMovel.ContratoPromoNetMovelId))
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
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoNetMovel.ContratoId);
            ViewData["PromoNetMovelId"] = new SelectList(_context.PromoNetMovel, "PromoNetMovelId", "PromoNetMovelId", contratoPromoNetMovel.PromoNetMovelId);
            return View(contratoPromoNetMovel);
        }

        // GET: ContratoPromoNetMovel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoNetMovel = await _context.ContratoPromoNetMovel
                .Include(c => c.Contratos)
                .Include(c => c.PromoNetMovel)
                .FirstOrDefaultAsync(m => m.ContratoPromoNetMovelId == id);
            if (contratoPromoNetMovel == null)
            {
                return NotFound();
            }

            return View(contratoPromoNetMovel);
        }

        // POST: ContratoPromoNetMovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratoPromoNetMovel = await _context.ContratoPromoNetMovel.FindAsync(id);
            _context.ContratoPromoNetMovel.Remove(contratoPromoNetMovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoPromoNetMovelExists(int id)
        {
            return _context.ContratoPromoNetMovel.Any(e => e.ContratoPromoNetMovelId == id);
        }
    }
}
