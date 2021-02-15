using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class ListaCanaisViewModel
    {
        public List<Canais> Canais { get; set; }
        public List<PacoteCanais> PacoteCanais { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }
    }
}
