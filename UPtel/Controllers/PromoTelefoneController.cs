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
    public class PromoTelefoneController : Controller
    {
        private readonly UPtelContext _context;

        public PromoTelefoneController(UPtelContext context)
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

        // GET: PromoTelefone
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.PromoTelefone.Where(p => p.Estado.Contains("On") && nomePesquisar == null || p.Estado.Contains("On") && p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<PromoTelefone> promoTelefone = await _context.PromoTelefone.Where(p => p.Estado.Contains("On") && nomePesquisar == null || p.Estado.Contains("On") && p.Nome.Contains(nomePesquisar))
                .Include(d=>d.DistritoNome)
                .OrderBy(c => c.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                PromoTelefone = promoTelefone,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }

        // GET: PromoTelefone Off
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> PromoOff(string nomePesquisar, int pagina = 1)
        {

            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.PromoTelefone.Where(p => p.Estado.Contains("Off") && nomePesquisar == null || p.Estado.Contains("Off") && p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<PromoTelefone> promotelefone = await _context.PromoTelefone.Where(p => p.Estado.Contains("Off") && nomePesquisar == null || p.Estado.Contains("Off") && p.Nome.Contains(nomePesquisar))
                .OrderBy(c => c.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                PromoTelefone = promotelefone,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);

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
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PromoTelefone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(int id, [Bind("PromoTelefoneId,Nome,Limite,DescontoMinNacional,DescontoMinInternacional,DescontoPrecoTotal,Descricao,Estado,DistritoId,DistritoNomes")] PromoTelefone promoTelefone)
        {

            //Código que vai buscar o ID do distrito atraves do distrito selecionado na vista SelectDistrito
            var distrito = _context.Distrito.SingleOrDefault(m => m.DistritoId == id);

            promoTelefone.DistritoId = distrito.DistritoId;
            promoTelefone.DistritoNomes = distrito.DistritoNome;

            if (ModelState.IsValid)
            {
                _context.Add(promoTelefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promoTelefone);
        }

        // GET: PromoTelefone/Edit/5
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("PromoTelefoneId,Nome,Limite,DescontoMinNacional,DescontoMinInternacional,DescontoPrecoTotal,Descricao,Estado,DistritoId,DistritoNomes")] PromoTelefone promoTelefone)
        {
            //Código que vai buscar o ID do distrito atraves do distrito selecionado na vista SelectDistrito
            var distrito = _context.Distrito.SingleOrDefault(m => m.DistritoId == id);

            var estado = _context.PromoTelefone.SingleOrDefault(e => e.PromoTelefoneId == id);

            promoTelefone.DistritoId = distrito.DistritoId;
            promoTelefone.DistritoNomes = distrito.DistritoNome;
            promoTelefone.Estado = estado.Estado;

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

        // GET: PromoTelefone/Estado/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Estado(int? id)
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

        // POST: PromoTelefone/Estado/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Estado(int id, [Bind("PromoTelefoneId,Nome,Limite,DescontoMinNacional,DescontoMinInternacional,DescontoPrecoTotal,Descricao,Estado,DistritoId,DistritoNomes")] PromoTelefone promoTelefone)
        {
            //Código que vai buscar o ID do distrito atraves do distrito selecionado na vista SelectDistrito
            var distrito = _context.Distrito.SingleOrDefault(m => m.DistritoId == id);

            promoTelefone.DistritoId = distrito.DistritoId;
            promoTelefone.DistritoNomes = distrito.DistritoNome;

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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
