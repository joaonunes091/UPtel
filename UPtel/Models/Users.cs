using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static System.ComponentModel.DataAnnotations.RegularExpressionAttribute;

#nullable disable

namespace UPtel.Models
{
    [Index(nameof(CartaoCidadao), Name = "IX_CartaoCidadaoClientes", IsUnique = true)]
    [Index(nameof(TipoId), Name = "IX_Clientes_TipoClienteId")]
    [Index(nameof(DataRegisto), Name = "IX_Clientes_DataRegisto")]
    [Index(nameof(Contribuinte), Name = "IX_ContribuinteClientes", IsUnique = true)]
    [Index(nameof(Nome), Name = "IX_Nome_Users")]

    public partial class Users
    {
        public Users()
        {
            ContratosCliente = new HashSet<Contratos>();
            ContratosFuncionario = new HashSet<Contratos>();
        }

        [Key]
        public int UsersId { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(80, ErrorMessage = "O limite de caracteres(80) foi ultrapassado")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário colocar uma data")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [StringLength(8, MinimumLength = 8,ErrorMessage ="É necessário colocar o cartão de cidadão")]
        [RegularExpression(@"\d{8}",ErrorMessage ="Este valor não é válido")]
        [Display(Name = "Cartão de Cidadão")]
        public string CartaoCidadao { get; set; }

        [Required(ErrorMessage = "É necessário colocar um número de contribuinte")]
        [StringLength(9, MinimumLength = 9,ErrorMessage ="Este valor é inválido")]
        [RegularExpression(@"\d{9}",ErrorMessage ="Este valor é inválido")]
        [Display(Name = "Contribuinte")]
        public string Contribuinte { get; set; }

        [Required(ErrorMessage = "É necessário colocar a morada")]
        [StringLength(80, ErrorMessage = "O limite de caracteres(80) foi ultrapassado")]
        [Display(Name ="Morada")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(4, MinimumLength = 4)]
        [Display(Name = "Código Postal")]
        [RegularExpression(@"([123456789]|1)\d{3}",ErrorMessage ="Valor inválido")]
        public string CodigoPostal { get; set; }

        [StringLength(9, MinimumLength = 9, ErrorMessage ="O número de telefone deve ter 9 dígitos")]
        [RegularExpression(@"(2|1\d)\d{8}", ErrorMessage = "Telefone Inválido")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O número de telemóvel deve ter 9 dígitos")]
        [RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Telefone Inválido")]
        [Display(Name = "Telemóvel")]
        public string Telemovel { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [EmailAddress(ErrorMessage ="Endereço eletrónico invalido")]
        [StringLength(255, ErrorMessage = "O limite de caracteres(255) foi ultrapassado")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Tipo")]
        public int TipoId { get; set; }

        [Display(Name = "Distrito")]
        public int DistritoId { get; set; }

        [Display(Name = "Valor total dos contratos")]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal PrecoContratos { get; set; }

        public int? Posicao { get; set; }

        //[Required(ErrorMessage = "É necessário colocar uma data")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DataRegisto { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(3, MinimumLength = 3)]
        [Display(Name = "Extensão do Código Postal")]
        [RegularExpression(@"\d{3}", ErrorMessage = "Este valor é inválido")]
        public string CodigoPostalExt { get; set; }

        [Column("IBAN")]
        [StringLength(25, ErrorMessage = "O limite de caracteres(25) foi ultrapassado", MinimumLength = 25)]
        [Display(Name = "IBAN")]
        public string Iban { get; set; }
        [StringLength(50)]
        public string Estado { get; set; }

        public byte[] Fotografia { get; set; }

        [ForeignKey(nameof(TipoId))]
        [InverseProperty(nameof(UserType.Users))]
        public virtual UserType Tipo { get; set; }

        [ForeignKey(nameof(DistritoId))]
        [InverseProperty(nameof(Distrito.Users))]
        [Display(Name = "Distrito")]
        public virtual Distrito DistritoNome { get; set; }

        [InverseProperty(nameof(Contratos.Cliente))]
        public virtual ICollection<Contratos> ContratosCliente { get; set; }

        [InverseProperty(nameof(Contratos.Funcionario))]
        public virtual ICollection<Contratos> ContratosFuncionario { get; set; }
    }

    //    public class RestrictedDate : ValidationAttribute
    //    {
    //        public override bool IsValid(object DataNascimento)
    //        {
    //            DateTime DataNascimento = (DateTime)DataNascimento;
    //            return DataNascimento < DateTime.Now;
    //        }
    //    }
}
