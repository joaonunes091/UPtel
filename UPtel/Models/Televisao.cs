using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class Televisao
    {
        public Televisao()
        {
            PacoteCanais = new HashSet<PacoteCanais>();
            Pacotes = new HashSet<Pacotes>();
        }

        [Key]
        public int TelevisaoId { get; set; }
        [Required]
        [StringLength(20)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string Descricao { get; set; }

        [InverseProperty("Televisao")]
        public virtual ICollection<PacoteCanais> PacoteCanais { get; set; }
        [InverseProperty("Televisao")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}
