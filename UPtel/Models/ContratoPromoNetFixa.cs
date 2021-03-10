using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class ContratoPromoNetFixa
    {
        [Key]
        public int ContratoPromoNetFixaId { get; set; }

        public int ContratoId { get; set; }

        public int PromoNetFixaId { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        [ForeignKey(nameof(ContratoId))]
        public virtual Contratos Contratos { get; set; }

        [ForeignKey(nameof(PromoNetFixaId))]
        public virtual PromoNetFixa PromoNetFixa { get; set; }

    }
}
