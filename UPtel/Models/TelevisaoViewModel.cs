using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class TelevisaoViewModel
    {


        [Key]
        public int TelevisaoId { get; set; }


        public string Nome { get; set; }


        public string Descricao { get; set; }

      
        public decimal PrecoPacoteTelevisao { get; set; }

        public List<CheckBox> ListaCanais { get; set; }


    }
}
