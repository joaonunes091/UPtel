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
        //     FUNÇÕES COM DADOS FICTICIOS PARA 
        //     TESTAR FUNCIONALIDADES, PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------


        internal static void InsereDadosTeste(UPtelContext DbContext)
        {
            InsereDadosTesteDistrito(DbContext);
            InsereDadosTesteUserTypes(DbContext);
            InsereDadosTesteUsers(DbContext);
            InsereDadosTesteTelefone(DbContext);
            InsereDadosTesteTelemovel(DbContext);
            InsereDadosTesteCanais(DbContext);
            InsereDadosTesteTelevisao(DbContext);
            InsereDadosTestePacoteCanais(DbContext);
            InsereDadosTesteNetMovel(DbContext);
            InsereDadosTesteNetfixa(DbContext);
            InsereDadosPromoTelemovel(DbContext);
            InsereDadosTestePacote(DbContext);
            InsereDadosTesteContratos(DbContext);
            InsereDadosPromoNetMovel(DbContext);
            InsereDadosPromoNetFixa(DbContext);
            InsereDadosPromoTelefone(DbContext);
            InsereDadosPromoTelevisao(DbContext);
            InsereDadosContratoPromoTelemovel(DbContext);
            InsereDadosContratoPromoNetMovel(DbContext);
            InsereDadosContratoPromoNetFixa(DbContext);
            InsereDadosContratoPromoTelefone(DbContext);
            InsereDadosContratoPromoTelevisao(DbContext);



            //InsereDadosTestePromocoes(DbContext);
        }

        internal static void InsereDadosTestePaginacaoPesquisa(UPtelContext DbContext)
        {

            InsereCanaisFicticiosParaTestarPaginacao(DbContext);
            //InserePromocoesFicticiosParaTestarPaginacao(DbContext);
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
                Descricao= "Não tem serviço de televisão",
                PrecoPacoteTelevisao = 00m,

            },
            new Televisao
            {
                Nome = "Básico",
                Descricao= "Teste",
                PrecoPacoteTelevisao = 30m,

            },
            new Televisao
            {
                Nome = "Entretenimento",
                Descricao= "Teste",
                PrecoPacoteTelevisao = 30m,

            },
            new Televisao
            {
                Nome = "Premium",
                Descricao= "Teste",
                PrecoPacoteTelevisao = 30m,

            },

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
                Nome = "Premium",
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
            },
              new Canais
            {
                NomeCanal = "TV Cine 1",
                Foto = null
            },
                new Canais
            {
                NomeCanal = "Hollywood",
                Foto = null
            },
                  new Canais
            {
                NomeCanal = "AXN",
                Foto = null
            },
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
                PrecoNetFixa = 10m,
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

            Canais canaisRTPAfrica = DbContext.Canais.FirstOrDefault(c => c.NomeCanal == "RTP Africa");
            Canais canaisRTP1 = DbContext.Canais.FirstOrDefault(c => c.NomeCanal == "RTP 1");
            Canais canaisRTP2 = DbContext.Canais.FirstOrDefault(c => c.NomeCanal == "RTP 2");
            Canais canaisRTP3 = DbContext.Canais.FirstOrDefault(c => c.NomeCanal == "RTP 3");
            Canais canaisTvCine = DbContext.Canais.FirstOrDefault(c => c.NomeCanal == "TV Cine 1");
            Canais canaisHoll = DbContext.Canais.FirstOrDefault(c => c.NomeCanal == "Hollywood");
            Canais canaisAXN = DbContext.Canais.FirstOrDefault(c => c.NomeCanal == "AXN");
            Televisao televisaoBasico = DbContext.Televisao.FirstOrDefault(t => t.Nome == "Básico");
            Televisao televisaoEnt = DbContext.Televisao.FirstOrDefault(t => t.Nome == "Entretenimento");

            

            DbContext.PacoteCanais.AddRange(new PacoteCanais[]
               {
                new PacoteCanais
                {
                    Televisao = televisaoBasico,
                    Canais = canaisRTPAfrica,
                },
                 new PacoteCanais
                {
                    Televisao = televisaoBasico,
                    Canais = canaisRTP1,
                },
                   new PacoteCanais
                {
                    Televisao = televisaoBasico,
                    Canais = canaisRTP2,
                },
                   new PacoteCanais
                {
                    Televisao = televisaoBasico,
                    Canais = canaisRTP3,
                },
                   new PacoteCanais
                {
                    Televisao = televisaoEnt,
                    Canais = canaisAXN,
                },
                   new PacoteCanais
                {
                    Televisao = televisaoEnt,
                    Canais = canaisTvCine,
                },
                   new PacoteCanais
                {
                    Televisao = televisaoEnt,
                    Canais = canaisHoll,
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
            NetFixa netFixa = DbContext.NetFixa.FirstOrDefault(n => n.TipoConexao == "Básico");
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
        //       Distritos
        //       DADOS DE TESTE 
        //-------------------------------------------------
        private static void InsereDadosTesteDistrito(UPtelContext DbContext)
        {
            if (DbContext.Distrito.Any()) return;
            DbContext.Distrito.AddRange(new Distrito[] {
            new Distrito
            {
                DistritoNome = "Nacional",
            },
            new Distrito
            {
                DistritoNome = "Aveiro",
            },
            new Distrito
            {
                DistritoNome = "Beja",
            },
            new Distrito
            {
                DistritoNome = "Braga",
            },            
            new Distrito
            {
                DistritoNome = "Bragança",
            },            
            new Distrito
            {
                DistritoNome = "Castelo Branco",
            },            
            new Distrito
            {
                DistritoNome = "Coimbra",
            },            
            new Distrito
            {
                DistritoNome = "Évora",
            },            
            new Distrito
            {
                DistritoNome = "Faro",
            },            
            new Distrito
            {
                DistritoNome = "Guarda",
            },            
            new Distrito
            {
                DistritoNome = "Leiria",
            },            
            new Distrito
            {
                DistritoNome = "Lisboa",
            },            
            new Distrito
            {
                DistritoNome = "Portalegre",
            },            
            new Distrito
            {
                DistritoNome = "Porto",
            },            
            new Distrito
            {
                DistritoNome = "Santarém",
            },            
            new Distrito
            {
                DistritoNome = "Setúbal",
            },            
            new Distrito
            {
                DistritoNome = "Viana do Castelo",
            },            
            new Distrito
            {
                DistritoNome = "Vila Real",
            },            
            new Distrito
            {
                DistritoNome = "Viseu",
            },            
            new Distrito
            {
                DistritoNome = "Açores",
            },            
            new Distrito
            {
                DistritoNome = "Madeira",
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
                    Estado = "Ativo",
                    CodigoPostalExt = "695",
                    DistritoId = 1,
                    DataRegisto = new DateTime(1999,12,1),


                },
                new Users
                {
                    Nome = "João Santos",
                    Data = new DateTime(1990,8,8),
                    CartaoCidadao="24045212",
                    Contribuinte="157782731",
                    Morada="Rua do Pinho Alto nº 25",
                    CodigoPostal="2300",
                    Telefone="271598874",
                    Telemovel="927856988",
                    Email="joao@ipg.pt",
                    Iban = "1234567891234567891234567",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="588",
                    DistritoId = 1,
                    DataRegisto = new DateTime(1999,12,1),

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
                    Email="maria@ipg.pt",
                    Iban = "1234567891234567891234567",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="588",
                    DistritoId = 1,
                    DataRegisto = new DateTime(1999,12,1),
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
                    Email="admin@UPtel.pt",
                    Iban = "1234567891234567891234567",
                    Tipo = tipoUserAdministrador,
                    Estado = "Ativo",
                    CodigoPostalExt="588",
                    DistritoId = 1,
                    DataRegisto = new DateTime(1999,12,1),
                },
                });

            DbContext.SaveChanges();
        }

        public static void InsereUsersFicticiosParaTestarPaginacao(UPtelContext DbContext)
        {

            for (int i = 0; i < 20; i++)

            {
                if (DbContext.Users.Any()) return;

                UserType tipoUser = DbContext.UserType.FirstOrDefault(c => c.Tipo == "Cliente Particular");
                UserType tipoUser1 = DbContext.UserType.FirstOrDefault(c => c.Tipo == "Cliente Empresarial");
                UserType tipoUser2 = DbContext.UserType.FirstOrDefault(c => c.Tipo == "Operador");

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
                    Email = "Jose.Ramos@gmail.com " + i,
                    Iban = "1234567891234567891234567",
                    Tipo = tipoUser,
                    Estado = "Ativo",
                    CodigoPostalExt = "695",
                    DataRegisto = new DateTime(1969 + i, 12, 18),
                    DistritoId = 1+i,
                });
                DbContext.Users.Add(new Users
                {
                    Nome = "Manuel Antunes " + i,
                    Data = new DateTime(1969, 12, 18),
                    CartaoCidadao = Convert.ToString(12345870 + i),
                    Contribuinte = Convert.ToString(123456800 + i),
                    Morada = "Rua Júlio Cesár Machado nº14",
                    CodigoPostal = "1500",
                    Telefone = Convert.ToString(247112500 + i),
                    Telemovel = Convert.ToString(913456700 + i),
                    Email = "Manuel.Antunes@gmail.com " + i,
                    Iban = "1234567891234567891234567",
                    Tipo = tipoUser1,
                    Estado = "Ativo",
                    CodigoPostalExt = "695",
                    DataRegisto = new DateTime(1969 + i, 12, 18),
                    DistritoId = 1 + i,
                });
                DbContext.Users.Add(new Users
                {
                    Nome = "Joaquim " + i,
                    Data = new DateTime(1969, 12, 18),
                    CartaoCidadao = Convert.ToString(12346870 + i),
                    Contribuinte = Convert.ToString(123466800 + i),
                    Morada = "Rua Júlio Cesár Machado nº14",
                    CodigoPostal = "1500",
                    Telefone = Convert.ToString(247112500 + i),
                    Telemovel = Convert.ToString(913456700 + i),
                    Email = "Joaquim@gmail.com " + i,
                    Iban = "1234567891234567891234567",
                    Tipo = tipoUser2,
                    Estado = "Ativo",
                    CodigoPostalExt = "695",
                    DataRegisto = new DateTime(1969 + i, 12, 18),
                    DistritoId = 1 + i,
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

            Users clientes = DbContext.Users.FirstOrDefault(t => t.Nome == "João Santos");
            Users funcionarios = DbContext.Users.FirstOrDefault(t => t.Nome == "Mariana Rute Guedes");
            Pacotes pacotes = DbContext.Pacotes.FirstOrDefault(t => t.NomePacote == "Básico");
            Distrito distrito = DbContext.Distrito.FirstOrDefault(d => d.DistritoNome == "Évora");

            DbContext.Contratos.AddRange(new Contratos[]
               {
                new Contratos
                {
                    Cliente = clientes,
                    Funcionario = funcionarios,
                    Pacote = pacotes,
                    DataInicio = new DateTime(1965,05,25),
                    Fidelizacao = 5,
                    PrecoContrato = 59m,
                    Numeros = null,
                    MoradaContrato = "rua",
                    CodigoPostalCont = "1252",
                    CodigoPostalExtCont= "222",
                    DistritoNome = distrito,
                },


                });

            DbContext.SaveChanges();
        }


        ////-------------------------------------------------
        ////         PROMO TELEMOVEL
        ////   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        ////-------------------------------------------------

        private static void InsereDadosPromoTelemovel(UPtelContext DbContext)
        {
          
            if (DbContext.PromoTelemovel.Any()) return;
           
            Distrito distrito = DbContext.Distrito.FirstOrDefault(c => c.DistritoNome == "Aveiro");
            Distrito distrito1 = DbContext.Distrito.FirstOrDefault(c => c.DistritoNome == "Lisboa");

            DbContext.PromoTelemovel.AddRange(new PromoTelemovel[] {
            new PromoTelemovel
            {
                Nome = "Dia dos namorados",
                LimiteMinutos = 500,
                LimiteSMS = 500,
                DecontoPrecoMinNacional = 0m,
                DecontoPrecoMinInternacional = 0m,
                DecontoPrecoSMS = 5m,
                DecontoPrecoMMS = 0m,
                DecontoPrecoTotal = 0m,
                Estado = "On",
                DistritoNome = distrito,
                DistritoNomes = distrito.DistritoNome,

            },
            new PromoTelemovel
            {
                Nome = "Páscoa",
                LimiteMinutos = 500,
                LimiteSMS = 500,
                DecontoPrecoMinNacional = 2m,
                DecontoPrecoMinInternacional = 2m,
                DecontoPrecoSMS = 0m,
                DecontoPrecoMMS = 0m,
                DecontoPrecoTotal = 0m,
                Estado = "On",
                DistritoNome = distrito,
                DistritoNomes = distrito.DistritoNome,

            },
            new PromoTelemovel
            {
                Nome = "Natal",
                LimiteMinutos = 0,
                LimiteSMS = 0,
                DecontoPrecoMinNacional = 0m,
                DecontoPrecoMinInternacional = 0m,
                DecontoPrecoSMS = 0m,
                DecontoPrecoMMS = 0m,
                DecontoPrecoTotal = 10m,
                Estado = "Off",
                DistritoNome = distrito,
                DistritoNomes = distrito.DistritoNome,

            },
            
            new PromoTelemovel
            {
                Nome = "Dia dos namorados",
                LimiteMinutos = 500,
                LimiteSMS = 500,
                DecontoPrecoMinNacional = 0m,
                DecontoPrecoMinInternacional = 0m,
                DecontoPrecoSMS = 5m,
                DecontoPrecoMMS = 0m,
                DecontoPrecoTotal = 0m,
                Estado = "On",
                DistritoNome = distrito1,
                DistritoNomes = distrito1.DistritoNome,

            },
            new PromoTelemovel
            {
                Nome = "Páscoa",
                LimiteMinutos = 500,
                LimiteSMS = 500,
                DecontoPrecoMinNacional = 2m,
                DecontoPrecoMinInternacional = 2m,
                DecontoPrecoSMS = 0m,
                DecontoPrecoMMS = 0m,
                DecontoPrecoTotal = 0m,
                Estado = "On",
                DistritoNome = distrito1,
                DistritoNomes = distrito1.DistritoNome,

            },
            new PromoTelemovel
            {
                Nome = "Natal",
                LimiteMinutos = 0,
                LimiteSMS = 0,
                DecontoPrecoMinNacional = 0m,
                DecontoPrecoMinInternacional = 0m,
                DecontoPrecoSMS = 0m,
                DecontoPrecoMMS = 0m,
                DecontoPrecoTotal = 10m,
                Estado = "Off",
                DistritoNome = distrito1,
                DistritoNomes = distrito1.DistritoNome,

            },

        });
            DbContext.SaveChanges();
        }

        ////-------------------------------------------------
        ////        CONTRATO PROMO TELEMOVEL
        ////   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        ////-------------------------------------------------

        private static void InsereDadosContratoPromoTelemovel(UPtelContext DbContext)
        {

            if (DbContext.ContratoPromoTelemovel.Any()) return;
            PromoTelemovel promoNatal = DbContext.PromoTelemovel.FirstOrDefault(c => c.Nome == "Natal");
            Contratos contratoNatal = DbContext.Contratos.FirstOrDefault(c => c.Cliente.Nome == "João Santos");


           DbContext.ContratoPromoTelemovel.AddRange(new ContratoPromoTelemovel[]
           {
            new ContratoPromoTelemovel
            {

                Contratos = contratoNatal,
                PromoTelemovel  = promoNatal,
                DataInicio =  new DateTime(2021,12,1),
                DataFim =  new DateTime(2021,12,31),
            },
            

           });
            DbContext.SaveChanges();
        }


        ////-------------------------------------------------
        ////         PROMO NET MÓVEL
        ////   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        ////-------------------------------------------------

        private static void InsereDadosPromoNetMovel(UPtelContext DbContext)
        {

            if (DbContext.PromoNetMovel.Any()) return;

            Distrito distrito = DbContext.Distrito.FirstOrDefault(c => c.DistritoNome == "Aveiro");

            DbContext.PromoNetMovel.AddRange(new PromoNetMovel[] {
            new PromoNetMovel
            {
                Nome = "Dia dos namorados",
                Limite = 1,
                DescontoPrecoTotal = 10,
                Estado = "On",
                DistritoNome = distrito,
                DistritoNomes = distrito.DistritoNome,

            },
            new PromoNetMovel
            {
                Nome = "Páscoa",
                Limite = 4,
                DescontoPrecoTotal = 5,
                Estado = "On",
                DistritoNome = distrito,
                DistritoNomes = distrito.DistritoNome,

            },
            new PromoNetMovel
            {
                Nome = "Natal",
                Limite = 5,
                DescontoPrecoTotal = 5,
                Estado = "Off",
                DistritoNome = distrito,
                DistritoNomes = distrito.DistritoNome,

            },

        });
            DbContext.SaveChanges();
        }

        ////-------------------------------------------------
        ////        CONTRATO PROMO NET MÓVEL
        ////   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        ////-------------------------------------------------

        private static void InsereDadosContratoPromoNetMovel(UPtelContext DbContext)
        {

            if (DbContext.ContratoPromoNetMovel.Any()) return;
            PromoNetMovel promoNatal = DbContext.PromoNetMovel.FirstOrDefault(c => c.Nome == "Natal");
            Contratos contratoNatal = DbContext.Contratos.FirstOrDefault(c => c.Cliente.Nome == "João Santos");


            DbContext.ContratoPromoNetMovel.AddRange(new ContratoPromoNetMovel[]
            {
            new ContratoPromoNetMovel
            {

                Contratos = contratoNatal,
                PromoNetMovel  = promoNatal,
                DataInicio =  new DateTime(2021,12,1),
                DataFim =  new DateTime(2021,12,31),
            },


            });
            DbContext.SaveChanges();
        }
       
        ////-------------------------------------------------
        ////         PROMO NET FIXA
        ////   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        ////-------------------------------------------------

        private static void InsereDadosPromoNetFixa(UPtelContext DbContext)
        {

            if (DbContext.PromoNetFixa.Any()) return;

            Distrito distrito = DbContext.Distrito.FirstOrDefault(c => c.DistritoNome == "Aveiro");

            DbContext.PromoNetFixa.AddRange(new PromoNetFixa[] {
            new PromoNetFixa
            {
                Nome = "Dia dos namorados",
                Velocidade  = 30,
                Limite = 1,
                DescontoPrecoTotal = 10,
                Estado = "On",
                DistritoNome = distrito,
                DistritoNomes =distrito.DistritoNome,


            },
            new PromoNetFixa
            {
                Nome = "Páscoa",
                Velocidade = 50,
                Limite = 4,
                DescontoPrecoTotal = 5,
                Estado = "On",
                DistritoNome = distrito,
                DistritoNomes =distrito.DistritoNome,
            },
            new PromoNetFixa
            {
                Nome = "Natal",
                Velocidade = 100,
                Limite = 5,
                DescontoPrecoTotal = 5,
                Estado = "Off",
                DistritoNome = distrito,
                DistritoNomes =distrito.DistritoNome,

            },

        });
            DbContext.SaveChanges();
        }

        ////-------------------------------------------------
        ////        CONTRATO PROMO NET FIXA
        ////   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        ////-------------------------------------------------

        private static void InsereDadosContratoPromoNetFixa(UPtelContext DbContext)
        {

            if (DbContext.ContratoPromoNetFixa.Any()) return;
            PromoNetFixa promoNatal = DbContext.PromoNetFixa.FirstOrDefault(c => c.Nome == "Páscoa");
            Contratos contratoNatal = DbContext.Contratos.FirstOrDefault(c => c.Cliente.Nome == "João Santos");


            DbContext.ContratoPromoNetFixa.AddRange(new ContratoPromoNetFixa[]
            {
            new ContratoPromoNetFixa
            {

                Contratos = contratoNatal,
                PromoNetFixa  = promoNatal,
                DataInicio =  new DateTime(2021,12,1),
                DataFim =  new DateTime(2021,12,31),
            },


            });
            DbContext.SaveChanges();
        }

        ////-------------------------------------------------
        ////         PROMO TELEFONE
        ////   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        ////-------------------------------------------------

        private static void InsereDadosPromoTelefone(UPtelContext DbContext)
        {

            if (DbContext.PromoTelefone.Any()) return;

            Distrito distrito = DbContext.Distrito.FirstOrDefault(c => c.DistritoNome == "Aveiro");
           
            DbContext.PromoTelefone.AddRange(new PromoTelefone[] {
            new PromoTelefone
            {
                Nome = "Dia dos namorados",
                DescontoMinNacional = 10,
                DescontoMinInternacional = 6,
                Limite = 1,
                DescontoPrecoTotal = 10,
                Estado = "On",
                DistritoNome = distrito,
                DistritoNomes = distrito.DistritoNome,

            },
            new PromoTelefone
            {
                Nome = "Páscoa",
                DescontoMinNacional = 5,
                DescontoMinInternacional = 10,
                Limite = 4,
                DescontoPrecoTotal = 5,
                Estado = "On",
                DistritoNome = distrito,
                DistritoNomes = distrito.DistritoNome,

            },
            new PromoTelefone
            {
                Nome = "Natal",
                DescontoMinNacional = 20,
                DescontoMinInternacional = 50,
                Limite = 5,
                DescontoPrecoTotal = 10,
                Estado = "Off",
                DistritoNome = distrito,
                DistritoNomes = distrito.DistritoNome,

            },

        });
            DbContext.SaveChanges();
        }

        ////-------------------------------------------------
        ////        CONTRATO PROMO TELEFONE
        ////   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        ////-------------------------------------------------

        private static void InsereDadosContratoPromoTelefone(UPtelContext DbContext)
        {

            if (DbContext.ContratoPromoTelefone.Any()) return;
            PromoTelefone promoNatal = DbContext.PromoTelefone.FirstOrDefault(c => c.Nome == "Páscoa");
            Contratos contratoNatal = DbContext.Contratos.FirstOrDefault(c => c.Cliente.Nome == "João Santos");


            DbContext.ContratoPromoTelefone.AddRange(new ContratoPromoTelefone[]
            {
            new ContratoPromoTelefone
            {

                Contratos = contratoNatal,
                PromoTelefone  = promoNatal,
                DataInicio =  new DateTime(2021,12,1),
                DataFim =  new DateTime(2021,12,31),
            },


            });
            DbContext.SaveChanges();
        }

        ////-------------------------------------------------
        ////         PROMO TELEVISÃO
        ////   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        ////-------------------------------------------------

        private static void InsereDadosPromoTelevisao(UPtelContext DbContext)
        {

            if (DbContext.PromoTelevisao.Any()) return;

            Distrito distrito = DbContext.Distrito.FirstOrDefault(c => c.DistritoNome == "Aveiro");
          
            DbContext.PromoTelevisao.AddRange(new PromoTelevisao[] {
            new PromoTelevisao
            {
                Nome = "Dia dos namorados",
                CanaisGratis = 5,
                DescontoPrecoTotal = 10,
                Estado = "On",
                DistritoNome = distrito,
                DistritoNomes = distrito.DistritoNome,


            },
            new PromoTelevisao
            {
                Nome = "Páscoa",
                CanaisGratis = 4,
                DescontoPrecoTotal = 5,
               Estado = "On",
                DistritoNome = distrito,
                DistritoNomes = distrito.DistritoNome,


            },
            new PromoTelevisao
            {
                Nome = "Natal",
                CanaisGratis = 2,
                DescontoPrecoTotal = 10,
               Estado = "Off",
                DistritoNome = distrito,
                DistritoNomes = distrito.DistritoNome,


            },

        });
            DbContext.SaveChanges();
        }

        ////-------------------------------------------------
        ////        CONTRATO PROMO TELEVISÃO
        ////   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        ////-------------------------------------------------

        private static void InsereDadosContratoPromoTelevisao(UPtelContext DbContext)
        {
            

            if (DbContext.ContratoPromoTelevisao.Any()) return;
            PromoTelevisao promoNatal = DbContext.PromoTelevisao.FirstOrDefault(c => c.Nome == "Páscoa");
            Contratos contratoNatal = DbContext.Contratos.FirstOrDefault(c => c.Cliente.Nome == "João Santos");


            DbContext.ContratoPromoTelevisao.AddRange(new ContratoPromoTelevisao[]
            {
            new ContratoPromoTelevisao
            {

                Contratos = contratoNatal,
                PromoTelevisao  = promoNatal,
                DataInicio =  new DateTime(2021,12,1),
                DataFim =  new DateTime(2021,12,31),
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