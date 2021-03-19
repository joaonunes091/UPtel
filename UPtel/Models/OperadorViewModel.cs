using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class OperadorViewModel 
    {
        public int Id { get; set; }

        //Dados Pessoais
        [Display(Name = "Nome")]
        public string NomeOperador { get; set; }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Número do cartão de cidadão")]
        public string CartaoCidadao { get; set; }

        [Display(Name = "Número de contribuinte")]
        public string NumeroContribuinte { get; set; }

        public string Morada { get; set; }

        [Display(Name = "Código postal")]
        public string CodiogoPostal { get; set; }

        public string ExtensaoCodigoPostal { get; set; }

        public string Telefone { get; set; }

        [Display(Name = "Telemóvel")]
        public string Telemovel { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public byte[] Fotografia { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataRegisto { get; set; }

        [Display(Name = "Distrito")]
        public virtual Distrito DistritoNome { get; set; }
    }
}
