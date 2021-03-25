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


        //Pesquisa nome distrito para adicionar à promo
        public async Task<IActionResult> SelectDistrito(string nomePesquisar)
        {
            List<Distrito> distrito = await _context.Distrito.Where(p => p.DistritoNome.Contains(nomePesquisar))
                    .OrderBy(c => c.DistritoNome)
                    .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Distritos = distrito,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }

        // GET: PromoTelevisao
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {

            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.PromoTelevisao.Where(p => p.Estado.Contains("On") && nomePesquisar == null || p.Estado.Contains("On") && p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<PromoTelevisao> promoTelevisao = await _context.PromoTelevisao.Where(p => p.Estado.Contains("On") && nomePesquisar == null || p.Estado.Contains("On") && p.Nome.Contains(nomePesquisar))
                .OrderBy(c => c.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                PromoTelevisao = promoTelevisao,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);

        }

        // GET: PromoTelevisão Off
        public async Task<IActionResult> PromoOff(string nomePesquisar, int pagina = 1)
        {

            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.PromoTelevisao.Where(p => p.Estado.Contains("Off") && nomePesquisar == null || p.Estado.Contains("Off") && p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<PromoTelevisao> promoTelevisao = await _context.PromoTelevisao.Where(p => p.Estado.Contains("Off") && nomePesquisar == null || p.Estado.Contains("Off") && p.Nome.Contains(nomePesquisar))
                .OrderBy(c => c.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                PromoTelevisao = promoTelevisao,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);

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
        public async Task<IActionResult> Create(int id, [Bind("PromoTelevisaoId,Nome,CanaisGratis,DescontoPrecoTotal,Descricao,Estado,DistritoId,DistritoNomes")] PromoTelevisao promoTelevisao)
        {
            //Código que vai buscar o ID do distrito atraves do distrito selecionado na vista SelectDistrito
            var distrito = _context.Distrito.SingleOrDefault(m => m.DistritoId == id);

            promoTelevisao.DistritoId = distrito.DistritoId;
            promoTelevisao.DistritoNomes = distrito.DistritoNome;

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
        public async Task<IActionResult> Edit(int id, [Bind(("PromoTelevisaoId,Nome,CanaisGratis,DescontoPrecoTotal,Descricao,Estado,DistritoId,DistritoNomes"))] PromoTelevisao promoTelevisao)
        {
            //Código que vai buscar o ID do distrito atraves do distrito selecionado na vista SelectDistrito
            var distrito = _context.Distrito.SingleOrDefault(m => m.DistritoId == id);

            promoTelevisao.DistritoId = distrito.DistritoId;
            promoTelevisao.DistritoNomes = distrito.DistritoNome;

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
      
        // GET: PromoTelevisao/Estado/5
        public async Task<IActionResult> Estado(int? id)
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

        // POST: PromoTelevisao/Estado/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Estado(int id, [Bind(("PromoTelevisaoId,Nome,CanaisGratis,DescontoPrecoTotal,Descricao,Estado,DistritoId,DistritoNomes"))] PromoTelevisao promoTelevisao)
        {
            //Código que vai buscar o ID do distrito atraves do distrito selecionado na vista SelectDistrito
            var distrito = _context.Distrito.SingleOrDefault(m => m.DistritoId == id);

            promoTelevisao.DistritoId = distrito.DistritoId;
            promoTelevisao.DistritoNomes = distrito.DistritoNome;

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
