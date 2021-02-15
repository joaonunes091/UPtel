using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UPtel.Models;

namespace UPtel.Data
{
    public class SeedData
    {
        private const string NOME_UTILIZADOR_ADMIN_PADRAO = "admin@UPtel.pt";
        private const string PASSWORD_UTILIZADOR_ADMIN_PADRAO = "Secret123$";

        private const string ROLE_ADMINISTRADOR = "Administrador";
        private const string ROLE_CLIENTE = "Cliente";
        private const string ROLE_OPERADOR = "Operador";


        private static void InsereDadosTesteTelevisao(UPtelContext DbContext)
        {
            if (DbContext.Televisao.Any()) return;
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
            if (DbContext.Telefone.Any()) return;
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
            if (DbContext.Telemovel.Any()) return;
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
                    LimiteMinutos = 44000,
                    LimiteSms = 5000,
                    PrecoMinutoNacional = 4,
                    PrecoMinutoInternacional = 0,
                    PrecoSms = 0.05M,
                    PrecoMms = 0.1M
                }
            });
            DbContext.SaveChanges();
        }

        private static void InsereDadosTestePromocoes(UPtelContext DbContext)
        {
            if (DbContext.Telemovel.Any()) return;
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

        private static void InsereDadosTesteCargos(UPtelContext DbContext)
        {
            if (DbContext.Cargos.Any()) return;
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
            DbContext.SaveChanges();
        }


        private static void InsereDadosTesteCanais(UPtelContext DbContext)
        {
            if (DbContext.Canais.Any()) return;
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
            DbContext.SaveChanges();
        }


        private static void InsereDadosTesteNetfixa(UPtelContext DbContext)
        {
            if (DbContext.NetFixa.Any()) return;
            DbContext.NetFixa.AddRange(new NetFixa[] {
                new NetFixa
                {
                    Limite = 7.5m,
                    Velocidade=100,
                    TipoConexao="Fibra",
                    Notas="",
                },
                new NetFixa
                {
                    Limite = 15,
                    Velocidade=200,
                    TipoConexao="Fibra",
                    Notas="",
                },
                new NetFixa
                {
                    Limite = 30,
                    Velocidade=500,
                    TipoConexao="Fibra",
                    Notas="A internet mais rápida dos nossos serviços",
                },
            });
            DbContext.SaveChanges();
        }
        private static void InsereDadosTesteNetmovel(UPtelContext DbContext)
        {
            if (DbContext.NetMovel.Any()) return;
            DbContext.NetMovel.AddRange(new NetMovel[] {
                new NetMovel
                {
                    Limite = 2m,
                    Numero="", //que número se deve colocar aqui? no dicionário diz que é o número de telemovel
                    Notas="",
                },

            });
            DbContext.SaveChanges();
        }

        private static void InsereCanaisFicticiosParaTestarPaginacao(UPtelContext DbContext)
        {
          
            for (int i = 0; i < 50; i++)

            {
                DbContext.Canais.Add(new Canais
                {
                    NomeCanal = "RTP " + i,

                });
            }

            DbContext.SaveChanges();
        }
        internal static void InsereDadosTesteTodos(UPtelContext DbContext)
        {

            //InsereCanaisFicticiosParaTestarPaginacao(DbContext);
            InsereDadosTesteCargos(DbContext);
            InsereDadosTesteCanais(DbContext);
            InsereDadosTesteNetfixa(DbContext);
            InsereDadosTesteTelevisao(DbContext);
            InsereDadosTesteTelefone(DbContext);
            InsereDadosTesteTelemovel(DbContext);
            InsereDadosTestePromocoes(DbContext);


        }

        internal static async Task InsereUtilizadoresFicticiosAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            IdentityUser cliente = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "joao@ipg.pt", "Secret123$");
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, cliente, ROLE_CLIENTE);

            IdentityUser gestor = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "maria@ipg.pt", "Secret123$");
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, gestor, ROLE_OPERADOR);
        }

        internal static async Task InsereRolesAsync(RoleManager<IdentityRole> gestorRoles)
        {
            await CriaRoleSeNecessario(gestorRoles, ROLE_ADMINISTRADOR);
            await CriaRoleSeNecessario(gestorRoles, ROLE_CLIENTE);
            await CriaRoleSeNecessario(gestorRoles, ROLE_OPERADOR);
            //await CriaRoleSeNecessario(gestorRoles, "PodeAlterarPrecoProdutos");
        }

        private static async Task CriaRoleSeNecessario(RoleManager<IdentityRole> gestorRoles, string funcao)
        {
            if (!await gestorRoles.RoleExistsAsync(funcao))
            {
                IdentityRole role = new IdentityRole(funcao);
                await gestorRoles.CreateAsync(role);
            }
        }


        internal static async Task InsereAdministradorPadraoAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            IdentityUser utilizador = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, NOME_UTILIZADOR_ADMIN_PADRAO, PASSWORD_UTILIZADOR_ADMIN_PADRAO);
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, utilizador, ROLE_ADMINISTRADOR);
        }

        private static async Task AdicionaUtilizadorRoleSeNecessario(UserManager<IdentityUser> gestorUtilizadores, IdentityUser utilizador, string role)
        {
            if (!await gestorUtilizadores.IsInRoleAsync(utilizador, role))
            {
                await gestorUtilizadores.AddToRoleAsync(utilizador, role);
            }
        }

        private static async Task<IdentityUser> CriaUtilizadorSeNaoExiste(UserManager<IdentityUser> gestorUtilizadores, string nomeUtilizador, string password)
        {
            IdentityUser utilizador = await gestorUtilizadores.FindByNameAsync(nomeUtilizador);

            if (utilizador == null)
            {
                utilizador = new IdentityUser(nomeUtilizador);
                await gestorUtilizadores.CreateAsync(utilizador, password);
            }

            return utilizador;
        }
    }
}
