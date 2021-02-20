﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UPtel.Data;
using UPtel.Models;
using System.IO;


namespace UPtel.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly UPtelContext _context;

        public FuncionariosController(UPtelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Funcionarios.Where(p => nomePesquisar == null || p.NomeFuncionario.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Funcionarios> funcionarios = await _context.Funcionarios.Where(p => nomePesquisar == null || p.NomeFuncionario.Contains(nomePesquisar))
                .Include(f => f.Cargo)
                .OrderBy(f => f.NomeFuncionario)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                Funcionarios = funcionarios,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios
                .Include(f => f.Cargo)
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "NomeCargo");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioId,NomeFuncionario,CargoId,DataNascimento,Contribuinte,Morada,CodigoPostal,Email,Telemovel,CartaoCidadao,Iban,Password,EstadoFuncionario,CodigoPostalExt,Fotografia")] Funcionarios funcionarios, IFormFile ficheiroFoto)
        {
            if (!ModelState.IsValid)
            {
                return View(funcionarios);
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "NomeCargo", funcionarios.CargoId);

            AtualizaFotofuncionario(funcionarios, ficheiroFoto);

            _context.Add(funcionarios);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "Funcionário adicionado com sucesso";
            return View("Sucesso");
        }

        private static void AtualizaFotofuncionario(Funcionarios funcionarios, IFormFile ficheiroFoto)
        {
            if (ficheiroFoto != null && ficheiroFoto.Length > 0)
            {
                using (var ficheiroMemoria = new MemoryStream())
                {
                    ficheiroFoto.CopyTo(ficheiroMemoria);
                    funcionarios.Fotografia = ficheiroMemoria.ToArray();
                }
            }
        }
        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios.FindAsync(id);
            if (funcionarios == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente o funcionário já foi eliminado.";
                return View("Erro");
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "NomeCargo", funcionarios.CargoId);
            return View(funcionarios);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioId,NomeFuncionario,CargoId,DataNascimento,Contribuinte,Morada,CodigoPostal,Email,Telemovel,CartaoCidadao,Iban,Password,EstadoFuncionario,CodigoPostalExt,Fotografia")] Funcionarios funcionarios, IFormFile ficheiroFoto)
        {
            if (id != funcionarios.FuncionarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AtualizaFotofuncionario(funcionarios, ficheiroFoto);
                    _context.Update(funcionarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionariosExists(funcionarios.FuncionarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Funcionário alterado com sucesso";
                return View("Sucesso");
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "CargoId", "NomeCargo", funcionarios.CargoId);
            return View(funcionarios);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios
                .Include(f => f.Cargo)
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionarios == null)
            {
                ViewBag.Mensagem = "O funcionário já foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(funcionarios);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionarios = await _context.Funcionarios.FindAsync(id);
            _context.Funcionarios.Remove(funcionarios);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "O funcionário foi eliminado com sucesso.";
            return View("Sucesso");
        }

        private bool FuncionariosExists(int id)
        {
            return _context.Funcionarios.Any(e => e.FuncionarioId == id);
        }
    }
}
