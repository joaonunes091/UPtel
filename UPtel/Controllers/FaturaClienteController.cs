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
    public class FaturaClienteController : Controller
    {
        private readonly UPtelContext _context;

        public FaturaClienteController(UPtelContext context)
        {
            _context = context;
        }

        // GET: FaturaCliente
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {

            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Faturas.Where(p => nomePesquisar == null || p.NomeCliente.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<FaturaCliente> faturaClientes = await _context.Faturas.Where(p => nomePesquisar == null || p.NomeCliente.Contains(nomePesquisar))
                .OrderBy(c => c.NomeCliente)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                FaturaClientes = faturaClientes,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }

        //Pesquisa nome cliente para adicionar uma fatura
        public async Task<IActionResult> SelectUser(string nomePesquisar)
        {
            List<Users> users = await _context.Users.Where(p => p.Tipo.Tipo.Contains("Cliente") && p.Nome.Contains(nomePesquisar) || p.Contribuinte.Contains(nomePesquisar))
                .Include(t =>t.Tipo)
                .OrderBy(c => c.Nome)
                .OrderBy(c => c.Contribuinte)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Users = users,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }

        //adicionar contrato depois de escolhido o cliente

        public async Task<IActionResult> SelectContrato(int id)
        {
            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var cliente = _context.Users.SingleOrDefault(m => m.UsersId == id);


            List<Contratos> contratos = await _context.Contratos.Where(m => m.ClienteId == id)
               .OrderBy(c => c.MoradaContrato)
               .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Contratos = contratos,
                
            };

            if (cliente == null)
            {
                return NotFound();
            }

            return View(modelo);

        }


        // GET: FaturaCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FaturaViewModel FVM = new FaturaViewModel();

           
            var faturaCliente = await _context.Faturas
                .Include(f => f.Fatura)                
                .FirstOrDefaultAsync(m => m.NrFaturaId == id);

            var pacote = await _context.Pacotes
                .SingleOrDefaultAsync(p => p.PacoteId == faturaCliente.PacoteId);

            FVM.NrFaturaId = (int) id;
            FVM.DataEmissao = faturaCliente.DataEmissao;
            FVM.ContratoId = faturaCliente.ContratoId;
            FVM.NomeCliente = faturaCliente.NomeCliente;
            FVM.Morada = faturaCliente.Morada;
            FVM.PrecoContrato = faturaCliente.PrecoContrato;
            FVM.NomePacote = pacote.NomePacote;
            FVM.PacoteId = pacote.PacoteId;
            FVM.Descricao = faturaCliente.Descricao;

            if (faturaCliente == null)
            {
                return NotFound();
            }

            return View(FVM);
        }

        // GET: FaturaCliente/Create
        public IActionResult Create()
        {
            
           

            return View();
        }

        // POST: FaturaCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[Bind("NrFaturaId,DataEmissao,ContratoId,Morada,NomeCliente,PacoteId,PrecoContrato,Descricao")] FaturaCliente faturaCliente)
        {
         
            //Código que vai buscar o ID do contrato atraves do contrato selecionado na vista SelectContrato
            var contrato = _context.Contratos.SingleOrDefault(m => m.ContratoId == id);
            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var cliente = _context.Users.SingleOrDefault(m => m.UsersId == contrato.ClienteId);

            faturaCliente.ContratoId = contrato.ContratoId;
            faturaCliente.NomeCliente = cliente.Nome;
            faturaCliente.Morada = contrato.MoradaContrato; 
            faturaCliente.PrecoContrato = contrato.PrecoContrato; 
            faturaCliente.PacoteId = contrato.PacoteId;

            if (faturaCliente.DataEmissao > DateTime.Today || faturaCliente.DataEmissao < DateTime.Today.AddDays(-90))
            {
                ModelState.AddModelError("DataEmissao", "A data da fatura não pode ultrapassar os 90 dias anteriores");
            }


            if (ModelState.IsValid)
            {
                _context.Add(faturaCliente);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Fatura criada com sucesso";
                return View("Sucesso");
            }
            
            return View(faturaCliente);
        }

        // GET: FaturaCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FaturaViewModel FVM = new FaturaViewModel();

            //var faturaCliente = await _context.Faturas.FindAsync(id);
            var faturaCliente = await _context.Faturas
                .Include(f => f.Fatura)
                .FirstOrDefaultAsync(m => m.NrFaturaId == id);

            var pacote = await _context.Pacotes
                .SingleOrDefaultAsync(p => p.PacoteId == faturaCliente.PacoteId);

            FVM.DataEmissao = faturaCliente.DataEmissao;
            FVM.ContratoId = faturaCliente.ContratoId;
            FVM.NomeCliente = faturaCliente.NomeCliente;
            FVM.Morada = faturaCliente.Morada;
            FVM.PrecoContrato = faturaCliente.PrecoContrato;
            FVM.NomePacote = pacote.NomePacote;
            FVM.Descricao = faturaCliente.Descricao;
            FVM.PacoteId = faturaCliente.PacoteId;


            
            if (faturaCliente == null)
            {
                return NotFound();
            }
            return View(FVM);
        }

        // POST: FaturaCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FaturaViewModel FVM, FaturaCliente faturaCliente)
        {

            var fatura = await _context.Faturas
                .Include(f => f.Fatura)
                .FirstOrDefaultAsync(m => m.NrFaturaId == id);

            var pacote = await _context.Pacotes
                .SingleOrDefaultAsync(p => p.PacoteId == fatura.PacoteId);

            fatura.DataEmissao = FVM.DataEmissao;
            fatura.Descricao = FVM.Descricao;
            fatura.NomeCliente = FVM.NomeCliente;
            fatura.ContratoId = FVM.ContratoId;
            fatura.Morada = FVM.Morada;
            fatura.PrecoContrato = FVM.PrecoContrato;
            fatura.PacoteId = FVM.PacoteId;
            FVM.NomePacote = pacote.NomePacote;

            if (faturaCliente.DataEmissao > DateTime.Today || faturaCliente.DataEmissao < DateTime.Today.AddDays(-90))
            {
                ModelState.AddModelError("DataEmissao", "A data da fatura não pode ultrapassar os 90 dias anteriores");
            }

            _context.Update(fatura);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "Fatura editada com sucesso";
            return View("Sucesso");
        }
          

        // GET: FaturaCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faturaCliente = await _context.Faturas
                .Include(f => f.Fatura)
                .FirstOrDefaultAsync(m => m.NrFaturaId == id);
            if (faturaCliente == null)
            {
                return NotFound();
            }
            return View(faturaCliente);
        }

        // POST: FaturaCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faturaCliente = await _context.Faturas.FindAsync(id);
            _context.Faturas.Remove(faturaCliente);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "Fatura apagada com sucesso";
            return View("Sucesso");
        }

        private bool FaturaClienteExists(int id)
        {
            return _context.Faturas.Any(e => e.NrFaturaId == id);
        }
        
    }
}
