using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class PreRegistoViewModel
    {

        [Display(Name = "Tipo de cliente")]
        public int TipoId { get; set; }
    }
}
