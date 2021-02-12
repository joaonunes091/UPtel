﻿using System;
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
    public class CanaisController : Controller
    {
        private readonly UPtelContext _context;

        public CanaisController(UPtelContext context)
        {
            _context = context;
        }

        // GET: Canais
        public async Task<IActionResult> Index()
        {
            return View(await _context.Canais.ToListAsync());
        }

        // GET: Canais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canais = await _context.Canais
                .FirstOrDefaultAsync(m => m.CanaisId == id);
            if (canais == null)
            {
                return NotFound();
            }

            return View(canais);
        }

        // GET: Canais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Canais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CanaisId,NomeCanal")] Canais canais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(canais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(canais);
        }

        // GET: Canais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canais = await _context.Canais.FindAsync(id);
            if (canais == null)
            {
                return NotFound();
            }
            return View(canais);
        }

        // POST: Canais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CanaisId,NomeCanal")] Canais canais)
        {
            if (id != canais.CanaisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanaisExists(canais.CanaisId))
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
            return View(canais);
        }

        // GET: Canais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canais = await _context.Canais
                .FirstOrDefaultAsync(m => m.CanaisId == id);
            if (canais == null)
            {
                return NotFound();
            }

            return View(canais);
        }

        // POST: Canais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var canais = await _context.Canais.FindAsync(id);
            _context.Canais.Remove(canais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanaisExists(int id)
        {
            return _context.Canais.Any(e => e.CanaisId == id);
        }
    }
}
