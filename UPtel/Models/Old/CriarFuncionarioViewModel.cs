//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace UPtel.Models
//{
//    public class CriarFuncionarioViewModel
//    {
//        [Key]
//        public int FuncionarioId { get; set; }

//        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//        [StringLength(80, ErrorMessage = "O limite de caracteres(80) foi ultrapassado")]
//        [Display(Name = "Nome de funcionário")]
//        public string NomeFuncionario { get; set; }

//        [Display(Name = "Cargo")]
//        public int CargoId { get; set; }

//        [Column(TypeName = "date")]
//        [Display(Name = "Data de nascimento")]
//        [DataType(DataType.Date)]
//        public DateTime DataNascimento { get; set; }

//        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//        [StringLength(9, MinimumLength = 9, ErrorMessage = "O cartão de contribuinte deve ter 9 dígitos")]
//        [RegularExpression(@"\d{9}", ErrorMessage = "Este valor é inválido")]
//        [Display(Name = "Número de contribuinte")]
//        public string Contribuinte { get; set; }

//        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//        [StringLength(80, ErrorMessage = "O limite de caracteres(80) foi ultrapassado")]
//        [Display(Name = "Morada")]
//        public string Morada { get; set; }

//        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//        [StringLength(4, MinimumLength = 4)]
//        [RegularExpression(@"([123456789]|1)\d{3}", ErrorMessage = "Este valor é inválido")]
//        [Display(Name = "Código Postal")]
//        public string CodigoPostal { get; set; }

//        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//        [EmailAddress]
//        [StringLength(50, ErrorMessage = "O limite de caracteres(50) foi ultrapassado")]
//        [Display(Name = "Endereço eletrónico")]
//        public string Email { get; set; }

//        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//        [StringLength(9, MinimumLength = 9)]
//        [Display(Name = "Número de telemóvel")]
//        [RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Número de telemóvel inválido")]
//        public string Telemovel { get; set; }

//        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//        [StringLength(8, MinimumLength = 8)]
//        [RegularExpression(@"\d{8}", ErrorMessage = "Este valor é inválido")]
//        [Display(Name = "Número do cartão de cidadão")]
//        public string CartaoCidadao { get; set; }

//        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//        [Column("IBAN")]
//        [StringLength(25, ErrorMessage = "O limite de caracteres(25) foi ultrapassado", MinimumLength = 25)]
//        [Display(Name = "IBAN")]
//        public string Iban { get; set; }

//        [DataType(DataType.Password)]
//        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//        [StringLength(16, ErrorMessage = "O limite de caracteres(16) foi ultrapassado")]
//        [Display(Name = "Palavra-passe")]
//        public string Password { get; set; }


//        [Display(Name = "Confirme a sua password")]
//        //[Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//        [DataType(DataType.Password)]
//        [StringLength(16)]
//        [Compare("Password", ErrorMessage = "A passord não coincide.")]
//        public string ConfirmePassword { get; set; }

//        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//        [StringLength(10, ErrorMessage = "O limite de caracteres(10) foi ultrapassado")]
//        [Display(Name = "Estado do funcionário(ativo/inativo)")]
//        public string EstadoFuncionario { get; set; }

//        //[Required(ErrorMessage = "Campo de preenchimento obrigatório")]
//        [Display(Name = "Extensão do Código Postal")]
//        [StringLength(3, MinimumLength = 3)]
//        [RegularExpression(@"\d{3}", ErrorMessage = "Valor inválido")]
//        public string CodigoPostalExt { get; set; }

//        public byte[] Fotografia { get; set; }

//        [ForeignKey(nameof(CargoId))]
//        [InverseProperty(nameof(TipoUsers.Funcionarios))]
//        public virtual TipoUsers Cargo { get; set; }
//        [InverseProperty("Funcionario")]
//        public virtual ICollection<Contratos> Contratos { get; set; }
//    }
//}

