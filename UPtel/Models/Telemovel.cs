﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class Telemovel
    {
        public Telemovel()
        {
            Pacotes = new HashSet<Pacotes>();
        }

        [Key]
        public int TelemovelId { get; set; }

        [Required(ErrorMessage = "É necessário colocar o nome do tarifário")]
        [Display(Name = "Tarifário")]
        [StringLength(45, ErrorMessage = "O limite de caracteres(45) foi ultrapassado")]
        //[RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Número de telemóvel inválido")]
        //[StringLength(9, MinimumLength = 9, ErrorMessage = "Número de telemóvel inválido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário colocar um limite de minutos")]
        [Display(Name = "Limite de minutos")]
        [Range(0, 44640,ErrorMessage ="O número não é válido, o valor tem que estar entre 0 e 44640.")]
        public int LimiteMinutos { get; set; }

        [Required(ErrorMessage = "É necessário olocar o limite de sms")]
        [Display(Name = "Limite de SMS")]
        [Column("LimiteSMS")]
        [Range(0,10000,ErrorMessage ="O número não é válido, o valor tem que estar entre 0 e 10000")]
        public int LimiteSms { get; set; }

        [Required(ErrorMessage = "É necessário colocar o preço por minuto de chamadas nacionais")]
        [Display(Name = "Preço por minuto de chamadas nacional")]
        [Column(TypeName = "decimal(4, 2)")]
        [Range(0,99,ErrorMessage ="Esse valor não é válido")]
        public decimal PrecoMinutoNacional { get; set; }

        [Required(ErrorMessage = "É necessário colocar o preço por minuto de chamadas internacionais")]
        [Display(Name = "Preço por minuto de chamadas internacionais")]
        [Column(TypeName = "decimal(4, 2)")]
        [Range(0, 99, ErrorMessage = "Esse valor não é válido")]
        public decimal PrecoMinutoInternacional { get; set; }

        [Required(ErrorMessage = "Deve colocar o preço por SMS nacional")]
        [Display(Name = "Preço de SMS nacional")]
        [Column("PrecoSMS", TypeName = "decimal(4, 2)")]
        [Range(0, 99, ErrorMessage = "Esse valor não é válido")]
        public decimal PrecoSms { get; set; }

        [Required(ErrorMessage = "Deve colocar o preço por MMS nacional")]
        [Display(Name = "Preço de MMS nacional")]
        [Column("PrecoMMS", TypeName = "decimal(4, 2)")]
        [Range(0, 99, ErrorMessage = "Esse valor não é válido")]
        public decimal PrecoMms { get; set; }

        [Display(Name = "Preço do pacote Telemóvel")]
        [Required(ErrorMessage = "Deve preencher o preço.")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(1, 9999, ErrorMessage = "O valor não é válido")]
        public decimal PrecoPacoteTelemovel { get; set; }

        [InverseProperty("Telemovel")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}
