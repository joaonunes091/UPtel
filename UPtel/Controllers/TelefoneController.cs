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
    public class TelefoneController : Controller
    {
        private readonly UPtelContext _context;

        public TelefoneController(UPtelContext context)
        {
            _context = context;
        }

        // GET: Telefone
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Telefone.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<Telefone> telefone = await _context.Telefone.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
                .OrderBy(c => c.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel model = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                Telefone = telefone,
                NomePesquisar = nomePesquisar
            };

            return base.View(model);
        }

        // GET: Telefone/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone
                .FirstOrDefaultAsync(m => m.TelefoneId == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // GET: Telefone/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Telefone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([Bind("TelefoneId,Nome,Limite,PrecoMinutoNacional,PrecoMinutoInternacional,PrecoPacoteTelefone")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefone);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Telefone adicionado com sucesso";
                return View("Sucesso");
            }
            return View(telefone);
        }

        // GET: Telefone/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone.FindAsync(id);
            if (telefone == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente o telefone já foi eliminado.";
                return View("Erro");
            }
            return View(telefone);
        }

        // POST: Telefone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("TelefoneId,Nome,Limite,PrecoMinutoNacional,PrecoMinutoInternacional,PrecoPacoteTelefone")] Telefone telefone)
        {
            if (id != telefone.TelefoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefoneExists(telefone.TelefoneId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Telefone alterado com sucesso";
                return View("Sucesso");
            }
            return View(telefone);
        }

        // GET: Telefone/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone
                .FirstOrDefaultAsync(m => m.TelefoneId == id);
            if (telefone == null)
            {
                ViewBag.Mensagem = "O telefone já foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(telefone);
        }

        // POST: Telefone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefone = await _context.Telefone.FindAsync(id);
            _context.Telefone.Remove(telefone);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "O telefone foi eliminado com sucesso.";
            return View("Sucesso");
        }

        private bool TelefoneExists(int id)
        {
            return _context.Telefone.Any(e => e.TelefoneId == id);
        }
    }
}
