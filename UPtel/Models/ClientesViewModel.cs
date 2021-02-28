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

        //Informação contrato

        //public string NomeFuncionario { get; set; }

        //public DateTime DataInicio { get; set; }

        //public int? Fidelizacao { get; set; }

        //public int? TempoPromocao { get; set; }

        //public decimal PrecoContrato { get; set; }
    }
}
