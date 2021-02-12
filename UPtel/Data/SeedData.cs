using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPtel.Models;

namespace UPtel.Data
{
    public class SeedData
    {
        private static void InsereDadosTesteCargos(UPtelContext DbContext)
        {
            if (!DbContext.Cargos.Any()) return;
            DbContext.Cargos.AddRange(new Cargos[] {
                new Cargos
                {
                    NomeCargo = "Administrador(a)",
                },
                new Cargos
                {
                    NomeCargo = "Operador(a)",
                }
            });
        }

        private static void InsereDadosTesteTipoClientes(UPtelContext DbContext)
        {
            if (!DbContext.TipoClientes.Any()) return;
            DbContext.TipoClientes.AddRange(new TipoClientes[] {
                new TipoClientes
                {
                    Designacao = "Particular",
                },
                new TipoClientes
                {
                    Designacao = "Empresarial",
                }
            });
        }

        private static void InsereDadosTesteCanais(UPtelContext DbContext)
        {
            if (!DbContext.Canais.Any()) return;
            DbContext.Canais.AddRange(new Canais[] {
                new Canais
                {
                    NomeCanal = "RTP 1",
                },
                new Canais
                {
                    NomeCanal = "RTP 2",
                },
                new Canais
                {
                    NomeCanal = "RTP 3",
                },
                new Canais
                {
                    NomeCanal = "RTP Africa",
                }
            });
        }



        internal static void InsereDadosTesteTodos(UPtelContext DbContext)
        {
            InsereDadosTesteCargos(DbContext);
            InsereDadosTesteTipoClientes(DbContext);
            InsereDadosTesteCanais(DbContext);
        }

    }
}
