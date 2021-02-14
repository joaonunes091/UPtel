﻿using System;
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
       
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(20,ErrorMessage ="O nome do canal precisa de ter menos de 20 caracteres")]
        [Display(Name = "Nome do canal")]
        public string NomeCanal { get; set; }

        public byte[] Foto { get; set; }

        [InverseProperty("Canais")]
        public virtual ICollection<PacoteCanais> PacoteCanais { get; set; }
    }
}
