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
        [Required]
        [StringLength(9)]
        public string Numero { get; set; }
        public int LimiteMinutos { get; set; }
        [Column("LimiteSMS")]
        public int LimiteSms { get; set; }
        [Column(TypeName = "decimal(4, 2)")]
        public decimal PrecoMinutoNacional { get; set; }
        [Column(TypeName = "decimal(4, 2)")]
        public decimal PrecoMinutoInternacional { get; set; }
        [Column("PrecoSMS", TypeName = "decimal(4, 2)")]
        public decimal PrecoSms { get; set; }
        [Column("PrecoMMS", TypeName = "decimal(4, 2)")]
        public decimal PrecoMms { get; set; }

        [InverseProperty("TelemovelNavigation")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}
