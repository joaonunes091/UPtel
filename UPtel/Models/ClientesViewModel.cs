using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class ClientesViewModel
    {
        public int Id { get; set; }

        //Dados Pessoais

        public string NomeCliente { get; set; }

        public DateTime DataNascimento { get; set; }

        public string CartaoCidadao { get; set; }

        public string NumeroContribuinte { get; set; }

        public string Morada { get; set; }

        public string CodiogoPostal { get; set; }

        public string ExtensaoCodigoPostal { get; set; }

        public string Telefone { get; set; }

        public string Telemovel { get; set; }

        public string Email { get; set; }

        //Informação Contrato

        public string NomeFuncionario { get; set; }

        public DateTime DataInicio { get; set; }

        public int? Fidelizacao { get; set; }

        public int? TempoPromocao { get; set; }

        public decimal PrecoContrato { get; set; }

        public string NumerosAssociados { get; set; }

        //Informacao Pacote

        public string NomePacote { get; set; }

        public string NetFixaPacote { get; set; }

        public string NetMovelPacote { get; set; }

        public string TelemovelPacote { get; set; }

        public string TelefonePacote { get; set; }

        public string TelevisaoPacote { get; set; }

        public decimal PrecoPacote { get; set; }

        //Informação Promoções

        public string NomePromocao { get; set; }

        public string DescricaoPromocao { get; set; }

        public int PromocaoCanais { get; set; }

        public int Desconto { get; set; }
    }
}
