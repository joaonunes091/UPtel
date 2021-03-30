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
    public class NetFixaController : Controller
    {
        private readonly UPtelContext _context;

        public NetFixaController(UPtelContext context)
        {
            _context = context;
        }

        // GET: NetFixa
        public async Task<IActionResult> Index()
        {
            return View(await _context.NetFixa.ToListAsync());
        }

        // GET: NetFixa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netFixa = await _context.NetFixa
                .FirstOrDefaultAsync(m => m.NetFixaId == id);
            if (netFixa == null)
            {
                return NotFound();
            }

            return View(netFixa);
        }

        // GET: NetFixa/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: NetFixa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([Bind("NetFixaId,Nome,Limite,Velocidade,TipoConexao,PrecoNetFixa,Notas")] NetFixa netFixa)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Não foi possível adicionar a NET Fixa, tente novamente");
                return View(netFixa);
            }

            _context.Add(netFixa);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "Net fixa adicionado com sucesso";
            return View("Sucesso");
        }

        // GET: NetFixa/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netFixa = await _context.NetFixa.FindAsync(id);
            if (netFixa == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente a net fixa já foi eliminada.";
                return View("Erro");
            }
            return View(netFixa);
        }

        // POST: NetFixa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("NetFixaId,Nome,Limite,Velocidade,TipoConexao,PrecoNetFixa,Notas")] NetFixa netFixa)
        {
            if (id != netFixa.NetFixaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(netFixa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NetFixaExists(netFixa.NetFixaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Net fixa alterada com sucesso";
                return View("Sucesso");
            }
            return View(netFixa);
        }

        // GET: NetFixa/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netFixa = await _context.NetFixa
                .FirstOrDefaultAsync(m => m.NetFixaId == id);
            if (netFixa == null)
            {
                ViewBag.Mensagem = "A netfixa já foi eliminada por outra pessoa.";
                return View("Sucesso");
            }

            return View(netFixa);
        }

        // POST: NetFixa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var netFixa = await _context.NetFixa.FindAsync(id);
            _context.NetFixa.Remove(netFixa);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "A net fixa foi eliminada com sucesso.";
            return View("Sucesso");
        }

        private bool NetFixaExists(int id)
        {
            return _context.NetFixa.Any(e => e.NetFixaId == id);
        }
    }
}
