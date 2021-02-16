using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class PacoteCanais
    {
        [Key]
        public int PacoteCanalId { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name ="Pacote Televisão")]
        public int TelevisaoId { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Canal")]
        public int CanaisId { get; set; }

        [ForeignKey(nameof(CanaisId))]
        [InverseProperty("PacoteCanais")]
        public virtual Canais Canais { get; set; }
        [ForeignKey(nameof(TelevisaoId))]
        [InverseProperty("PacoteCanais")]
        public virtual Televisao Televisao { get; set; }
    }
}
