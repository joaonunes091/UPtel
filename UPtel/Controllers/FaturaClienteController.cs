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

        // GET: FaturaCliente/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: FaturaCliente/Create
        public IActionResult Create(int? id)
        {
            ViewData["ContratoId"] = new SelectList(_context.Contratos.Where(x =>x.ContratoId == id), "ContratoId", "ContratoId");
            ViewData["Morada"] = new SelectList(_context.Contratos.Where(x => x.ContratoId == id), "ContratoId", "MoradaContrato");
       
            return View();
        }

        // POST: FaturaCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[Bind("NrFaturaId,DataEmissao,ContratoId,Morada,NomeCliente,PacoteId,PrecoContrato,Descricao")] FaturaCliente faturaCliente)
        {
            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var cliente = _context.Users.SingleOrDefault(m => m.UsersId == id);
            var contrato = _context.Contratos.SingleOrDefault(c => c.ContratoId == id);
                
            faturaCliente.NomeCliente = cliente.Nome;
            faturaCliente.PrecoContrato = contrato.PrecoContrato;
            faturaCliente.PacoteId = contrato.PacoteId;
            faturaCliente.Morada = contrato.MoradaContrato;
           
            if (ModelState.IsValid)
            {
                _context.Add(faturaCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos.Where(x => x.ContratoId == id), "ContratoId", "ContratoId");
            ViewData["Morada"] = new SelectList(_context.Contratos.Where(x => x.ContratoId == id), "ContratoId", "MoradaContrato");
            return View(faturaCliente);
        }

        // GET: FaturaCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faturaCliente = await _context.Faturas.FindAsync(id);
            if (faturaCliente == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "CodigoPostalCont", faturaCliente.ContratoId);
            return View(faturaCliente);
        }

        // POST: FaturaCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NrFaturaId,DataEmissao,ContratoId,Morada,NomeCliente,PacoteId,PrecoContrato,Descricao")] FaturaCliente faturaCliente)
        {
            if (id != faturaCliente.NrFaturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faturaCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaturaClienteExists(faturaCliente.NrFaturaId))
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
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "CodigoPostalCont", faturaCliente.ContratoId);
            return View(faturaCliente);
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
            return RedirectToAction(nameof(Index));
        }

        private bool FaturaClienteExists(int id)
        {
            return _context.Faturas.Any(e => e.NrFaturaId == id);
        }
    }
}
