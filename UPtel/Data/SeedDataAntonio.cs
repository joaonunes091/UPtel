using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPtel.Models;

namespace UPtel.Data
{
    public class SeedDataAntonio
    {
        private static void InsereDadosTesteTelevisao(UPtelContext DbContext)
        {
            if (!DbContext.Televisao.Any()) return;
            DbContext.Televisao.AddRange(new Televisao[] {
                new Televisao
                {
                    Nome = "Base"
                },
                new Televisao
                {
                    Nome = "Base + Informação"
                },
                new Televisao
                {
                    Nome = "Series e Filmes"
                },
                new Televisao
                {
                    Nome = "Up"
                }
            });
            DbContext.SaveChanges();
        }
            private static void InsereDadosTesteTelefone(UPtelContext DbContext)
            {
                if (!DbContext.Telefone.Any()) return;
            DbContext.Telefone.AddRange(new Telefone[] {
                new Telefone
                {
                    Numero = "220000000",
                    Limite = 3000,
                    PrecoMinutoNacional = 0,
                    PrecoMinutoInternacional = 0.1M
                },
                new Telefone
                {
                    Numero = "200100000",
                    Limite = 44600,
                    PrecoMinutoNacional = 0,
                    PrecoMinutoInternacional = 0.1M
                },
                new Telefone
                {
                    Numero = "290100000",
                    Limite = 44600,
                    PrecoMinutoNacional = 0,
                    PrecoMinutoInternacional = 0
                }
            });
            DbContext.SaveChanges();
        }
        private static void InsereDadosTesteTelemovel(UPtelContext DbContext)
        {
            if (!DbContext.Telemovel.Any()) return;
            DbContext.Telemovel.AddRange(new Telemovel[] {
                new Telemovel
                {
                    Numero = "90010000",
                    LimiteMinutos = 3000,
                    LimiteSms = 3000,
                    PrecoMinutoNacional = 0,
                    PrecoMinutoInternacional = 0.1M,
                    PrecoSms = 0.05M,
                    PrecoMms = 0.1M
                },
                new Telemovel
                {
                    Numero = "90010001",
                    LimiteMinutos = 44600,
                    LimiteSms = 5000,
                    PrecoMinutoNacional = 0,
                    PrecoMinutoInternacional = 0.1M,
                    PrecoSms = 0.05M,
                    PrecoMms = 0.1M
                },
                new Telemovel
                {
                    Numero = "90010002",
                    LimiteMinutos = 44600,
                    LimiteSms = 5000,
                    PrecoMinutoNacional = 44600,
                    PrecoMinutoInternacional = 0,
                    PrecoSms = 0.05M,
                    PrecoMms = 0.1M
                }
            });
            DbContext.SaveChanges();
        }

        private static void InsereDadosTestePromocoes(UPtelContext DbContext)
        {
            if (!DbContext.Telemovel.Any()) return;
            DbContext.Promocoes.AddRange(new Promocoes[] {
                new Promocoes
                {
                    NomePromocao = "Extra Nacional",
                    Descricao = "Oferta de minutos nacionais"                    
                },
                new Promocoes
                {
                    NomePromocao = "Inter Extra",
                    Descricao = "Oferta de minutos internacionais"

                },
                new Promocoes
                {
                    NomePromocao = "Up Top",
                    Descricao = "VIP only!... Comunicações grátis!"

                }
            });
            DbContext.SaveChanges();
        }
        internal static void InsereDadosTesteTodos(UPtelContext DbContext)
        {
            InsereDadosTesteTelevisao(DbContext);
            InsereDadosTesteTelefone(DbContext);
            InsereDadosTesteTelemovel(DbContext);
            InsereDadosTestePromocoes(DbContext);
        }
    }
}
