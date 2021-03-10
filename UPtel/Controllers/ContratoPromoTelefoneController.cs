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
    public class ContratoPromoTelefoneController : Controller
    {
        private readonly UPtelContext _context;

        public ContratoPromoTelefoneController(UPtelContext context)
        {
            _context = context;
        }

        // GET: ContratoPromoTelefone
        public async Task<IActionResult> Index()
        {
            var uPtelContext = _context.ContratoPromoTelefone.Include(c => c.Contratos).Include(c => c.PromoTelefone);
            return View(await uPtelContext.ToListAsync());
        }

        // GET: ContratoPromoTelefone/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoTelefone = await _context.ContratoPromoTelefone
                .Include(c => c.Contratos)
                .Include(c => c.PromoTelefone)
                .FirstOrDefaultAsync(m => m.ContratoPromoTelefoneId == id);
            if (contratoPromoTelefone == null)
            {
                return NotFound();
            }

            return View(contratoPromoTelefone);
        }

        // GET: ContratoPromoTelefone/Create
        public IActionResult Create()
        {
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId");
            ViewData["PromoTelefoneId"] = new SelectList(_context.PromoTelefone, "PromoTelefoneId", "PromoTelefoneId");
            return View();
        }

        // POST: ContratoPromoTelefone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratoPromoTelefoneId,ContratoId,PromoTelefoneId,DataInicio,DataFim")] ContratoPromoTelefone contratoPromoTelefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoPromoTelefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoTelefone.ContratoId);
            ViewData["PromoTelefoneId"] = new SelectList(_context.PromoTelefone, "PromoTelefoneId", "PromoTelefoneId", contratoPromoTelefone.PromoTelefoneId);
            return View(contratoPromoTelefone);
        }

        // GET: ContratoPromoTelefone/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoTelefone = await _context.ContratoPromoTelefone.FindAsync(id);
            if (contratoPromoTelefone == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoTelefone.ContratoId);
            ViewData["PromoTelefoneId"] = new SelectList(_context.PromoTelefone, "PromoTelefoneId", "PromoTelefoneId", contratoPromoTelefone.PromoTelefoneId);
            return View(contratoPromoTelefone);
        }

        // POST: ContratoPromoTelefone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratoPromoTelefoneId,ContratoId,PromoTelefoneId,DataInicio,DataFim")] ContratoPromoTelefone contratoPromoTelefone)
        {
            if (id != contratoPromoTelefone.ContratoPromoTelefoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoPromoTelefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoPromoTelefoneExists(contratoPromoTelefone.ContratoPromoTelefoneId))
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
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoTelefone.ContratoId);
            ViewData["PromoTelefoneId"] = new SelectList(_context.PromoTelefone, "PromoTelefoneId", "PromoTelefoneId", contratoPromoTelefone.PromoTelefoneId);
            return View(contratoPromoTelefone);
        }

        // GET: ContratoPromoTelefone/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoTelefone = await _context.ContratoPromoTelefone
                .Include(c => c.Contratos)
                .Include(c => c.PromoTelefone)
                .FirstOrDefaultAsync(m => m.ContratoPromoTelefoneId == id);
            if (contratoPromoTelefone == null)
            {
                return NotFound();
            }

            return View(contratoPromoTelefone);
        }

        // POST: ContratoPromoTelefone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratoPromoTelefone = await _context.ContratoPromoTelefone.FindAsync(id);
            _context.ContratoPromoTelefone.Remove(contratoPromoTelefone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoPromoTelefoneExists(int id)
        {
            return _context.ContratoPromoTelefone.Any(e => e.ContratoPromoTelefoneId == id);
        }
    }
}
