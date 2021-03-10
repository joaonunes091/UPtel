using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class PromoTelemovel
    {
        [Key]
        public int PromoTelemovelId { get; set; }

        public string Nome { get; set; }

        public int LimiteMinutos { get; set; }

        public int LimiteSMS { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal DecontoPrecoMinNacional { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal DecontoPrecoMinInternacional { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal DecontoPrecoSMS { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal DecontoPrecoMMS { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal DecontoPrecoTotal { get; set; }

        public virtual ICollection<ContratoPromoTelemovel> ContratoPromoTelemovel { get; set; }
    }
}
