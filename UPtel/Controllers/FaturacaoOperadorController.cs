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
    public class FaturacaoOperadorController : Controller
    {
        private readonly UPtelContext _context;

        public FaturacaoOperadorController(UPtelContext context)
        {
            _context = context;
        }

        // GET: FaturacaoOperador
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.FaturacaoOperadors.Where(p => nomePesquisar== null || p.Mes.Mes.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<FaturacaoOperador> fat = await _context.FaturacaoOperadors.Where(p => nomePesquisar == null || p.Mes.Mes.Contains(nomePesquisar))
                .Include(p => p.Mes)
                .OrderBy(c => c.Data)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                FaturacaoOperadores = fat,
                NomePesquisar = nomePesquisar
            };

            


            //Código que vai buscar o ID do funcionário que tem login feito e atribui automaticamente ao contrato
            var funcionario = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);


            var uPtelContext = _context.FaturacaoOperadors.Where(f => f.FuncinarioId == funcionario.UsersId)
                .Include(f => f.Mes)
                .OrderBy(d => d.MesId);

            return base.View(modelo);
            //return View(await uPtelContext.ToListAsync());
        }

        //Escolha de mês para ver a faturação
        public IActionResult Contabilizar(FaturacaoOperador faturacao)
        {

            MonthlySum(faturacao);

            return RedirectToAction("Index", "OperadorViewModel");
        }

        public async Task<IActionResult> Contratos(Contratos contratos, string nomePesquisar, int pagina = 1) 
        {
            var funcionario = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);

            Paginacao paginacao = new Paginacao
            {
                
                PaginaAtual = pagina
            };

            List<Contratos> contrato = await _context.Contratos.Where(x => x.FuncionarioId == funcionario.UsersId)
                .Include(c=>c.Cliente)
                .OrderByDescending(c=>c.DataInicio)
                .ToListAsync();
            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Contratos = contrato,
                Paginacao = paginacao,
            };


            //return RedirectToAction("Contratos");
            return base.View(modelo);
        }

       


        //OUTRAS FUNÇÕES
        public void MonthlySum(FaturacaoOperador faturacao)
        {


            //Código que vai buscar o ID do funcionário que tem login feito e atribui automaticamente ao contrato
            var funcionario = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);

            //DateTime data = DateTime.Today.AddMonths(-1);
            //DateTime dia = DateTime.Today;
            DateTime data = DateTime.Today.AddMonths(-1);
            var FisrtDayMonth = new DateTime(data.Year, data.Month, 1);
            var LastDayMonth = FisrtDayMonth.AddMonths(1).AddMinutes(-1);
            DateTime dia = DateTime.Today;
            var dia1 = new DateTime(dia.Year, dia.Month, 1);
            DateTime finaldia = dia1.AddMonths(1).AddMinutes(-1);
            var fat = _context.FaturacaoOperadors.Where(d => d.Data >= dia1 && d.Data <= finaldia && d.FuncinarioId == funcionario.UsersId)
                .SingleOrDefault(c => c.Mes.MesId == data.Month);

            if (fat == null)
            {

                var contratos = _context.Contratos.Where(d => d.DataInicio >= FisrtDayMonth && d.DataInicio <= LastDayMonth && d.FuncionarioId == funcionario.UsersId)
               .Include(d => d.Funcionario)
               .Sum(d => d.PrecoContrato);

                faturacao.Data = DateTime.Today;
                faturacao.FuncinarioId = funcionario.UsersId;
                faturacao.MesId = data.Month;
                faturacao.ValorMensalFat = contratos;

                _context.Add(faturacao);
                _context.SaveChanges();
            }
            return;
        }

        // GET: FaturacaoOperador/Details/5
        [Authorize(Roles ="Operador, Administrador")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faturacaoOperador = await _context.FaturacaoOperadors
                .Include(f => f.Mes)
                .FirstOrDefaultAsync(m => m.FatOpId == id);
            if (faturacaoOperador == null)
            {
                return NotFound();
            }

            return View(faturacaoOperador);
        }

        // GET: FaturacaoOperador/Create
        [Authorize(Roles = " Administrador")]
        public IActionResult Create()
        {
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "MesId");
            return View();
        }

        // POST: FaturacaoOperador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = " Administrador")]
        public async Task<IActionResult> Create([Bind("FatOpId,Data,valorMensalFat,MesId,FuncinarioId")] FaturacaoOperador faturacaoOperador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faturacaoOperador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "MesId", faturacaoOperador.MesId);
            return View(faturacaoOperador);
        }

        // GET: FaturacaoOperador/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faturacaoOperador = await _context.FaturacaoOperadors.FindAsync(id);
            if (faturacaoOperador == null)
            {
                return NotFound();
            }
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "MesId", faturacaoOperador.MesId);
            return View(faturacaoOperador);
        }

        // POST: FaturacaoOperador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = " Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("FatOpId,Data,valorMensalFat,MesId,FuncinarioId")] FaturacaoOperador faturacaoOperador)
        {
            if (id != faturacaoOperador.FatOpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faturacaoOperador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaturacaoOperadorExists(faturacaoOperador.FatOpId))
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
            ViewData["MesId"] = new SelectList(_context.Meses, "MesId", "MesId", faturacaoOperador.MesId);
            return View(faturacaoOperador);
        }

        // GET: FaturacaoOperador/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faturacaoOperador = await _context.FaturacaoOperadors
                .Include(f => f.Mes)
                .FirstOrDefaultAsync(m => m.FatOpId == id);
            if (faturacaoOperador == null)
            {
                return NotFound();
            }

            return View(faturacaoOperador);
        }

        // POST: FaturacaoOperador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faturacaoOperador = await _context.FaturacaoOperadors.FindAsync(id);
            _context.FaturacaoOperadors.Remove(faturacaoOperador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaturacaoOperadorExists(int id)
        {
            return _context.FaturacaoOperadors.Any(e => e.FatOpId == id);
        }
    }
}
