using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Models
{
    public class PromocoesViewModel
    {
        public int ContratoId { get; set; }

        //Promoção televisão
        public int ContratoTelevisaoId { get; set; }

        public int PromoTelevisaoId { get; set; }

        public DateTime DataInicioTelevisao { get; set; }

        public DateTime DataFimTelevisao { get; set; }

        //Promoçoes Telefone
        public int ContratoPromoTelefoneId { get; set; }

        public int PromoTelefoneId { get; set; }

        public DateTime DataInicioTelefone { get; set; }

        public DateTime DataFimTelefone { get; set; }


        //Promoçoes Telemovel
        public int ContratoPromoTelemovelId { get; set; }

        public int PromoTelemovelId { get; set; }

        public DateTime DataInicioTelemovel { get; set; }

        public DateTime DataFimTelemovel { get; set; }


        //Promoçoes NetMovel
        public int ContratoPromoNetMovelId { get; set; }

        public int PromoNetMovelId { get; set; }

        public DateTime DataInicioNetMovel { get; set; }

        public DateTime DataFimNetMovel { get; set; }


        //Promoçoes NetFixa
        public int ContratoPromoNetFixaId { get; set; }

        public int PromoNetFixaId { get; set; }

        public DateTime DataInicioNetFixa { get; set; }

        public DateTime DataFimNetFixa { get; set; }
    }
}
