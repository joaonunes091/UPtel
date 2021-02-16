﻿using System;
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
        public int ContratoId { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public int PromocaoId { get; set; }
        public int PacoteId { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Data de início do contrato")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Fidelização")]
        public int? Fidelizacao { get; set; }

        [Display(Name = "Período de promoção")]
        public int? TempoPromocao { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Nome do Cliente")]
        [StringLength(80, ErrorMessage = "O limite de caracteres(80) foi ultrapassado")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Nome do pacote de serviços")]
        [StringLength(50, ErrorMessage = "O limite de caracteres(50) foi ultrapassado")]
        public string NomePacote { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Nome da promoção")]
        [StringLength(50, ErrorMessage = "O limite de caracteres(50) foi ultrapassado")]
        public string NomePromocao { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Nome do funcionário")]
        [StringLength(80, ErrorMessage = "O limite de caracteres(80) foi ultrapassado")]
        public string NomeFuncionario { get; set; }

        [Display(Name = "Valor total do contrato")]
        [Required(ErrorMessage = "Deve preencher o preço.")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(1, 9999, ErrorMessage = "O valor não é válido")]
        public decimal PrecoContrato { get; set; }


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
