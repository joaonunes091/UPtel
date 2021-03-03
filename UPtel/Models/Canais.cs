using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class Canais
    {
        public Canais()
        {
            PacoteCanais = new HashSet<PacoteCanais>();
        }

        [Key]
        public int CanaisId { get; set; }
       
        [Required(ErrorMessage = "É necessário colocar um nome para o canal")]
        [StringLength(20,ErrorMessage = "O limite de caracteres(20) foi ultrapassado")]
        [Display(Name = "Nome do canal")]
        public string NomeCanal { get; set; }

        public byte[] Foto { get; set; }

        [InverseProperty("Canais")]
        public virtual ICollection<PacoteCanais> PacoteCanais { get; set; }
    }
}
