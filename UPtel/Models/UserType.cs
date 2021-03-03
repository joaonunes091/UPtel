using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UPtel.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "É necessário colocar um tipo de utilizador")]
        [StringLength(30, ErrorMessage = "O limite de carateres(30) foi ultrapassado")]
        public string Tipo { get; set; }

        [InverseProperty("Tipo")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
