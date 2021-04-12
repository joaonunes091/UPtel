using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UPtel.Data;
using UPtel.Models;
using UPtel.Services;

namespace UPtel.Controllers
{
    public class ReclamacaoController : Controller
    {
        private readonly UPtelContext _context;
        private readonly IEmailSender _emailSender;

        public ReclamacaoController(IEmailSender emailSender, IWebHostEnvironment env, UPtelContext context)
        {
            _emailSender = emailSender;
            _context = context;
        }

        // GET: Reclamacao/Index
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {

            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Reclamacao.Include(p => p.Contratos.Cliente).Where(p => nomePesquisar == null || p.NomeCliente.Contains(nomePesquisar) || p.Contratos.Cliente.Contribuinte.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Reclamacao> reclamacoes = await _context.Reclamacao.Include(p => p.Contratos.Cliente).Where(p => nomePesquisar == null || p.NomeCliente.Contains(nomePesquisar) || p.Contratos.Cliente.Contribuinte.Contains(nomePesquisar))
                .OrderByDescending(c => c.DataReclamacao)
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

        // GET: Reclamacao/Index
        public async Task<IActionResult> IndexCliente()
        {
            var cliente = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);


            var uPtelContext = _context.Reclamacao.Include(r => r.Contratos).Where(x => x.NomeCliente == cliente.Nome);

            return View(await uPtelContext.ToListAsync());
        }

        // GET: Reclamacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ReclamacaoViewModel RVM = new ReclamacaoViewModel();

            var reclamacao = await _context.Reclamacao
                        .AsNoTracking()
                        .Include(r => r.Contratos)
                        .Include(r => r.Feedback)
                        .FirstOrDefaultAsync(m => m.ReclamacaoId == id);


            RVM.ContratoId = reclamacao.ContratoId;
            RVM.NomeCliente = reclamacao.NomeCliente;
            RVM.FuncionarioId = reclamacao.FuncionarioId;
            RVM.Assunto = reclamacao.Assunto;
            RVM.Descricao = reclamacao.Descricao;
            RVM.ResolvidoOperador = reclamacao.ResolvidoOperador;
            RVM.ResolvidoCliente = reclamacao.ResolvidoCliente;
            RVM.DataReclamacao = reclamacao.DataReclamacao;
            RVM.ListaMensagens = reclamacao.Feedback;

            return View(RVM);
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
                reclamacao.PorResoponder = true;
                reclamacao.DataReclamacao = DateTime.Now;
                reclamacao.Assunto = RVM.Assunto;
                reclamacao.Descricao = RVM.Descricao;
                reclamacao.ReclamacaoId = RVM.ReclamacaoId;

                _context.Add(reclamacao);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Reclamação enviada com sucesso";
                return View("SucessoReclamacao");
            }

            ModelState.AddModelError("", "Não foi possível registar a reclamação, tente novamente");

            return View(reclamacao);
        }

        // GET: Reclamacao/RespostaReclamacaoOperador/5
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> RespostaReclamacaoOperador(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
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

            var feedback = await _context.Feedback.FirstOrDefaultAsync(x => x.ReclamacaoId == reclamacao.ReclamacaoId);
            var funcionario = await _context.Users.SingleOrDefaultAsync(c => c.Email == User.Identity.Name);
          
            if (feedback != null)
            { 
            RVM.FuncionarioId = feedback.FuncionarioId;
            RVM.Mensagem = feedback.Mensagem;
            RVM.DataFeedback = feedback.DataFeedback;
            }

            if (reclamacao == null)
            {
                return NotFound();
            }
            ViewData["ContartoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", RVM.ContratoId);
            return View(RVM);
        }

        // POST: Reclamacao/RespostaReclamacaoOperador/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> RespostaReclamacaoOperador(int id, ReclamacaoViewModel RVM, Feedback feedback)
        {
            if (id != RVM.ReclamacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var reclamacao = await _context.Reclamacao.Include(p => p.Feedback)
                        .AsNoTracking()
                        .SingleOrDefaultAsync(p => p.ReclamacaoId == id);

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
                    reclamacao.PorResoponder = false;

                    var contrato = await _context.Contratos.SingleOrDefaultAsync(c => c.ContratoId == reclamacao.ContratoId);
                    var cliente = await _context.Users.SingleOrDefaultAsync(c => c.UsersId == contrato.ClienteId);

                    string email; string assunto; string mensagem;
                    assunto = "UPtel - Reclamação de " + reclamacao.NomeCliente;
                    mensagem = "Caro/a " + reclamacao.NomeCliente + ", informamos que o nosso operador " + funcionario.Nome + " respondeu à sua reclamação";
                    email = cliente.Email;

                    _context.Reclamacao.Update(reclamacao);
                    await _context.SaveChangesAsync();

                    feedback.FuncionarioId = funcionario.UsersId;
                    feedback.DataFeedback = DateTime.Now;
                    feedback.Mensagem = RVM.Mensagem;
                    feedback.Nome = funcionario.Nome;

                    _context.Feedback.Add(feedback);
                    await _context.SaveChangesAsync();

                    try
                    {
                        await _emailSender.SendEmailAsync(email, assunto, mensagem);
                    }
                    catch (Exception)
                    {
                        return RedirectToAction("RespostaReclamacaoOperador");
                    }

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

        // GET: Reclamacao/FeedbackCliente/5
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> FeedbackCliente(int? id)
        {
            ReclamacaoViewModel RVM = new ReclamacaoViewModel();

            var reclamacao = await _context.Reclamacao
                        .AsNoTracking()
                        .Include(r => r.Contratos)
                        .Include(r => r.Feedback)
                        .FirstOrDefaultAsync(m => m.ReclamacaoId == id);


            RVM.ContratoId = reclamacao.ContratoId;
            RVM.NomeCliente = reclamacao.NomeCliente;
            RVM.FuncionarioId = reclamacao.FuncionarioId;
            RVM.Assunto = reclamacao.Assunto;
            RVM.Descricao = reclamacao.Descricao;
            RVM.ResolvidoOperador = reclamacao.ResolvidoOperador;
            RVM.ResolvidoCliente = reclamacao.ResolvidoCliente;
            RVM.DataReclamacao = reclamacao.DataReclamacao;
            RVM.ListaMensagens = reclamacao.Feedback;

            return View(RVM);
            
        }

        // POST: Reclamacao/FeedbackCliente/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> FeedbackCliente(ReclamacaoViewModel RVM,Feedback feedback, int id)
        {
            if (ModelState.IsValid)
            {
                var reclamacao = await _context.Reclamacao
                        .Include(p => p.Feedback)
                        .AsNoTracking()
                        .SingleOrDefaultAsync(p => p.ReclamacaoId == id);
                var cliente = await _context.Users.SingleOrDefaultAsync(c => c.Email == User.Identity.Name);

                reclamacao.ContratoId = RVM.ContratoId;
                reclamacao.NomeCliente = RVM.NomeCliente;
                reclamacao.FuncionarioId = reclamacao.FuncionarioId;
                reclamacao.Assunto = RVM.Assunto;
                reclamacao.Descricao = RVM.Descricao;
                reclamacao.ResolvidoOperador = reclamacao.ResolvidoOperador;
                reclamacao.ResolvidoCliente = RVM.ResolvidoCliente;
                reclamacao.DataReclamacao = RVM.DataReclamacao;
                reclamacao.PorResoponder = true;

                _context.Reclamacao.Update(reclamacao);
                await _context.SaveChangesAsync();

                feedback.FuncionarioId = reclamacao.FuncionarioId;
                feedback.DataFeedback = DateTime.Now;
                feedback.Mensagem = RVM.Mensagem;
                feedback.ReclamacaoId = id;
                feedback.Nome = cliente.Nome;

                _context.Feedback.Add(feedback);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Feedback enviado com sucesso";
                return View("SucessoFeedback");
            }

            ModelState.AddModelError("", "Não foi possível registar a reclamação, tente novamente");

            return View(RVM);
        }

        // GET: Reclamacao/RespostaFeedback/5
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> RespostaFeedback(int? id)
        {
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
            RVM.ListaMensagens = reclamacao.Feedback;

            return View(RVM);

        }

        // POST: Reclamacao/RespostaFeedback/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> RespostaFeedback(ReclamacaoViewModel RVM, Feedback feedback, int id)
        {
            if (ModelState.IsValid)
            {
                var reclamacao = await _context.Reclamacao.Include(p => p.Feedback)
                        .AsNoTracking()
                        .SingleOrDefaultAsync(p => p.ReclamacaoId == id);

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
                reclamacao.PorResoponder = false;

                var contrato = await _context.Contratos.SingleOrDefaultAsync(c => c.ContratoId == reclamacao.ContratoId);
                var cliente = await _context.Users.SingleOrDefaultAsync(c => c.UsersId == contrato.ClienteId);

                string email; string assunto; string mensagem;
                assunto = "UPtel - Resposta ao feedback de " + reclamacao.NomeCliente;
                mensagem = "Caro/a " + reclamacao.NomeCliente + ", informamos que o nosso operador " + funcionario.Nome + " respondeu ao seu feedback";
                email = cliente.Email;

                _context.Reclamacao.Update(reclamacao);
                await _context.SaveChangesAsync();

                feedback.FuncionarioId = funcionario.UsersId;
                feedback.DataFeedback = DateTime.Now;
                feedback.Mensagem = RVM.Mensagem;
                feedback.Nome = funcionario.Nome;

                _context.Feedback.Add(feedback);
                await _context.SaveChangesAsync();

                try
                {
                    await _emailSender.SendEmailAsync(email, assunto, mensagem);
                }
                catch (Exception)
                {
                    return RedirectToAction("RespostaFeedback");
                }

                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Não foi possível registar a reclamação, tente novamente");

            return View(RVM);
        }

        // GET: Reclamacao/Delete/5
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var reclamacao = await _context.Reclamacao
            //    .Include(r => r.Contratos)
            //    .FirstOrDefaultAsync(m => m.ReclamacaoId == id);
            //if (reclamacao == null)
            //{
            //    ViewBag.Mensagem = "O cliente já foi eliminado por outra pessoa.";
            //    return View("Sucesso");
            //}

            //return View(reclamacao);

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
            RVM.ListaMensagens = reclamacao.Feedback;

            return View(RVM);
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
    }
}
