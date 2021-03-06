﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using UPtel.Data;
//using UPtel.Models;

//namespace UPtel.Controllers
//{
//    public class CargosController : Controller
//    {
//        private readonly UPtelContext _context;

//        public CargosController(UPtelContext context)
//        {
//            _context = context;
//        }

//        // GET: Cargos
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Cargos.ToListAsync());
//        }

//        // GET: Cargos/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var cargos = await _context.Cargos
//                .FirstOrDefaultAsync(m => m.CargoId == id);
//            if (cargos == null)
//            {
//                return NotFound();
//            }

//            return View(cargos);
//        }

//        // GET: Cargos/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Cargos/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("CargoId,NomeCargo")] TipoFuncionario cargos)
//        {

//            if (!ModelState.IsValid)
//            {
//                return View(cargos);
//            }

//            _context.Add(cargos);
//            await _context.SaveChangesAsync();

//            ViewBag.Mensagem = "Cargo adicionado com sucesso";
//            return View("Sucesso");

//        }

//        // GET: Cargos/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var cargos = await _context.Cargos.FindAsync(id);
//            if (cargos == null)
//            {
//                ViewBag.Mensagem = "Ocorreu um erro, possivelmente o cargo já foi eliminado.";
//                return View("Erro");
//            }
//            return View(cargos);
//        }

//        // POST: Cargos/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("CargoId,NomeCargo")] TipoFuncionario cargos)
//        {
//            if (id != cargos.CargoId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(cargos);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CargosExists(cargos.CargoId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                ViewBag.Mensagem = "Cargo alterado com sucesso";
//                return View("Sucesso");
//            }
//            return View(cargos);
//        }

//        // GET: Cargos/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var cargos = await _context.Cargos
//                .FirstOrDefaultAsync(m => m.CargoId == id);
//            if (cargos == null)
//            {
//                ViewBag.Mensagem = "O cargo já foi eliminado por outra pessoa.";
//                return View("Sucesso");
//            }

//            return View(cargos);
//        }

//        // POST: Cargos/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var cargos = await _context.Cargos.FindAsync(id);
//            _context.Cargos.Remove(cargos);
//            await _context.SaveChangesAsync();
//            ViewBag.Mensagem = "O cargo foi eliminado com sucesso.";
//            return View("Sucesso");
//        }

//        private bool CargosExists(int id)
//        {
//            return _context.Cargos.Any(e => e.CargoId == id);
//        }
//    }
//}
