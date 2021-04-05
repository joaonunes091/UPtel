using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class FaturacaoOperador
    {
        
        [Key]
        public int FatOpId { get; set; }

        [Display(Name = "Data")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Display(Name = "Valor da faturação")]
        [Column(TypeName = "decimal(5, 2)")]        
        public decimal ValorMensalFat { get; set; }

        public int MesId { get; set; }

        [Display(Name ="Funcionário")]
        public int FuncinarioId { get; set; }

        [ForeignKey(nameof(MesId))]
        [InverseProperty(nameof(Meses.FaturacaoOperador))]
        [Display(Name = "Mês")]
        public virtual Meses Mes { get; set; }

        [ForeignKey("FuncionarioId")]
        public Users Users { get; set; }

    }
}
