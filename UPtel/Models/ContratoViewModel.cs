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

        [Display(Name = "Nome de cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Nome de funcionário")]
        public int FuncionarioId { get; set; }
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

        [Display(Name = "Valor total do contrato")]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal PrecoContrato { get; set; }

        public List<CheckBox> ListaPromoNetFixa { get; set; }
        public List<CheckBox> ListaPromoNetMovel { get; set; }
        public List<CheckBox> ListaPromoTelefone { get; set; }
        public List<CheckBox> ListaPromoTelemovel { get; set; }
        public List<CheckBox> ListaPromoTelevisao { get; set; }
    }
}
