using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class ContratoViewModel
    {
        public int ContratoId { get; set; }
        public string NomeContrato { get; set; }


        [Display(Name = "Nome de cliente")]
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }

        [Display(Name = "Nome de funcionário")]
        public int FuncionarioId { get; set; }
        public string NomeFuncionario { get; set; }

        [Display(Name = "Nome da promoção")]
        public int PromocaoId { get; set; }
        [Display(Name = "Nome do pacote")]
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

        [Display(Name = "Valor total do contrato")]
        [Column(TypeName = "decimal(5, 2)")]
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

        [Display(Name = "Distrito")]
        public string DistritoNome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInicioPromoNetFixa { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFimPromoNetFixa { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInicioPromoNetMovel { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFimPromoNetMovel { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInicioPromoTelefone { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFimPromoTelefone { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInicioPromoTelemovel { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFimPromoTelemovel { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInicioPromoTelevisao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFimPromoTelevisao { get; set; }

        [ForeignKey(nameof(DistritoId))]
        [InverseProperty(nameof(Distrito.Contratos))]
        [Display(Name = "Distrito")]
        public virtual Distrito DistritoNomes { get; set; }

        [ForeignKey(nameof(ClienteId))]
        [InverseProperty(nameof(Users.ContratosCliente))]
        public virtual Users Cliente { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        [InverseProperty(nameof(Users.ContratosFuncionario))]
        public virtual Users Funcionario { get; set; }

        [ForeignKey(nameof(PacoteId))]
        [InverseProperty(nameof(Pacotes.Contratos))]
        public virtual Pacotes Pacote { get; set; }

        public List<CheckBox> ListaPromoNetFixa { get; set; }
        public List<CheckBox> ListaPromoNetMovel { get; set; }
        public List<CheckBox> ListaPromoTelefone { get; set; }
        public List<CheckBox> ListaPromoTelemovel { get; set; }
        public List<CheckBox> ListaPromoTelevisao { get; set; }
    }
}
