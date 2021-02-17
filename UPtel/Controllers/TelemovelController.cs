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
    public class TelemovelController : Controller
    {
        private readonly UPtelContext _context;

        public TelemovelController(UPtelContext context)
        {
            _context = context;
        }

        // GET: Telemovel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Telemovel.ToListAsync());
        }

        // GET: Telemovel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telemovel = await _context.Telemovel
                .FirstOrDefaultAsync(m => m.TelemovelId == id);
            if (telemovel == null)
            {
                return NotFound();
            }

            return View(telemovel);
        }

        // GET: Telemovel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Telemovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TelemovelId,Numero,LimiteMinutos,LimiteSms,PrecoMinutoNacional,PrecoMinutoInternacional,PrecoSms,PrecoMms,PrecoPacoteTelemovel")] Telemovel telemovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telemovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telemovel);
        }

        // GET: Telemovel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telemovel = await _context.Telemovel.FindAsync(id);
            if (telemovel == null)
            {
                return NotFound();
            }
            return View(telemovel);
        }

        // POST: Telemovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TelemovelId,Numero,LimiteMinutos,LimiteSms,PrecoMinutoNacional,PrecoMinutoInternacional,PrecoSms,PrecoMms,PrecoPacoteTelemovel")] Telemovel telemovel)
        {
            if (id != telemovel.TelemovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telemovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelemovelExists(telemovel.TelemovelId))
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
            return View(telemovel);
        }

        // GET: Telemovel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telemovel = await _context.Telemovel
                .FirstOrDefaultAsync(m => m.TelemovelId == id);
            if (telemovel == null)
            {
                return NotFound();
            }

            return View(telemovel);
        }

        // POST: Telemovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telemovel = await _context.Telemovel.FindAsync(id);
            _context.Telemovel.Remove(telemovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelemovelExists(int id)
        {
            return _context.Telemovel.Any(e => e.TelemovelId == id);
        }
    }
}
