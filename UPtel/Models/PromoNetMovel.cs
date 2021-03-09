using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class PromoNetMovel
    {
        [Key]
        public int PromoNetMovelId { get; set; }

        public string Nome { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Limite { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public int DescontoPrecoTotal { get; set; }

        public ICollection<Contratos> Contratos { get; set; }
    }
}
