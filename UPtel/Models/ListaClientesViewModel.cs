using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class ListaClientesViewModel
    {
        public List<Clientes> Clientes { get; set; }
        public List<TipoClientes> TipoClientes { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }

    }
}
