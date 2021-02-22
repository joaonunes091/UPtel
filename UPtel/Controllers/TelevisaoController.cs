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

            var televisao = await _context.Televisao
                .FirstOrDefaultAsync(m => m.TelevisaoId == id);
            if (televisao == null)
            {
                return NotFound();
            }

            return View(televisao);
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
            }).ToList(); ;

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
            if (id == null)
            {
                return NotFound();
            }

            var televisao = await _context.Televisao.Include(p => p.PacoteCanais)
                        .SingleOrDefaultAsync(p => p.TelevisaoId == id);

            var canal = _context.Canais.ToList();
           
            TelevisaoViewModel TVM = new TelevisaoViewModel();
            TVM.Nome = televisao.Nome;
            TVM.Descricao = televisao.Descricao;
            TVM.PrecoPacoteTelevisao = televisao.PrecoPacoteTelevisao;
            TVM.ListaCanais = canal.Select(x => new CheckBox()
            {
                Id = x.CanaisId,
                Nome = x.NomeCanal,
                Selecionado = false
            }).ToList(); ;


            if (televisao == null)
            {
                ViewBag.Mensagem = "Ocorreu um erro, possivelmente a televisão já foi eliminada.";
                return View("Erro");
            }
            return View(TVM);
        }

        // POST: Televisao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TelevisaoId,Nome,Descricao,PrecoPacoteTelevisao")] Televisao televisao)
        {
            if (id != televisao.TelevisaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(televisao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelevisaoExists(televisao.TelevisaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Televisão alterada com sucesso";
                return View("Sucesso");
            }
            return View(televisao);
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
