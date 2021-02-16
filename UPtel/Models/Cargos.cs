using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class Cargos
    {
        public Cargos()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        [Key]
        public int CargoId { get; set; }
       
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "O limite de caracteres(50) foi ultrapassado")]
        [Display(Name = "Nome do Cargo")]
        public string NomeCargo { get; set; }

        [InverseProperty("Cargo")]
        public virtual ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
