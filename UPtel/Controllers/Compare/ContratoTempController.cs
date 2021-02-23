//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Uptel1.Data;
//using Uptel1.Models;

//namespace Uptel1.Controllers
//{
//    public class ContratoTempController : Controller
//    {
//        private readonly UPtel1Context _context;

//        public ContratoTempController(UPtel1Context context)
//        {
//            _context = context;
//        }

//        // GET: ContratoTemp
//        public async Task<IActionResult> Index()
//        {
//            var uPtel1Context = _context.Contratos.Include(c => c.Cliente).Include(c => c.Funcionario).Include(c => c.Pacote).Include(c => c.Promocao);
//            return View(await uPtel1Context.ToListAsync());
//        }

//        // GET: ContratoTemp/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var contratos = await _context.Contratos
//                .Include(c => c.Cliente)
//                .Include(c => c.Funcionario)
//                .Include(c => c.Pacote)
//                .Include(c => c.Promocao)
//                .FirstOrDefaultAsync(m => m.ContratoId == id);
//            if (contratos == null)
//            {
//                return NotFound();
//            }

//            return View(contratos);
//        }

//        // GET: ContratoTemp/Create
//        public IActionResult Create()
//        {
//            ViewData["ClienteId"] = new SelectList(_context.Users, "UsersId", "CartaoCidadao");
//            ViewData["FuncionarioId"] = new SelectList(_context.Users, "UsersId", "CartaoCidadao");
//            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote");
//            ViewData["PromocaoId"] = new SelectList(_context.Promocoes, "PromocaoId", "Descricao");
//            return View();
//        }

//        // POST: ContratoTemp/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ContratoId,ClienteId,FuncionarioId,PromocaoId,PacoteId,DataInicio,Fidelizacao,TempoPromocao,PrecoContrato")] Contratos contratos)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(contratos);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ClienteId"] = new SelectList(_context.Users, "UsersId", "CartaoCidadao", contratos.ClienteId);
//            ViewData["FuncionarioId"] = new SelectList(_context.Users, "UsersId", "CartaoCidadao", contratos.FuncionarioId);
//            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratos.PacoteId);
//            ViewData["PromocaoId"] = new SelectList(_context.Promocoes, "PromocaoId", "Descricao", contratos.PromocaoId);
//            return View(contratos);
//        }

//        // GET: ContratoTemp/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var contratos = await _context.Contratos.FindAsync(id);
//            if (contratos == null)
//            {
//                return NotFound();
//            }
//            ViewData["ClienteId"] = new SelectList(_context.Users, "UsersId", "CartaoCidadao", contratos.ClienteId);
//            ViewData["FuncionarioId"] = new SelectList(_context.Users, "UsersId", "CartaoCidadao", contratos.FuncionarioId);
//            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratos.PacoteId);
//            ViewData["PromocaoId"] = new SelectList(_context.Promocoes, "PromocaoId", "Descricao", contratos.PromocaoId);
//            return View(contratos);
//        }

//        // POST: ContratoTemp/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ContratoId,ClienteId,FuncionarioId,PromocaoId,PacoteId,DataInicio,Fidelizacao,TempoPromocao,PrecoContrato")] Contratos contratos)
//        {
//            if (id != contratos.ContratoId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(contratos);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ContratosExists(contratos.ContratoId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ClienteId"] = new SelectList(_context.Users, "UsersId", "CartaoCidadao", contratos.ClienteId);
//            ViewData["FuncionarioId"] = new SelectList(_context.Users, "UsersId", "CartaoCidadao", contratos.FuncionarioId);
//            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratos.PacoteId);
//            ViewData["PromocaoId"] = new SelectList(_context.Promocoes, "PromocaoId", "Descricao", contratos.PromocaoId);
//            return View(contratos);
//        }

//        // GET: ContratoTemp/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var contratos = await _context.Contratos
//                .Include(c => c.Cliente)
//                .Include(c => c.Funcionario)
//                .Include(c => c.Pacote)
//                .Include(c => c.Promocao)
//                .FirstOrDefaultAsync(m => m.ContratoId == id);
//            if (contratos == null)
//            {
//                return NotFound();
//            }

//            return View(contratos);
//        }

//        // POST: ContratoTemp/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var contratos = await _context.Contratos.FindAsync(id);
//            _context.Contratos.Remove(contratos);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ContratosExists(int id)
//        {
//            return _context.Contratos.Any(e => e.ContratoId == id);
//        }
//    }
//}
