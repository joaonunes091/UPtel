using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    [Index(nameof(CartaoCidadao), Name = "IX_CartaoCidadaoFuncionarios", IsUnique = true)]
    [Index(nameof(Contribuinte), Name = "IX_ContribuinteFuncionarios", IsUnique = true)]
    [Index(nameof(Email), Name = "IX_EmailFuncionarios", IsUnique = true)]
    [Index(nameof(Telemovel), Name = "IX_TelemovelFuncionarios", IsUnique = true)]
    public partial class Funcionarios
    {
        public Funcionarios()
        {
            Contratos = new HashSet<Contratos>();
        }

        [Key]
        public int FuncionarioId { get; set; }
        [Required]
        [StringLength(80)]
        public string NomeFuncionario { get; set; }
        public int CargoId { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeCargo { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }
        [Required]
        [StringLength(9)]
        public string Contribuinte { get; set; }
        [Required]
        [StringLength(80)]
        public string Morada { get; set; }
        [Required]
        [StringLength(4)]
        public string CodigoPostal { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(9)]
        public string Telemovel { get; set; }
        [Required]
        [StringLength(8)]
        public string CartaoCidadao { get; set; }
        [Required]
        [Column("IBAN")]
        [StringLength(25)]
        public string Iban { get; set; }
        [Required]
        [StringLength(16)]
        public string Password { get; set; }
        [Required]
        [StringLength(10)]
        public string EstadoFuncionario { get; set; }
        [Required]
        [StringLength(3)]
        public string CodigoPostalExt { get; set; }
        public byte[] Fotografia { get; set; }

        [ForeignKey(nameof(CargoId))]
        [InverseProperty(nameof(Cargos.Funcionarios))]
        public virtual Cargos Cargo { get; set; }
        [InverseProperty("Funcionario")]
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
