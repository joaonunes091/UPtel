using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        //Pesquisa nome distrito para adicionar à promo
        [Authorize(Roles = "Administrador")]
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
       
        // GET: PromoTelemovel
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.PromoTelemovel.Where(p => p.Estado.Contains("On") && nomePesquisar == null || p.Estado.Contains("On") && p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<PromoTelemovel> promoTelemovel = await _context.PromoTelemovel.Where(p => p.Estado.Contains("On") && nomePesquisar == null || p.Estado.Contains("On") && p.Nome.Contains(nomePesquisar))
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

        // GET: PromoTelemovel
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> PromoOff (string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.PromoTelemovel.Where(p => p.Estado.Contains("Off") && nomePesquisar == null || p.Estado.Contains("Off") && p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<PromoTelemovel> promoTelemovel = await _context.PromoTelemovel.Where(p => p.Estado.Contains("Off") && nomePesquisar == null || p.Estado.Contains("Off") && p.Nome.Contains(nomePesquisar))
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
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PromoTelemovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(int id, [Bind("PromoTelemovelId,Nome,LimiteMinutos,LimiteSMS,DecontoPrecoMinNacional,DecontoPrecoMinInternacional,DecontoPrecoSMS,DecontoPrecoMMS,DecontoPrecoTotal,Descricao,Estado,DistritoId,DistritoNomes")] PromoTelemovel promoTelemovel)
        {
            //Código que vai buscar o ID do distrito atraves do distrito selecionado na vista SelectDistrito
            var distrito = _context.Distrito.SingleOrDefault(m => m.DistritoId == id);

            promoTelemovel.DistritoId = distrito.DistritoId;
            promoTelemovel.DistritoNomes = distrito.DistritoNome;

            if (ModelState.IsValid)
            {
                _context.Add(promoTelemovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promoTelemovel);
        }

        // GET: PromoTelemovel/Edit/5
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("PromoTelemovelId,Nome,LimiteMinutos,LimiteSMS,DecontoPrecoMinNacional,DecontoPrecoMinInternacional,DecontoPrecoSMS,DecontoPrecoMMS,DecontoPrecoTotal,Descricao,Estado,DistritoId,DistritoNomes")] PromoTelemovel promoTelemovel)
        {
            //Código que vai buscar o ID do distrito atraves do distrito selecionado na vista SelectDistrito
            var distrito = _context.Distrito.SingleOrDefault(m => m.DistritoId == id);

            var estado = _context.PromoTelefone.SingleOrDefault(e => e.PromoTelefoneId == id);

            promoTelemovel.DistritoId = distrito.DistritoId;
            promoTelemovel.DistritoNomes = distrito.DistritoNome;
            promoTelemovel.Estado = estado.Estado;

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

        // GET: PromoTelemovel/Estado/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Estado(int? id)
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

        // POST: PromoTelemovel/Estado/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Estado(int id, [Bind("PromoTelemovelId,Nome,LimiteMinutos,LimiteSMS,DecontoPrecoMinNacional,DecontoPrecoMinInternacional,DecontoPrecoSMS,DecontoPrecoMMS,DecontoPrecoTotal,Descricao,Estado,DistritoId,DistritoNomes")] PromoTelemovel promoTelemovel)
        {
            //Código que vai buscar o ID do distrito atraves do distrito selecionado na vista SelectDistrito
            var distrito = _context.Distrito.SingleOrDefault(m => m.DistritoId == id);

            promoTelemovel.DistritoId = distrito.DistritoId;
            promoTelemovel.DistritoNomes = distrito.DistritoNome;

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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
