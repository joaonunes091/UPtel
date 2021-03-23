using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class ListaCanaisViewModel
    {
        public List<PromoNetMovel> PromoNetMovel { get; set; }
        public List<PromoNetFixa> PromoNetFixas { get; set; }
        public List<PromoTelefone> PromoTelefone { get; set; }
        public List<PromoTelemovel> PromoTelemovel { get; set; }
        public List<PromoTelevisao> PromoTelevisao { get; set; }
       
        public List<FaturaCliente> FaturaClientes { get; set; }
        public List<NetMovel> NetMovel { get; set; }
        public List<Canais> Canais { get; set; }
        public List<PacoteCanais> PacoteCanais { get; set; }
        public List<Pacotes> Pacotes { get; set; }
        //public List<Promocoes> Promocoes { get; set; }
        public List<Telefone> Telefone { get; set; }
        public List<Telemovel> Telemovel { get; set; }
        public List<Televisao> Televisao { get; set; }

        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }
        public List<Users> Users { get; set; }

        public List<Contratos> Contratos { get; set; }
        public List<Distrito> Distritos { get; set; }
        public int DistritoPesquisar { get; set; }

        //public IEnumerable<Funcionarios> Funcionarios { get; set; }
        //public IEnumerable<Contratos> Contratos { get; set; }
    }
}
