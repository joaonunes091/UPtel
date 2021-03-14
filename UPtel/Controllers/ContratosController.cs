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

            ContratoViewModel CVM = new ContratoViewModel();

            var contrato = await _context.Contratos.Include(p => p.ContratoPromoNetFixa).ThenInclude(p => p.PromoNetFixa)
                .Include(p => p.ContratoPromoNetMovel).ThenInclude(p => p.PromoNetMovel)
                .Include(p => p.ContratoPromoTelefone).ThenInclude(p => p.PromoTelefone)
                .Include(p => p.ContratoPromoTelemovel).ThenInclude(p => p.PromoTelemovel)
                .Include(p => p.ContratoPromoTelevisao).ThenInclude(p => p.PromoTelevisao)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ContratoId == id);

            var listaPromoNetFixa = _context.PromoNetFixa.Select(x => new CheckBox()
            {
                Id = x.PromoNetFixaId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoNetFixa.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            var listaPromoNetMovel = _context.PromoNetMovel.Select(x => new CheckBox()
            {
                Id = x.PromoNetMovelId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoNetMovel.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            var listaPromoTelefone = _context.PromoTelefone.Select(x => new CheckBox()
            {
                Id = x.PromoTelefoneId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelefone.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            var listaPromoTelemovel = _context.PromoTelemovel.Select(x => new CheckBox()
            {
                Id = x.PromoTelemovelId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelemovel.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            var listaPromoTelevisao = _context.PromoTelevisao.Select(x => new CheckBox()
            {
                Id = x.PromoTelevisaoId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelevisao.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();

            CVM.FuncionarioId = contrato.FuncionarioId;
            CVM.ClienteId = contrato.ClienteId;
            CVM.DataInicio = contrato.DataInicio;
            CVM.PacoteId = contrato.PacoteId;
            CVM.Numeros = contrato.Numeros;
            CVM.Fidelizacao = contrato.Fidelizacao;
            CVM.ContratoId = (int)id;
            CVM.ListaPromoNetFixa = listaPromoNetFixa;
            CVM.ListaPromoNetMovel = listaPromoNetMovel;
            CVM.ListaPromoTelefone = listaPromoTelefone;
            CVM.ListaPromoTelemovel = listaPromoTelemovel;
            CVM.ListaPromoTelevisao = listaPromoTelevisao;


            return View(CVM);
        }


        // GET: Contratos/Create/
        public IActionResult Create()
        {
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
            //decimal precoContrato, desconto, total;
            //var promocoes = _context.Promocoes.SingleOrDefault(e => e.PromocaoId == contratos.PromocaoId);
            //var pacote = _context.Pacotes.SingleOrDefault(p => p.PacoteId == contratos.PacoteId);

            //precoContrato = pacote.PrecoTotal;
            //desconto = promocoes.Desconto;
            //total = precoContrato - (precoContrato * (desconto / 100));
            //contratos.PrecoContrato = total;

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
            ContratoViewModel CVM = new ContratoViewModel();
            var contrato = await _context.Contratos.Include(p => p.ContratoPromoNetFixa).ThenInclude(p => p.PromoNetFixa)
                .Include(p => p.ContratoPromoNetMovel).ThenInclude(p => p.PromoNetMovel)
                .Include(p => p.ContratoPromoTelefone).ThenInclude(p => p.PromoTelefone)
                .Include(p => p.ContratoPromoTelemovel).ThenInclude(p => p.PromoTelemovel)
                .Include(p => p.ContratoPromoTelevisao).ThenInclude(p => p.PromoTelevisao)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ContratoId == id);

            List<ContratoPromoNetFixa> listaContratosPromoNetFixa = new List<ContratoPromoNetFixa>();
            List<ContratoPromoNetMovel> listaContratosPromoNetMovel = new List<ContratoPromoNetMovel>();
            List<ContratoPromoTelefone> listaContratosPromoTelefone = new List<ContratoPromoTelefone>();
            List<ContratoPromoTelemovel> listaContratosPromoTelemovel = new List<ContratoPromoTelemovel>();
            List<ContratoPromoTelevisao> listaContratosPromoTelevisao = new List<ContratoPromoTelevisao>();

            CVM.ListaPromoNetFixa = _context.PromoNetFixa.Select(x => new CheckBox()
            {
                Id = x.PromoNetFixaId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoNetFixa.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoNetMovel = _context.PromoNetMovel.Select(x => new CheckBox()
            {
                Id = x.PromoNetMovelId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoNetMovel.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoTelefone = _context.PromoTelefone.Select(x => new CheckBox()
            {
                Id = x.PromoTelefoneId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelefone.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoTelemovel = _context.PromoTelemovel.Select(x => new CheckBox()
            {
                Id = x.PromoTelemovelId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelemovel.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoTelevisao = _context.PromoTelevisao.Select(x => new CheckBox()
            {
                Id = x.PromoTelevisaoId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelevisao.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();

            //Código que vai buscar o ID do funcionário que tem login feito e atribui automaticamente ao contrato
            var funcionario = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);
            CVM.FuncionarioId = funcionario.UsersId;

            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var contratoOriginal = _context.Contratos.AsNoTracking().SingleOrDefault(m => m.ContratoId == id);
            CVM.ClienteId = contratoOriginal.ClienteId;
            CVM.DataInicio = contratoOriginal.DataInicio;

            CVM.PacoteId = contrato.PacoteId;
            CVM.Numeros = contrato.Numeros;
            CVM.Fidelizacao = contrato.Fidelizacao;
            CVM.ContratoId = (int)id;

            return View(CVM);

        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , ContratoViewModel CVM)
        {
            var contrato = await _context.Contratos.Include(p => p.ContratoPromoNetFixa).ThenInclude(p => p.PromoNetFixa)
                .Include(p => p.ContratoPromoNetMovel).ThenInclude(p => p.PromoNetMovel)
                .Include(p => p.ContratoPromoTelefone).ThenInclude(p => p.PromoTelefone)
                .Include(p => p.ContratoPromoTelemovel).ThenInclude(p => p.PromoTelemovel)
                .Include(p => p.ContratoPromoTelevisao).ThenInclude(p => p.PromoTelevisao)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ContratoId == id);

            List<ContratoPromoNetFixa> listaContratosPromoNetFixa = new List<ContratoPromoNetFixa>();
            List<ContratoPromoNetMovel> listaContratosPromoNetMovel = new List<ContratoPromoNetMovel>();
            List<ContratoPromoTelefone> listaContratosPromoTelefone = new List<ContratoPromoTelefone>();
            List<ContratoPromoTelemovel> listaContratosPromoTelemovel = new List<ContratoPromoTelemovel>();
            List<ContratoPromoTelevisao> listaContratosPromoTelevisao = new List<ContratoPromoTelevisao>();

            //Código que vai buscar o ID do funcionário que tem login feito e atribui automaticamente ao contrato
            var funcionario = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);
            contrato.FuncionarioId = funcionario.UsersId;

            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var contratoOriginal = _context.Contratos.AsNoTracking().SingleOrDefault(m => m.ContratoId == id);
            contrato.ClienteId = contratoOriginal.ClienteId;
            contrato.DataInicio = contratoOriginal.DataInicio;

            contrato.PacoteId = CVM.PacoteId;
            contrato.Numeros = CVM.Numeros;
            contrato.Fidelizacao = CVM.Fidelizacao;

            _context.Contratos.Update(contrato);
            await _context.SaveChangesAsync();

            int contratoId = contrato.ContratoId;
            if (CVM.ListaPromoNetFixa != null)
            {
                foreach (var promoNetFixa in CVM.ListaPromoNetFixa)
                {
                    if (promoNetFixa.Selecionado == true)
                    {
                        listaContratosPromoNetFixa.Add(new ContratoPromoNetFixa() { ContratoId = contrato.ContratoId, PromoNetFixaId = promoNetFixa.Id });
                    }
                }

                var ListaContratoPromoNetFixa = _context.ContratoPromoNetFixa.Where(p => p.ContratoId == id).ToList();
                var resultadoPromoNetFixa = ListaContratoPromoNetFixa.Except(listaContratosPromoNetFixa).ToList();
                foreach (var contratoPromoNetFixa in resultadoPromoNetFixa)
                {
                    _context.ContratoPromoNetFixa.Remove(contratoPromoNetFixa);
                    await _context.SaveChangesAsync();
                }
                var novaListaContratoPromoNetFixa = _context.ContratoPromoNetFixa.Where(P => P.ContratoId == id).ToList();
                foreach (var promoNetFixa in listaContratosPromoNetFixa)
                {
                    if (!novaListaContratoPromoNetFixa.Contains(promoNetFixa))
                    {
                        _context.ContratoPromoNetFixa.Add(promoNetFixa);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            if (CVM.ListaPromoNetMovel != null)
            {
                foreach (var promoNetMovel in CVM.ListaPromoNetMovel)
                {
                    if (promoNetMovel.Selecionado == true)
                    {
                        listaContratosPromoNetMovel.Add(new ContratoPromoNetMovel() { ContratoId = contrato.ContratoId, PromoNetMovelId = promoNetMovel.Id });
                    }
                }

                var ListaContratoPromoNetMovel = _context.ContratoPromoNetMovel.Where(p => p.ContratoId == id).ToList();
                var resultadoPromoNetMovel = ListaContratoPromoNetMovel.Except(listaContratosPromoNetMovel).ToList();
                foreach (var contratoPromoNetMovel in resultadoPromoNetMovel)
                {
                    _context.ContratoPromoNetMovel.Remove(contratoPromoNetMovel);
                    await _context.SaveChangesAsync();
                }
                var novaListaContratoPromoNetMovel = _context.ContratoPromoNetMovel.Where(P => P.ContratoId == id).ToList();
                foreach (var promoNetMovel in listaContratosPromoNetMovel)
                {
                    if (!novaListaContratoPromoNetMovel.Contains(promoNetMovel))
                    {
                        _context.ContratoPromoNetMovel.Add(promoNetMovel);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            if (CVM.ListaPromoTelefone != null)
            {
                foreach (var promoTelefone in CVM.ListaPromoTelefone)
                {
                    if (promoTelefone.Selecionado == true)
                    {
                        listaContratosPromoTelefone.Add(new ContratoPromoTelefone() { ContratoId = contrato.ContratoId, PromoTelefoneId = promoTelefone.Id });
                    }
                }

                var ListaContratoPromoTelefone = _context.ContratoPromoTelefone.Where(p => p.ContratoId == id).ToList();
                var resultadoPromoTelefone = ListaContratoPromoTelefone.Except(listaContratosPromoTelefone).ToList();
                foreach (var contratoPromoTelefone in resultadoPromoTelefone)
                {
                    _context.ContratoPromoTelefone.Remove(contratoPromoTelefone);
                    await _context.SaveChangesAsync();
                }
                var novaListaContratoPromoTelefone = _context.ContratoPromoTelefone.Where(P => P.ContratoId == id).ToList();
                foreach (var promoTelefone in listaContratosPromoTelefone)
                {
                    if (!novaListaContratoPromoTelefone.Contains(promoTelefone))
                    {
                        _context.ContratoPromoTelefone.Add(promoTelefone);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            if (CVM.ListaPromoTelemovel != null)
            {
                foreach (var promoTelemovel in CVM.ListaPromoTelemovel)
                {
                    if (promoTelemovel.Selecionado == true)
                    {
                        listaContratosPromoTelemovel.Add(new ContratoPromoTelemovel() { ContratoId = contrato.ContratoId, PromoTelemovelId = promoTelemovel.Id });
                    }
                }

                var ListaContratoPromoTelemovel = _context.ContratoPromoTelemovel.Where(p => p.ContratoId == id).ToList();
                var resultadoPromoTelemovel = ListaContratoPromoTelemovel.Except(listaContratosPromoTelemovel).ToList();
                foreach (var contratoPromoTelemovel in resultadoPromoTelemovel)
                {
                    _context.ContratoPromoTelemovel.Remove(contratoPromoTelemovel);
                    await _context.SaveChangesAsync();
                }
                var novaListaContratoPromoTelemovel = _context.ContratoPromoTelemovel.Where(P => P.ContratoId == id).ToList();
                foreach (var promoTelemovel in listaContratosPromoTelemovel)
                {
                    if (!novaListaContratoPromoTelemovel.Contains(promoTelemovel))
                    {
                        _context.ContratoPromoTelemovel.Add(promoTelemovel);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            if (CVM.ListaPromoTelevisao != null)
            {
                foreach (var promoTelevisao in CVM.ListaPromoTelevisao)
                {
                    if (promoTelevisao.Selecionado == true)
                    {
                        listaContratosPromoTelevisao.Add(new ContratoPromoTelevisao() { ContratoId = contrato.ContratoId, PromoTelevisaoId = promoTelevisao.Id });
                    }
                }

                var ListaContratoPromoTelevisao = _context.ContratoPromoTelevisao.Where(p => p.ContratoId == id).ToList();
                var resultadoPromoTelevisao = ListaContratoPromoTelevisao.Except(listaContratosPromoTelevisao).ToList();
                foreach (var contratoPromoTelevisao in resultadoPromoTelevisao)
                {
                    _context.ContratoPromoTelevisao.Remove(contratoPromoTelevisao);
                    await _context.SaveChangesAsync();
                }
                var novaListaContratoPromoTelevisao = _context.ContratoPromoTelevisao.Where(P => P.ContratoId == id).ToList();
                foreach (var promoTelevisao in listaContratosPromoTelevisao)
                {
                    if (!novaListaContratoPromoTelevisao.Contains(promoTelevisao))
                    {
                        _context.ContratoPromoTelevisao.Add(promoTelevisao);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            return RedirectToAction("Index", "Contratos");
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
