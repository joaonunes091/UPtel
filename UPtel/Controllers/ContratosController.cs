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


        public async Task<IActionResult> MelhorCliente()
        {
            List<Contratos> melhorCliente = await _context.Contratos.Where(p => p.Cliente.Tipo.Tipo.Contains("Cliente"))
                .Include(p => p.Cliente)
                .Include(p => p.Cliente.DistritoNome)
                .OrderByDescending(c => c.PrecoContrato)
                .ToListAsync();

            int x = 0;

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Contratos = melhorCliente,
                
            };
            foreach (var item in modelo.Contratos)
            {
                x++;
                item.Posicao = x;
            }

            return base.View(modelo);
        }
        
        public async Task<IActionResult> MelhorClienteDistrito(string distrito)
        {
            List<Contratos> melhorCliente = await _context.Contratos
                .Include(p => p.Cliente.DistritoNome)
                .Include(p => p.Cliente)
                .Where(p => p.Cliente.Tipo.Tipo.Contains("Cliente") &&  p.Cliente.DistritoNome.DistritoNome.Contains(distrito))
                .OrderByDescending(c => c.PrecoContrato)
                //.Take(10)
                .ToListAsync();

            int x = 0;

            ListaCanaisViewModel modelo = new ListaCanaisViewModel
            {
                Contratos = melhorCliente,
            };
            foreach (var item in modelo.Contratos)
            {
                x++;
                item.Posicao = x;
            }

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
                .Include(p => p.Cliente)
                .Include(p => p.Funcionario)
                .Include(p => p.Pacote)
                .Include(p => p.DistritoNome)

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

            CVM.ContratoId = (int)id;
            CVM.FuncionarioId = contrato.FuncionarioId;
            CVM.ClienteId = contrato.ClienteId;
            CVM.DataInicio = contrato.DataInicio;
            CVM.PacoteId = contrato.PacoteId;
            CVM.Numeros = contrato.Numeros;
            CVM.Fidelizacao = contrato.Fidelizacao;
            CVM.ListaPromoNetFixa = listaPromoNetFixa;
            CVM.ListaPromoNetMovel = listaPromoNetMovel;
            CVM.ListaPromoTelefone = listaPromoTelefone;
            CVM.ListaPromoTelemovel = listaPromoTelemovel;
            CVM.ListaPromoTelevisao = listaPromoTelevisao;
            CVM.NomeCliente = contrato.Cliente.Nome;
            CVM.NomeFuncionario = contrato.Funcionario.Nome;
            CVM.NomeContrato = contrato.Pacote.NomePacote;
            CVM.PrecoContrato = contrato.PrecoContrato;
            CVM.DistritoNome = contrato.DistritoNome.DistritoNome;
            CVM.MoradaContrato = contrato.MoradaContrato;
            CVM.CodigoPostalCont = contrato.CodigoPostalCont;
            CVM.CodigoPostalExtCont = contrato.CodigoPostalExtCont;

            return View(CVM);
        }

        // GET: Contratos/Details/5
        public async Task<IActionResult> DetailsMelhorCliente(int? id)
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
                .Include(p => p.Cliente)
                .Include(p => p.Funcionario)
                .Include(p => p.Pacote)
                .Include(p => p.DistritoNome)

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

            CVM.ContratoId = (int)id;
            CVM.FuncionarioId = contrato.FuncionarioId;
            CVM.ClienteId = contrato.ClienteId;
            CVM.DataInicio = contrato.DataInicio;
            CVM.PacoteId = contrato.PacoteId;
            CVM.Numeros = contrato.Numeros;
            CVM.Fidelizacao = contrato.Fidelizacao;
            CVM.ListaPromoNetFixa = listaPromoNetFixa;
            CVM.ListaPromoNetMovel = listaPromoNetMovel;
            CVM.ListaPromoTelefone = listaPromoTelefone;
            CVM.ListaPromoTelemovel = listaPromoTelemovel;
            CVM.ListaPromoTelevisao = listaPromoTelevisao;
            CVM.NomeCliente = contrato.Cliente.Nome;
            CVM.NomeFuncionario = contrato.Funcionario.Nome;
            CVM.NomeContrato = contrato.Pacote.NomePacote;
            CVM.PrecoContrato = contrato.PrecoContrato;

            return View(CVM);
        }


        // GET: Contratos/Create/
        public IActionResult Create()
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito.Where(x => !x.DistritoNome.Contains("Nacional"))
               .OrderBy(x => x.DistritoNome), "DistritoId", "DistritoNome");
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote");
            var contratoPromoNetFixa = _context.ContratoPromoNetFixa.FirstOrDefault();
            var contratoPromoNetMovel = _context.ContratoPromoNetMovel.FirstOrDefault();
            var contratoPromoTelefone = _context.ContratoPromoTelefone.FirstOrDefault();
            var contratoPromoTelemovel = _context.ContratoPromoTelemovel.FirstOrDefault();
            var contratoPromoTelevisao = _context.ContratoPromoTelevisao.FirstOrDefault();

            var promoNetFixa = _context.PromoNetFixa.ToList();
            var promoNetMovel = _context.PromoNetMovel.ToList();
            var promoTelefone = _context.PromoTelefone.ToList();
            var promoTelemovel = _context.PromoTelemovel.ToList();
            var promoTelevisao = _context.PromoTelevisao.ToList();
            ContratoViewModel CVM = new ContratoViewModel();

            //CVM.DataInicioPromoNetFixa = contratoPromoNetFixa.DataInicio;
            //CVM.DataFimPromoNetFixa = contratoPromoNetFixa.DataFim;

            //CVM.DataInicioPromoNetMovel = contratoPromoNetMovel.DataInicio;
            //CVM.DataFimPromoNetMovel = contratoPromoNetMovel.DataFim;

            //CVM.DataInicioPromoTelefone = contratoPromoTelefone.DataInicio;
            //CVM.DataFimPromoTelefone = contratoPromoTelefone.DataFim;

            //CVM.DataInicioPromoTelemovel = contratoPromoTelemovel.DataInicio;
            //CVM.DataFimPromoTelemovel = contratoPromoTelemovel.DataFim;

            //CVM.DataInicioPromoTelevisao = contratoPromoTelevisao.DataInicio;
            //CVM.DataFimPromoTelevisao = contratoPromoTelevisao.DataFim;
            
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

            contratos.PacoteId = CVM.PacoteId;
            contratos.Numeros = CVM.Numeros;
            contratos.DataInicio = CVM.DataInicio;
            contratos.Fidelizacao = CVM.Fidelizacao;

            _context.Contratos.Add(contratos);
            await _context.SaveChangesAsync();

           
            int contratoId = contratos.ContratoId;
            decimal x1 = 0, x2 = 0, x3 = 0, x4 = 0, x5 = 0;
            decimal descontoNetFixas = 0, descontoNetMovel = 0 , descontoTelefone = 0, descontoTelevisao = 0, descontoTelemovel = 0;
           
           
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
                    var netFixa = _context.PromoNetFixa.SingleOrDefault(n => n.PromoNetFixaId == item.PromoNetFixaId);
                    descontoNetFixas += netFixa.DescontoPrecoTotal;
                    x1++;
                    item.DataInicio = CVM.DataInicioPromoNetFixa;
                    item.DataFim = CVM.DataFimPromoNetFixa;

                    _context.ContratoPromoNetFixa.Add(item);
                    await _context.SaveChangesAsync();
                }
                if (descontoNetFixas > 50)
                {
                    descontoNetFixas = 50;
                }
                else
                {
                    if (x1 == 0)
                    {
                        x1 = 1;
                        descontoNetFixas = descontoNetFixas / x1;
                    }
                    else
                    {
                        descontoNetFixas = descontoNetFixas / x1;
                    }
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
                    var netMovel = _context.PromoNetMovel.SingleOrDefault(n => n.PromoNetMovelId == item.PromoNetMovelId);
                    descontoNetMovel += netMovel.DescontoPrecoTotal;
                    x2++;
                    item.DataInicio = CVM.DataInicioPromoNetMovel;
                    item.DataFim = CVM.DataFimPromoNetMovel;

                    _context.ContratoPromoNetMovel.Add(item);
                    await _context.SaveChangesAsync();
                }
                if (descontoNetMovel > 50)
                {
                    descontoNetMovel = 50;
                }
                else
                {
                    if (x2 == 0)
                    {
                        x2 = 1;
                        descontoNetMovel = descontoNetMovel / x2;
                    }
                    else
                    {
                        descontoNetMovel = descontoNetMovel / x2;
                    }
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
                    var netTelefone = _context.PromoTelefone.SingleOrDefault(n => n.PromoTelefoneId == item.PromoTelefoneId);
                    descontoTelefone += netTelefone.DescontoPrecoTotal;
                    x3++;
                    item.DataInicio = CVM.DataInicioPromoTelefone;
                    item.DataFim = CVM.DataFimPromoTelefone;
                    _context.ContratoPromoTelefone.Add(item);
                    await _context.SaveChangesAsync();
                }
                if (descontoTelefone > 50)
                {
                    descontoTelefone = 50;
                }
                else
                {
                    if (x3 == 0)
                    {
                        x3 = 1;
                        descontoTelefone = descontoTelefone / x3;
                    }
                    else
                    {
                        descontoTelefone = descontoTelefone / x3;
                    }
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
                    var Telemovel = _context.PromoTelemovel.SingleOrDefault(n => n.PromoTelemovelId== item.PromoTelemovelId);
                    descontoTelemovel += Telemovel.DecontoPrecoTotal;
                    x4++;
                    item.DataInicio = CVM.DataInicioPromoTelemovel;
                    item.DataFim = CVM.DataFimPromoTelemovel;
                    _context.ContratoPromoTelemovel.Add(item);
                    await _context.SaveChangesAsync();
                }
                if (descontoTelemovel > 50)
                {
                    descontoTelemovel = 50;
                }
                else
                {
                    if (x4 == 0)
                    {
                        x4 = 1;
                        descontoTelemovel = descontoTelemovel / x4;
                    }
                    else
                    {
                        descontoTelemovel = descontoTelemovel / x4;
                    }
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
                    var Televisao = _context.PromoTelevisao.SingleOrDefault(n => n.PromoTelevisaoId == item.PromoTelevisaoId);
                    descontoTelevisao += Televisao.DescontoPrecoTotal;
                    x5++;
                    item.DataInicio = CVM.DataInicioPromoTelevisao;
                    item.DataFim = CVM.DataFimPromoTelevisao;
                    _context.ContratoPromoTelevisao.Add(item);
                    await _context.SaveChangesAsync();
                }
                if (descontoTelevisao > 50)
                {
                    descontoTelevisao = 50;
                }
                else
                {
                    if (x5 == 0)
                    {
                        x5 = 1;
                        descontoTelevisao = descontoTelevisao / x5;
                    }
                    else
                    {
                        descontoTelevisao = descontoTelevisao / x5;
                    }
                }
            }
           

            //valor do contrato
            decimal precoContrato, totalNetFixa, totalTelemovel, totalNetMovel, totalTelevisao, totalTelefone, total;
 
            var pacote = _context.Pacotes.SingleOrDefault(p => p.PacoteId == contratos.PacoteId);

            precoContrato = pacote.PrecoTotal;
            

            //valor do desconto
            totalTelefone = precoContrato * (descontoTelefone / 100);
            totalNetFixa = precoContrato * (descontoNetFixas / 100);
            totalTelevisao = precoContrato * (descontoTelevisao / 100);
            totalNetMovel = precoContrato * (descontoNetMovel / 100);
            totalTelemovel = precoContrato * (descontoTelemovel / 100);

            //total do valor do contrato
            total = precoContrato - (totalTelevisao + totalNetFixa + totalNetMovel + totalTelefone + totalTelemovel);
            contratos.PrecoContrato = total;
            cliente.PrecoContratos = contratos.PrecoContrato + cliente.PrecoContratos;
            if (contratos.DataInicio > DateTime.Today || contratos.DataInicio < DateTime.Today.AddDays(-90))
            {
                ModelState.AddModelError("DataInicio", "A data de ínicio do contrato deverá entre os 90 dias anteriores");
            }

            if (!ModelState.IsValid)
            {
                ViewData["DistritoId"] = new SelectList(_context.Distrito.Where(x => !x.DistritoNome.Contains("Nacional"))
              .OrderBy(x => x.DistritoNome), "DistritoId", "DistritoNome");
                ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratos.PacoteId);
                return View(CVM);
            }
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "Contrato adicionado com sucesso";
            return View("Sucesso");


        }


        //Atribuir promoção ao contrato AtribuirPromocao
        //GET
        public async Task<IActionResult> AtribuirPromocao(int? id)
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito.Where(x => !x.DistritoNome.Contains("Nacional"))
              .OrderBy(x => x.DistritoNome), "DistritoId", "DistritoNome");
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote");
            ContratoViewModel CVM = new ContratoViewModel();
            var contrato = await _context.Contratos.Include(p => p.ContratoPromoNetFixa).ThenInclude(p => p.PromoNetFixa)
                .Include(p => p.ContratoPromoNetMovel).ThenInclude(p => p.PromoNetMovel)
                .Include(p => p.ContratoPromoTelefone).ThenInclude(p => p.PromoTelefone)
                .Include(p => p.ContratoPromoTelemovel).ThenInclude(p => p.PromoTelemovel)
                .Include(p => p.ContratoPromoTelevisao).ThenInclude(p => p.PromoTelevisao)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ContratoId == id);

            var promocoesNetFixa = _context.PromoNetFixa.Where(e => e.Estado.Contains("On"));
            List<ContratoPromoNetFixa> listaContratosPromoNetFixa = new List<ContratoPromoNetFixa>();
            List<ContratoPromoNetMovel> listaContratosPromoNetMovel = new List<ContratoPromoNetMovel>();
            List<ContratoPromoTelefone> listaContratosPromoTelefone = new List<ContratoPromoTelefone>();
            List<ContratoPromoTelemovel> listaContratosPromoTelemovel = new List<ContratoPromoTelemovel>();
            List<ContratoPromoTelevisao> listaContratosPromoTelevisao = new List<ContratoPromoTelevisao>();
          //if (promocoesNetFixa.) { }
            CVM.ListaPromoNetFixa = _context.PromoNetFixa.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoNetFixaId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoNetFixa.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoNetMovel = _context.PromoNetMovel.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoNetMovelId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoNetMovel.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoTelefone = _context.PromoTelefone.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoTelefoneId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelefone.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoTelemovel = _context.PromoTelemovel.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoTelemovelId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelemovel.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoTelevisao = _context.PromoTelevisao.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoTelevisaoId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelevisao.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();

            var contratoOriginal = _context.Contratos.AsNoTracking().SingleOrDefault(m => m.ContratoId == id);

            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            CVM.ClienteId = contratoOriginal.ClienteId;
            CVM.DataInicio = contratoOriginal.DataInicio;

            CVM.PacoteId = contrato.PacoteId;
            CVM.Numeros = contrato.Numeros;
            CVM.Fidelizacao = contrato.Fidelizacao;
            CVM.ContratoId = (int)id;
            CVM.PrecoContrato = contrato.PrecoContrato;
            CVM.DistritoId = contrato.DistritoId;
            CVM.MoradaContrato = contrato.MoradaContrato;
            CVM.CodigoPostalCont = contrato.CodigoPostalCont;
            CVM.CodigoPostalExtCont = contrato.CodigoPostalExtCont;


            return View(CVM);

        }
        //POST
        [HttpPost]
        public async Task<IActionResult> AtribuirPromocao(int id, ContratoViewModel CVM, Contratos contratos)
        {
            var contratoOriginal = _context.Contratos.AsNoTracking().SingleOrDefault(m => m.ContratoId == id);

            var contrato = await _context.Contratos.Include(p => p.ContratoPromoNetFixa).ThenInclude(p => p.PromoNetFixa)
                .Include(p => p.ContratoPromoNetMovel).ThenInclude(p => p.PromoNetMovel)
                .Include(p => p.ContratoPromoTelefone).ThenInclude(p => p.PromoTelefone)
                .Include(p => p.ContratoPromoTelemovel).ThenInclude(p => p.PromoTelemovel)
                .Include(p => p.ContratoPromoTelevisao).ThenInclude(p => p.PromoTelevisao)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ContratoId == id);

            //Código que vai buscar o ID do funcionário que tem login feito e atribui automaticamente ao contrato
            var funcionario = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);
            contrato.FuncionarioId = funcionario.UsersId;

            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var cliente = _context.Users.SingleOrDefault(m => m.UsersId == contratoOriginal.ClienteId);
            contrato.ClienteId = contratoOriginal.ClienteId;
            contrato.DataInicio = contratoOriginal.DataInicio;

            List<ContratoPromoNetFixa> listaContratosPromoNetFixa = new List<ContratoPromoNetFixa>();
            List<ContratoPromoNetMovel> listaContratosPromoNetMovel = new List<ContratoPromoNetMovel>();
            List<ContratoPromoTelefone> listaContratosPromoTelefone = new List<ContratoPromoTelefone>();
            List<ContratoPromoTelemovel> listaContratosPromoTelemovel = new List<ContratoPromoTelemovel>();
            List<ContratoPromoTelevisao> listaContratosPromoTelevisao = new List<ContratoPromoTelevisao>();



            contrato.PacoteId = CVM.PacoteId;
            contrato.Numeros = CVM.Numeros;
            contrato.Fidelizacao = CVM.Fidelizacao;
            contrato.PrecoContrato = CVM.PrecoContrato;
            contrato.DistritoId = CVM.DistritoId;
            contrato.MoradaContrato = CVM.MoradaContrato;
            contrato.CodigoPostalCont = CVM.CodigoPostalCont;
            contrato.CodigoPostalExtCont = CVM.CodigoPostalExtCont;

            _context.Contratos.Update(contrato);
            await _context.SaveChangesAsync();

            cliente.PrecoContratos = cliente.PrecoContratos - contrato.PrecoContrato;

            int contratoId = contrato.ContratoId;
            decimal x1 = 0, x2 = 0, x3 = 0, x4 = 0, x5 = 0;
            decimal descontoNetFixas = 0, descontoNetMovel = 0, descontoTelefone = 0, descontoTelevisao = 0, descontoTelemovel = 0;

            
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
                    var netFixa = _context.PromoNetFixa.SingleOrDefault(n => n.PromoNetFixaId == item.PromoNetFixaId);
                    descontoNetFixas += netFixa.DescontoPrecoTotal;
                    x1++;
                    item.DataInicio = CVM.DataInicioPromoNetFixa;
                    item.DataFim = CVM.DataFimPromoNetFixa;

                    _context.ContratoPromoNetFixa.Add(item);
                    await _context.SaveChangesAsync();
                }
                if (descontoNetFixas > 50)
                {
                    descontoNetFixas = 50;
                }
                else
                {
                    if (x1 == 0)
                    {
                        x1 = 1;
                        descontoNetFixas = descontoNetFixas / x1;
                    }
                    else
                    {
                        descontoNetFixas = descontoNetFixas / x1;
                    }
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
                    var netMovel = _context.PromoNetMovel.SingleOrDefault(n => n.PromoNetMovelId == item.PromoNetMovelId);
                    descontoNetMovel += netMovel.DescontoPrecoTotal;
                    x2++;
                    item.DataInicio = CVM.DataInicioPromoNetMovel;
                    item.DataFim = CVM.DataFimPromoNetMovel;

                    _context.ContratoPromoNetMovel.Add(item);
                    await _context.SaveChangesAsync();
                }
                if (descontoNetMovel > 50)
                {
                    descontoNetMovel = 50;
                }
                else
                {
                    if (x2 == 0)
                    {
                        x2 = 1;
                        descontoNetMovel = descontoNetMovel / x2;
                    }
                    else
                    {
                        descontoNetMovel = descontoNetMovel / x2;
                    }
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
                    var netTelefone = _context.PromoTelefone.SingleOrDefault(n => n.PromoTelefoneId == item.PromoTelefoneId);
                    descontoTelefone += netTelefone.DescontoPrecoTotal;
                    x3++;
                    item.DataInicio = CVM.DataInicioPromoTelefone;
                    item.DataFim = CVM.DataFimPromoTelefone;
                    _context.ContratoPromoTelefone.Add(item);
                    await _context.SaveChangesAsync();
                }
                if (descontoTelefone > 50)
                {
                    descontoTelefone = 50;
                }
                else
                {
                    if (x3 == 0)
                    {
                        x3 = 1;
                        descontoTelefone = descontoTelefone / x3;
                    }
                    else
                    {
                        descontoTelefone = descontoTelefone / x3;
                    }
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
                    var Telemovel = _context.PromoTelemovel.SingleOrDefault(n => n.PromoTelemovelId == item.PromoTelemovelId);
                    descontoTelemovel += Telemovel.DecontoPrecoTotal;
                    x4++;
                    item.DataInicio = CVM.DataInicioPromoTelemovel;
                    item.DataFim = CVM.DataFimPromoTelemovel;
                    _context.ContratoPromoTelemovel.Add(item);
                    await _context.SaveChangesAsync();
                }
                if (descontoTelemovel > 50)
                {
                    descontoTelemovel = 50;
                }
                else
                {
                    if (x4 == 0)
                    {
                        x4 = 1;
                        descontoTelemovel = descontoTelemovel / x4;
                    }
                    else
                    {
                        descontoTelemovel = descontoTelemovel / x4;
                    }
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
                    var Televisao = _context.PromoTelevisao.SingleOrDefault(n => n.PromoTelevisaoId == item.PromoTelevisaoId);
                    descontoTelevisao += Televisao.DescontoPrecoTotal;
                    x5++;
                    item.DataInicio = CVM.DataInicioPromoTelevisao;
                    item.DataFim = CVM.DataFimPromoTelevisao;
                    _context.ContratoPromoTelevisao.Add(item);
                    await _context.SaveChangesAsync();
                }
                if (descontoTelevisao > 50)
                {
                    descontoTelevisao = 50;
                }
                else
                {
                    if (x5 == 0)
                    {
                        x5 = 1;
                        descontoTelevisao = descontoTelevisao / x5;
                    }
                    else
                    {
                        descontoTelevisao = descontoTelevisao / x5;
                    }
                }
            }

         

            //valor do contrato
            decimal precoContrato, totalNetFixa, totalTelemovel, totalNetMovel, totalTelevisao, totalTelefone, total;

            var pacote = _context.Pacotes.SingleOrDefault(p => p.PacoteId == contratos.PacoteId);

            precoContrato = pacote.PrecoTotal;


            //valor do desconto
            totalTelefone = precoContrato * (descontoTelefone / 100);
            totalNetFixa = precoContrato * (descontoNetFixas / 100);
            totalTelevisao = precoContrato * (descontoTelevisao / 100);
            totalNetMovel = precoContrato * (descontoNetMovel / 100);
            totalTelemovel = precoContrato * (descontoTelemovel / 100);

            //total do valor do contrato
            total = precoContrato - (totalTelevisao + totalNetFixa + totalNetMovel + totalTelefone + totalTelemovel);
            CVM.PrecoContrato = total;
            contrato.PrecoContrato = CVM.PrecoContrato;
            cliente.PrecoContratos = cliente.PrecoContratos + contrato.PrecoContrato;

            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "Contrato Editado com sucesso";
            return View("Sucesso");

        }


        // GET: Contratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito.Where(x => !x.DistritoNome.Contains("Nacional"))
              .OrderBy(x => x.DistritoNome), "DistritoId", "DistritoNome");
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote");
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

            CVM.ListaPromoNetFixa = _context.PromoNetFixa.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoNetFixaId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoNetFixa.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoNetMovel = _context.PromoNetMovel.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoNetMovelId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoNetMovel.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoTelefone = _context.PromoTelefone.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoTelefoneId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelefone.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoTelemovel = _context.PromoTelemovel.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoTelemovelId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelemovel.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoTelevisao = _context.PromoTelevisao.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoTelevisaoId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelevisao.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();

            var contratoOriginal = _context.Contratos.AsNoTracking().SingleOrDefault(m => m.ContratoId == id);

            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            CVM.ClienteId = contratoOriginal.ClienteId;
            CVM.DataInicio = contratoOriginal.DataInicio;

            CVM.PacoteId = contrato.PacoteId;
            CVM.Numeros = contrato.Numeros;
            CVM.Fidelizacao = contrato.Fidelizacao;
            CVM.ContratoId = (int)id;
            CVM.PrecoContrato = contrato.PrecoContrato;
            CVM.DistritoId = contrato.DistritoId;
            CVM.MoradaContrato = contrato.MoradaContrato;
            CVM.CodigoPostalCont = contrato.CodigoPostalCont;
            CVM.CodigoPostalExtCont = contrato.CodigoPostalExtCont;
            

            return View(CVM);

        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContratoViewModel CVM, Contratos contratos)
        {
            var contratoOriginal = _context.Contratos.AsNoTracking().SingleOrDefault(m => m.ContratoId == id);

            var contrato = await _context.Contratos.Include(p => p.ContratoPromoNetFixa).ThenInclude(p => p.PromoNetFixa)
                .Include(p => p.ContratoPromoNetMovel).ThenInclude(p => p.PromoNetMovel)
                .Include(p => p.ContratoPromoTelefone).ThenInclude(p => p.PromoTelefone)
                .Include(p => p.ContratoPromoTelemovel).ThenInclude(p => p.PromoTelemovel)
                .Include(p => p.ContratoPromoTelevisao).ThenInclude(p => p.PromoTelevisao)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ContratoId == id);
           
            //Código que vai buscar o ID do funcionário que tem login feito e atribui automaticamente ao contrato
            var funcionario = _context.Users.SingleOrDefault(c => c.Email == User.Identity.Name);
            contrato.FuncionarioId = funcionario.UsersId;

            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var cliente = _context.Users.SingleOrDefault(m => m.UsersId == contratoOriginal.ClienteId);
            contrato.ClienteId = contratoOriginal.ClienteId;
            contrato.DataInicio = contratoOriginal.DataInicio;

            List<ContratoPromoNetFixa> listaContratosPromoNetFixa = new List<ContratoPromoNetFixa>();
            List<ContratoPromoNetMovel> listaContratosPromoNetMovel = new List<ContratoPromoNetMovel>();
            List<ContratoPromoTelefone> listaContratosPromoTelefone = new List<ContratoPromoTelefone>();
            List<ContratoPromoTelemovel> listaContratosPromoTelemovel = new List<ContratoPromoTelemovel>();
            List<ContratoPromoTelevisao> listaContratosPromoTelevisao = new List<ContratoPromoTelevisao>();



            contrato.PacoteId = CVM.PacoteId;
            contrato.Numeros = CVM.Numeros;
            contrato.Fidelizacao = CVM.Fidelizacao;
            contrato.PrecoContrato = CVM.PrecoContrato;
            contrato.DistritoId= CVM.DistritoId;
            contrato.MoradaContrato = CVM.MoradaContrato  ;
            contrato.CodigoPostalCont = CVM.CodigoPostalCont;
            contrato.CodigoPostalExtCont = CVM.CodigoPostalExtCont;

            _context.Contratos.Update(contrato);
            await _context.SaveChangesAsync();
           
            cliente.PrecoContratos = cliente.PrecoContratos - contrato.PrecoContrato;
            
            int contratoId = contrato.ContratoId;
            decimal x1 = 0, x2 = 0, x3 = 0, x4 = 0, x5 = 0;
            decimal descontoNetFixa = 0, descontoNetMovel = 0, descontoTelefone = 0, descontoTelevisao = 0, descontoTelemovel = 0;

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
                        var netFixa = _context.PromoNetFixa.SingleOrDefault(n => n.PromoNetFixaId == promoNetFixa.PromoNetFixaId);
                        descontoNetFixa += netFixa.DescontoPrecoTotal;
                        x1++;
                        _context.ContratoPromoNetFixa.Add(promoNetFixa);
                        await _context.SaveChangesAsync();
                    }
                }
                if (descontoNetFixa > 50)
                {
                    descontoNetFixa = 50;
                }
                else
                {
                    if (x1 == 0)
                    {
                        x1 = 1;
                        descontoNetFixa = descontoNetFixa / x1;
                    }
                    else
                    {
                        descontoNetFixa = descontoNetFixa / x1;
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
                        var netMovel = _context.PromoNetMovel.SingleOrDefault(n => n.PromoNetMovelId == promoNetMovel.PromoNetMovelId);
                        descontoNetMovel += netMovel.DescontoPrecoTotal;
                        x2++;
                        _context.ContratoPromoNetMovel.Add(promoNetMovel);
                        await _context.SaveChangesAsync();
                    }
                }
                if (descontoNetMovel > 50)
                {
                    descontoNetMovel = 50;
                }
                else
                {
                    if (x2 == 0)
                    {
                        x2 = 1;
                        descontoNetMovel = descontoNetMovel / x2;
                    }
                    else
                    {
                        descontoNetMovel = descontoNetMovel / x2;
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
                        var telefone = _context.PromoTelefone.SingleOrDefault(n => n.PromoTelefoneId == promoTelefone.PromoTelefoneId);
                        descontoTelefone += telefone.DescontoPrecoTotal;
                        x3++;
                        _context.ContratoPromoTelefone.Add(promoTelefone);
                        await _context.SaveChangesAsync();
                    }
                }
                if (descontoTelefone > 50)
                {
                    descontoTelefone = 50;
                }
                else
                {
                    if (x3 == 0)
                    {
                        x3 = 1;
                        descontoTelefone = descontoTelefone / x3;
                    }
                    else
                    {
                        descontoTelefone = descontoTelefone / x3;
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
                        var telemovel = _context.PromoTelemovel.SingleOrDefault(n => n.PromoTelemovelId == promoTelemovel.PromoTelemovelId);
                        descontoTelemovel += telemovel.DecontoPrecoTotal;
                        x4++;
                        _context.ContratoPromoTelemovel.Add(promoTelemovel);
                        await _context.SaveChangesAsync();
                    }
                }
                if (descontoTelemovel > 50)
                {
                    descontoTelemovel = 50;
                }
                else
                {
                    if (x4 == 0)
                    {
                        x4 = 1;
                        descontoTelemovel = descontoTelemovel / x4;
                    }
                    else
                    {
                        descontoTelemovel = descontoTelemovel / x4;
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
                        var Televisao = _context.PromoTelevisao.SingleOrDefault(n => n.PromoTelevisaoId == promoTelevisao.PromoTelevisaoId);
                        descontoTelevisao += Televisao.DescontoPrecoTotal;
                        x5++; 
                        _context.ContratoPromoTelevisao.Add(promoTelevisao);
                        await _context.SaveChangesAsync();
                    }
                }
                if (descontoTelevisao > 50)
                {
                    descontoTelevisao = 50;
                }
                else
                {
                    if (x5 == 0)
                    {
                        x5 = 1;
                        descontoTelevisao = descontoTelevisao / x5;
                    }
                    else
                    {
                        descontoTelevisao = descontoTelevisao / x5;
                    }
                }
            }

            //valor do contrato
            decimal precoContrato, totalNetFixa, totalTelemovel, totalNetMovel, totalTelevisao, totalTelefone, total;

            var pacote = _context.Pacotes.SingleOrDefault(p => p.PacoteId == contratos.PacoteId);

            precoContrato = pacote.PrecoTotal;


            //valor do desconto
            totalTelefone = precoContrato * (descontoTelefone / 100);
            totalNetFixa = precoContrato * (descontoNetFixa / 100);
            totalTelevisao = precoContrato * (descontoTelevisao / 100);
            totalNetMovel = precoContrato * (descontoNetMovel / 100);
            totalTelemovel = precoContrato * (descontoTelemovel / 100);

            //total do valor do contrato
            total = precoContrato - (totalTelevisao + totalNetFixa + totalNetMovel + totalTelefone + totalTelemovel);
            CVM.PrecoContrato = total;
            contrato.PrecoContrato = CVM.PrecoContrato;
            cliente.PrecoContratos = cliente.PrecoContratos + contrato.PrecoContrato;

            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "Contrato Editado com sucesso";
            return View("Sucesso");
        
        }
       
        // GET: Contratos/EditVistaCliente/5
        public async Task<IActionResult> EditVistaCliente(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote");
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

            CVM.ListaPromoNetFixa = _context.PromoNetFixa.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoNetFixaId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoNetFixa.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoNetMovel = _context.PromoNetMovel.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoNetMovelId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoNetMovel.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoTelefone = _context.PromoTelefone.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoTelefoneId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelefone.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoTelemovel = _context.PromoTelemovel.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoTelemovelId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelemovel.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();
            CVM.ListaPromoTelevisao = _context.PromoTelevisao.Where(m => m.Estado.Contains("On") && m.DistritoId == contrato.DistritoId).Select(x => new CheckBox()
            {
                Id = x.PromoTelevisaoId,
                Nome = x.Nome,
                Selecionado = x.ContratoPromoTelevisao.Any(x => x.ContratoId == contrato.ContratoId) ? true : false
            }).ToList();

            var contratoOriginal = _context.Contratos.AsNoTracking().SingleOrDefault(m => m.ContratoId == id);

            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            CVM.ClienteId = contratoOriginal.ClienteId;
            CVM.DataInicio = contratoOriginal.DataInicio;

            CVM.PacoteId = contrato.PacoteId;
            CVM.Numeros = contrato.Numeros;
            CVM.Fidelizacao = contrato.Fidelizacao;
            CVM.ContratoId = (int)id;
            CVM.PrecoContrato = contrato.PrecoContrato;

            return View(CVM);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVistaCliente(int id, ContratoViewModel CVM, Contratos contratos)
        {

            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var contratoOriginal = _context.Contratos.AsNoTracking().SingleOrDefault(m => m.ContratoId == id);
            
            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            var cliente = _context.Users.SingleOrDefault(m => m.UsersId == contratoOriginal.ClienteId);
            contratos.ClienteId = cliente.UsersId;

            var contrato = await _context.Contratos.Include(p => p.ContratoPromoNetFixa).ThenInclude(p => p.PromoNetFixa)
                .Include(p => p.ContratoPromoNetMovel).ThenInclude(p => p.PromoNetMovel)
                .Include(p => p.ContratoPromoTelefone).ThenInclude(p => p.PromoTelefone)
                .Include(p => p.ContratoPromoTelemovel).ThenInclude(p => p.PromoTelemovel)
                .Include(p => p.ContratoPromoTelevisao).ThenInclude(p => p.PromoTelevisao)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ContratoId == id);

            contrato.ContratoId = contratoOriginal.ContratoId;
            contrato.FuncionarioId = contratoOriginal.FuncionarioId;
            contrato.EdicaoCliente = "Editado pelo cliente a " + DateTime.Now;

            //Código que vai buscar o ID do cliente atraves do cliente selecionado na vista SelectUser
            contrato.ClienteId = contratoOriginal.ClienteId;
            contrato.DataInicio = contratoOriginal.DataInicio;

            List<ContratoPromoNetFixa> listaContratosPromoNetFixa = new List<ContratoPromoNetFixa>();
            List<ContratoPromoNetMovel> listaContratosPromoNetMovel = new List<ContratoPromoNetMovel>();
            List<ContratoPromoTelefone> listaContratosPromoTelefone = new List<ContratoPromoTelefone>();
            List<ContratoPromoTelemovel> listaContratosPromoTelemovel = new List<ContratoPromoTelemovel>();
            List<ContratoPromoTelevisao> listaContratosPromoTelevisao = new List<ContratoPromoTelevisao>();



            contrato.PacoteId = CVM.PacoteId;
            contrato.Numeros = CVM.Numeros;
            contrato.Fidelizacao = CVM.Fidelizacao;
            contrato.PrecoContrato = CVM.PrecoContrato;
            contrato.DistritoId = contratoOriginal.DistritoId;
            contrato.MoradaContrato = contratoOriginal.MoradaContrato;
            contrato.CodigoPostalCont = contratoOriginal.CodigoPostalCont;
            contrato.CodigoPostalExtCont = contratoOriginal.CodigoPostalExtCont;

          
            _context.Contratos.Update(contrato);
            await _context.SaveChangesAsync();
            cliente.PrecoContratos = cliente.PrecoContratos - contrato.PrecoContrato;


            int contratoId = contrato.ContratoId;
            decimal x1 = 0, x2 = 0, x3 = 0, x4 = 0, x5 = 0;
            decimal descontoNetFixa = 0, descontoNetMovel = 0, descontoTelefone = 0, descontoTelevisao = 0, descontoTelemovel = 0;

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
                        var netFixa = _context.PromoNetFixa.SingleOrDefault(n => n.PromoNetFixaId == promoNetFixa.PromoNetFixaId);
                        descontoNetFixa += netFixa.DescontoPrecoTotal;
                        x1++;
                        _context.ContratoPromoNetFixa.Add(promoNetFixa);
                        await _context.SaveChangesAsync();
                    }
                }
                if (descontoNetFixa > 50)
                {
                    descontoNetFixa = 50;
                }
                else
                {
                    if (x1 == 0)
                    {
                        x1 = 1;
                        descontoNetFixa = descontoNetFixa / x1;
                    }
                    else
                    {
                        descontoNetFixa = descontoNetFixa / x1;
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
                        var netMovel = _context.PromoNetMovel.SingleOrDefault(n => n.PromoNetMovelId == promoNetMovel.PromoNetMovelId);
                        descontoNetMovel += netMovel.DescontoPrecoTotal;
                        x2++;
                        _context.ContratoPromoNetMovel.Add(promoNetMovel);
                        await _context.SaveChangesAsync();
                    }
                }
                if (descontoNetMovel > 50)
                {
                    descontoNetMovel = 50;
                }
                else
                {
                    if (x2 == 0)
                    {
                        x2 = 1;
                        descontoNetMovel = descontoNetMovel / x2;
                    }
                    else
                    {
                        descontoNetMovel = descontoNetMovel / x2;
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
                        var telefone = _context.PromoTelefone.SingleOrDefault(n => n.PromoTelefoneId == promoTelefone.PromoTelefoneId);
                        descontoTelefone += telefone.DescontoPrecoTotal;
                        x3++;
                        _context.ContratoPromoTelefone.Add(promoTelefone);
                        await _context.SaveChangesAsync();
                    }
                }
                if (descontoTelefone > 50)
                {
                    descontoTelefone = 50;
                }
                else
                {
                    if (x3 == 0)
                    {
                        x3 = 1;
                        descontoTelefone = descontoTelefone / x3;
                    }
                    else
                    {
                        descontoTelefone = descontoTelefone / x3;
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
                        var telemovel = _context.PromoTelemovel.SingleOrDefault(n => n.PromoTelemovelId == promoTelemovel.PromoTelemovelId);
                        descontoTelemovel += telemovel.DecontoPrecoTotal;
                        x4++;
                        _context.ContratoPromoTelemovel.Add(promoTelemovel);
                        await _context.SaveChangesAsync();
                    }
                }
                if (descontoTelemovel > 50)
                {
                    descontoTelemovel = 50;
                }
                else
                {
                    if (x4 == 0)
                    {
                        x4 = 1;
                        descontoTelemovel = descontoTelemovel / x4;
                    }
                    else
                    {
                        descontoTelemovel = descontoTelemovel / x4;
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
                        var Televisao = _context.PromoTelevisao.SingleOrDefault(n => n.PromoTelevisaoId == promoTelevisao.PromoTelevisaoId);
                        descontoTelevisao += Televisao.DescontoPrecoTotal;
                        x5++;
                        _context.ContratoPromoTelevisao.Add(promoTelevisao);
                        await _context.SaveChangesAsync();
                    }
                }
                if (descontoTelevisao > 50)
                {
                    descontoTelevisao = 50;
                }
                else
                {
                    if (x5 == 0)
                    {
                        x5 = 1;
                        descontoTelevisao = descontoTelevisao / x5;
                    }
                    else
                    {
                        descontoTelevisao = descontoTelevisao / x5;
                    }
                }
            }

            //valor do contrato
            decimal precoContrato, totalNetFixa, totalTelemovel, totalNetMovel, totalTelevisao, totalTelefone, total;

            var pacote = _context.Pacotes.SingleOrDefault(p => p.PacoteId == contratos.PacoteId);
           
            precoContrato = pacote.PrecoTotal;
           
            //valor do desconto
            totalTelefone = precoContrato * (descontoTelefone / 100);
            totalNetFixa = precoContrato * (descontoNetFixa / 100);
            totalTelevisao = precoContrato * (descontoTelevisao / 100);
            totalNetMovel = precoContrato * (descontoNetMovel / 100);
            totalTelemovel = precoContrato * (descontoTelemovel / 100);

            //total do valor do contrato
            total = precoContrato - (totalTelevisao + totalNetFixa + totalNetMovel + totalTelefone + totalTelemovel);
            CVM.PrecoContrato = total;
            contrato.PrecoContrato = CVM.PrecoContrato;
            cliente.PrecoContratos = cliente.PrecoContratos + contrato.PrecoContrato;

            if (id != contratos.ContratoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
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
                ViewBag.Mensagem = "Contrato alterado com sucesso";
                return View("SucessoCliente");
            }
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "NomePacote", contratos.PacoteId);
            
            return View(CVM);
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
                .Include(c => c.DistritoNome)
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
