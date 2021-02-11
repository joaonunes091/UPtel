using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class Contratos
    {
        [Key]
        public int Contrato { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public int PromocaoId { get; set; }
        public int PacoteId { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataInicio { get; set; }
        public int? Fidelizacao { get; set; }
        public int? TempoPromocao { get; set; }
        [Required]
        [StringLength(80)]
        public string NomeCliente { get; set; }
        [Required]
        [StringLength(50)]
        public string NomePacote { get; set; }
        [Required]
        [StringLength(50)]
        public string NomePromocao { get; set; }
        [Required]
        [StringLength(80)]
        public string NomeFuncionario { get; set; }

        [ForeignKey(nameof(ClienteId))]
        [InverseProperty(nameof(Clientes.Contratos))]
        public virtual Clientes Cliente { get; set; }
        [ForeignKey(nameof(FuncionarioId))]
        [InverseProperty(nameof(Funcionarios.Contratos))]
        public virtual Funcionarios Funcionario { get; set; }
        [ForeignKey(nameof(PacoteId))]
        [InverseProperty(nameof(Pacotes.Contratos))]
        public virtual Pacotes Pacote { get; set; }
        [ForeignKey(nameof(PromocaoId))]
        [InverseProperty(nameof(Promocoes.Contratos))]
        public virtual Promocoes Promocao { get; set; }
    }
}
