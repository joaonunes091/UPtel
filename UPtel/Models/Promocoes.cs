using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class Promocoes
    {
        public Promocoes()
        {
            Contratos = new HashSet<Contratos>();
        }

        [Key]
        public int PromocaoId { get; set; }
      
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(50)]
        [Display(Name = "Nome da Promoção")]
        public string NomePromocao { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name = "Descrição")]
        [StringLength(100)]
        public string Descricao { get; set; }

        [InverseProperty("Promocao")]
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
