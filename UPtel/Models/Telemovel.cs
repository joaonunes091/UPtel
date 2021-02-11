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
        [RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Telefone Inválido")]
        [StringLength(9, MinimumLength = 9)]
        public string Numero { get; set; }
        
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Limite de minutos")]
        public int LimiteMinutos { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Limite de SMS")]
        [Column("LimiteSMS")]
        public int LimiteSms { get; set; }
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Preço por minuto de chamadas nacional")]
        [Column(TypeName = "decimal(4, 2)")]
        public decimal PrecoMinutoNacional { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Preço por minuto de chamadas internacionais")]
        [Column(TypeName = "decimal(4, 2)")]
        public decimal PrecoMinutoInternacional { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Preço de SMS nacional")]
        [Column("PrecoSMS", TypeName = "decimal(4, 2)")]
        public decimal PrecoSms { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Preço de MMS nacional")]
        [Column("PrecoMMS", TypeName = "decimal(4, 2)")]
        public decimal PrecoMms { get; set; }

        [InverseProperty("TelemovelNavigation")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}
