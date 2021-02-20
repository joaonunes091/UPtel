using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class RegistoClienteViewModel
    {
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Nome do Cliente")]
        [StringLength(80, ErrorMessage = "O limite de caracteres(80) foi ultrapassado")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        //[Column(TypeName = "date")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Este valor é inválido")]
        [RegularExpression(@"\d{8}", ErrorMessage = "Este valor não é válido")]
        [Display(Name = "Número do Cartão de Cidadão")]
        public string CartaoCidadao { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Este valor é inválido")]
        [RegularExpression(@"\d{9}", ErrorMessage = "Este valor é inválido")]
        [Display(Name = "Número de Contribuinte")]
        public string Contribuinte { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(80, ErrorMessage = "O limite de caracteres(80) foi ultrapassado")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(4, MinimumLength = 4)]
        [Display(Name = "Código Postal")]
        [RegularExpression(@"([123456789]|1)\d{3}", ErrorMessage = "Valor inválido")]
        public string CodigoPostal { get; set; }

        [StringLength(9, MinimumLength = 9)]
        [RegularExpression(@"(2|1\d)\d{8}", ErrorMessage = "Telefone Inválido")]
        [Display(Name = "Número de telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(9, MinimumLength = 9)]
        [RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Telefone Inválido")]
        [Display(Name = "Número de telemóvel")]
        public string Telemovel { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "O limite de caracteres(50) foi ultrapassado")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(16)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirme a sua password")]
        //[Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [DataType(DataType.Password)]
        [StringLength(16)]
        [Compare("Password",ErrorMessage ="A passord não coincide.")]
        public string ConfirmePassword { get; set; }

        public int TipoClienteId { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(3, MinimumLength = 3)]
        [Display(Name = "Extensão do Código Postal")]
        [RegularExpression(@"\d{3}", ErrorMessage = "Este valor é inválido")]
        public string CodigoPostalExt { get; set; }
    }
}
