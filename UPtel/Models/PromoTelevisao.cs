using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class PromoTelevisao
    {
        [Key]
        public int PromoTelevisaoId { get; set; }

        public string Nome { get; set; }

        public int CanaisGratis { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal DescontoPrecoTotal { get; set; }
       
        [StringLength(300, ErrorMessage = "O limite de carateres(300) foi ultrapassado")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Distrito")]
        public int DistritoId { get; set; }

        public string DistritoNomes { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }

        [ForeignKey(nameof(DistritoId))]
        [InverseProperty(nameof(Distrito.PromoTelevisao))]
        [Display(Name = "Distrito")]
        public virtual Distrito DistritoNome { get; set; }


        public virtual ICollection<ContratoPromoTelevisao> ContratoPromoTelevisao { get; set; }
    }
}
