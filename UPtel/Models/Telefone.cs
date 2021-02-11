using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class Telefone
    {
        public Telefone()
        {
            Pacotes = new HashSet<Pacotes>();
        }

        [Key]
        public int TelefoneId { get; set; }
        [Required]
        [StringLength(9)]
        public string Numero { get; set; }
        public int Limite { get; set; }
        [Column(TypeName = "decimal(4, 2)")]
        public decimal PrecoMinutoNacional { get; set; }
        [Column(TypeName = "decimal(4, 2)")]
        public decimal PrecoMinutoInternacional { get; set; }

        [InverseProperty("Telemovel")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}
