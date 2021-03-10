using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class ContratoPromoNetMovel
    {
        [Key]
        public int ContratoPromoNetMovelId { get; set; }

        public int ContratoId { get; set; }

        public int PromoNetMovelId { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        [ForeignKey(nameof(ContratoId))]
        public virtual Contratos Contratos { get; set; }

        [ForeignKey(nameof(PromoNetMovelId))]
        public virtual PromoNetMovel PromoNetMovel { get; set; }

    }
}
