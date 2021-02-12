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
    public class TelevisaoController : Controller
    {
        private readonly UPtelContext _context;

        public TelevisaoController(UPtelContext context)
        {
            _context = context;
        }

        // GET: Televisao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Televisao.ToListAsync());
        }

        // GET: Televisao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var televisao = await _context.Televisao
                .FirstOrDefaultAsync(m => m.TelevisaoId == id);
            if (televisao == null)
            {
                return NotFound();
            }

            return View(televisao);
        }

        // GET: Televisao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Televisao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TelevisaoId,Nome,Descricao")] Televisao televisao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(televisao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(televisao);
        }

        // GET: Televisao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var televisao = await _context.Televisao.FindAsync(id);
            if (televisao == null)
            {
                return NotFound();
            }
            return View(televisao);
        }

        // POST: Televisao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TelevisaoId,Nome,Descricao")] Televisao televisao)
        {
            if (id != televisao.TelevisaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(televisao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelevisaoExists(televisao.TelevisaoId))
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
            return View(televisao);
        }

        // GET: Televisao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var televisao = await _context.Televisao
                .FirstOrDefaultAsync(m => m.TelevisaoId == id);
            if (televisao == null)
            {
                return NotFound();
            }

            return View(televisao);
        }

        // POST: Televisao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var televisao = await _context.Televisao.FindAsync(id);
            _context.Televisao.Remove(televisao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelevisaoExists(int id)
        {
            return _context.Televisao.Any(e => e.TelevisaoId == id);
        }
    }
}
