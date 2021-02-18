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


        //-------------------------------------------------
        //         TELEVISÃO
        //   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------

        //-------------------------------------------------
        //         TELEMOVEL
        //   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------

        private static void InsereDadosTesteTelemovel(UPtelContext DbContext)
        {
            if (DbContext.Telemovel.Any()) return;
            DbContext.Telemovel.AddRange(new Telemovel[] {
            new Telemovel
            {
                Numero = "910010000",
                LimiteMinutos = 3000,
                LimiteSms = 3000,
                PrecoMinutoNacional = 0,
                PrecoMinutoInternacional = 0.1M,
                PrecoSms = 0.05M,
                PrecoMms = 0.1M
            },
            new Telemovel
            {
                Numero = "960100010",
                LimiteMinutos = 44600,
                LimiteSms = 5000,
                PrecoMinutoNacional = 0,
                PrecoMinutoInternacional = 0.1M,
                PrecoSms = 0.05M,
                PrecoMms = 0.1M
            },
            new Telemovel
            {
                Numero = "910100020",
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
        private static void InsereTeleMovelFicticiosParaTestarPaginacao(UPtelContext DbContext)
        {

            if (DbContext.Telemovel.Any()) return;

            for (int i = 0; i < 50; i++)

            {
                DbContext.Telemovel.Add(new Telemovel
                {
                    Numero = "910010000",
                    LimiteMinutos = 3000,
                    LimiteSms = 3000,
                    PrecoMinutoNacional = 0,
                    PrecoMinutoInternacional = 0.1M,
                    PrecoSms = 0.05M,
                    PrecoMms = 0.1M

                });
            }

            DbContext.SaveChanges();
        }


        //-------------------------------------------------
        //         TELEFONE
        //   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------

        private static void InsereDadosTesteTelefone(UPtelContext DbContext)
        {
            if (DbContext.Telefone.Any()) return;
            DbContext.Telefone.AddRange(new Telefone[] {
            new Telefone
            {
                Numero = "910000000",
                Limite = 3000,
                PrecoMinutoNacional = 0,
                PrecoMinutoInternacional = 0.1M,
                PrecoPacoteTelefone = 15m

            },
            new Telefone
            {
                Numero = "910000000",
                Limite = 44600,
                PrecoMinutoNacional = 0,
                PrecoMinutoInternacional = 0.1M,
                PrecoPacoteTelefone = 15m

            },
            new Telefone
            {
                Numero = "910000000",
                Limite = 44600,
                PrecoMinutoNacional = 0,
                PrecoMinutoInternacional = 0,
                PrecoPacoteTelefone = 15m
            }
        });
            DbContext.SaveChanges();
        }
        private static void InsereTelefoneFicticiosParaTestarPaginacao(UPtelContext DbContext)
        {

            if (DbContext.Telefone.Any()) return;

            for (int i = 0; i < 50; i++)

            {
                DbContext.Telefone.Add(new Telefone
                {
                    Numero = "910000000",
                    Limite = 44600 + i,
                    PrecoMinutoNacional = 0,
                    PrecoMinutoInternacional = 0,
                    PrecoPacoteTelefone = 15m

                });
            }

            DbContext.SaveChanges();
        }


        //-------------------------------------------------
        //         PROMOÇOES
        //   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------


        private static void InsereDadosTestePromocoes(UPtelContext DbContext)
        {
            if (DbContext.Telemovel.Any()) return;
            DbContext.Promocoes.AddRange(new Promocoes[] {
            new Promocoes
            {
                NomePromocao = "Extra Nacional",
                Descricao = "Oferta de minutos nacionais",
                PromoCanais= 3,
                Desconto = 2 
            },
            new Promocoes
            {
                NomePromocao = "Inter Extra",
                Descricao = "Oferta de minutos internacionais",
                PromoCanais= 3,
                Desconto = 2
            },
            new Promocoes
            {
                NomePromocao = "Up Top",
                Descricao = "VIP only!... Comunicações grátis!",
                PromoCanais= 3,
                Desconto = 2

            }
        });
            DbContext.SaveChanges();
        }

        private static void InserePromocoesFicticiosParaTestarPaginacao(UPtelContext DbContext)
        {

            if (DbContext.Promocoes.Any()) return;

            for (int i = 0; i < 50; i++)

            {
                DbContext.Promocoes.Add(new Promocoes
                {
                    NomePromocao = "Up Top" + i,
                    Descricao = "VIP only!... Comunicações grátis!",
                    PromoCanais = 3,
                    Desconto = 2

                });
            }

            DbContext.SaveChanges();
        }

        //-------------------------------------------------
        //         CARGOS
        //     DADOS DE TESTE 
        //-------------------------------------------------

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
   

        //-------------------------------------------------
        //         CANAIS 
        // DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //--------------------------------------------------

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

        private static void InsereCanaisFicticiosParaTestarPaginacao(UPtelContext DbContext)
        {
            if (DbContext.Canais.Any()) return;

            for (int i = 0; i < 50; i++)

            {
                DbContext.Canais.Add(new Canais
                {
                    NomeCanal = "RTP " + i,

                });
            }

            DbContext.SaveChanges();
        }

        //-------------------------------------------------
        //       TIPO CLIENTES
        //       DADOS DE TESTE 
        //-------------------------------------------------


        private static void InsereDadosTesteTipoClientes(UPtelContext DbContext)
        {
            if (DbContext.TipoClientes.Any()) return;
            DbContext.TipoClientes.AddRange(new TipoClientes[] {
            new TipoClientes
            {
                Designacao = "Particular",
            },
            new TipoClientes
            {
                Designacao = "Empresa",
            },new TipoClientes
            {
                Designacao = "Grandes",
            },
            new TipoClientes
            {
                Designacao = "Estatal",
            }
        });
            DbContext.SaveChanges();
        }

        //-------------------------------------------------
        //       NET FIXA
        //    DADOS DE TESTE  
        //-------------------------------------------------


        private static void InsereDadosTesteNetfixa(UPtelContext DbContext)
        {
            if (DbContext.NetFixa.Any()) return;
            DbContext.NetFixa.AddRange(new NetFixa[] {
            new NetFixa
            {
                Limite = 7.5m,
                Velocidade=100,
                TipoConexao="Fibra",
                PrecoNetFixa = 1m,
                Notas="",
            },
            new NetFixa
            {
                Limite = 15,
                Velocidade=200,
                TipoConexao="Fibra",
                PrecoNetFixa = 1m,
                Notas="",
            },
            new NetFixa
            {
                Limite = 30,
                Velocidade=500,
                TipoConexao="Fibra",
                PrecoNetFixa = 1m,
                Notas="A internet mais rápida dos nossos serviços",
            },
        });
            DbContext.SaveChanges();
        }


        //-------------------------------------------------
        //       NET MOVEL
        // DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------

        private static void InsereDadosTesteNetmovel(UPtelContext DbContext)
        {
            if (DbContext.NetMovel.Any()) return;
            for (int i = 1; i < 50; i++)
            {

                DbContext.NetMovel.Add(new NetMovel
                {
                    Limite = 2,
                    PrecoNetMovel = 1,
                    Numero = "910000000", //que número se deve colocar aqui? no dicionário diz que é o número de telemovel
                    Notas = "teste" + i
                });

            }
            DbContext.SaveChanges();
        }

   



        internal static void InsereDadosTeste(UPtelContext DbContext)
        {
            InsereDadosTesteNetmovel(DbContext);
            InsereDadosTesteNetfixa(DbContext);
            InsereDadosTesteTipoClientes(DbContext);
            InsereDadosTesteCanais(DbContext);
            InsereDadosTesteCargos(DbContext);
            InsereDadosTestePromocoes(DbContext);
            InsereDadosTesteTelefone(DbContext);
            InsereDadosTesteTelemovel(DbContext);

        }



        internal static void InsereDadosTestePaginacaoPesquisa(UPtelContext DbContext)
        {

            InsereCanaisFicticiosParaTestarPaginacao(DbContext);
            InserePromocoesFicticiosParaTestarPaginacao(DbContext);
            InsereTelefoneFicticiosParaTestarPaginacao(DbContext);
            InsereTeleMovelFicticiosParaTestarPaginacao(DbContext);


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

 

        public static void InsereDadosFuncionarios(UPtelContext DbContext)
        {

            for (int i = 10; i < 50; i++)

            {
                if (DbContext.Funcionarios.Any()) return;
                DbContext.Funcionarios.Add(new Funcionarios
                {
                    NomeFuncionario = "Funcionário " + i,
                    CargoId = 4,
                    NomeCargo = "Operador",
                    DataNascimento = new DateTime(1911, 11, 11),
                    Contribuinte = Convert.ToString(123456700 + i),
                    Morada = "Sem Abrigo",
                    CodigoPostal = "1234",
                    Email = "a" + i + "@b.com",
                    Telemovel = Convert.ToString(913456700 + i),
                    CartaoCidadao = Convert.ToString(12345670 + i),
                    Iban = "1234567891234567891234567",
                    Password = "password",
                    CodigoPostalExt = "123",
                    EstadoFuncionario = "ativo"

                });

            }
            DbContext.SaveChanges();
        }
        



    }
}