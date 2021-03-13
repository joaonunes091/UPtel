using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class PromoTelefone
    {
        [Key]
        public int PromoTelefoneId { get; set; }

        public string Nome { get; set; }

        public int Limite { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal DescontoMinNacional { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal DescontoMinInternacional { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal DescontoPrecoTotal { get; set; }

        [StringLength(300, ErrorMessage = "O limite de carateres(300) foi ultrapassado")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public virtual ICollection<ContratoPromoTelefone> ContratoPromoTelefone { get; set; }
    }
}
