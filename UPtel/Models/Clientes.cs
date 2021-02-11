using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    [Index(nameof(CartaoCidadao), Name = "IX_CartaoCidadaoClientes", IsUnique = true)]
    [Index(nameof(Contribuinte), Name = "IX_ContribuinteClientes", IsUnique = true)]
    public partial class Clientes
    {
        public Clientes()
        {
            Contratos = new HashSet<Contratos>();
        }

        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Nome  do Cliente")]
        [StringLength(80)]
        public string NomeCliente { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(8)]
        [Display(Name = "Número do Cartão de Cidadão")]
        public string CartaoCidadao { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(9)]
        [Display(Name = "Número de Contribuinte")]
        public string Contribuinte { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(80)]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(4)]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }

        [StringLength(9)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Telefone Inválido")]
        [Display(Name = "Telemóvel")]
        public string Telemovel { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [EmailAddress]
        [StringLength(50)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(16)]
        public string Password { get; set; }

        public int TipoClienteId { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(3)]
        [Display(Name = "Extensão do Código Postal")]
        public string CodigoPostalExt { get; set; }

        [ForeignKey(nameof(TipoClienteId))]
        [InverseProperty(nameof(TipoClientes.Clientes))]
        public virtual TipoClientes TipoCliente { get; set; }
        [InverseProperty("Cliente")]
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
