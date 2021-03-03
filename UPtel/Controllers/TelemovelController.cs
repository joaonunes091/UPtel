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
    public class TelemovelController : Controller
    {
        private readonly UPtelContext _context;

        public TelemovelController(UPtelContext context)
        {
            _context = context;
        }

        // GET: Telemovel.        
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Telemovel.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
        List<Telemovel> telemovel = await _context.Telemovel.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
            .OrderBy(c => c.Nome)
            .Skip(paginacao.ItemsPorPagina * (pagina - 1))
            .Take(paginacao.ItemsPorPagina)
            .ToListAsync();

        ListaCanaisViewModel model = new ListaCanaisViewModel
        {
            Paginacao = paginacao,
            Telemovel = telemovel,
            NomePesquisar = nomePesquisar
        };

            return base.View(model);
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
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Telemovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([Bind("TelemovelId,Nome,LimiteMinutos,LimiteSms,PrecoMinutoNacional,PrecoMinutoInternacional,PrecoSms,PrecoMms,PrecoPacoteTelemovel")] Telemovel telemovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telemovel);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Tevemóvel adicionado com sucesso";
                return View("Sucesso");
            }
            return View(telemovel);
        }

        // GET: Telemovel/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telemovel = await _context.Telemovel.FindAsync(id);
            if (telemovel == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente o telemóvel já foi eliminado.";
                return View("Erro");
            }
            return View(telemovel);
        }

        // POST: Telemovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("TelemovelId,Nome,LimiteMinutos,LimiteSms,PrecoMinutoNacional,PrecoMinutoInternacional,PrecoSms,PrecoMms,PrecoPacoteTelemovel")] Telemovel telemovel)
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
                ViewBag.Mensagem = "Tevemóvel alterado com sucesso";
                return View("Sucesso");
            }
            return View(telemovel);
        }

        // GET: Telemovel/Delete/5
        [Authorize(Roles = "Administrador")]
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
                ViewBag.Mensagem = "O telemóvel já foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(telemovel);
        }

        // POST: Telemovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telemovel = await _context.Telemovel.FindAsync(id);
            _context.Telemovel.Remove(telemovel);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "O telemóvel foi eliminado com sucesso.";
            return View("Sucesso");
        }

        private bool TelemovelExists(int id)
        {
            return _context.Telemovel.Any(e => e.TelemovelId == id);
        }
    }
}
