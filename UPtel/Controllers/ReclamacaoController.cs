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
            ReclamacaoViewModel RVM = new ReclamacaoViewModel();
            return View(RVM);
        }

        // POST: Reclamacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> Create(ReclamacaoViewModel RVM,Reclamacao reclamacao, int id)
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
                reclamacao.Assunto = RVM.Assunto;
                reclamacao.Descricao = RVM.Descricao;
                reclamacao.ReclamacaoId = RVM.ReclamacaoId;

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
            //var reclamacao = await _context.Reclamacao.FindAsync(id);
            ReclamacaoViewModel RVM = new ReclamacaoViewModel();
            var reclamacao = await _context.Reclamacao.Include(p => p.Feedback)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ReclamacaoId == id);

            RVM.ReclamacaoId = reclamacao.ReclamacaoId;
            RVM.ContratoId = reclamacao.ContratoId;
            RVM.NomeCliente = reclamacao.NomeCliente;
            RVM.FuncionarioId = reclamacao.FuncionarioId;
            RVM.Assunto = reclamacao.Assunto;
            RVM.Descricao = reclamacao.Descricao;
            RVM.ResolvidoOperador = reclamacao.ResolvidoOperador;
            RVM.ResolvidoCliente = reclamacao.ResolvidoCliente;
            RVM.DataReclamacao = reclamacao.DataReclamacao;

            //var fb = await _context.Feedback
            //    .FirstOrDefaultAsync(x => x.ReclamacaoId == reclamacao.ReclamacaoId);

            //RVM.Mensagem = fb.Mensagem;
            //RVM.DataFeedback = DateTime.Now;

            if (reclamacao == null)
            {
                return NotFound();
            }
            ViewData["ContartoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", RVM.ContratoId);
            return View(RVM);
        }

        // POST: Reclamacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReclamacaoViewModel RVM, Feedback feedback)
        {
            if (id != RVM.ReclamacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var reclamacao = await _context.Reclamacao
                        .AsNoTracking()
                        .Include(r => r.Contratos)
                        .Include(r => r.Feedback)
                        .FirstOrDefaultAsync(m => m.ReclamacaoId == id);

                    var funcionario = await _context.Users.SingleOrDefaultAsync(c => c.Email == User.Identity.Name);

                    reclamacao.ReclamacaoId = RVM.ReclamacaoId;
                    reclamacao.ContratoId = RVM.ContratoId;
                    reclamacao.NomeCliente = RVM.NomeCliente;
                    reclamacao.FuncionarioId = funcionario.UsersId;
                    reclamacao.Assunto = RVM.Assunto;
                    reclamacao.Descricao = RVM.Descricao;
                    reclamacao.ResolvidoOperador = RVM.ResolvidoOperador;
                    reclamacao.ResolvidoCliente = RVM.ResolvidoCliente;
                    reclamacao.DataReclamacao = RVM.DataReclamacao;

                    _context.Reclamacao.Update(reclamacao);
                    await _context.SaveChangesAsync();

                    feedback.FuncionarioId = funcionario.UsersId;
                    feedback.DataFeedback = DateTime.Now;

                    _context.Feedback.Add(feedback);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclamacaoExists(RVM.ReclamacaoId))
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
            return View(RVM);
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
