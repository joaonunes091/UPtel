﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            Users = new HashSet<Users>();
            Contratos = new HashSet<Contratos>();
            PromoNetFixa = new HashSet<PromoNetFixa>();
            PromoNetMovel = new HashSet<PromoNetMovel>();
            PromoTelefone = new HashSet<PromoTelefone>();
            PromoTelemovel = new HashSet<PromoTelemovel>();
            PromoTelevisao = new HashSet<PromoTelevisao>();
        }
        [Key]
        public int DistritoId { get; set; }

        [Required(ErrorMessage = "É necessário colocar um distrito")]
        [StringLength(30, ErrorMessage = "O limite de carateres(30) foi ultrapassado")]
        public string DistritoNome { get; set; }

        [InverseProperty("DistritoNome")]
        public virtual ICollection<Users> Users { get; set; }

        [InverseProperty("DistritoNome")]
        public virtual ICollection<Contratos> Contratos { get; set; }
        
        [InverseProperty("DistritoNome")]
        public virtual ICollection<PromoNetFixa> PromoNetFixa { get; set; }

        [InverseProperty("DistritoNome")]
        public virtual ICollection<PromoNetMovel> PromoNetMovel { get; set; }

        [InverseProperty("DistritoNome")]
        public virtual ICollection<PromoTelefone> PromoTelefone { get; set; }

        [InverseProperty("DistritoNome")]
        public virtual ICollection<PromoTelemovel> PromoTelemovel { get; set; }

        [InverseProperty("DistritoNome")]
        public virtual ICollection<PromoTelevisao> PromoTelevisao { get; set; }

    }
}
