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
    public class PromoNetMovelController : Controller
    {
        private readonly UPtelContext _context;

        public PromoNetMovelController(UPtelContext context)
        {
            _context = context;
        }

        // GET: PromoNetMovel
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.PromoNetMovel.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<PromoNetMovel> promoNetMovel = await _context.PromoNetMovel.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
                .OrderBy(c => c.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                PromoNetMovel = promoNetMovel,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }

        // GET: PromoNetMovel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoNetMovel = await _context.PromoNetMovel
                .FirstOrDefaultAsync(m => m.PromoNetMovelId == id);
            if (promoNetMovel == null)
            {
                return NotFound();
            }

            return View(promoNetMovel);
        }

        // GET: PromoNetMovel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PromoNetMovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoNetMovelId,Nome,Limite,DescontoPrecoTotal")] PromoNetMovel promoNetMovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promoNetMovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promoNetMovel);
        }

        // GET: PromoNetMovel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoNetMovel = await _context.PromoNetMovel.FindAsync(id);
            if (promoNetMovel == null)
            {
                return NotFound();
            }
            return View(promoNetMovel);
        }

        // POST: PromoNetMovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoNetMovelId,Nome,Limite,DescontoPrecoTotal")] PromoNetMovel promoNetMovel)
        {
            if (id != promoNetMovel.PromoNetMovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promoNetMovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoNetMovelExists(promoNetMovel.PromoNetMovelId))
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
            return View(promoNetMovel);
        }

        // GET: PromoNetMovel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoNetMovel = await _context.PromoNetMovel
                .FirstOrDefaultAsync(m => m.PromoNetMovelId == id);
            if (promoNetMovel == null)
            {
                return NotFound();
            }

            return View(promoNetMovel);
        }

        // POST: PromoNetMovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promoNetMovel = await _context.PromoNetMovel.FindAsync(id);
            _context.PromoNetMovel.Remove(promoNetMovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoNetMovelExists(int id)
        {
            return _context.PromoNetMovel.Any(e => e.PromoNetMovelId == id);
        }
    }
}
