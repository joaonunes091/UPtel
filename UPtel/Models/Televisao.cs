using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class Televisao
    {
        public Televisao()
        {
            PacoteCanais = new HashSet<PacoteCanais>();
            Pacotes = new HashSet<Pacotes>();
        }

        [Key]
        public int TelevisaoId { get; set; }
       
        [Required(ErrorMessage = "É necessário colocar o nome do pacote de canais")]
        [Display(Name = "Nome pacote de canais")]
        [StringLength(20, ErrorMessage = "O limite de carateres(20) foi ultrapassado")]
        public string Nome { get; set; }
        
        [StringLength(100, ErrorMessage = "O limite de carateres(100) foi ultrapassado")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Preço do pacote Televisão")]
        [Required(ErrorMessage = "Deve preencher o preço.")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(1, 9999, ErrorMessage = "O valor não é válido")]
        public decimal PrecoPacoteTelevisao { get; set; }

        [InverseProperty("Televisao")]
        public virtual ICollection<PacoteCanais> PacoteCanais { get; set; }
        [InverseProperty("Televisao")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}
