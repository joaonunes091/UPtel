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
    public class PromoTelevisaoController : Controller
    {
        private readonly UPtelContext _context;

        public PromoTelevisaoController(UPtelContext context)
        {
            _context = context;
        }

        // GET: PromoTelevisao
        public async Task<IActionResult> Index()
        {
            return View(await _context.PromoTelevisao.ToListAsync());
        }

        // GET: PromoTelevisao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoTelevisao = await _context.PromoTelevisao
                .FirstOrDefaultAsync(m => m.PromoTelevisaoId == id);
            if (promoTelevisao == null)
            {
                return NotFound();
            }

            return View(promoTelevisao);
        }

        // GET: PromoTelevisao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PromoTelevisao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoTelevisaoId,Nome,CanaisGratis,DescontoPrecoTotal")] PromoTelevisao promoTelevisao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promoTelevisao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promoTelevisao);
        }

        // GET: PromoTelevisao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoTelevisao = await _context.PromoTelevisao.FindAsync(id);
            if (promoTelevisao == null)
            {
                return NotFound();
            }
            return View(promoTelevisao);
        }

        // POST: PromoTelevisao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoTelevisaoId,Nome,CanaisGratis,DescontoPrecoTotal")] PromoTelevisao promoTelevisao)
        {
            if (id != promoTelevisao.PromoTelevisaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promoTelevisao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoTelevisaoExists(promoTelevisao.PromoTelevisaoId))
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
            return View(promoTelevisao);
        }

        // GET: PromoTelevisao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoTelevisao = await _context.PromoTelevisao
                .FirstOrDefaultAsync(m => m.PromoTelevisaoId == id);
            if (promoTelevisao == null)
            {
                return NotFound();
            }

            return View(promoTelevisao);
        }

        // POST: PromoTelevisao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promoTelevisao = await _context.PromoTelevisao.FindAsync(id);
            _context.PromoTelevisao.Remove(promoTelevisao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoTelevisaoExists(int id)
        {
            return _context.PromoTelevisao.Any(e => e.PromoTelevisaoId == id);
        }
    }
}
