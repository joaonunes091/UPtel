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
    public class PromoNetFixaController : Controller
    {
        private readonly UPtelContext _context;

        public PromoNetFixaController(UPtelContext context)
        {
            _context = context;
        }

        // GET: PromoNetFixa
        public async Task<IActionResult> Index()
        {
            return View(await _context.PromoNetFixa.ToListAsync());
        }

        // GET: PromoNetFixa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoNetFixa = await _context.PromoNetFixa
                .FirstOrDefaultAsync(m => m.PromoNetFixaId == id);
            if (promoNetFixa == null)
            {
                return NotFound();
            }

            return View(promoNetFixa);
        }

        // GET: PromoNetFixa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PromoNetFixa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoNetFixaId,Nome,Limite,Velocidade,DescontoPrecoTotal")] PromoNetFixa promoNetFixa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promoNetFixa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promoNetFixa);
        }

        // GET: PromoNetFixa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoNetFixa = await _context.PromoNetFixa.FindAsync(id);
            if (promoNetFixa == null)
            {
                return NotFound();
            }
            return View(promoNetFixa);
        }

        // POST: PromoNetFixa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoNetFixaId,Nome,Limite,Velocidade,DescontoPrecoTotal")] PromoNetFixa promoNetFixa)
        {
            if (id != promoNetFixa.PromoNetFixaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promoNetFixa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoNetFixaExists(promoNetFixa.PromoNetFixaId))
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
            return View(promoNetFixa);
        }

        // GET: PromoNetFixa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoNetFixa = await _context.PromoNetFixa
                .FirstOrDefaultAsync(m => m.PromoNetFixaId == id);
            if (promoNetFixa == null)
            {
                return NotFound();
            }

            return View(promoNetFixa);
        }

        // POST: PromoNetFixa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promoNetFixa = await _context.PromoNetFixa.FindAsync(id);
            _context.PromoNetFixa.Remove(promoNetFixa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoNetFixaExists(int id)
        {
            return _context.PromoNetFixa.Any(e => e.PromoNetFixaId == id);
        }
    }
}
