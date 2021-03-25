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
        
        [StringLength(300, ErrorMessage = "O limite de carateres(300) foi ultrapassado")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }


        [Display(Name = "Distrito")]
        public int DistritoId { get; set; }

        public string DistritoNomes { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }

        [ForeignKey(nameof(DistritoId))]
        [InverseProperty(nameof(Distrito.PromoTelemovel))]
        [Display(Name = "Distrito")]
        public virtual Distrito DistritoNome { get; set; }


        public virtual ICollection<ContratoPromoTelemovel> ContratoPromoTelemovel { get; set; }
    }
}
