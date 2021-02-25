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
    public class ContratosController : Controller
    {
        private readonly UPtelContext _context;

        public ContratosController(UPtelContext context)
        {
            _context = context;
        }

        // GET: Contratos
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Contratos.Include(p => p.Cliente).Where(p => nomePesquisar == null || p.Cliente.Nome.Contains(nomePesquisar) || p.Cliente.Contribuinte.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Contratos> contratos = await _context.Contratos.Include(p => p.Cliente).Where(p => nomePesquisar == null || p.Cliente.Nome.Contains(nomePesquisar) || p.Cliente.Contribuinte.Contains(nomePesquisar))
                .OrderBy(c => c.Cliente.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                Contratos = contratos,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }

        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await _context.Contratos
                .Include(c => c.Cliente)
                .Include(c => c.Funcionario)
                .Include(c => c.Pacote)
                .Include(c => c.Promocao)
                .FirstOrDefaultAsync(m => m.ContratoId == id);
            if (contratos == null)
            {
                return NotFound();
            }

            return View(contratos);
        }

        // GET: Contratos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Users, "UsersId", "Nome");
            ViewData["FuncionarioId"] = new SelectList(_context.Users, "UsersId", "Nome");
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote");
            ViewData["PromocaoId"] = new SelectList(_context.Promocoes, "PromocaoId", "Descricao");
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratoId,ClienteId,FuncionarioId,PromocaoId,PacoteId,DataInicio,Fidelizacao,TempoPromocao,PrecoContrato")] Contratos contratos)
        {
         

            
            //Código que vai buscar o preço do pacote
            var pacote = _context.Pacotes.SingleOrDefault(p => p.PacoteId == contratos.PacoteId);
            contratos.PrecoContrato = pacote.PrecoTotal;

            //Código que vai buscar o desconto da promoção
            var promocaopacoteid = _context.Promocoes.SingleOrDefault(e => e.PromocaoId == contratos.PromocaoId);
            var promocaoid = _context.Promocoes.SingleOrDefault(p => p.PromocaoId == promocaopacoteid.PromocaoId);
            contratos.PromocaoId = promocaoid.PromocaoId;

            //Cálculo do PrecoFinal
            contratos.PrecoContrato -= (contratos.PrecoContrato * (promocaoid.Desconto / 100));

            _context.Add(contratos);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "Contrato adicionado com sucesso";
           
            

            ViewData["ClienteId"] = new SelectList(_context.Users, "UsersId", "Nome", contratos.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Users, "UsersId", "Nome", contratos.FuncionarioId);
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratos.PacoteId);
            ViewData["PromocaoId"] = new SelectList(_context.Promocoes, "PromocaoId", "Descricao", contratos.PromocaoId);

            return View("Sucesso");

        }

        // GET: Contratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await _context.Contratos.FindAsync(id);
            if (contratos == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente o contrato já foi eliminado.";
                return View("Erro");
            }
            ViewData["ClienteId"] = new SelectList(_context.Users, "UsersId", "Nome", contratos.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Users, "UsersId", "Nome", contratos.FuncionarioId);
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratos.PacoteId);
            ViewData["PromocaoId"] = new SelectList(_context.Promocoes, "PromocaoId", "Descricao", contratos.PromocaoId);
            return View(contratos);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratoId,ClienteId,FuncionarioId,PromocaoId,PacoteId,DataInicio,Fidelizacao,TempoPromocao,PrecoContrato")] Contratos contratos)
        {
            if (id != contratos.ContratoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratosExists(contratos.ContratoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Contrato alterado com sucesso";
                return View("Sucesso");
            }
            ViewData["ClienteId"] = new SelectList(_context.Users, "UsersId", "Nome", contratos.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Users, "UsersId", "Nome", contratos.FuncionarioId);
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratos.PacoteId);
            ViewData["PromocaoId"] = new SelectList(_context.Promocoes, "PromocaoId", "Descricao", contratos.PromocaoId);
            return View(contratos);
        }

        // GET: Contratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await _context.Contratos
                .Include(c => c.Cliente)
                .Include(c => c.Funcionario)
                .Include(c => c.Pacote)
                .Include(c => c.Promocao)
                .FirstOrDefaultAsync(m => m.ContratoId == id);
            if (contratos == null)
            {
                ViewBag.Mensagem = "O contrato já foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(contratos);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratos = await _context.Contratos.FindAsync(id);
            _context.Contratos.Remove(contratos);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "O contrato foi eliminado com sucesso.";
            return View("Sucesso");
        }

        private bool ContratosExists(int id)
        {
            return _context.Contratos.Any(e => e.ContratoId == id);
        }
    }
}
