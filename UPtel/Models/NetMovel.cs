using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class NetMovel
    {
        public NetMovel()
        {
            Pacotes = new HashSet<Pacotes>();
        }

        [Key]
        public int NetMovelId { get; set; }

        [Display(Name = "Limite de plafond")]
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(1,999,ErrorMessage ="O valor não é válido")]
        public decimal Limite { get; set; }

        [Display(Name = "Preço do tarifário")]
        [Required(ErrorMessage = "Deve preencher o preço.")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(1, 9999, ErrorMessage = "O valor não é válido")]
        public decimal PrecoNetMovel { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Número")]
        [RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Telefone Inválido")]
        [StringLength(9, MinimumLength = 9)]
        public string Numero { get; set; }

        [StringLength(100)]
        public string Notas { get; set; }
        
        //[Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        //[Display(Name = "Número")]
        //[RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Telefone Inválido")]
        //[StringLength(9, MinimumLength = 9)]
        //public string Numero { get; set; }

        [InverseProperty("NetMovel")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}