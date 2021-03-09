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

        public ICollection<Contratos> Contratos { get; set; }
    }
}
