using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class NetFixa
    {
        public NetFixa()
        {
            Pacotes = new HashSet<Pacotes>();
        }

        [Key]
        public int NetFixaId { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Tarifário")]
        [StringLength(45, ErrorMessage = "O limite de caracteres(45) foi ultrapassado")]
        public string Nome { get; set; }

        [Display(Name = "Limite de plafond")]
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(1,999,ErrorMessage ="Valor inválido")]
        public decimal Limite { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Velocidade de ligação em MB")]
        public int Velocidade { get; set; }
       
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display( Name ="Tipo de Conexão")]
        [StringLength(30, ErrorMessage = "O limite de carateres(30) foi ultrapassado")]
        public string TipoConexao { get; set; }

        [Display(Name = "Preço do tarifário")]
        [Required(ErrorMessage = "Deve preencher o preço.")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(1, 9999, ErrorMessage = "O valor não é válido")]
        public decimal PrecoNetFixa { get; set; }

        [StringLength(100)]
        public string Notas { get; set; }

        [InverseProperty("NetIfixa")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}