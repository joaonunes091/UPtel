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
            InsereDadosTesteMeses(DbContext);
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
            NetFixa netFixa = DbContext.NetFixa.FirstOrDefault(n => n.Nome == "Básico");
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
        //       MESES
        //       DADOS DE TESTE 
        //-------------------------------------------------


        private static void InsereDadosTesteMeses(UPtelContext DbContext)
        {
            if (DbContext.Meses.Any()) return;
            DbContext.Meses.AddRange(new Meses[] {
            new Meses
            {
                MesId= 1,
                Mes = "Janeiro",
            },
            new Meses
            {
                MesId=2,
                Mes = "Fevereiro",
            },new Meses
            {
                MesId=3,
                Mes = "Março",
            }, new Meses
            {
                MesId=4,
                Mes = "Abril",
            },
            new Meses
            {
                MesId=5,
                Mes = "Maio",
            },
            new Meses
            {
                MesId=6,
                Mes = "Junho",
            },new Meses
            {
                MesId=7,
                Mes = "Julho",
            }, new Meses
            {
                MesId=8,
                Mes = "Agosto",
            },
            new Meses
            {
                MesId=9,
                Mes = "Setembro",
            },
            new Meses
            {
                MesId=10,
                Mes = "Outubro",
            },new Meses
            {
                MesId=11,
                Mes = "Novembro",
            }, new Meses
            {
                MesId=12,
                Mes = "Dezembro",
            },
        });
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

                //USERS AVEIRO ID=2
                //CLIENTES
                new Users
                {
                    Nome = "Pedro Silva",
                    Data = new DateTime(1975,11,20),
                    CartaoCidadao="12445217",
                    Contribuinte="153654459",
                    Morada="Rua da Fonte nº20",
                    CodigoPostal="4500",
                    Telefone="271487444",
                    Telemovel="965598777",
                    Email="PedroSilva@UPtelAveiro.pt",
                    Iban = "1234598765555567891234567",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="756",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2020,12,1),
                },
                new Users
                {
                    Nome = "Simão Gonçalves",
                    Data = new DateTime(1998,7,25),
                    CartaoCidadao="24045217",
                    Contribuinte="157782459",
                    Morada="Rua da Fonte nº3",
                    CodigoPostal="4500",
                    Telefone="271487569",
                    Telemovel="965484777",
                    Email="SimaoGonçalves@UPtelAveiro.pt",
                    Iban = "1234567895555567891234567",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="700",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2020,10,12),
                },
                new Users
                {
                    Nome = "Carlos Costa",
                    Data = new DateTime(1969,10,25),
                    CartaoCidadao="24187217",
                    Contribuinte="157799959",
                    Morada="Rua da Praça nº5",
                    CodigoPostal="4500",
                    Telefone="272548769",
                    Telemovel="965154877",
                    Email="CarlosCosta@UPtelAveiro.pt",
                    Iban = "1234567567891895555444567",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="550",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2019,12,28),
                },
                new Users
                {
                    Nome = "Vanessa Ferreira",
                    Data = new DateTime(1980,5,15),
                    CartaoCidadao="24041452",
                    Contribuinte="157142659",
                    Morada="Rua do Largo nº 16",
                    CodigoPostal="4500",
                    Telefone="271487569",
                    Telemovel="965484777",
                    Email="VanessaFerreira@UPtelAveiro.pt",
                    Iban = "1234567895554167891234567",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="726",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2021,3,1),
                },
                new Users
                {
                    Nome = "Luis Dias",
                    Data = new DateTime(1998,7,25),
                    CartaoCidadao="24044859",
                    Contribuinte="168592459",
                    Morada="Rua da Fonte nº 2",
                    CodigoPostal="4500",
                    Telefone="271548965",
                    Telemovel="965665847",
                    Email="LuisDias@UPtelAveiro.pt",
                    Iban = "1234567895555567891234567",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="700",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2020,12,20),
                },
                new Users
                {
                    Nome = "Fernando Rui",
                    Data = new DateTime(1987,7,15),
                    CartaoCidadao="24487559",
                    Contribuinte="162548659",
                    Morada="Rua da Praça nº2",
                    CodigoPostal="4500",
                    Telefone="271514565",
                    Telemovel="965145967",
                    Email="FernandoRui@UPtelAveiro.pt",
                    Iban = "1234561526475567891234567",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="421",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2021,2,17),
                },
                new Users
                {
                    Nome = "Joana Lima",
                    Data = new DateTime(1988,8,18),
                    CartaoCidadao="24445879",
                    Contribuinte="162547749",
                    Morada="Rua da Praça nº8",
                    CodigoPostal="4500",
                    Telefone="271514565",
                    Telemovel="965145967",
                    Email="JoanaLima@UPtelAveiro.pt",
                    Iban = "1237556789145615264234567",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="421",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2020,2,14),
                },
                new Users
                {
                    Nome = "Madalena Vieira",
                    Data = new DateTime(1990,9,25),
                    CartaoCidadao="24459875",
                    Contribuinte="162565948",
                    Morada="Rua do General nº27",
                    CodigoPostal="4500",
                    Telefone="271145655",
                    Telemovel="969651457",
                    Email="MadalenaVieira@UPtelAveiro.pt",
                    Iban = "1237556615264789145723456",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="300",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2019,8,13),
                },
                new Users
                {
                    Nome = "Rosa Sousa",
                    Data = new DateTime(1994,3,7),
                    CartaoCidadao="29874455",
                    Contribuinte="156596248",
                    Morada="Rua do General nº14",
                    CodigoPostal="4500",
                    Telefone="271551645",
                    Telemovel="966591457",
                    Email="RosaSousa@UPtelAveiro.pt",
                    Iban = "1236655277152345891457646",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="301",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2019,8,28),
                },
                new Users
                {
                    Nome = "Rute Antunes",
                    Data = new DateTime(1996,6,6),
                    CartaoCidadao="29484628",
                    Contribuinte="151548748",
                    Morada="Rua de S.Pedro nº 4",
                    CodigoPostal="4500",
                    Telefone="",
                    Telemovel="966591457",
                    Email="RuteAntunes@UPtelAveiro.pt",
                    Iban = "1236623458911889715457646",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="289",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2019,10,8),
                },

                //OPERADORES
                new Users
                {
                    Nome = "Silvia Mafalda",
                    Data = new DateTime(1988,11,19),
                    CartaoCidadao="26472591",
                    Contribuinte="13254495",
                    Morada="Rua do Comércio nº16",
                    CodigoPostal="4500",
                    Telefone="234515496",
                    Telemovel="961151844",
                    Email="SilviaMafalda@UPtelAveiro.pt",
                    Iban = "1234567891234591234567867",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="600",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2017,8,2),
                },
                new Users
                {
                    Nome = "António Fonte",
                    Data = new DateTime(1976,3,33),
                    CartaoCidadao="26725914",
                    Contribuinte="13544952",
                    Morada="Largo da Praça nº 19",
                    CodigoPostal="4500",
                    Telefone="234515496",
                    Telemovel="961151844",
                    Email="AntonioFonte@UPtelAveiro.pt",
                    Iban = "1129173456786345223459678",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="390",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2017,8,3),
                },
                new Users
                {
                    Nome = "Nuno Azeite",
                    Data = new DateTime(1980,1,9),
                    CartaoCidadao="26387991",
                    Contribuinte="13253335",
                    Morada="Rua do Pinhal nº 7",
                    CodigoPostal="4500",
                    Telefone="234515496",
                    Telemovel="961151844",
                    Email="NunoAzeite@UPtelAveiro.pt",
                    Iban = "1234567891234591234567867",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="600",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2017,8,2),
                },
                new Users
                {
                    Nome = "Nelsón Pinto",
                    Data = new DateTime(1983,10,20),
                    CartaoCidadao="26459172",
                    Contribuinte="19325445",
                    Morada="Rua da Câmara nº6",
                    CodigoPostal="4500",
                    Telefone="",
                    Telemovel="961415117",
                    Email="NelsonPinto@UPtelAveiro.pt",
                    Iban = "1234789123459123456785667",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="186",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2017,11,22),
                },
                new Users
                {
                    Nome = "Vitor Fernandes",
                    Data = new DateTime(1983,10,20),
                    CartaoCidadao="26459172",
                    Contribuinte="19325445",
                    Morada="Rua da Câmara nº18",
                    CodigoPostal="4500",
                    Telefone="",
                    Telemovel="961684994",
                    Email="VitorFernandes@UPtelAveiro.pt",
                    Iban = "1263478912453485659123677",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="189",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2018,7,10),
                },
                new Users
                {
                    Nome = "Ana Gomes",
                    Data = new DateTime(1985,3,4),
                    CartaoCidadao="26545847",
                    Contribuinte="13658499",
                    Morada="Rua do Olival nº1",
                    CodigoPostal="4500",
                    Telefone="271958684",
                    Telemovel="968491469",
                    Email="AnaGomes@UPtelAveiro.pt",
                    Iban = "1263478912453485659123677",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="109",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2018,5,17),
                },
                new Users
                {
                    Nome = "Rúben Fernandes",
                    Data = new DateTime(1998,10,20),
                    CartaoCidadao="26174592",
                    Contribuinte="19544532",
                    Morada="Rua da Escola Nova nº4",
                    CodigoPostal="4500",
                    Telefone="",
                    Telemovel="961698494",
                    Email="RubenFernandes@UPtelAveiro.pt",
                    Iban = "1263456259178917236348547",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="139",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2021,1,26),
                },
                new Users
                {
                    Nome = "Inês Sousa",
                    Data = new DateTime(1999,3,16),
                    CartaoCidadao="26414452",
                    Contribuinte="19359752",
                    Morada="Bairro de S.Pedro nº14",
                    CodigoPostal="4500",
                    Telefone="",
                    Telemovel="961698494",
                    Email="InesSousa@UPtelAveiro.pt",
                    Iban = "1265917472538948345176362",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="220",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2021,1,14),
                },
                new Users
                {
                    Nome = "Rita Silva",
                    Data = new DateTime(1998,4,10),
                    CartaoCidadao="26745921",
                    Contribuinte="15395442",
                    Morada="Rua da Escola Nova nº4",
                    CodigoPostal="4500",
                    Telefone="",
                    Telemovel="964916984",
                    Email="RitaSilva@UPtelAveiro.pt",
                    Iban = "1263458594786363251249177",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="356",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2020,11,8),
                },
                new Users
                {
                    Nome = "Ricardo Vieira",
                    Data = new DateTime(1996,4,1),
                    CartaoCidadao="26173692",
                    Contribuinte="19368432",
                    Morada="Rua da Escola Nova nº18",
                    CodigoPostal="4500",
                    Telefone="",
                    Telemovel="964616994",
                    Email="RicardoVieira@UPtelAveiro.pt",
                    Iban = "1263456259178917236348547",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="140",
                    DistritoId = 2,
                    DataRegisto = new DateTime(2020,1,6),
                },

                //USERS BEJA ID=3
                //CLIENTES
                new Users
                {
                    Nome = "Gustavo Simões",
                    Data = new DateTime(1980,8,29),
                    CartaoCidadao="12452174",
                    Contribuinte="153965445",
                    Morada="Rua da Fonte nº20",
                    CodigoPostal="3900",
                    Telefone="278744414",
                    Telemovel="965757987",
                    Email="GustavoSimoes@UPtelBeja.pt",
                    Iban = "1234589987655515567623457",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="100",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2019,6,15),
                },
                new Users
                {
                    Nome = "Sara Forte",
                    Data = new DateTime(1991,8,31),
                    CartaoCidadao="14521472",
                    Contribuinte="154963545",
                    Morada="Rua da Enseada nº18",
                    CodigoPostal="3900",
                    Telefone="",
                    Telemovel="965123457",
                    Email="SaraForte@UPtelBeja.pt",
                    Iban = "1236599675514586238755457",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="110",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2019,4,20),
                },
                new Users
                {
                    Nome = "Rute Manteigas",
                    Data = new DateTime(1994,4,1),
                    CartaoCidadao="12452174",
                    Contribuinte="153965445",
                    Morada="Rua da Fonte nº4",
                    CodigoPostal="3900",
                    Telefone="277444184",
                    Telemovel="965798577",
                    Email="RuteManteigas@UPtelBeja.pt",
                    Iban = "1234155655235876554998767",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="120",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2019,6,3),
                },
                new Users
                {
                    Nome = "Hélton Leite",
                    Data = new DateTime(1992,10,21),
                    CartaoCidadao="12447874",
                    Contribuinte="156493745",
                    Morada="Rua da Fonte nº15",
                    CodigoPostal="3900",
                    Telefone="",
                    Telemovel="965793377",
                    Email="HéltonLeite@UPtelBeja.pt",
                    Iban = "1523587655494155987623657",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="130",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2019,10,18),
                },
                new Users
                {
                    Nome = "Francisco Ferreira",
                    Data = new DateTime(1998,5,7),
                    CartaoCidadao="12411874",
                    Contribuinte="151113745",
                    Morada="Rua da Ponte nº2",
                    CodigoPostal="3900",
                    Telefone="",
                    Telemovel="965793377",
                    Email="FranciscoFerreira@UPtelBeja.pt",
                    Iban = "1523587655987623554941657",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="140",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2018,9,10),
                },
                new Users
                {
                    Nome = "Jorge Conceição",
                    Data = new DateTime(1972,1,8),
                    CartaoCidadao="12478744",
                    Contribuinte="153764945",
                    Morada="Rua da Fonte nº15",
                    CodigoPostal="3900",
                    Telefone="",
                    Telemovel="965718727",
                    Email="JorgeConceicao@UPtelBeja.pt",
                    Iban = "1527587655496233415598657",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="150",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2019,10,15),
                },
                new Users
                {
                    Nome = "Miguel Garcia",
                    Data = new DateTime(1995,10,4),
                    CartaoCidadao="12441234",
                    Contribuinte="156258745",
                    Morada="Rua da Praça nº5",
                    CodigoPostal="3900",
                    Telefone="271598654",
                    Telemovel="965793377",
                    Email="MiguelGarcia@UPtelBeja.pt",
                    Iban = "1529876238765549355741556",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="160",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2019,3,31),
                },
                new Users
                {
                    Nome = "Susana Sampaio",
                    Data = new DateTime(1986,7,21),
                    CartaoCidadao="12441598",
                    Contribuinte="289374645",
                    Morada="Rua do Jardim nº4",
                    CodigoPostal="3900",
                    Telefone="",
                    Telemovel="965793377",
                    Email="SusanaSampaio@UPtelBeja.pt",
                    Iban = "1523587655494598652223657",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="170",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2019,10,1),
                },
                new Users
                {
                    Nome = "Beatriz Nunes",
                    Data = new DateTime(1985,4,12),
                    CartaoCidadao="12487447",
                    Contribuinte="159374645",
                    Morada="Rua do Pinhal Novo nº10",
                    CodigoPostal="3900",
                    Telefone="",
                    Telemovel="965793377",
                    Email="BeatrizNunes@UPtelBeja.pt",
                    Iban = "1523587655494155987623657",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="180",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2021,1,8),
                },
                new Users
                {
                    Nome = "Vasco Simões",
                    Data = new DateTime(1997,7,27),
                    CartaoCidadao="12487447",
                    Contribuinte="157464935",
                    Morada="Rua da Fonte nº30",
                    CodigoPostal="3900",
                    Telefone="",
                    Telemovel="963577793",
                    Email="VascoSimoes@UPtelBeja.pt",
                    Iban = "1523587655494155987623657",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="190",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2020,5,20),
                },

                //OPERADORES

                new Users
                {
                    Nome = "Mauro Oliveira",
                    Data = new DateTime(1997,1,4),
                    CartaoCidadao="26568472",
                    Contribuinte="14369851",
                    Morada="Rua da Praça nº 45",
                    CodigoPostal="4500",
                    Telefone="",
                    Telemovel="961694694",
                    Email="MauroOliveira@UPtelBeja.pt",
                    Iban = "1263259178917211775648547",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="200",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2019,1,23),
                },
                new Users
                {
                    Nome = "Sérgio Moura",
                    Data = new DateTime(1986,4,11),
                    CartaoCidadao="26547268",
                    Contribuinte="14985361",
                    Morada="Rua da Fonte nº 32",
                    CodigoPostal="4500",
                    Telefone="",
                    Telemovel="916169464",
                    Email="SergioMoura@UPtelBeja.pt",
                    Iban = "1263259178917211775648547",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="210",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2019,5,14),
                },
                new Users
                {
                    Nome = "Laura Fonseca",
                    Data = new DateTime(1994,4,7),
                    CartaoCidadao="26698572",
                    Contribuinte="16795851",
                    Morada="Rua da Fonte nº 27",
                    CodigoPostal="4500",
                    Telefone="",
                    Telemovel="961452394",
                    Email="LauraFonseca@UPtelBeja.pt",
                    Iban = "1261721173854259178975647",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="220",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2018,8,23),
                },
                new Users
                {
                    Nome = "Miguel Salgueiro",
                    Data = new DateTime(1986,7,1),
                    CartaoCidadao="26793572",
                    Contribuinte="16712451",
                    Morada="Rua do Largo nº 20",
                    CodigoPostal="4500",
                    Telefone="",
                    Telemovel="931784484",
                    Email="MiguelSalgueiro@UPtelBeja.pt",
                    Iban = "1261721173854259178975647",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="230",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2018,10,14),
                },
                new Users
                {
                    Nome = "Ricardo Pereira",
                    Data = new DateTime(1982,2,26),
                    CartaoCidadao="26351179",
                    Contribuinte="25169824",
                    Morada="Rua do Largo nº 28",
                    CodigoPostal="4500",
                    Telefone="271659863",
                    Telemovel="934481784",
                    Email="RicardoPereira@UPtelBeja.pt",
                    Iban = "1261721173854259178975647",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="240",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2018,11,30),
                },
                new Users
                {
                    Nome = "Duarte Damas",
                    Data = new DateTime(1990,8,4),
                    CartaoCidadao="24632179",
                    Contribuinte="27625824",
                    Morada="Rua do Largo nº 31",
                    CodigoPostal="4500",
                    Telefone="271123863",
                    Telemovel="934481123",
                    Email="DuarteDamas@UPtelBeja.pt",
                    Iban = "1261756438572194259717178",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="250",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2018,3,30),
                },
                new Users
                {
                    Nome = "Clara Silva",
                    Data = new DateTime(1982,9,11),
                    CartaoCidadao="24618579",
                    Contribuinte="27975824",
                    Morada="Rua do Ferreiro nº10",
                    CodigoPostal="4500",
                    Telefone="272381613",
                    Telemovel="931144823",
                    Email="ClaraSilva@UPtelBeja.pt",
                    Iban = "1261756438572194259717178",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="260",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2017,10,20),
                },
                new Users
                {
                    Nome = "Micaela Ramos",
                    Data = new DateTime(1983,9,28),
                    CartaoCidadao="26185479",
                    Contribuinte="28259375",
                    Morada="Rua do Ferreiro nº24",
                    CodigoPostal="4500",
                    Telefone="272331816",
                    Telemovel="938211443",
                    Email="MicaelaRamos@UPtelBeja.pt",
                    Iban = "1261173271787177572112346",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="270",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2016,4,26),
                },
                new Users
                {
                    Nome = "Manuel Almeida",
                    Data = new DateTime(1986,5,2),
                    CartaoCidadao="26791854",
                    Contribuinte="28297553",
                    Morada="Largo do General nº10",
                    CodigoPostal="4500",
                    Telefone="272142916",
                    Telemovel="939961443",
                    Email="ManuelAlmeida@UPtelBeja.pt",
                    Iban = "1261112112378746725873246",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="280",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2018,6,30),
                },
                new Users
                {
                    Nome = "Joana Costa",
                    Data = new DateTime(1992,5,12),
                    CartaoCidadao="26791854",
                    Contribuinte="28297553",
                    Morada="Largo do General nº28",
                    CodigoPostal="4500",
                    Telefone="272161429",
                    Telemovel="966112393",
                    Email="JoanaCosta@UPtelBeja.pt",
                    Iban = "1261116874672587323254146",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="290",
                    DistritoId = 3,
                    DataRegisto = new DateTime(2020,2,25),
                },

                //USERS COIMBRA ID=7
                //CLIENTES
                new Users
                {
                    Nome = "Gabriel Fernandes",
                    Data = new DateTime(1993,10,18),
                    CartaoCidadao="12684233",
                    Contribuinte="154765239",
                    Morada="Rua da Fonte nº3",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="916347598",
                    Email="GabrielFernandes@UPtelCoimbra.pt",
                    Iban = "1234589658749651987655513",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="100",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2020,6,20),
                },
                new Users
                {
                    Nome = "Henrique Matos",
                    Data = new DateTime(1993,10,18),
                    CartaoCidadao="12685233",
                    Contribuinte="154369239",
                    Morada="Rua da Fonte nº8",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="916314898",
                    Email="HenriqueRamos@UPtelCoimbra.pt",
                    Iban = "1234589658749123637655513",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="110",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2019,7,9),
                },
                new Users
                {
                    Nome = "Soraia Ramos",
                    Data = new DateTime(1989,7,6),
                    CartaoCidadao="12685456",
                    Contribuinte="154842239",
                    Morada="Largo da Fonte Antiga nº4",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="916314898",
                    Email="SoraiaRamos@UPtelCoimbra.pt",
                    Iban = "1234589658715486637655513",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="120",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2019,7,20),
                },
                new Users
                {
                    Nome = "Luis Albuquerque",
                    Data = new DateTime(1979,12,6),
                    CartaoCidadao="12696456",
                    Contribuinte="154452639",
                    Morada="Largo da Fonte Antiga nº18",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="916356398",
                    Email="LuisAlbuquerque@UPtelCoimbra.pt",
                    Iban = "1234589652366378956655513",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="130",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2018,8,16),
                },
                new Users
                {
                    Nome = "Rita Pereira",
                    Data = new DateTime(1977,6,18),
                    CartaoCidadao="12648984",
                    Contribuinte="154634489",
                    Morada="Rua do Mercado nº3",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="916217398",
                    Email="RitaPereira@UPtelCoimbra.pt",
                    Iban = "1234589651589378956648513",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="140",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2019,1,18),
                },
                new Users
                {
                    Nome = "Susana Matias",
                    Data = new DateTime(1980,9,5),
                    CartaoCidadao="12643644",
                    Contribuinte="154784489",
                    Morada="Rua do Mercado nº6",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="916215388",
                    Email="SusanaMatias@UPtelCoimbra.pt",
                    Iban = "1234589653654858956648513",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="150",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2020,1,30),
                },
                new Users
                {
                    Nome = "Júlio Pinheiro",
                    Data = new DateTime(1978,7,8),
                    CartaoCidadao="12925644",
                    Contribuinte="154799489",
                    Morada="Rua da Estação nº4",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="916215148",
                    Email="JulioPinheiro@UPtelCoimbra.pt",
                    Iban = "1234589653654858524898513",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="160",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2019,8,9),
                },
                new Users
                {
                    Nome = "Marta Tobias",
                    Data = new DateTime(1978,12,8),
                    CartaoCidadao="12996844",
                    Contribuinte="154785489",
                    Morada="Rua da Estação nº9",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="916296848",
                    Email="MartaTobias@UPtelCoimbra.pt",
                    Iban = "1234589653653648524898513",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="170",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2019,4,9),
                },
                new Users
                {
                    Nome = "Hélder Tomás",
                    Data = new DateTime(1986,6,7),
                    CartaoCidadao="12996354",
                    Contribuinte="159784489",
                    Morada="Rua do Parque nº11",
                    CodigoPostal="7000",
                    Telefone="269854111",
                    Telemovel="916296848",
                    Email="HelderTomas@UPtelCoimbra.pt",
                    Iban = "1234583843653648965828513",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="180",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2019,12,9),
                },
                new Users
                {
                    Nome = "Pedro Saraiva",
                    Data = new DateTime(1990,2,28),
                    CartaoCidadao="12999654",
                    Contribuinte="154788889",
                    Morada="Rua da Estação nº9",
                    CodigoPostal="7000",
                    Telefone="258475963",
                    Telemovel="916298528",
                    Email="PedroSaraiva@UPtelCoimbra.pt",
                    Iban = "1234589653653636754898513",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="190",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2020,1,31),
                },

                //OPERADORES
                new Users
                {
                    Nome = "Rui Gonçalves",
                    Data = new DateTime(1995,12,14),
                    CartaoCidadao="26368472",
                    Contribuinte="14996551",
                    Morada="Rua da Praça nº 6",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="961684524",
                    Email="RuiGoncalves@UPtelCoimbra.pt",
                    Iban = "1263178152681772595648547",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="200",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2019,1,10),
                },
                new Users
                {
                    Nome = "Joaquim Barreiros",
                    Data = new DateTime(1992,1,1),
                    CartaoCidadao="26368122",
                    Contribuinte="14991251",
                    Morada="Rua da Fonte nº 5",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="961684411",
                    Email="JoaquimBarreiros@UPtelCoimbra.pt",
                    Iban = "1263178152681716485348547",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="210",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2021,3,18),
                },
                new Users
                {
                    Nome = "Filipa César",
                    Data = new DateTime(1999,1,26),
                    CartaoCidadao="21263682",
                    Contribuinte="14125991",
                    Morada="Rua da Fonte nº 18",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="968441611",
                    Email="FilipaCesar@UPtelCoimbra.pt",
                    Iban = "1263171716415268854785348",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="220",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2020,5,20),
                },
                new Users
                {
                    Nome = "Mário Luis",
                    Data = new DateTime(1980,6,26),
                    CartaoCidadao="21824569",
                    Contribuinte="14259251",
                    Morada="Rua João de Sousa nº 8",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="968467261",
                    Email="MarioLuis@UPtelCoimbra.pt",
                    Iban = "1263171885477526164254868",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="230",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2019,7,16),
                },
                new Users
                {
                    Nome = "André Coelho",
                    Data = new DateTime(1985,5,25),
                    CartaoCidadao="21569824",
                    Contribuinte="14251592",
                    Morada="Rua Filipe Leão nº3",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="968461672",
                    Email="AndreCoelho@UPtelCoimbra.pt",
                    Iban = "1263171885473652164254868",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="240",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2019,4,15),
                },
                new Users
                {
                    Nome = "Carlos Pacheco",
                    Data = new DateTime(1991,11,20),
                    CartaoCidadao="21544612",
                    Contribuinte="19523654",
                    Morada="Rua Filipe Leão nº14",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="968746162",
                    Email="CarlosPacheco@UPtelCoimbra.pt",
                    Iban = "1264218867631752545488136",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="250",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2019,6,20),
                },
                new Users
                {
                    Nome = "Manuel Carriço",
                    Data = new DateTime(1991,1,21),
                    CartaoCidadao="21538612",
                    Contribuinte="19585384",
                    Morada="Rua da Fonte nº1",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="962861326",
                    Email="ManuelCarrico@UPtelCoimbra.pt",
                    Iban = "1264313512218867682545136",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="260",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2019,6,30),
                },
                new Users
                {
                    Nome = "Nuno Pedrosa",
                    Data = new DateTime(1993,3,23),
                    CartaoCidadao="24321121",
                    Contribuinte="19869544",
                    Morada="Rua da Fonte nº16",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="962815326",
                    Email="NunoPedrosa@UPtelCoimbra.pt",
                    Iban = "1264124586762112223158256",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="270",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2019,8,15),
                },
                new Users
                {
                    Nome = "Bernardo Amorim",
                    Data = new DateTime(1994,4,24),
                    CartaoCidadao="21061542",
                    Contribuinte="19034585",
                    Morada="Bairro Luis de Camões nº2",
                    CodigoPostal="7000",
                    Telefone="248596478",
                    Telemovel="962328616",
                    Email="BernardoAmorim@UPtelCoimbra.pt",
                    Iban = "1264313576825196488645136",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="280",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2017,7,21),
                },
                new Users
                {
                    Nome = "Salvador Pinhal",
                    Data = new DateTime(1995,5,25),
                    CartaoCidadao="21062742",
                    Contribuinte="19068345",
                    Morada="Bairro Luis de Camões nº9",
                    CodigoPostal="7000",
                    Telefone="248337598",
                    Telemovel="962852866",
                    Email="BernardoAmorim@UPtelCoimbra.pt",
                    Iban = "1264317686545964881253248",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="290",
                    DistritoId = 7,
                    DataRegisto = new DateTime(2018,7,2),
                },

                //USERS LEIRIA ID=11
                //CLIENTES
                new Users
                {
                    Nome = "Tiago Silva",
                    Data = new DateTime(1981,1,19),
                    CartaoCidadao="12419904",
                    Contribuinte="153910045",
                    Morada="Rua do Castelo nº 2",
                    CodigoPostal="1600",
                    Telefone="278736594",
                    Telemovel="965362547",
                    Email="TiagoSilva@UPtelLeiria.pt",
                    Iban = "1234587621298786238349656",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="100",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,4,23),
                },
                new Users
                {
                    Nome = "Filipe Costa",
                    Data = new DateTime(1982,2,10),
                    CartaoCidadao="12491417",
                    Contribuinte="153004915",
                    Morada="Rua do Castelo nº6",
                    CodigoPostal="1600",
                    Telefone="275948736",
                    Telemovel="965536247",
                    Email="FilipeCosta@UPtelLeiria.pt",
                    Iban = "1234587627849656183298623",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="110",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,5,24),
                },
                new Users
                {
                    Nome = "Alexandre Conde",
                    Data = new DateTime(1983,3,11),
                    CartaoCidadao="12414917",
                    Contribuinte="150049135",
                    Morada="Rua de S.Luis nº2",
                    CodigoPostal="1600",
                    Telefone="275948367",
                    Telemovel="965753246",
                    Email="AlexandreConde@UPtelLeiria.pt",
                    Iban = "1237832984968745261586623",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="120",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,6,26),
                },
                new Users
                {
                    Nome = "Beatriz Lopes",
                    Data = new DateTime(1994,4,12),
                    CartaoCidadao="12435867",
                    Contribuinte="154830305",
                    Morada="Rua de S.Luis nº6",
                    CodigoPostal="1600",
                    Telefone="275948367",
                    Telemovel="965753246",
                    Email="BeatrizLopes@UPtelLeiria.pt",
                    Iban = "1237832985874866215269643",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="130",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,7,27),
                },
                new Users
                {
                    Nome = "Beatriz Lopes",
                    Data = new DateTime(1995,5,13),
                    CartaoCidadao="12435342",
                    Contribuinte="154841965",
                    Morada="Rua da Estação Nova nº6",
                    CodigoPostal="1600",
                    Telefone="275943017",
                    Telemovel="965700466",
                    Email="BeatrizLopes@UPtelLeiria.pt",
                    Iban = "1286621858746329523789643",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="140",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,8,20),
                },
                new Users
                {
                    Nome = "Sofia Monteiro",
                    Data = new DateTime(1996,6,14),
                    CartaoCidadao="12415792",
                    Contribuinte="154861119",
                    Morada="Rua da Estação Nova nº13",
                    CodigoPostal="1600",
                    Telefone="279430157",
                    Telemovel="965466700",
                    Email="SofiaMonteiro@UPtelLeiria.pt",
                    Iban = "1286621858952863239643774",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="150",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,9,10),
                },
                new Users
                {
                    Nome = "Vasco Teixeira",
                    Data = new DateTime(1997,5,12),
                    CartaoCidadao="12436992",
                    Contribuinte="154236499",
                    Morada="Rua da Torre nº2",
                    CodigoPostal="1600",
                    Telefone="279086157",
                    Telemovel="965462190",
                    Email="VascoTeixeira@UPtelLeiria.pt",
                    Iban = "1286621237744358989686352",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="160",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,10,1),
                },
                new Users
                {
                    Nome = "João Pedro",
                    Data = new DateTime(1997,7,27),
                    CartaoCidadao="12436132",
                    Contribuinte="154236139",
                    Morada="Rua da Torre nº1",
                    CodigoPostal="1600",
                    Telefone="279024457",
                    Telemovel="965463660",
                    Email="JoaoPedro@UPtelLeiria.pt",
                    Iban = "1923768617243583528662984",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="170",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,3,17),
                },
                new Users
                {
                    Nome = "António Reis",
                    Data = new DateTime(1987,7,30),
                    CartaoCidadao="12613243",
                    Contribuinte="154323619",
                    Morada="Rua da Torre nº6",
                    CodigoPostal="1600",
                    Telefone="270244957",
                    Telemovel="965411730",
                    Email="AntonioReis@UPtelLeiria.pt",
                    Iban = "1925835716323646298688724",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="180",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2019,6,24),
                },
                new Users
                {
                    Nome = "Conceição Pimenta",
                    Data = new DateTime(1988,8,18),
                    CartaoCidadao="12613243",
                    Contribuinte="153611432",
                    Morada="Rua do Bispo nº4",
                    CodigoPostal="1600",
                    Telefone="270239957",
                    Telemovel="965331730",
                    Email="AntonioReis@UPtelLeiria.pt",
                    Iban = "1925835716386462972877764",
                    Tipo = tipoUserParticular,
                    Estado = "Ativo",
                    CodigoPostalExt="190",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2018,1,16),
                },

                //OPERADORES
                new Users
                {
                    Nome = "Silvia Ventura",
                    Data = new DateTime(1979,5,16),
                    CartaoCidadao="12356995",
                    Contribuinte="14130254",
                    Morada="Rua Diogo Cão nº1",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="968412548",
                    Email="SilviaVentura@UPtelLeiria.pt",
                    Iban = "1263171821847348684946855",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="200",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2019,6,15),
                },
                new Users
                {
                    Nome = "Manuel Figueiras",
                    Data = new DateTime(1981,6,13),
                    CartaoCidadao="19295356",
                    Contribuinte="10213544",
                    Morada="Rua Diogo Cão nº6",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="964125488",
                    Email="ManuelFigueiras@UPtelLeiria.pt",
                    Iban = "1263171821847348684946855",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="210",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2019,7,16),
                },
                new Users
                {
                    Nome = "Gustavo Santos",
                    Data = new DateTime(1982,2,12),
                    CartaoCidadao="19295322",
                    Contribuinte="10218974",
                    Morada="Rua do Castelo nº3",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="965484128",
                    Email="GustavoSantos@UPtelLeiria.pt",
                    Iban = "1263171738218485548684946",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="220",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2019,8,17),
                },
                new Users
                {
                    Nome = "Filipe Neto",
                    Data = new DateTime(1983,3,30),
                    CartaoCidadao="19291243",
                    Contribuinte="10210474",
                    Morada="Rua do Castelo nº10",
                    CodigoPostal="7000",
                    Telefone="235948661",
                    Telemovel="968541112",
                    Email="FilipeNeto@UPtelLeiria.pt",
                    Iban = "1263175421848486838175694",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="230",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2019,10,20),
                },
                new Users
                {
                    Nome = "Marta Seguro",
                    Data = new DateTime(1983,6,3),
                    CartaoCidadao="19243912",
                    Contribuinte="10042174",
                    Morada="Rua S.João nº3",
                    CodigoPostal="7000",
                    Telefone="238661594",
                    Telemovel="964185102",
                    Email="MartaSeguro@UPtelLeiria.pt",
                    Iban = "1268483817317542148111694",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="240",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2019,12,27),
                },
                new Users
                {
                    Nome = "Sabrina Oliveira",
                    Data = new DateTime(1985,9,10),
                    CartaoCidadao="19241102",
                    Contribuinte="10049684",
                    Morada="Rua S.João nº9",
                    CodigoPostal="7000",
                    Telefone="238661108",
                    Telemovel="964180687",
                    Email="SabrinaOliveira@UPtelLeiria.pt",
                    Iban = "1268483817321349481883694",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="250",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,6,18),
                },
                new Users
                {
                    Nome = "Fábio Torres",
                    Data = new DateTime(1987,9,13),
                    CartaoCidadao="19215841",
                    Contribuinte="10896448",
                    Morada="Rua da Misericórdia nº4",
                    CodigoPostal="7000",
                    Telefone="238661848",
                    Telemovel="964176587",
                    Email="FabioTorres@UPtelLeiria.pt",
                    Iban = "1848314128669813447882933",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="260",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,8,6),
                },
                new Users
                {
                    Nome = "Paulo Silva",
                    Data = new DateTime(1989,9,19),
                    CartaoCidadao="11101492",
                    Contribuinte="16440898",
                    Morada="Rua da Misericórdia nº6",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="964176182",
                    Email="PauloSilva@UPtelLeiria.pt",
                    Iban = "1412384831447882866981933",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="270",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,7,7),
                },
                new Users
                {
                    Nome = "Natália Figueiredo",
                    Data = new DateTime(1995,10,5),
                    CartaoCidadao="12101491",
                    Contribuinte="16444898",
                    Morada="Rua da Misericórdia nº13",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="961761482",
                    Email="NataliaFigueiredo@UPtelLeiria.pt",
                    Iban = "1384148312193344788286698",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="280",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,12,2),
                },
                new Users
                {
                    Nome = "Raúl Ramos",
                    Data = new DateTime(1994,8,17),
                    CartaoCidadao="12012561",
                    Contribuinte="16444818",
                    Morada="Rua da Fonte nº6",
                    CodigoPostal="7000",
                    Telefone="",
                    Telemovel="961257482",
                    Email="RaulRamos@UPtelLeiria.pt",
                    Iban = "1988813849142128647698831",
                    Tipo = tipoUserOperador,
                    Estado = "Ativo",
                    CodigoPostalExt="290",
                    DistritoId = 11,
                    DataRegisto = new DateTime(2020,10,23),
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