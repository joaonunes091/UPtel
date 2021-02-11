﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    [Index(nameof(CartaoCidadao), Name = "IX_CartaoCidadaoClientes", IsUnique = true)]
    [Index(nameof(Contribuinte), Name = "IX_ContribuinteClientes", IsUnique = true)]
    public partial class Clientes
    {
        public Clientes()
        {
            Contratos = new HashSet<Contratos>();
        }

        [Key]
        public int ClienteId { get; set; }
        [Required]
        [StringLength(80)]
        public string NomeCliente { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }
        [Required]
        [StringLength(8)]
        public string CartaoCidadao { get; set; }
        [Required]
        [StringLength(9)]
        public string Contribuinte { get; set; }
        [Required]
        [StringLength(80)]
        public string Morada { get; set; }
        [Required]
        [StringLength(4)]
        public string CodigoPostal { get; set; }
        [StringLength(9)]
        public string Telefone { get; set; }
        [Required]
        [StringLength(9)]
        public string Telemovel { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(16)]
        public string Password { get; set; }
        public int TipoClienteId { get; set; }
        [Required]
        [StringLength(3)]
        public string CodigoPostalExt { get; set; }

        [ForeignKey(nameof(TipoClienteId))]
        [InverseProperty(nameof(TipoClientes.Clientes))]
        public virtual TipoClientes TipoCliente { get; set; }
        [InverseProperty("Cliente")]
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
