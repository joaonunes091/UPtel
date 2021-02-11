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
        [Required]
        [StringLength(50)]
        public string NomePacote { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Preco { get; set; }
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
        [InverseProperty(nameof(Telefone.Pacotes))]
        public virtual Telefone Telemovel { get; set; }
        [ForeignKey(nameof(TelemovelId))]
        [InverseProperty("Pacotes")]
        public virtual Telemovel TelemovelNavigation { get; set; }
        [ForeignKey(nameof(TelevisaoId))]
        [InverseProperty("Pacotes")]
        public virtual Televisao Televisao { get; set; }
        [InverseProperty("Pacote")]
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
