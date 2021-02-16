using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class Pacotes
    {
        public Pacotes()
        {
            Contratos = new HashSet<Contratos>();
        }

        [Key]
        public int PacoteId { get; set; }
       
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name ="Nome do pacote")]
        [StringLength(50, ErrorMessage = "O limite de caracteres(50) foi ultrapassado")]
        public string NomePacote { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Preço do pacote")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(1, 9999, ErrorMessage = "O valor não é válido")]
        //problema dos numero decimais?
        public decimal PrecoTotal { get; set; }
        public int? TelevisaoId { get; set; }
        public int? TelemovelId { get; set; }
        [Column("NetIFixaId")]
        public int? NetIfixaId { get; set; }
        public int? TelefoneId { get; set; }
        public int? NetMovelId { get; set; }

        [ForeignKey(nameof(NetIfixaId))]
        [InverseProperty(nameof(NetFixa.Pacotes))]
        public virtual NetFixa NetIfixa { get; set; }
        [ForeignKey(nameof(NetMovelId))]
        [InverseProperty("Pacotes")]
        public virtual NetMovel NetMovel { get; set; }

        [ForeignKey(nameof(TelemovelId))]
        [InverseProperty("Pacotes")]
        public virtual Telemovel Telemovel { get; set; }

        [ForeignKey(nameof(TelefoneId))]
        [InverseProperty("Pacotes")]
        public virtual Telefone Telefone { get; set; }

        [ForeignKey(nameof(TelevisaoId))]
        [InverseProperty("Pacotes")]
        public virtual Televisao Televisao { get; set; }

        [InverseProperty("Pacote")]
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
