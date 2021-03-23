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
    public partial class Contratos
    {
        public Contratos()
        {
            Fatura = new HashSet<FaturaCliente>();
        }

        [Key]
        [Display(Name ="Nome de contrato")]
        public int ContratoId { get; set; }

        [Display(Name ="Nome de cliente")]
        public int ClienteId { get; set; }
        
        [Display(Name ="Nome de funcionário")]
        public int FuncionarioId { get; set; }
        
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

        public int? Posicao { get; set; }

        [StringLength(300, ErrorMessage = "O limite de caracteres(300) foi ultrapassado")]
        public string EdicaoCliente { get; set; }

        [Display(Name = "Valor total do contrato")]
        //[Required(ErrorMessage = "É necessário preencher o preço.")]
        [Column(TypeName = "decimal(5, 2)")]
        //[Range(1, 9999, ErrorMessage = "O valor não é válido")]
        public decimal PrecoContrato { get; set; }

        [Required(ErrorMessage = "É necessário colocar a morada")]
        [StringLength(80, ErrorMessage = "O limite de caracteres(80) foi ultrapassado")]
        [Display(Name = "Morada")]
        public string MoradaContrato { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(4, MinimumLength = 4)]
        [Display(Name = "Código Postal")]
        [RegularExpression(@"([123456789]|1)\d{3}", ErrorMessage = "Valor inválido")]
        public string CodigoPostalCont { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(3, MinimumLength = 3)]
        [Display(Name = "Extensão do Código Postal")]
        [RegularExpression(@"\d{3}", ErrorMessage = "Este valor é inválido")]
        public string CodigoPostalExtCont { get; set; }

        [Display(Name = "Distrito")]
        public int DistritoId { get; set; }


        [ForeignKey(nameof(DistritoId))]
        [InverseProperty(nameof(Distrito.Contratos))]
        [Display(Name = "Distrito")]
        public virtual Distrito DistritoNome { get; set; }

        [ForeignKey(nameof(ClienteId))]
        [InverseProperty(nameof(Users.ContratosCliente))]
        public virtual Users Cliente { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        [InverseProperty(nameof(Users.ContratosFuncionario))]
        public virtual Users Funcionario { get; set; }

        [ForeignKey(nameof(PacoteId))]
        [InverseProperty(nameof(Pacotes.Contratos))]
        public virtual Pacotes Pacote { get; set; }


        [InverseProperty("Fatura")]
        public virtual ICollection<FaturaCliente> Fatura { get; set; }

        public virtual ICollection<ContratoPromoNetFixa> ContratoPromoNetFixa { get; set; }
        public virtual ICollection<ContratoPromoNetMovel> ContratoPromoNetMovel { get; set; }
        public virtual ICollection<ContratoPromoTelefone> ContratoPromoTelefone { get; set; }
        public virtual ICollection<ContratoPromoTelemovel> ContratoPromoTelemovel { get; set; }
        public virtual ICollection<ContratoPromoTelevisao> ContratoPromoTelevisao { get; set; }


    }
}

