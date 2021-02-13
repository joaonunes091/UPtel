﻿using System;
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
       
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Número de telefone")]
        [RegularExpression(@"(2|1\d)\d{8}", ErrorMessage = "Telefone Inválido")]
        //[StringLength(9, MinimumLength = 9)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Limite de minutos")]
        [Range(0, 44600, ErrorMessage ="O número não é válido, o valor tem que estar entre 0 e 44640")]
        public int Limite { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Preço por minuto de chamadas nacional")]
        [Column(TypeName = "decimal(4, 2)")]
        [Range(0,99, ErrorMessage ="O valor não é válido")]
        public decimal PrecoMinutoNacional { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Preço por minuto de chamadas internacionais")]
        [Column(TypeName = "decimal(4, 2)")]
        [Range(0, 99, ErrorMessage = "O valor não é válido")]
        public decimal PrecoMinutoInternacional { get; set; }

        [InverseProperty("Telefone")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}
