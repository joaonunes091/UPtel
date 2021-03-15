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
    public class PromoTelemovelController : Controller
    {
        private readonly UPtelContext _context;

        public PromoTelemovelController(UPtelContext context)
        {
            _context = context;
        }

        // GET: PromoTelemovel
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.PromoTelemovel.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<PromoTelemovel> promoTelemovel = await _context.PromoTelemovel.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
                .OrderBy(c => c.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();
            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                PromoTelemovel = promoTelemovel,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }

        // GET: PromoTelemovel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoTelemovel = await _context.PromoTelemovel
                .FirstOrDefaultAsync(m => m.PromoTelemovelId == id);
            if (promoTelemovel == null)
            {
                return NotFound();
            }

            return View(promoTelemovel);
        }

        // GET: PromoTelemovel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PromoTelemovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoTelemovelId,Nome,LimiteMinutos,LimiteSMS,DecontoPrecoMinNacional,DecontoPrecoMinInternacional,DecontoPrecoSMS,DecontoPrecoMMS,DecontoPrecoTotal")] PromoTelemovel promoTelemovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promoTelemovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promoTelemovel);
        }

        // GET: PromoTelemovel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoTelemovel = await _context.PromoTelemovel.FindAsync(id);
            if (promoTelemovel == null)
            {
                return NotFound();
            }
            return View(promoTelemovel);
        }

        // POST: PromoTelemovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoTelemovelId,Nome,LimiteMinutos,LimiteSMS,DecontoPrecoMinNacional,DecontoPrecoMinInternacional,DecontoPrecoSMS,DecontoPrecoMMS,DecontoPrecoTotal")] PromoTelemovel promoTelemovel)
        {
            if (id != promoTelemovel.PromoTelemovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promoTelemovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoTelemovelExists(promoTelemovel.PromoTelemovelId))
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
            return View(promoTelemovel);
        }

        // GET: PromoTelemovel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoTelemovel = await _context.PromoTelemovel
                .FirstOrDefaultAsync(m => m.PromoTelemovelId == id);
            if (promoTelemovel == null)
            {
                return NotFound();
            }

            return View(promoTelemovel);
        }

        // POST: PromoTelemovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promoTelemovel = await _context.PromoTelemovel.FindAsync(id);
            _context.PromoTelemovel.Remove(promoTelemovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoTelemovelExists(int id)
        {
            return _context.PromoTelemovel.Any(e => e.PromoTelemovelId == id);
        }
    }
}
