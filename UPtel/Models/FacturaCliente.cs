using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class FaturaCliente
    {
        [Key]
        public int NrFaturaId { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime DataEmissao { get; set; }

        [Display(Name = "Contrato")]
        public int ContratoId { get; set; }

        public string Morada { get; set; }
       
        [Display(Name = "Nome do Cliente")]
        public string NomeCliente { get; set; }

        [Display(Name = "Pacote")]
        public int PacoteId { get; set; }

        [Display(Name = "Valor a pagar")]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal PrecoContrato { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }



        [ForeignKey(nameof(ContratoId))]
        [InverseProperty("Fatura")]
        public virtual Contratos Fatura { get; set; }


    }
}

