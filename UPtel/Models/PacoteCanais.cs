﻿using System;
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

        [Required(ErrorMessage = "É necessário colocar o nome do pacote de televisão")]
        [Display(Name ="Pacote Televisão")]
        public int TelevisaoId { get; set; }


        [Required(ErrorMessage = "É necessário colocar o nome do canal")]
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
