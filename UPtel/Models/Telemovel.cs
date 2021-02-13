using System;
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
       
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Número de telemóvel")]
        [RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Número de telemóvel inválido")]
        [StringLength(9, MinimumLength = 9,ErrorMessage ="Número de telemóvel inválido")]
        public string Numero { get; set; }
        
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Limite de minutos")]
        [Range(0, 44640,ErrorMessage ="O número não é válido, o valor tem que estar entre 0 e 44640.")]
        public int LimiteMinutos { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Limite de SMS")]
        [Column("LimiteSMS")]
        [Range(0,10000,ErrorMessage ="O número não é válido, o valor tem que estar entre 0 e 10000")]
        public int LimiteSms { get; set; }
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Preço por minuto de chamadas nacional")]
        [Column(TypeName = "decimal(4, 2)")]
        [Range(0,99,ErrorMessage ="Esse valor não é válido")]
        public decimal PrecoMinutoNacional { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Preço por minuto de chamadas internacionais")]
        [Column(TypeName = "decimal(4, 2)")]
        [Range(0, 99, ErrorMessage = "Esse valor não é válido")]
        public decimal PrecoMinutoInternacional { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Preço de SMS nacional")]
        [Column("PrecoSMS", TypeName = "decimal(4, 2)")]
        [Range(0, 99, ErrorMessage = "Esse valor não é válido")]
        public decimal PrecoSms { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Preço de MMS nacional")]
        [Column("PrecoMMS", TypeName = "decimal(4, 2)")]
        [Range(0, 99, ErrorMessage = "Esse valor não é válido")]
        public decimal PrecoMms { get; set; }

        [InverseProperty("Telemovel")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}
