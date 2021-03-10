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
    public class ContratoPromoTelevisaoController : Controller
    {
        private readonly UPtelContext _context;

        public ContratoPromoTelevisaoController(UPtelContext context)
        {
            _context = context;
        }

        // GET: ContratoPromoTelevisao
        public async Task<IActionResult> Index()
        {
            var uPtelContext = _context.ContratoPromotelevisao.Include(c => c.Contratos).Include(c => c.PromoTelevisao);
            return View(await uPtelContext.ToListAsync());
        }

        // GET: ContratoPromoTelevisao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoTelevisao = await _context.ContratoPromotelevisao
                .Include(c => c.Contratos)
                .Include(c => c.PromoTelevisao)
                .FirstOrDefaultAsync(m => m.ContratoTelevisaoId == id);
            if (contratoPromoTelevisao == null)
            {
                return NotFound();
            }

            return View(contratoPromoTelevisao);
        }

        // GET: ContratoPromoTelevisao/Create
        public IActionResult Create()
        {
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId");
            ViewData["PromoTelevisaoId"] = new SelectList(_context.PromoTelevisao, "PromoTelevisaoId", "PromoTelevisaoId");
            return View();
        }

        // POST: ContratoPromoTelevisao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratoTelevisaoId,ContratoId,PromoTelevisaoId,DataInicio,DataFim")] ContratoPromoTelevisao contratoPromoTelevisao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoPromoTelevisao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoTelevisao.ContratoId);
            ViewData["PromoTelevisaoId"] = new SelectList(_context.PromoTelevisao, "PromoTelevisaoId", "PromoTelevisaoId", contratoPromoTelevisao.PromoTelevisaoId);
            return View(contratoPromoTelevisao);
        }

        // GET: ContratoPromoTelevisao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoTelevisao = await _context.ContratoPromotelevisao.FindAsync(id);
            if (contratoPromoTelevisao == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoTelevisao.ContratoId);
            ViewData["PromoTelevisaoId"] = new SelectList(_context.PromoTelevisao, "PromoTelevisaoId", "PromoTelevisaoId", contratoPromoTelevisao.PromoTelevisaoId);
            return View(contratoPromoTelevisao);
        }

        // POST: ContratoPromoTelevisao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratoTelevisaoId,ContratoId,PromoTelevisaoId,DataInicio,DataFim")] ContratoPromoTelevisao contratoPromoTelevisao)
        {
            if (id != contratoPromoTelevisao.ContratoTelevisaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoPromoTelevisao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoPromoTelevisaoExists(contratoPromoTelevisao.ContratoTelevisaoId))
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
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", contratoPromoTelevisao.ContratoId);
            ViewData["PromoTelevisaoId"] = new SelectList(_context.PromoTelevisao, "PromoTelevisaoId", "PromoTelevisaoId", contratoPromoTelevisao.PromoTelevisaoId);
            return View(contratoPromoTelevisao);
        }

        // GET: ContratoPromoTelevisao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoPromoTelevisao = await _context.ContratoPromotelevisao
                .Include(c => c.Contratos)
                .Include(c => c.PromoTelevisao)
                .FirstOrDefaultAsync(m => m.ContratoTelevisaoId == id);
            if (contratoPromoTelevisao == null)
            {
                return NotFound();
            }

            return View(contratoPromoTelevisao);
        }

        // POST: ContratoPromoTelevisao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratoPromoTelevisao = await _context.ContratoPromotelevisao.FindAsync(id);
            _context.ContratoPromotelevisao.Remove(contratoPromoTelevisao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoPromoTelevisaoExists(int id)
        {
            return _context.ContratoPromotelevisao.Any(e => e.ContratoTelevisaoId == id);
        }
    }
}
