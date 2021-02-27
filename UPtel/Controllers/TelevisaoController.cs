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
    public class TelevisaoController : Controller
    {
        private readonly UPtelContext _context;

        public TelevisaoController(UPtelContext context)
        {
            _context = context;
        }

        // GET: Televisao
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Televisao.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<Televisao> televisao = await _context.Televisao.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
                .OrderBy(c => c.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel model = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                Televisao = televisao,
                NomePesquisar = nomePesquisar
            };

            return base.View(model);
        }

        // GET: Televisao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TelevisaoViewModel TVM = new TelevisaoViewModel();
            var televisao = await _context.Televisao.Include(p => p.PacoteCanais)
                .ThenInclude(c => c.Canais)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.TelevisaoId == id);

            var listaCanais = _context.Canais.Select(x => new CheckBox()
            {
                Id = x.CanaisId,
                Nome = x.NomeCanal,
                Selecionado = x.PacoteCanais.Any(x => x.TelevisaoId == televisao.TelevisaoId) ? true : false
            }).ToList();

            TVM.Nome = televisao.Nome;
            TVM.Descricao = televisao.Descricao;
            TVM.PrecoPacoteTelevisao = televisao.PrecoPacoteTelevisao;
            TVM.ListaCanais = listaCanais;
            TVM.TelevisaoId = (int)id;


            if (televisao == null)
            {
                return NotFound();
            }

            return View(TVM);
        }

        // GET: Televisao/Create
        public IActionResult Create()
        {
            var canal = _context.Canais.ToList();
            TelevisaoViewModel TVM = new TelevisaoViewModel();
            TVM.ListaCanais= canal.Select(x => new CheckBox()
            {
                Id = x.CanaisId,
                Nome = x.NomeCanal,
                Selecionado = false
            }).ToList();

            return View(TVM);
        }

        // POST: Televisao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public async Task<IActionResult> Create(TelevisaoViewModel TVM, Televisao televisao, PacoteCanais pacoteCanais)
        {
            List<PacoteCanais> listaCanais = new List<PacoteCanais>();
            televisao.Nome = TVM.Nome;
            televisao.Descricao = TVM.Descricao;
            televisao.PrecoPacoteTelevisao = TVM.PrecoPacoteTelevisao;
            _context.Televisao.Add(televisao);
            await _context.SaveChangesAsync();
            int televisaoId = televisao.TelevisaoId;

            foreach(var item in TVM.ListaCanais)
            {
                if(item.Selecionado == true)
                {
                    listaCanais.Add(new PacoteCanais() {TelevisaoId = televisaoId, CanaisId = item.Id });
                }
            }
            foreach(var item in listaCanais)
            {
                _context.PacoteCanais.Add(item);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Televisao");
        }



        // GET: Televisao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            TelevisaoViewModel TVM = new TelevisaoViewModel();
            var televisao = await _context.Televisao.Include(p => p.PacoteCanais)
                .ThenInclude(c => c.Canais)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.TelevisaoId == id);

            var listaCanais = _context.Canais.Select(x => new CheckBox()
            {
                Id = x.CanaisId,
                Nome = x.NomeCanal,
                Selecionado = x.PacoteCanais.Any(x => x.TelevisaoId == televisao.TelevisaoId) ? true : false
            }).ToList();

            TVM.Nome = televisao.Nome;
            TVM.Descricao = televisao.Descricao;
            TVM.PrecoPacoteTelevisao = televisao.PrecoPacoteTelevisao;
            TVM.ListaCanais = listaCanais;
            TVM.TelevisaoId = (int)id;

            return View(TVM);
        }

        // POST: Televisao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, TelevisaoViewModel TVM/*, Televisao televisao*//*, PacoteCanais pacoteCanais*/)
        {
            List<PacoteCanais> listaCanais = new List<PacoteCanais>();

            Televisao televisao = await _context.Televisao.Include(p => p.PacoteCanais)
                .ThenInclude(c => c.Canais)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.TelevisaoId == id);

            televisao.Nome = TVM.Nome;
            televisao.Descricao = TVM.Descricao;
            televisao.PrecoPacoteTelevisao = TVM.PrecoPacoteTelevisao;

            _context.Televisao.Update(televisao);
            await _context.SaveChangesAsync();

            int televisaoId = televisao.TelevisaoId;


            foreach (var canal in TVM.ListaCanais)
            {
                if (canal.Selecionado == true)
                {
                    listaCanais.Add(new PacoteCanais() { TelevisaoId = televisao.TelevisaoId, CanaisId = canal.Id });
                }
            }

            var ListaPacoteCanais = _context.PacoteCanais.Where(p => p.TelevisaoId == id).ToList();
            var resultado = ListaPacoteCanais.Except(listaCanais).ToList();
            foreach (var pacoteCanal in resultado)
            {
                _context.PacoteCanais.Remove(pacoteCanal);
                await _context.SaveChangesAsync();
            }
            var novaListaPacoteCanais = _context.PacoteCanais.Where(p => p.TelevisaoId == id).ToList();
            foreach (var canal in listaCanais)
            {
                if (!novaListaPacoteCanais.Contains(canal))
                {
                    _context.PacoteCanais.Add(canal);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Index", "Televisao");
            //return RedirectToAction("Details", "Televisao");
        }

        // GET: Televisao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var televisao = await _context.Televisao
                .FirstOrDefaultAsync(m => m.TelevisaoId == id);
            if (televisao == null)
            {
                ViewBag.Mensagem = "A televisão já foi eliminada por outra pessoa.";
                return View("Sucesso");
            }

            return View(televisao);
        }

        // POST: Televisao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var televisao = await _context.Televisao.FindAsync(id);
            _context.Televisao.Remove(televisao);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "A televisão foi eliminada com sucesso.";
            return View("Sucesso");
        }

        private bool TelevisaoExists(int id)
        {
            return _context.Televisao.Any(e => e.TelevisaoId == id);
        }
    }
}
