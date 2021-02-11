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
        [Column(TypeName = "decimal(5, 2)")]
        //como fazer o limite?
        public decimal Limite { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Velocidade de ligação")]
        public int Velocidade { get; set; }
       
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display( Name ="Tipo de Conexão")]
        [StringLength(30)]
        public string TipoConexao { get; set; }
       
        [StringLength(100)]
        public string Notas { get; set; }

        [InverseProperty("NetIfixa")]
        public virtual ICollection<Pacotes> Pacotes { get; set; }
    }
}
