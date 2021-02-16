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
        public List<Pacotes> Pacotes { get; set; }
        public List<Promocoes> Promocoes { get; set; }
        public List<Telefone> Telefone { get; set; }

        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }
        public List<Clientes> Clientes { get; set; }
        public List<TipoClientes> TipoClientes { get; set; }
    }
}
