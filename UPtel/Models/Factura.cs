using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class Fatura
    {
        public int NrFaturaId { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime DataEmissao { get; set; }

        public int ContratoId { get; set; }

        public string Morada { get; set; }

        public string NomeCliente { get; set; }

        public int PacoteId { get; set; }

        public decimal PrecoContrato { get; set; }

        public string Descricao { get; set; }



        [ForeignKey(nameof(ContratoId))]
        [InverseProperty(nameof(Contratos.ContratoId))]
        public virtual Contratos Contrato { get; set; }


    }
}
