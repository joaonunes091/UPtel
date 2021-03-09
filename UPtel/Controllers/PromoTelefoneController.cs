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
    public class PromoTelefoneController : Controller
    {
        private readonly UPtelContext _context;

        public PromoTelefoneController(UPtelContext context)
        {
            _context = context;
        }

        // GET: PromoTelefone
        public async Task<IActionResult> Index()
        {
            return View(await _context.PromoTelefone.ToListAsync());
        }

        // GET: PromoTelefone/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoTelefone = await _context.PromoTelefone
                .FirstOrDefaultAsync(m => m.PromoTelefoneId == id);
            if (promoTelefone == null)
            {
                return NotFound();
            }

            return View(promoTelefone);
        }

        // GET: PromoTelefone/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PromoTelefone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromTelefoneId,Nome,Limite,DescontoMinNacional,DescontoMinInternacional,DescontoPrecoTotal")] PromoTelefone promoTelefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promoTelefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promoTelefone);
        }

        // GET: PromoTelefone/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoTelefone = await _context.PromoTelefone.FindAsync(id);
            if (promoTelefone == null)
            {
                return NotFound();
            }
            return View(promoTelefone);
        }

        // POST: PromoTelefone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromTelefoneId,Nome,Limite,DescontoMinNacional,DescontoMinInternacional,DescontoPrecoTotal")] PromoTelefone promoTelefone)
        {
            if (id != promoTelefone.PromoTelefoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promoTelefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoTelefoneExists(promoTelefone.PromoTelefoneId))
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
            return View(promoTelefone);
        }

        // GET: PromoTelefone/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoTelefone = await _context.PromoTelefone
                .FirstOrDefaultAsync(m => m.PromoTelefoneId == id);
            if (promoTelefone == null)
            {
                return NotFound();
            }

            return View(promoTelefone);
        }

        // POST: PromoTelefone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promoTelefone = await _context.PromoTelefone.FindAsync(id);
            _context.PromoTelefone.Remove(promoTelefone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoTelefoneExists(int id)
        {
            return _context.PromoTelefone.Any(e => e.PromoTelefoneId == id);
        }
    }
}
