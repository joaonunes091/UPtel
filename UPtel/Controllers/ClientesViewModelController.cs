using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UPtel.Data;
using UPtel.Models;

namespace UPtel.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class ClientesViewModelController : Controller
    {
        private readonly UPtelContext _context;
        private readonly UserManager<IdentityUser> _gestorUtilizadores;

        public ClientesViewModelController(UPtelContext context, UserManager<IdentityUser> gestorUtilizadores)
        {
            _context = context;
            _gestorUtilizadores = gestorUtilizadores;
        }

        // GET: ClientesViewModel
        public async Task<IActionResult> Index(int? id, ClientesViewModel cliente)
        {
            //Vai buscar email do utilizador com log in
            var userEmail = _gestorUtilizadores.GetUserName(HttpContext.User);

            //Vai buscar os dados pessoais do utilizador
            Users infoCliente = await _context.Users.SingleOrDefaultAsync(x => x.Email == userEmail);

            List<Contratos> listaContratos = new List<Contratos>();
            foreach (var contrato in _context.Contratos.Include(p => p.Pacote))
            {
                if (contrato.ClienteId == infoCliente.UsersId)
                {
                    listaContratos.Add(contrato);
                }
            }


            cliente = new ClientesViewModel
            {
                //Dados Pessoais
                Id = infoCliente.UsersId,
                NomeCliente = infoCliente.Nome,
                DataNascimento = infoCliente.Data,
                CartaoCidadao = infoCliente.CartaoCidadao,
                NumeroContribuinte = infoCliente.Contribuinte,
                Morada = infoCliente.Morada,
                CodiogoPostal = infoCliente.CodigoPostal,
                ExtensaoCodigoPostal = infoCliente.CodigoPostalExt,
                Telefone = infoCliente.Telefone,
                Telemovel = infoCliente.Telemovel,
                Email = infoCliente.Email,
                Fotografia = infoCliente.Fotografia,
                ListaContratos = listaContratos
            };

            return View(cliente);

        }

        public async Task<IActionResult> Details(int? id, ClientesViewModel cliente)
        {
            //Vai buscar email do utilizador com log in
            var userEmail = _gestorUtilizadores.GetUserName(HttpContext.User);

            //Vai buscar os dados pessoais do utilizador
            Users infoCliente = await _context.Users.SingleOrDefaultAsync(x => x.Email == userEmail);

            //Vai buscar as informações dos contratos
            List<Contratos> listaContratos = new List<Contratos>();
            foreach (var contrato in _context.Contratos.Include(p => p.Pacote))
            {
                if (contrato.ClienteId == infoCliente.UsersId)
                {
                    listaContratos.Add(contrato);
                }
            }

            Contratos infoContartos = listaContratos.FirstOrDefault(x => x.PacoteId == id);

            var funcionario = await _context.Users.SingleOrDefaultAsync(x => x.UsersId == infoContartos.FuncionarioId);
            var nomeFuncionario = funcionario.Nome;

            //Vai buscar as informações dos pacotes
            Pacotes infoPacotes = await _context.Pacotes.SingleOrDefaultAsync(x => x.PacoteId == infoContartos.PacoteId);

            var netFixaPacotes = await _context.NetFixa.SingleOrDefaultAsync(x => x.NetFixaId == infoPacotes.NetIfixaId);
            var nomeNetFixa = netFixaPacotes.Nome;

            var netMovelPacotes = await _context.NetMovel.SingleOrDefaultAsync(x => x.NetMovelId == infoPacotes.NetMovelId);
            var nomeNetMovel = netMovelPacotes.Nome;

            var telemovelPacotes = await _context.Telemovel.SingleOrDefaultAsync(x => x.TelemovelId == infoPacotes.TelemovelId);
            var nomeTelemovel = telemovelPacotes.Nome;

            var telefonePacotes = await _context.Telefone.SingleOrDefaultAsync(x => x.TelefoneId == infoPacotes.TelefoneId);
            var nomeTelefone = telefonePacotes.Nome;

            var televisaoPacotes = await _context.Televisao.SingleOrDefaultAsync(x => x.TelevisaoId == infoPacotes.TelevisaoId);
            var nomeTelevisao = televisaoPacotes.Nome;

            //Vai buscar as informações das promoções
            Promocoes infoPromocoes = await _context.Promocoes.SingleOrDefaultAsync(x => x.PromocaoId == infoContartos.PromocaoId);

            cliente = new ClientesViewModel
            {
                //Contrato
                NomeFuncionario = nomeFuncionario,
                DataInicio = infoContartos.DataInicio,
                NumerosAssociados = infoContartos.Numeros,
                Fidelizacao = infoContartos.Fidelizacao,
                TempoPromocao = infoContartos.TempoPromocao,
                PrecoContrato = infoContartos.PrecoContrato,
                //Pacotes
                NomePacote = infoPacotes.NomePacote,
                NetFixaPacote = nomeNetFixa,
                NetMovelPacote = nomeNetMovel,
                TelemovelPacote = nomeTelemovel,
                TelefonePacote = nomeTelefone,
                TelevisaoPacote = nomeTelevisao,
                PrecoPacote = infoPacotes.PrecoTotal,
                //Promoções
                NomePromocao = infoPromocoes.NomePromocao,
                DescricaoPromocao = infoPromocoes.Descricao,
                Desconto = infoPromocoes.Desconto
            };

            return View(cliente);
        }
        public IActionResult Sucesso()
        {
            return View();
        }
    }
}
