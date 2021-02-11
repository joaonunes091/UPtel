using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class TipoClientes
    {
        public TipoClientes()
        {
            Clientes = new HashSet<Clientes>();
        }

        [Key]
        public int TipoClienteId { get; set; }
       
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [StringLength(10)]
        [Display(Name = "Designação")]
        public string Designacao { get; set; }

        [InverseProperty("TipoCliente")]
        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
