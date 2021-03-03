﻿using System;
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
    public class PromocoesController : Controller
    {
        private readonly UPtelContext _context;

        public PromocoesController(UPtelContext context)
        {
            _context = context;
        }

        // GET: Promocoes
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Promocoes.Where(p => nomePesquisar == null || p.NomePromocao.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<Promocoes> promocoes = await _context.Promocoes.Where(p => nomePesquisar == null || p.NomePromocao.Contains(nomePesquisar))
                .OrderBy(c => c.NomePromocao)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();
            //var UPtelContext = _context.Promocoes.Include(p => p.NomePromocao).Include(p => p.Descricao);
            ListaCanaisViewModel model = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                Promocoes = promocoes,
                NomePesquisar = nomePesquisar
            };

            return base.View(model);
        }

        // GET: Promocoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoes = await _context.Promocoes
                .FirstOrDefaultAsync(m => m.PromocaoId == id);
            if (promocoes == null)
            {
                return NotFound();
            }

            return View(promocoes);
        }

        // GET: Promocoes/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promocoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([Bind("PromocaoId,NomePromocao,Descricao,PromoCanais,Desconto")] Promocoes promocoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promocoes);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Promoção criada com sucesso";
                return View("Sucesso");
            }
            return View(promocoes);
        }

        // GET: Promocoes/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoes = await _context.Promocoes.FindAsync(id);
            if (promocoes == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente a promoção já foi eliminada.";
                return View("Erro");
            }
            return View(promocoes);
        }

        // POST: Promocoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, [Bind("PromocaoId,NomePromocao,Descricao,PromoCanais,Desconto")] Promocoes promocoes)
        {
            if (id != promocoes.PromocaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promocoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocoesExists(promocoes.PromocaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Promoção criada com sucesso";
                return View("Sucesso");
            }
            return View(promocoes);
        }

        // GET: Promocoes/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoes = await _context.Promocoes
                .FirstOrDefaultAsync(m => m.PromocaoId == id);
            if (promocoes == null)
            {
                ViewBag.Mensagem = "A promoção já foi eliminada por outra pessoa.";
                return View("Sucesso");
            }

            return View(promocoes);
        }

        // POST: Promocoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocoes = await _context.Promocoes.FindAsync(id);
            _context.Promocoes.Remove(promocoes);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "A promoção foi eliminada com sucesso.";
            return View("Sucesso");
        }

        private bool PromocoesExists(int id)
        {
            return _context.Promocoes.Any(e => e.PromocaoId == id);
        }
    }
}
