﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Required(ErrorMessage = "É necessário colocar o nome do tarifário")]
        [Display(Name = "Tarifário")]
        [StringLength(45, ErrorMessage = "O limite de caracteres(45) foi ultrapassado")]
        //[RegularExpression(@"(2|1\d)\d{8}", ErrorMessage = "Telefone Inválido")]
        //[StringLength(9, MinimumLength = 9, ErrorMessage ="Telefone Inválido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário colocar o limite de minutos")]
        [Display(Name = "Limite de minutos")]
        [Range(0, 44640, ErrorMessage ="O número não é válido, o valor tem que estar entre 0 e 44640")]
        public int Limite { get; set; }


        [Required(ErrorMessage = "É necessário colocar o preço por minuto de chamadas nacionais")]
        [Display(Name = "Preço por minuto de chamadas nacionais")]
        [Column(TypeName = "decimal(4, 2)")]
        [Range(0,99, ErrorMessage ="O valor não é válido")]
        public decimal PrecoMinutoNacional { get; set; }

        internal static object ConvertAll(Func<object, SelectListItem> p)
        {
            throw new NotImplementedException();
        }

        [Required(ErrorMessage = "É necessário colocar o preço por minuto de chamadas internacionais")]
        [Display(Name = "Preço por minuto de chamadas internacionais")]
        [Column(TypeName = "decimal(4, 2)")]
        [Range(0, 99, ErrorMessage = "O valor não é válido")]
        public decimal PrecoMinutoInternacional { get; set; }

        [Display(Name = "Preço do pacote Telefone")]
        [Required(ErrorMessage = "Deve preencher o preço")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(1, 9999, ErrorMessage = "O valor não é válido")]
        public decimal PrecoPacoteTelefone { get; set; }

        [InverseProperty("Telefone")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}
