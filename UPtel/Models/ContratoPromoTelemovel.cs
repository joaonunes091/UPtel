using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class ContratoPromoTelemovel
    {
        [Key]
        public int ContratoPromoTelemovelId { get; set; }

        public int ContratoId { get; set; }

        public int PromoTelemovelId { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        [ForeignKey(nameof(ContratoId))]
        public virtual Contratos Contratos { get; set; }

        [ForeignKey(nameof(PromoTelemovelId))]
        public virtual PromoTelemovel PromoTelemovel { get; set; }
    }
}
