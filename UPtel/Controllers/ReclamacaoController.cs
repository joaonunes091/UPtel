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
    public class ReclamacaoController : Controller
    {
        private readonly UPtelContext _context;

        public ReclamacaoController(UPtelContext context)
        {
            _context = context;
        }

        // GET: Reclamacao
        public async Task<IActionResult> Index()
        {
            var uPtelContext = _context.Reclamacao.Include(r => r.Contratos);
            return View(await uPtelContext.ToListAsync());
        }

        // GET: Reclamacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            var reclamacao = await _context.Reclamacao
                .Include(r => r.Contratos)
                .FirstOrDefaultAsync(m => m.ReclamacaoId == id);
            if (reclamacao == null)
            {
                return NotFound();
            }

            return View(reclamacao);
        }

        // GET: Reclamacao/Create

        [Authorize(Roles = "Cliente")]
        public IActionResult Create(int id)
        {
            return View();
        }

        // POST: Reclamacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> Create([Bind("ReclamacaoId,ContratoId,UsersId,Assunto,Descriçao,ResolvidoCliente,ResolvidoOperador")] Reclamacao reclamacao, int id)
        {
            if (ModelState.IsValid)
            {
                var cliente = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);
                var contrato = _context.Contratos.SingleOrDefault(c => c.ContratoId == id);

                reclamacao.NomeCliente = cliente.Nome;
                reclamacao.FuncionarioId = contrato.FuncionarioId;  
                reclamacao.ContratoId = id;
                reclamacao.ResolvidoCliente = false;
                reclamacao.ResolvidoOperador = false;
                reclamacao.DataReclamacao = DateTime.Now;
                
                _context.Add(reclamacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Não foi possível registar a reclamação, tente novamente");

            return View(reclamacao);
        }

        // GET: Reclamacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reclamacao = await _context.Reclamacao.FindAsync(id);
            
            if (reclamacao == null)
            {
                return NotFound();
            }
            ViewData["ContartoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", reclamacao.ContratoId);
            return View(reclamacao);
        }

        // POST: Reclamacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReclamacaoId,ContartoId,UsersId,Assunto,Descriçao,NomeCliente,ResolvidoOperador,ResolvidoCliente")] Reclamacao reclamacao)
        {
            if (id != reclamacao.ReclamacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var rec = await _context.Reclamacao
                    .AsNoTracking()
                    .Include(r => r.Contratos)
                    .FirstOrDefaultAsync(m => m.ReclamacaoId == id);

                    var funcionario = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);

                    
                    reclamacao.ContratoId = rec.ContratoId;
                    reclamacao.DataReclamacao = rec.DataReclamacao;
                    reclamacao.FuncionarioId = funcionario.UsersId;

                    _context.Update(reclamacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclamacaoExists(reclamacao.ReclamacaoId))
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


            ModelState.AddModelError("", "Não foi possível registar a reclamação, tente novamente");
            return View(reclamacao);
        }

        // GET: Reclamacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamacao
                .Include(r => r.Contratos)
                .FirstOrDefaultAsync(m => m.ReclamacaoId == id);
            if (reclamacao == null)
            {
                ViewBag.Mensagem = "O cliente já foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(reclamacao);
        }

        // POST: Reclamacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reclamacao = await _context.Reclamacao.FindAsync(id);
            _context.Reclamacao.Remove(reclamacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReclamacaoExists(int id)
        {
            return _context.Reclamacao.Any(e => e.ReclamacaoId == id);
        }
    }
}
