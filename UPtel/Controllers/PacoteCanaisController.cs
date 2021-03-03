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
    [Authorize(Roles = "Administrador")]
    public class PacoteCanaisController : Controller
    {
        private readonly UPtelContext _context;

        public PacoteCanaisController(UPtelContext context)
        {
            _context = context;
        }

        // GET: PacoteCanais
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.PacoteCanais.Include(p => p.Canais).Include(p => p.Televisao).Where(p => nomePesquisar == null || p.Canais.NomeCanal.Contains(nomePesquisar) || p.Televisao.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<PacoteCanais> pacoteCanais = await _context.PacoteCanais.Include(p => p.Canais).Include(p => p.Televisao).Where(p => nomePesquisar == null || p.Canais.NomeCanal.Contains(nomePesquisar) || p.Televisao.Nome.Contains(nomePesquisar))
                .OrderBy(c => c.Canais.NomeCanal)
                .OrderBy(c => c.Televisao.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                PacoteCanais = pacoteCanais,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }

        // GET: PacoteCanais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteCanais = await _context.PacoteCanais
                .Include(p => p.Canais)
                .Include(p => p.Televisao)
                .FirstOrDefaultAsync(m => m.PacoteCanalId == id);
            if (pacoteCanais == null)
            {
                return NotFound();
            }

            return View(pacoteCanais);
        }

        // GET: PacoteCanais/Create
        public IActionResult Create()
        {
            ViewData["CanaisId"] = new SelectList(_context.Canais, "CanaisId", "NomeCanal");
            ViewData["TelevisaoId"] = new SelectList(_context.Televisao, "TelevisaoId", "Nome");
            return View();
        }

        // POST: PacoteCanais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacoteCanalId,TelevisaoId,CanaisId")] PacoteCanais pacoteCanais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacoteCanais);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Pacote de canais adicionado com sucesso";
                return View("Sucesso");
            }
            ViewData["CanaisId"] = new SelectList(_context.Canais, "CanaisId", "NomeCanal", pacoteCanais.CanaisId);
            ViewData["TelevisaoId"] = new SelectList(_context.Televisao, "TelevisaoId", "Nome", pacoteCanais.TelevisaoId);
            return View(pacoteCanais);
        }

        // GET: PacoteCanais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteCanais = await _context.PacoteCanais.FindAsync(id);
            if (pacoteCanais == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmenteo pacote de canais já foi eliminado.";
                return View("Erro");
            }
            ViewData["CanaisId"] = new SelectList(_context.Canais, "CanaisId", "NomeCanal", pacoteCanais.CanaisId);
            ViewData["TelevisaoId"] = new SelectList(_context.Televisao, "TelevisaoId", "Nome", pacoteCanais.TelevisaoId);
            return View(pacoteCanais);
        }

        // POST: PacoteCanais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacoteCanalId,TelevisaoId,CanaisId")] PacoteCanais pacoteCanais)
        {
            if (id != pacoteCanais.PacoteCanalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacoteCanais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacoteCanaisExists(pacoteCanais.PacoteCanalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Pacote de canais alterado com sucesso";
                return View("Sucesso");
            }
            ViewData["CanaisId"] = new SelectList(_context.Canais, "CanaisId", "NomeCanal", pacoteCanais.CanaisId);
            ViewData["TelevisaoId"] = new SelectList(_context.Televisao, "TelevisaoId", "Nome", pacoteCanais.TelevisaoId);
            return View(pacoteCanais);
        }

        // GET: PacoteCanais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteCanais = await _context.PacoteCanais
                .Include(p => p.Canais)
                .Include(p => p.Televisao)
                .FirstOrDefaultAsync(m => m.PacoteCanalId == id);
            if (pacoteCanais == null)
            {
                ViewBag.Mensagem = "O pacote de canais já foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(pacoteCanais);
        }

        // POST: PacoteCanais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacoteCanais = await _context.PacoteCanais.FindAsync(id);
            _context.PacoteCanais.Remove(pacoteCanais);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "O pacote de canais foi eliminado com sucesso.";
            return View("Sucesso");
        }

        private bool PacoteCanaisExists(int id)
        {
            return _context.PacoteCanais.Any(e => e.PacoteCanalId == id);
        }
    }
}
