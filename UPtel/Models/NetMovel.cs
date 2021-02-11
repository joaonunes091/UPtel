﻿using System;
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
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Limite { get; set; }
        [StringLength(100)]
        public string Notas { get; set; }
        [Required]
        [StringLength(9)]
        public string Numero { get; set; }

        [InverseProperty("NetMovel")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}
