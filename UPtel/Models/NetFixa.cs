using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class NetFixa
    {
        public NetFixa()
        {
            Pacotes = new HashSet<Pacotes>();
        }

        [Key]
        public int NetFixaId { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Limite { get; set; }
        public int Velocidade { get; set; }
        [Required]
        [StringLength(30)]
        public string TipoConexao { get; set; }
        [StringLength(100)]
        public string Notas { get; set; }

        [InverseProperty("NetIfixa")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}
