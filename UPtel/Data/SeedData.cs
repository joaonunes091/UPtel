﻿using System;
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
        //     FUNÇÕES COM DADOS FICTICIOS PARA 
        //     TESTAR FUNCIONALIDADES, PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------


        internal static void InsereDadosTeste(UPtelContext DbContext)
        {
            InsereDadosTesteNetMovel(DbContext);
            InsereDadosTesteNetfixa(DbContext);
            InsereDadosTesteCanais(DbContext);
            InsereDadosTestePromocoes(DbContext);
            InsereDadosTesteTelefone(DbContext);
            InsereDadosTesteTelemovel(DbContext);
            InsereDadosTesteTelevisao(DbContext);
            InsereDadosTestePacoteCanais(DbContext);
            InsereDadosTestePacote(DbContext);
            InsereDadosTesteUserTypes(DbContext);
            InsereDadosTesteUsers(DbContext);
            InsereDadosTesteContratos(DbContext);
        }

        internal static void InsereDadosTestePaginacaoPesquisa(UPtelContext DbContext)
        {

            InsereCanaisFicticiosParaTestarPaginacao(DbContext);
            InserePromocoesFicticiosParaTestarPaginacao(DbContext);
            InsereTelefoneFicticiosParaTestarPaginacao(DbContext);
            InsereTeleMovelFicticiosParaTestarPaginacao(DbContext);
            InsereTelevisaoFicticiosParaTestarPaginacao(DbContext);
            InsereNetMovelFicticiosParaTestarPaginacao(DbContext);
            InserePacoteFicticiosParaTestarPaginacao(DbContext);
            InsereUsersFicticiosParaTestarPaginacao(DbContext);
            //InsereFuncionariosFicticiosParaTestarPaginacao(DbContext);

        }



        //-------------------------------------------------
        //         TELEVISÃO
        //   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------

        private static void InsereDadosTesteTelevisao(UPtelContext DbContext)
        {
            if (DbContext.Televisao.Any()) return;
            DbContext.Televisao.AddRange(new Televisao[]
            {
                new Televisao
            {
                Nome = "Sem serviço",
                Descricao= "Teste",
                PrecoPacoteTelevisao = 00m,

            },
            new Televisao
            {
                Nome = "Básico",
                Descricao= "Teste",
                PrecoPacoteTelevisao = 30m,

            },
            //new Televisao
            //{
            //    Nome = "Entretenimento",
            //    Descricao= "Teste",
            //    PrecoPacoteTelevisao = 30m,

            //},
            //new Televisao
            //{
            //    Nome = "Premium",
            //    Descricao= "Teste",
            //    PrecoPacoteTelevisao = 30m,

            //},

            });
            DbContext.SaveChanges();
        }
        private static void InsereTelevisaoFicticiosParaTestarPaginacao(UPtelContext DbContext)
        {

            if (DbContext.Televisao.Any()) return;

            for (int i = 0; i < 50; i++)

            {
                DbContext.Televisao.Add(new Televisao
                {
                    Nome = "Premium" + i,
                    Descricao = "Teste",
                    PrecoPacoteTelevisao = 30m,

                });
            }

            DbContext.SaveChanges();
        }

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
                Nome = "Novo",
                LimiteMinutos = 3000,
                LimiteSms = 3000,
                PrecoMinutoNacional = 0,
                PrecoMinutoInternacional = 0.1M,
                PrecoSms = 0.05M,
                PrecoMms = 0.1M,
                PrecoPacoteTelemovel = 0m
            },
               new Telemovel
            {
                Nome = "Básico",
                LimiteMinutos = 3000,
                LimiteSms = 3000,
                PrecoMinutoNacional = 0,
                PrecoMinutoInternacional = 0.1M,
                PrecoSms = 0.05M,
                PrecoMms = 0.1M,
                PrecoPacoteTelemovel = 15m
            },
            //new Telemovel
            //{
            //    Numero = "960100010",
            //    LimiteMinutos = 44600,
            //    LimiteSms = 5000,
            //    PrecoMinutoNacional = 0,
            //    PrecoMinutoInternacional = 0.1M,
            //    PrecoSms = 0.05M,
            //    PrecoMms = 0.1M,
            //    PrecoPacoteTelemovel = 1m
            //},
            //new Telemovel
            //{
            //    Numero = "910100020",
            //    LimiteMinutos = 44000,
            //    LimiteSms = 5000,
            //    PrecoMinutoNacional = 4,
            //    PrecoMinutoInternacional = 0,
            //    PrecoSms = 0.05M,
            //    PrecoMms = 0.1M,
            //    PrecoPacoteTelemovel = 1m
            //}
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
                    Nome = "910010000",
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
                Nome = "Teste",
                Limite = 3000,
                PrecoMinutoNacional = 0,
                PrecoMinutoInternacional = 0.1M,
                PrecoPacoteTelefone = 15m

            },
             new Telefone
            {
                Nome = "Básico",
                Limite = 3000,
                PrecoMinutoNacional = 0,
                PrecoMinutoInternacional = 0.1M,
                PrecoPacoteTelefone = 0m

            },
            //new Telefone
            //{
            //    Numero = "275888888",
            //    Limite = 44600,
            //    PrecoMinutoNacional = 0,
            //    PrecoMinutoInternacional = 0.1M,
            //    PrecoPacoteTelefone = 1m

            //},
            //new Telefone
            //{
            //    Numero = "224567891",
            //    Limite = 44600,
            //    PrecoMinutoNacional = 0,
            //    PrecoMinutoInternacional = 0,
            //    PrecoPacoteTelefone = 1m
            //}
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
                    Nome = "Básico",
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
                Foto = null
            },
            new Canais
            {
                NomeCanal = "RTP 2",
                Foto = null
            },
            new Canais
            {
                NomeCanal = "RTP 3",
                Foto = null
            },
            new Canais
            {
                NomeCanal = "RTP Africa",
                Foto = null
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
        //       NET FIXA
        //    DADOS DE TESTE  
        //-------------------------------------------------


        private static void InsereDadosTesteNetfixa(UPtelContext DbContext)
        {
            if (DbContext.NetFixa.Any()) return;
            DbContext.NetFixa.AddRange(new NetFixa[] {
               new NetFixa
            {
                Nome = "Básico",
                Limite = 7.5m,
                Velocidade=100,
                TipoConexao="Sem conexão",
                PrecoNetFixa = 0m,
                Notas="",
            },
                new NetFixa
            {
                Nome = "Premium",
                Limite = 7.5m,
                Velocidade=100,
                TipoConexao="Fibra 1",
                PrecoNetFixa = 15m,
                Notas="",
            },
            //new NetFixa
            //{
            //    Limite = 15,
            //    Velocidade=200,
            //    TipoConexao="Fibra",
            //    PrecoNetFixa = 1m,
            //    Notas="",
            //},
            //new NetFixa
            //{
            //    Limite = 30,
            //    Velocidade=500,
            //    TipoConexao="Fibra",
            //    PrecoNetFixa = 1m,
            //    Notas="A internet mais rápida dos nossos serviços",
            //},
        });
            DbContext.SaveChanges();
        }


        //-------------------------------------------------
        //       NET MOVEL
        // DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------

        private static void InsereDadosTesteNetMovel(UPtelContext DbContext)
        {
            if (DbContext.NetMovel.Any()) return;
            DbContext.NetMovel.AddRange(new NetMovel[] {
            new NetMovel
            {
                    Limite = 5,
                    PrecoNetMovel = 0m,
                    Nome = "Básico",
                    Notas = "teste 1"
            },
                new NetMovel
            {
                    Limite = 5,
                    PrecoNetMovel = 15m,
                    Nome = "Premium",
                    Notas = "teste 1"
            },
            //new NetMovel
            //{
            //        Limite = 7,
            //        PrecoNetMovel = 1,
            //        Numero = "929876543",
            //        Notas = "teste 2"
            //},
            //new NetMovel
            //{
            //        Limite = 26,
            //        PrecoNetMovel = 5,
            //        Numero = "969513578",
            //        Notas = "teste 3"
            //},
        });
            DbContext.SaveChanges();
        }

        private static void InsereNetMovelFicticiosParaTestarPaginacao(UPtelContext DbContext)
        {
            if (DbContext.NetMovel.Any()) return;
            for (int i = 1; i < 50; i++)
            {

                DbContext.NetMovel.Add(new NetMovel
                {
                    Limite = 2,
                    PrecoNetMovel = 1,
                    Nome = "Básico", //que número se deve colocar aqui? no dicionário diz que é o número de telemovel
                    Notas = "teste" + i
                });

            }
            DbContext.SaveChanges();
        }

        //-------------------------------------------------
        //         PACOTES CANAIS
        //   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------


        private static void InsereDadosTestePacoteCanais(UPtelContext DbContext)
        {
            if (DbContext.PacoteCanais.Any()) return;

            Canais canaisRTP = DbContext.Canais.FirstOrDefault(c => c.NomeCanal == "RTP Africa");
            Televisao televisaoBasico = DbContext.Televisao.FirstOrDefault(t => t.Nome == "Básico");

            DbContext.PacoteCanais.AddRange(new PacoteCanais[]
               {
                new PacoteCanais
                {
                    Televisao = televisaoBasico,
                    Canais = canaisRTP
                }

                });

            DbContext.SaveChanges();
        }


        //-------------------------------------------------
        //         PACOTES
        //   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------

        private static void InsereDadosTestePacote(UPtelContext DbContext)
        {
            if (DbContext.Pacotes.Any()) return;

            Televisao televisaoBasico = DbContext.Televisao.FirstOrDefault(t => t.Nome == "Básico");
            Telemovel telemovel = DbContext.Telemovel.FirstOrDefault(t => t.Nome == "Básico");
            NetFixa netFixa = DbContext.NetFixa.FirstOrDefault(n => n.TipoConexao == "Fibra 1");
            Telefone telefone = DbContext.Telefone.FirstOrDefault(t => t.Nome == "Básico");
            NetMovel netMovel = DbContext.NetMovel.FirstOrDefault(n => n.Nome == "Básico");


            DbContext.Pacotes.AddRange(new Pacotes[]
               {
                new Pacotes
                {
                    NomePacote = "Básico",
                    PrecoTotal = 59m,
                    Televisao = televisaoBasico,
                    Telemovel = telemovel,
                    NetIfixa = netFixa,
                    Telefone = telefone,
                    NetMovel = netMovel

                },
                  new Pacotes
                {
                    NomePacote = "VIP",
                    PrecoTotal = 54m,
                    Televisao = televisaoBasico,
                    Telemovel = telemovel,
                    NetIfixa = netFixa,
                    Telefone = telefone,
                    NetMovel = netMovel

                },
                    new Pacotes
                {
                    NomePacote = "Premium",
                    PrecoTotal = 34m,
                    Televisao = televisaoBasico,
                    Telemovel = telemovel,
                    NetIfixa = netFixa,
                    Telefone = telefone,
                    NetMovel = netMovel

                }

                });

            DbContext.SaveChanges();
        }
        public static void InserePacoteFicticiosParaTestarPaginacao(UPtelContext DbContext)
        {

            for (int i = 10; i < 50; i++)

            {
                if (DbContext.Pacotes.Any()) return;

                Televisao televisaoBasico = DbContext.Televisao.FirstOrDefault(t => t.Nome == "Básico");
                Telemovel telemovel = DbContext.Telemovel.FirstOrDefault(t => t.Nome == "910100020");
                NetFixa netFixa = DbContext.NetFixa.FirstOrDefault(n => n.TipoConexao == "Fibra");
                Telefone telefone = DbContext.Telefone.FirstOrDefault(t => t.Nome == "275888888");
                NetMovel netMovel = DbContext.NetMovel.FirstOrDefault(n => n.Nome == "911234567");

                DbContext.Pacotes.Add(new Pacotes
                {
                    NomePacote = "Básico " + i,
                    PrecoTotal = 34m,
                    Televisao = televisaoBasico,
                    Telemovel = telemovel,
                    NetIfixa = netFixa,
                    Telefone = telefone,
                    NetMovel = netMovel

                });

            }
            DbContext.SaveChanges();
        }

        //-------------------------------------------------
        //       USER TYPES
        //       DADOS DE TESTE 
        //-------------------------------------------------


        private static void InsereDadosTesteUserTypes(UPtelContext DbContext)
        {
            if (DbContext.UserType.Any()) return;
            DbContext.UserType.AddRange(new UserType[] {
            new UserType
            {
                Tipo = "Administrador",
            },
            new UserType
            {
                Tipo = "Operador",
            },new UserType
            {
                Tipo = "Cliente Empresarial",
            }, new UserType
            {
                Tipo = "Cliente Particular",
            },
        });
            DbContext.SaveChanges();
        }



        //-------------------------------------------------
        //         USERS
        //   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------

        private static void InsereDadosTesteUsers(UPtelContext DbContext)
        {
            if (DbContext.Users.Any()) return;

            UserType tipoUserEmpresa = DbContext.UserType.FirstOrDefault(c => c.Tipo == "Cliente Empresarial");
            UserType tipoUserParticular = DbContext.UserType.FirstOrDefault(c => c.Tipo == "Cliente Particular");
            UserType tipoUserOperador = DbContext.UserType.FirstOrDefault(c => c.Tipo == "Operador");
            UserType tipoUserAdministrador = DbContext.UserType.FirstOrDefault(c => c.Tipo == "Administrador");



            DbContext.Users.AddRange(new Users[]
               {
                new Users
                {

                    Nome = "José Figueiras",
                    Data = new DateTime(1969,12,18),
                    CartaoCidadao = "15485963",
                    Contribuinte = "154965739",
                    Morada = "Rua Júlio Cesár Machado nº14",
                    CodigoPostal = "1500",
                    Telefone="231584687",
                    Telemovel="961847659",
                    Email="Jose.Ramos@gmail.com",
                    Iban = "1234567891234567891234567",
                    Tipo = tipoUserEmpresa,
                    CodigoPostalExt = "695",


                },
                new Users
                {
                    Nome = "Rui Pedro Santos",
                    Data = new DateTime(1990,8,8),
                    CartaoCidadao="24045212",
                    Contribuinte="157782731",
                    Morada="Rua do Pinho Alto nº 25",
                    CodigoPostal="2300",
                    Telefone="271598874",
                    Telemovel="927856988",
                    Email="Rui.Pedro.Santos@gmail.com",
                    Iban = "1234567891234567891234567",
                    Tipo = tipoUserParticular,
                    CodigoPostalExt="588",

                },
                new Users
                {
                    Nome = "Mariana Rute Guedes",
                    Data = new DateTime(1987,11,7),
                    CartaoCidadao="15487986",
                    Contribuinte="16687495",
                    Morada="Rua do Comércio nº4",
                    CodigoPostal="1700",
                    Telefone="234598777",
                    Telemovel="961155484",
                    Email="Mariana.Rute.Guedes@gmail.com",
                    Iban = "1234567891234567891234567",
                    Tipo = tipoUserOperador,
                    CodigoPostalExt="588",
                },
                new Users
                {
                    Nome = "David Rui Pedroso",
                    Data = new DateTime(1985,1,20),
                    CartaoCidadao="34657986",
                    Contribuinte="376554971",
                    Morada="Rua de São Mamede nº10",
                    CodigoPostal="4000",
                    Telefone="236459557",
                    Telemovel="915444789",
                    Email="David.Rui.Pedroso@gmail.com",
                    Iban = "1234567891234567891234567",
                    Tipo = tipoUserAdministrador,
                    CodigoPostalExt="588",
                },
                });

            DbContext.SaveChanges();
        }

        public static void InsereUsersFicticiosParaTestarPaginacao(UPtelContext DbContext)
        {

            for (int i = 10; i < 50; i++)

            {
                if (DbContext.Users.Any()) return;

                UserType tipoUser = DbContext.UserType.FirstOrDefault(c => c.Tipo == "Operador");

                DbContext.Users.Add(new Users
                {
                    Nome = "José Figueiras " + i,
                    Data = new DateTime(1969, 12, 18),
                    CartaoCidadao = Convert.ToString(12345670 + i),
                    Contribuinte = Convert.ToString(123456700 + i),
                    Morada = "Rua Júlio Cesár Machado nº14",
                    CodigoPostal = "1500",
                    Telefone = Convert.ToString(247112500 + i),
                    Telemovel = Convert.ToString(913456700 + i),
                    Email = "José.Ramos@gmail.com " + i,
                    Iban = "1234567891234567891234567",
                    Tipo = tipoUser,
                    CodigoPostalExt = "695",

                });

            }
            DbContext.SaveChanges();
        }


        ////-------------------------------------------------
        ////         CONTRATOS
        ////   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        ////-------------------------------------------------


        private static void InsereDadosTesteContratos(UPtelContext DbContext)
        {
            if (DbContext.Contratos.Any()) return;

            Users clientes = DbContext.Users.FirstOrDefault(t => t.Nome == "José Figueiras");
            Users funcionarios = DbContext.Users.FirstOrDefault(t => t.Nome == "Rui Pedro Santos");
            Promocoes promocoes = DbContext.Promocoes.FirstOrDefault(n => n.NomePromocao == "Extra Nacional");
            Pacotes pacotes = DbContext.Pacotes.FirstOrDefault(t => t.NomePacote == "Básico");


            DbContext.Contratos.AddRange(new Contratos[]
               {
                new Contratos
                {
                    Cliente = clientes,
                    Funcionario = funcionarios,
                    Promocao = promocoes,
                    Pacote = pacotes,
                    Numeros = null,
                    DataInicio = new DateTime(1965,05,25),
                    Fidelizacao = 5,
                    TempoPromocao = 5,
                    PrecoContrato = 59m,
                },


                });

            DbContext.SaveChanges();
        }




        //-------------------------------------------------
        //   CRIAÇÃO DE UTILIZADORES E ROLES
        //   FICTICIOS E REAIS 
        //-------------------------------------------------

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