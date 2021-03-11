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
        public async Task<IActionResult> Index()
        {
            var uPtelContext = _context.Contratos.Include(c => c.Cliente).Include(c => c.Funcionario).Include(c => c.Pacote);
            return View(await uPtelContext.ToListAsync());
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
            ViewData["ClienteId"] = new SelectList(_context.Users, "UsersId", "CodigoPostal");
            ViewData["FuncionarioId"] = new SelectList(_context.Users, "UsersId", "CodigoPostal");
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote");

            var promoNetFixa = _context.PromoNetFixa.ToList();
            var promoNetMovel = _context.PromoNetMovel.ToList();
            var promoTelefone = _context.PromoTelefone.ToList();
            var promoTelemovel = _context.PromoTelemovel.ToList();
            var promoTelevisao = _context.PromoTelevisao.ToList();
            ContratoViewModel CVM = new ContratoViewModel();
            CVM.ListaPromoNetFixa = promoNetFixa.Select(x => new CheckBox()
            {
                Id = x.PromoNetFixaId,
                Nome = x.Nome,
                Selecionado = false
            }).ToList();
            CVM.ListaPromoNetMovel = promoNetMovel.Select(x => new CheckBox()
            {
                Id = x.PromoNetMovelId,
                Nome = x.Nome,
                Selecionado = false
            }).ToList();
            CVM.ListaPromoTelefone = promoTelefone.Select(x => new CheckBox()
            {
                Id = x.PromoTelefoneId,
                Nome = x.Nome,
                Selecionado = false
            }).ToList();
            CVM.ListaPromoTelemovel = promoTelemovel.Select(x => new CheckBox()
            {
                Id = x.PromoTelemovelId,
                Nome = x.Nome,
                Selecionado = false
            }).ToList();
            CVM.ListaPromoTelevisao = promoTelevisao.Select(x => new CheckBox()
            {
                Id = x.PromoTelevisaoId,
                Nome = x.Nome,
                Selecionado = false
            }).ToList();

            return View(CVM);
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ContratoId,ClienteId,FuncionarioId,PromocaoId,PacoteId,Numeros,DataInicio,Fidelizacao,PrecoContrato")] Contratos contratos)
        public async Task<IActionResult> Create(ContratoViewModel CVM, Contratos contratos, ContratoPromoNetFixa contratoPromoNetFixa, ContratoPromoNetMovel contratoPromoNetMovel, ContratoPromoTelefone contratoPromoTelefone, ContratoPromoTelemovel contratoPromoTelemovel, ContratoPromoTelevisao contratoPromoTelevisao)

        {
            List<ContratoPromoNetFixa> listaContratosPromoNetFixa = new List<ContratoPromoNetFixa>();
            List<ContratoPromoNetMovel> listaContratosPromoNetMovel = new List<ContratoPromoNetMovel>();
            List<ContratoPromoTelefone> listaContratosPromoTelefone = new List<ContratoPromoTelefone>();
            List<ContratoPromoTelemovel> listaContratosPromoTelemovel = new List<ContratoPromoTelemovel>();
            List<ContratoPromoTelevisao> listaContratosPromoTelevisao = new List<ContratoPromoTelevisao>();
            
            contratos.ClienteId = CVM.ClienteId;
            contratos.FuncionarioId = CVM.FuncionarioId;
            contratos.PacoteId = CVM.PacoteId;
            contratos.Numeros = CVM.Numeros;
            contratos.DataInicio = CVM.DataInicio;
            contratos.Fidelizacao = CVM.Fidelizacao;
            
            _context.Contratos.Add(contratos);
            await _context.SaveChangesAsync();
            
            int contratoId = contratos.ContratoId;

            foreach (var item in CVM.ListaPromoNetFixa)
            {
                if (item.Selecionado == true)
                {
                    listaContratosPromoNetFixa.Add(new ContratoPromoNetFixa() { ContratoId = contratoId, PromoNetFixaId = item.Id });
                }
            }
            foreach (var item in listaContratosPromoNetFixa)
            {
                _context.ContratoPromoNetFixa.Add(item);
            }

            foreach (var item in CVM.ListaPromoNetMovel)
            {
                if (item.Selecionado == true)
                {
                    listaContratosPromoNetMovel.Add(new ContratoPromoNetMovel() { ContratoId = contratoId, PromoNetMovelId = item.Id });
                }
            }
            foreach (var item in listaContratosPromoNetMovel)
            {
                _context.ContratoPromoNetMovel.Add(item);
            }

            foreach (var item in CVM.ListaPromoTelefone)
            {
                if (item.Selecionado == true)
                {
                    listaContratosPromoTelefone.Add(new ContratoPromoTelefone() { ContratoId = contratoId, PromoTelefoneId = item.Id });
                }
            }
            foreach (var item in listaContratosPromoTelefone)
            {
                _context.ContratoPromoTelefone.Add(item);
            }

            foreach (var item in CVM.ListaPromoTelemovel)
            {
                if (item.Selecionado == true)
                {
                    listaContratosPromoTelemovel.Add(new ContratoPromoTelemovel() { ContratoId = contratoId, PromoTelemovelId = item.Id });
                }
            }
            foreach (var item in listaContratosPromoTelemovel)
            {
                _context.ContratoPromoTelemovel.Add(item);
            }

            foreach (var item in CVM.ListaPromoTelevisao)
            {
                if (item.Selecionado == true)
                {
                    listaContratosPromoTelevisao.Add(new ContratoPromoTelevisao() { ContratoId = contratoId, PromoTelevisaoId = item.Id });
                }
            }
            foreach (var item in listaContratosPromoTelevisao)
            {
                _context.ContratoPromoTelevisao.Add(item);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Contratos");

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
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Users, "UsersId", "CodigoPostal", contratos.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Users, "UsersId", "CodigoPostal", contratos.FuncionarioId);
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratos.PacoteId);
            return View(contratos);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratoId,ClienteId,FuncionarioId,PromocaoId,PacoteId,Numeros,DataInicio,Fidelizacao,PrecoContrato")] Contratos contratos)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Users, "UsersId", "CodigoPostal", contratos.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Users, "UsersId", "CodigoPostal", contratos.FuncionarioId);
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratos.PacoteId);
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
                .FirstOrDefaultAsync(m => m.ContratoId == id);
            if (contratos == null)
            {
                return NotFound();
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
            return RedirectToAction(nameof(Index));
        }

        private bool ContratosExists(int id)
        {
            return _context.Contratos.Any(e => e.ContratoId == id);
        }
    }
}
