using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _gestorUtilizadores;

        public ReclamacaoController(UPtelContext context, UserManager<IdentityUser> gestorUtilizadores)
        {
            _context = context;
            _gestorUtilizadores = gestorUtilizadores;
        }

        // GET: Reclamacao
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Reclamacao.Include(p => p.Cliente).Where(p => nomePesquisar == null || p.Cliente.Nome.Contains(nomePesquisar) || p.Cliente.Contribuinte.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Reclamacao> reclamacoes = await _context.Reclamacao.Include(p => p.Cliente).Where(p => nomePesquisar == null || p.Cliente.Nome.Contains(nomePesquisar) || p.Cliente.Contribuinte.Contains(nomePesquisar))
                .OrderBy(c => c.Cliente.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                Reclamacoes = reclamacoes,
                NomePesquisar = nomePesquisar
            };


            return base.View(modelo);
        }

        // GET: Reclamacao/Details/5
        [Authorize(Roles = "Operador , Cliente")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamacao
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.ReclamacaoId == id);
            if (reclamacao == null)
            {
                return NotFound();
            }

            return View(reclamacao);
        }

        // GET: Reclamacao/Create
        [Authorize(Roles = "Cliente")]
        public IActionResult Create()
        {
            var userEmail = _gestorUtilizadores.GetUserName(HttpContext.User);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "UsersId");

            List<Reclamacao> listaReclamacoes = _context.Reclamacao.Include(c => c.Cliente).Where(c => c.Cliente.Email == userEmail).ToList();

            Reclamacao reclamacao = new Reclamacao();
            reclamacao.ReclamacoesCliente = listaReclamacoes;

            return View(reclamacao);
        }

        // POST: Reclamacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> Create([Bind("ReclamacaoId,UsersId,Assunto,Descriçao,NomeCliente,Resolvido")] Reclamacao reclamacao)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);
                reclamacao.UsersId = user.UsersId;
                reclamacao.NomeCliente = user.Nome;
                reclamacao.Resolvido = false;

                _context.Add(reclamacao);
                await _context.SaveChangesAsync();
                return RedirectToAction("ConfirmacaoReclamacao", "ClientesViewModel");
            }
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Nome", reclamacao.UsersId);
            
            return RedirectToAction("ConfirmacaoReclamacao", "ClientesViewModel");
        }

        // GET: Reclamacao/Edit/5
        [Authorize(Roles = "Operador")]
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
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Nome", reclamacao.UsersId);
            return View(reclamacao);
        }

        // POST: Reclamacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Edit(int id, [Bind("ReclamacaoId,UsersId,Assunto,Descriçao,NomeCliente,Resolvido")] Reclamacao reclamacao)
        {
            if (id != reclamacao.ReclamacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Reclamacao.Update(reclamacao);
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
                return RedirectToAction("Details" ,new {id = id });
            }
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Nome", reclamacao.UsersId);
            return View(reclamacao);
        }

        // GET: Reclamacao/Delete/5
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamacao
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.ReclamacaoId == id);
            if (reclamacao == null)
            {
                return NotFound();
            }

            return View(reclamacao);
        }

        // POST: Reclamacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operador")]
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

        // GET: Reclamacao/Feedback/5
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> Feedback(int? id)
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
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Nome", reclamacao.UsersId);
            return View(reclamacao);
        }

        // POST: Reclamacao/Feedback/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> Feedback(int id, [Bind("ReclamacaoId,UsersId,Assunto,Descriçao,NomeCliente,Resolvido,FeedbackDescricao")] Reclamacao reclamacao)
        {
            if (id != reclamacao.ReclamacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Reclamacao rec = new Reclamacao();

                    //List<Reclamacao> listaReclamacoes = new List<Reclamacao>();
                    //rec.FeedbackData = DateTime.Now;
                    //rec.FeedbackDescricao = reclamacao.FeedbackDescricao;

                    //rec.Assunto = reclamacao.Assunto;
                    //rec.Cliente = reclamacao.Cliente;
                    //rec.Descriçao = reclamacao.Descriçao;
                    //rec.FeedbackCliente = reclamacao.FeedbackCliente;
                    //rec.NomeCliente = reclamacao.NomeCliente;
                    ////rec.ReclamacaoId = reclamacao.ReclamacaoId;
                    //rec.Resolvido = reclamacao.Resolvido;
                    //rec.UsersId = reclamacao.UsersId;

                    //listaReclamacoes.Add(rec);

                    //reclamacao.ReclamacoesCliente = listaReclamacoes;

                    reclamacao.FeedbackData = DateTime.Now;
                    _context.Reclamacao.Update(reclamacao);
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
                return RedirectToAction("Details", new { id = id });
            }
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Nome", reclamacao.UsersId);
            return View(reclamacao);
        }
    }
}
