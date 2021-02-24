using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class CheckBox
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Selecionado { get; set; }
    }
}
