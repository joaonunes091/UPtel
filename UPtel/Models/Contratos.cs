using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    [Index(nameof(ClienteId), Name = "IX_Contratos_ClienteId")]
    [Index(nameof(FuncionarioId), Name = "IX_Contratos_FuncionarioId")]
    [Index(nameof(PacoteId), Name = "IX_Contratos_PacoteId")]
    [Index(nameof(PromocaoId), Name = "IX_Contratos_PromocaoId")]
    public partial class Contratos
    {
        [Key]
        [Display(Name ="Nome de contrato")]
        public int ContratoId { get; set; }

        [Display(Name ="Nome de cliente")]
        public int ClienteId { get; set; }
        [Display(Name ="Nome de funcionário")]
        public int FuncionarioId { get; set; }
        [Display(Name ="Nome da promoção")]
        public int PromocaoId { get; set; }
        [Display(Name ="Nome do pacote")]
        public int PacoteId { get; set; }

        [StringLength(300, ErrorMessage = "O limite de caracteres(300) foi ultrapassado")]
        [Display(Name = "Números associados")]
        public string Numeros { get; set; }

        [Required(ErrorMessage = "É necessário colocar uma data para o início de contrato")]
        [Display(Name = "Data de início do contrato")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Fidelização")]
        public int? Fidelizacao { get; set; }

        [Display(Name = "Período de promoção")]
        public int? TempoPromocao { get; set; }


        [Display(Name = "Valor total do contrato")]
        //[Required(ErrorMessage = "É necessário preencher o preço.")]
        [Column(TypeName = "decimal(5, 2)")]
        //[Range(1, 9999, ErrorMessage = "O valor não é válido")]
        public decimal PrecoContrato { get; set; }


        [ForeignKey(nameof(ClienteId))]
        [InverseProperty(nameof(Users.ContratosCliente))]
        public virtual Users Cliente { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        [InverseProperty(nameof(Users.ContratosFuncionario))]
        public virtual Users Funcionario { get; set; }

        [ForeignKey(nameof(PacoteId))]
        [InverseProperty(nameof(Pacotes.Contratos))]
        public virtual Pacotes Pacote { get; set; }

        [ForeignKey(nameof(PromocaoId))]
        [InverseProperty(nameof(Promocoes.Contratos))]
        public virtual Promocoes Promocao { get; set; }
    }
}

//[Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//[Display(Name = "Nome do Cliente")]
//[StringLength(80, ErrorMessage = "O limite de caracteres(80) foi ultrapassado")]
//public string NomeCliente { get; set; }

//[Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//[Display(Name = "Nome do pacote de serviços")]
//[StringLength(50, ErrorMessage = "O limite de caracteres(50) foi ultrapassado")]
//public string NomePacote { get; set; }

//[Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//[Display(Name = "Nome da promoção")]
//[StringLength(50, ErrorMessage = "O limite de caracteres(50) foi ultrapassado")]
//public string NomePromocao { get; set; }

//[Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//[Display(Name = "Nome do funcionário")]
//[StringLength(80, ErrorMessage = "O limite de caracteres(80) foi ultrapassado")]
//public string NomeFuncionario { get; set; }
