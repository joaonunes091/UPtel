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
    public class NetMovelController : Controller
    {
        private readonly UPtelContext _context;

        public NetMovelController(UPtelContext context)
        {
            _context = context;
        }

        // GET: NetMovel
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.NetMovel.Where(p => nomePesquisar == null || p.Numero.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<NetMovel> netmovel = await _context.NetMovel.Where(p => nomePesquisar == null || p.Numero.Contains(nomePesquisar))
                .OrderBy(c => c.Numero)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                NetMovel = netmovel,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }
           
            // GET: NetMovel/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netMovel = await _context.NetMovel
                .FirstOrDefaultAsync(m => m.NetMovelId == id);
            if (netMovel == null)
            {
                return NotFound();
            }

            return View(netMovel);
        }

        // GET: NetMovel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NetMovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NetMovelId,Limite,PrecoNetMovel,Numero,Notas")] NetMovel netMovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(netMovel);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Net móvel adicionado com sucesso";
                return View("Sucesso");
            }
            return View(netMovel);
        }

        // GET: NetMovel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netMovel = await _context.NetMovel.FindAsync(id);
            if (netMovel == null)
            {
                return NotFound();
            }
            return View(netMovel);
        }

        // POST: NetMovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NetMovelId,Limite,PrecoNetMovel,Numero,Notas")] NetMovel netMovel)
        {
            if (id != netMovel.NetMovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(netMovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NetMovelExists(netMovel.NetMovelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Net móvel adicionado com sucesso";
                return View("Sucesso");
            }
            return View(netMovel);
        }

        // GET: NetMovel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netMovel = await _context.NetMovel
                .FirstOrDefaultAsync(m => m.NetMovelId == id);
            if (netMovel == null)
            {
                return NotFound();
            }

            return View(netMovel);
        }

        // POST: NetMovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var netMovel = await _context.NetMovel.FindAsync(id);
            _context.NetMovel.Remove(netMovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NetMovelExists(int id)
        {
            return _context.NetMovel.Any(e => e.NetMovelId == id);
        }
    }
}
