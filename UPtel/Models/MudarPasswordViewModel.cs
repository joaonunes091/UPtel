using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class MudarPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password atual")]
        public string PasswordAtual { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password nova")]
        public string PasswordNova { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a nova password")]
        [Compare("PasswordNova",ErrorMessage="A nova password e a sua confirmação não são iguais")]
        public string ConfirmarPassword { get; set; }
    }
}
