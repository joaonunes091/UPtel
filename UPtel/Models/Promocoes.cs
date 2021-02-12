﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class Promocoes
    {
        public Promocoes()
        {
            Contratos = new HashSet<Contratos>();
        }

        [Key]
        public int PromocaoId { get; set; }
      
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "O limite de carateres(50) foi ultrapassado")]
        [Display(Name = "Nome da Promoção")]
        public string NomePromocao { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Descrição")]
        [StringLength(100, ErrorMessage = "O limite de carateres(100) foi ultrapassado")]
        public string Descricao { get; set; }

        [InverseProperty("Promocao")]
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
