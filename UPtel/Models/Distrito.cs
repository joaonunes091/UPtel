using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            Users = new HashSet<Users>();
            Contratos = new HashSet<Contratos>();
            PromoNetFixa = new HashSet<PromoNetFixa>();
        }
        [Key]
        public int DistritoId { get; set; }

        [Required(ErrorMessage = "É necessário colocar um distrito")]
        [StringLength(30, ErrorMessage = "O limite de carateres(30) foi ultrapassado")]
        public string DistritoNome { get; set; }

        [InverseProperty("DistritoNome")]
        public virtual ICollection<Users> Users { get; set; }

        [InverseProperty("DistritoNome")]
        public virtual ICollection<Contratos> Contratos { get; set; }
        
        [InverseProperty("DistritoNome")]
        public virtual ICollection<PromoNetFixa> PromoNetFixa { get; set; }
    }
}
