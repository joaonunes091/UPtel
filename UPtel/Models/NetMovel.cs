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
        [Required(ErrorMessage = "É necessário colocar um limite de plafond")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(1,999,ErrorMessage ="O valor não é válido")]
        public decimal Limite { get; set; }

        [Display(Name = "Preço do tarifário")]
        [Required(ErrorMessage = "Deve preencher o preço.")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(1, 9999, ErrorMessage = "O valor não é válido")]
        public decimal PrecoNetMovel { get; set; }

        [Required(ErrorMessage = "É necessário colocar o nome do tarifário")]
        [Display(Name = "Tarifário")]
        [StringLength(45, ErrorMessage = "O limite de caracteres(45) foi ultrapassado")]
        //[RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Telemóvel Inválido")]
        //[StringLength(9, MinimumLength = 9, ErrorMessage ="O número deve ter 9 dígitos")]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Notas { get; set; }
        
        [InverseProperty("NetMovel")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}