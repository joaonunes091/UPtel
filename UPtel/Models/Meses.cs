using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class Meses
    {
        public Meses()
        {
            FaturacaoOperador = new HashSet<FaturacaoOperador>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MesId { get; set; }

        [Display(Name ="Mês")]
        public string Mes { get; set; }

        

        [InverseProperty("Mes")]
        public virtual ICollection<FaturacaoOperador> FaturacaoOperador { get; set; }

    }
}
