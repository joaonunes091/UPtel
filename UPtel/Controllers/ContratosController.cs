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
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Contratos.Include(p => p.Cliente).Where(p => nomePesquisar == null || p.Cliente.Nome.Contains(nomePesquisar) || p.Cliente.Contribuinte.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Contratos> contratos = await _context.Contratos.Include(p => p.Cliente).Where(p => nomePesquisar == null || p.Cliente.Nome.Contains(nomePesquisar) || p.Cliente.Contribuinte.Contains(nomePesquisar))
                .OrderBy(c => c.Cliente.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Paginacao = paginacao,
                Contratos = contratos,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }

        //Pesquisa nome cliente para adicionar contrato
        public async Task<IActionResult> SelectUser(string nomePesquisar)
        {
            List<Users> users = await _context.Users.Where(p => !p.Estado.Contains("Desativo") && p.Tipo.Tipo.Contains("Cliente") && p.Nome.Contains(nomePesquisar) || p.Contribuinte.Contains(nomePesquisar) || p.Tipo.Tipo.Contains(nomePesquisar))

                    .Include(t => t.Tipo)
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

        //public IActionResult Create()
        //{
        //    //ViewData["ClienteId"] = new SelectList(_context.Users.Where(c => c.Tipo.Tipo.Contains("Cliente Particular") || c.Tipo.Tipo.Contains("Cliente Empresarial")), "UsersId", "Contribuinte");
        //    ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote");
        //    return View();
        //}

        //// POST: Contratos/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(int? id, [Bind("ContratoId,ClienteId,FuncionarioId,PromocaoId,PacoteId,Numeros,DataInicio,Fidelizacao,TempoPromocao,PrecoContrato")] ContratoViewModel contratoViewModel)
        //{

        //    //decimal precoContrato, desconto, total;
        //    //var promocoes = _context.Promocoes.SingleOrDefault(e => e.PromocaoId == contratos.PromocaoId);
        //    //var pacote = _context.Pacotes.SingleOrDefault(p => p.PacoteId == contratos.PacoteId);

        //    //precoContrato = pacote.PrecoTotal;
        //    //desconto = promocoes.Desconto;
        //    //total = precoContrato - (precoContrato * (desconto / 100));
        //    //contratos.PrecoContrato = total;

        //    //Código que vai buscar o ID do funcionário que tem login feito e atribui automaticamente ao contrato
        //    var funcionario = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);
        //    contratoViewModel.FuncionarioId = funcionario.UsersId;

        //    //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
        //    var cliente = _context.Users.SingleOrDefault(m => m.UsersId == id);
        //    contratoViewModel.ClienteId = cliente.UsersId;

        //    if (contratoViewModel.DataInicio > DateTime.Today || contratoViewModel.DataInicio < DateTime.Today.AddDays(-90))
        //    {
        //        ModelState.AddModelError("DataInicio", "A data de ínicio do contrato deverá entre os 90 dias anteriores");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratoViewModel.PacoteId);
        //        //ViewData["PromocaoId"] = new SelectList(_context.Promocoes, "PromocaoId", "Descricao", contratos.PromocaoId);
        //        return View(contratoViewModel);
        //    }

        //    _context.Add(contratoViewModel);
        //    await _context.SaveChangesAsync();
        //    ViewBag.Mensagem = "Contrato adicionado com sucesso";

        //    ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratoViewModel.PacoteId);
        //    //ViewData["PromocaoId"] = new SelectList(_context.Promocoes, "PromocaoId", "Descricao", contratos.PromocaoId);

        //    return View("Sucesso");
        //}

        // GET: Contratos/Create/Promo
        public IActionResult Create()
        {
            //ViewData["ClienteId"] = new SelectList(_context.Users, "UsersId", "CodigoPostal");
            //ViewData["FuncionarioId"] = new SelectList(_context.Users, "UsersId", "CodigoPostal");
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
        public async Task<IActionResult> Create(int? id, ContratoViewModel CVM, Contratos contratos, ContratoPromoNetFixa contratoPromoNetFixa, ContratoPromoNetMovel contratoPromoNetMovel, ContratoPromoTelefone contratoPromoTelefone, ContratoPromoTelemovel contratoPromoTelemovel, ContratoPromoTelevisao contratoPromoTelevisao)

        {
            //Código que vai buscar o ID do funcionário que tem login feito e atribui automaticamente ao contrato
            var funcionario = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);
            contratos.FuncionarioId = funcionario.UsersId;

            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var cliente = _context.Users.SingleOrDefault(m => m.UsersId == id);
            contratos.ClienteId = cliente.UsersId;

            List<ContratoPromoNetFixa> listaContratosPromoNetFixa = new List<ContratoPromoNetFixa>();
            List<ContratoPromoNetMovel> listaContratosPromoNetMovel = new List<ContratoPromoNetMovel>();
            List<ContratoPromoTelefone> listaContratosPromoTelefone = new List<ContratoPromoTelefone>();
            List<ContratoPromoTelemovel> listaContratosPromoTelemovel = new List<ContratoPromoTelemovel>();
            List<ContratoPromoTelevisao> listaContratosPromoTelevisao = new List<ContratoPromoTelevisao>();

            //contratos.ClienteId = CVM.ClienteId;
            //contratos.FuncionarioId = CVM.FuncionarioId;
            contratos.PacoteId = CVM.PacoteId;
            contratos.Numeros = CVM.Numeros;
            contratos.DataInicio = CVM.DataInicio;
            contratos.Fidelizacao = CVM.Fidelizacao;

            _context.Contratos.Add(contratos);
            await _context.SaveChangesAsync();

            int contratoId = contratos.ContratoId;

            if (CVM.ListaPromoNetFixa != null)
            {
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
            }

            if (CVM.ListaPromoNetMovel != null)
            {
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
            }

            if (CVM.ListaPromoTelefone != null)
            {
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
            }

            if (CVM.ListaPromoTelemovel != null)
            {
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
            }

            if (CVM.ListaPromoTelevisao != null)
            {
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
            }

            if (contratos.DataInicio > DateTime.Today || contratos.DataInicio < DateTime.Today.AddDays(-90))
            {
                ModelState.AddModelError("DataInicio", "A data de ínicio do contrato deverá entre os 90 dias anteriores");
            }

            if (!ModelState.IsValid)
            {
                ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratos.PacoteId);
                return View(contratos);
            }
            await _context.SaveChangesAsync();
            return View("Sucesso");

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
