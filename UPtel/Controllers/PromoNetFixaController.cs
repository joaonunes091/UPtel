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


        //Pesquisa nome distrito para adicionar à promo
        public async Task<IActionResult> SelectDistrito (string nomePesquisar)
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


        // GET: PromoNetFixa
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.PromoNetFixa.Where(p => p.Estado.Contains("On") && nomePesquisar == null || p.Estado.Contains("On") && p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };


            List<PromoNetFixa> promoNetFixas = await _context.PromoNetFixa.Where(p => p.Estado.Contains("On") && nomePesquisar == null || p.Estado.Contains("On") && p.Nome.Contains(nomePesquisar))
                .OrderBy(c => c.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();
           



            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                PromoNetFixas = promoNetFixas,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);

        }
        // GET: PromoNetFixa Off
        public async Task<IActionResult> PromoOff (string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.PromoNetFixa.Where(p => p.Estado.Contains("Off") && nomePesquisar == null || p.Estado.Contains("Off") && p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };


            List<PromoNetFixa> promoNetFixas = await _context.PromoNetFixa.Where(p => p.Estado.Contains("Off") && nomePesquisar == null || p.Estado.Contains("Off") && p.Nome.Contains(nomePesquisar))
                .OrderBy(c => c.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();




            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                PromoNetFixas = promoNetFixas,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);

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
        public async Task<IActionResult> Create(int id,[Bind("PromoNetFixaId,Nome,Limite,Velocidade,DescontoPrecoTotal,Descricao,Estado,DistritoId,DistritoNomes")] PromoNetFixa promoNetFixa)
        {
            //Código que vai buscar o ID do distrito atraves do distrito selecionado na vista SelectDistrito
            var distrito = _context.Distrito.SingleOrDefault(m => m.DistritoId == id);

            promoNetFixa.DistritoId = distrito.DistritoId;
            promoNetFixa.DistritoNomes = distrito.DistritoNome;

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
        public async Task<IActionResult> Edit(int id, [Bind("PromoNetFixaId,Nome,Limite,Velocidade,DescontoPrecoTotal,Descricao,Estado,DistritoId,DistritoNomes")] PromoNetFixa promoNetFixa)
        {

            //Código que vai buscar o ID do distrito atraves do distrito selecionado na vista SelectDistrito
            var distrito = _context.Distrito.SingleOrDefault(m => m.DistritoId == id);

            promoNetFixa.DistritoId = distrito.DistritoId;
            promoNetFixa.DistritoNomes = distrito.DistritoNome;

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

        // GET: PromoNetFixa/Estado/5
        public async Task<IActionResult> Estado (int? id)
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

        // POST: PromoNetFixa/Estado/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Estado (int id, [Bind("PromoNetFixaId,Nome,Limite,Velocidade,DescontoPrecoTotal,Descricao,Estado,DistritoId,DistritoNomes")] PromoNetFixa promoNetFixa)
        {

            //Código que vai buscar o ID do distrito atraves do distrito selecionado na vista SelectDistrito
            var distrito = _context.Distrito.SingleOrDefault(m => m.DistritoId == id);

            promoNetFixa.DistritoId = distrito.DistritoId;
            promoNetFixa.DistritoNomes = distrito.DistritoNome;

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
