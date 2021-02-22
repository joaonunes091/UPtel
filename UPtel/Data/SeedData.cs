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
            //InsereDadosTesteNetMovel(DbContext);
            //InsereDadosTesteNetfixa(DbContext);
            InsereDadosTesteTipoClientes(DbContext);
            //InsereDadosTesteCanais(DbContext);
            InsereDadosTesteCargos(DbContext);
            InsereDadosTestePromocoes(DbContext);
            //InsereDadosTesteTelefone(DbContext);
            //InsereDadosTesteTelemovel(DbContext);
            //InsereDadosTesteTelevisao(DbContext);
            //InsereDadosTestePacoteCanais(DbContext);
            //InsereDadosTestePacote(DbContext);
            //InsereDadosTesteClientes(DbContext);
            //InsereDadosTesteFuncionarios(DbContext);
            //InsereDadosTesteContratos(DbContext);



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
            InsereClientesFicticiosParaTestarPaginacao(DbContext);
            InsereFuncionariosFicticiosParaTestarPaginacao(DbContext);

        }



        //-------------------------------------------------
        //         TELEVISÃO
        //   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------

        private static void InsereDadosTesteTelevisao(UPtelContext DbContext)
        {
            if (DbContext.Televisao.Any()) return;
            DbContext.Televisao.AddRange(new Televisao[] {
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
                Numero = "275888888",
                Limite = 3000,
                PrecoMinutoNacional = 0,
                PrecoMinutoInternacional = 0.1M,
                PrecoPacoteTelefone = 15m

            },
            new Telefone
            {
                Numero = "275888888",
                Limite = 44600,
                PrecoMinutoNacional = 0,
                PrecoMinutoInternacional = 0.1M,
                PrecoPacoteTelefone = 15m

            },
            new Telefone
            {
                Numero = "224567891",
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
                    Numero = "210000000",
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

        private static void InsereDadosTesteNetMovel(UPtelContext DbContext)
        {
            if (DbContext.NetMovel.Any()) return;
            DbContext.NetMovel.AddRange(new NetMovel[] {
            new NetMovel
            {
                    Limite = 5,
                    PrecoNetMovel = 1,
                    Numero = "911234567",
                    Notas = "teste 1"
            },
            new NetMovel
            {
                    Limite = 7,
                    PrecoNetMovel = 1,
                    Numero = "929876543",
                    Notas = "teste 2"
            },
            new NetMovel
            {
                    Limite = 26,
                    PrecoNetMovel = 5,
                    Numero = "969513578",
                    Notas = "teste 3"
            },
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
                    Numero = "910000000", //que número se deve colocar aqui? no dicionário diz que é o número de telemovel
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
            Telemovel telemovel = DbContext.Telemovel.FirstOrDefault(t => t.Numero == "910100020");
            NetFixa netFixa = DbContext.NetFixa.FirstOrDefault(n => n.TipoConexao == "Fibra");
            Telefone telefone = DbContext.Telefone.FirstOrDefault(t => t.Numero == "275888888");
            NetMovel netMovel = DbContext.NetMovel.FirstOrDefault(n => n.Numero == "911234567");


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
                Telemovel telemovel = DbContext.Telemovel.FirstOrDefault(t => t.Numero == "910100020");
                NetFixa netFixa = DbContext.NetFixa.FirstOrDefault(n => n.TipoConexao == "Fibra");
                Telefone telefone = DbContext.Telefone.FirstOrDefault(t => t.Numero == "275888888");
                NetMovel netMovel = DbContext.NetMovel.FirstOrDefault(n => n.Numero == "911234567");

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
        //         CLIENTES
        //   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------

        private static void InsereDadosTesteClientes(UPtelContext DbContext)
        {
            if (DbContext.Clientes.Any()) return;

            TipoClientes tipoCliente = DbContext.TipoClientes.FirstOrDefault(c => c.Designacao == "Empresa");


            DbContext.Clientes.AddRange(new Clientes[]
               {
                new Clientes
                {
                    NomeCliente = "José Figueiras",
                    DataNascimento = new DateTime(1969,12,18),
                    CartaoCidadao = "15485963",
                    Contribuinte = "154965739",
                    Morada = "Rua Júlio Cesár Machado nº14",
                    CodigoPostal = "1500",
                    Telefone="231584687",
                    Telemovel="961847659",
                    Email="José.Ramos@gmail.com",
                    TipoCliente = tipoCliente,
                    Password="Ola123$",
                    CodigoPostalExt="695",
                },
                new Clientes
                {
                    NomeCliente = "Rui Pedro Santos",
                    DataNascimento=new DateTime(1990,8,8),
                    CartaoCidadao="24045212",
                    Contribuinte="157782731",
                    Morada="Rua do Pinho Alto nº 25",
                    CodigoPostal="2300",
                    Telefone="271598874",
                    Telemovel="927856988",
                    Email="Rui.Pedro.Santos@gmail.com",
                    TipoCliente = tipoCliente,
                    Password="Ola123$",
                    CodigoPostalExt="588",

                },
                new Clientes
                {
                    NomeCliente = "Mariana Rute Guedes",
                    DataNascimento=new DateTime(1987,11,7),
                    CartaoCidadao="15487986",
                    Contribuinte="16687495",
                    Morada="Rua do Comércio nº4",
                    CodigoPostal="1700",
                    Telefone="234598777",
                    Telemovel="961155484",
                    Email="Mariana.Rute.Guedes@gmail.com",
                    TipoCliente = tipoCliente,
                    Password="Ola123$",
                    CodigoPostalExt="588",
                },
                new Clientes
                {
                    NomeCliente = "David Rui Pedroso",
                    DataNascimento=new DateTime(1985,1,20),
                    CartaoCidadao="34657986",
                    Contribuinte="376554971",
                    Morada="Rua de São Mamede nº10",
                    CodigoPostal="4000",
                    Telefone="236459557",
                    Telemovel="915444789",
                    Email="David.Rui.Pedroso@gmail.com",
                    TipoCliente = tipoCliente,
                    Password="Ola123$",
                    CodigoPostalExt="588",
                },
                });

            DbContext.SaveChanges();
        }

        public static void InsereClientesFicticiosParaTestarPaginacao(UPtelContext DbContext)
        {

            for (int i = 10; i < 50; i++)

            {
                if (DbContext.Clientes.Any()) return;

                TipoClientes tipoCliente = DbContext.TipoClientes.FirstOrDefault(c => c.Designacao == "Empresa");

                DbContext.Clientes.Add(new Clientes
                {
                    NomeCliente = "José Figueiras " + i,
                    DataNascimento = new DateTime(1969, 12, 18),
                    CartaoCidadao = Convert.ToString(12345670 + i),
                    Contribuinte = Convert.ToString(123456700 + i),
                    Morada = "Rua Júlio Cesár Machado nº14",
                    CodigoPostal = "1500",
                    Telefone = Convert.ToString(247112500 + i),
                    Telemovel = Convert.ToString(913456700 + i),
                    Email = "José.Ramos@gmail.com " + i,
                    TipoCliente = tipoCliente,
                    Password = "Ola123$",
                    CodigoPostalExt = "695",

                });

            }
            DbContext.SaveChanges();
        }

        //-------------------------------------------------
        //         FUNCIONARIOS
        //   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------

        private static void InsereDadosTesteFuncionarios(UPtelContext DbContext)
        {
            if (DbContext.Funcionarios.Any()) return;

            Cargos cargos = DbContext.Cargos.FirstOrDefault(c => c.NomeCargo == "Operador(a)");


            DbContext.Funcionarios.AddRange(new Funcionarios[]
               {
                new Funcionarios
                {
                    NomeFuncionario = "Mário",
                    Cargo = cargos,
                    DataNascimento = new DateTime(1982, 11, 11),
                    Contribuinte = "123456700",
                    Morada = "Sem Abrigo",
                    CodigoPostal = "1234",
                    Email = "a@b.com",
                    Telemovel = "913456700",
                    CartaoCidadao = "12345670",
                    Iban = "1234567891234567891234567",
                    Password = "Ola123$",
                    CodigoPostalExt = "123",
                    EstadoFuncionario = "ativo"
                },
                new Funcionarios
                {
                    NomeFuncionario = "Maria",
                    Cargo = cargos,
                    DataNascimento = new DateTime(1979, 11, 11),
                    Contribuinte = "123456589",
                    Morada = "Sem Abrigo",
                    CodigoPostal = "1234",
                    Email = "b@b.com",
                    Telemovel = "913456150",
                    CartaoCidadao = "12345678",
                    Iban = "1234567891234567891234567",
                    Password = "Ola123$",
                    CodigoPostalExt = "123",
                    EstadoFuncionario = "ativo"
                },
                new Funcionarios
                {
                    NomeFuncionario = "Manuel",
                    Cargo = cargos,
                    DataNascimento = new DateTime(1968, 11, 11),
                    Contribuinte = "123456747",
                    Morada = "Sem Abrigo",
                    CodigoPostal = "1234",
                    Email = "c@b.com",
                    Telemovel = "913456747",
                    CartaoCidadao = "12345474",
                    Iban = "1234567891234567891234567",
                    Password = "Ola123$",
                    CodigoPostalExt = "123",
                    EstadoFuncionario = "ativo"
                },
                 new Funcionarios
                {
                    NomeFuncionario = "Madalena",
                    Cargo = cargos,
                    DataNascimento = new DateTime(1995, 11, 11),
                    Contribuinte = "123456774",
                    Morada = "Sem Abrigo",
                    CodigoPostal = "1234",
                    Email = "d@b.com",
                    Telemovel = "913456440",
                    CartaoCidadao = "23456701",
                    Iban = "1234567891234567891234567",
                    Password = "Ola123$",
                    CodigoPostalExt = "123",
                    EstadoFuncionario = "ativo"
                },
                });

            DbContext.SaveChanges();
        }
        public static void InsereFuncionariosFicticiosParaTestarPaginacao(UPtelContext DbContext)
        {

            for (int i = 10; i < 50; i++)

            {
                if (DbContext.Funcionarios.Any()) return;

                Cargos cargos = DbContext.Cargos.FirstOrDefault(c => c.NomeCargo == "Operador(a)");

                DbContext.Funcionarios.Add(new Funcionarios
                {
                    NomeFuncionario = "Funcionário " + i,
                    Cargo = cargos,
                    DataNascimento = new DateTime(1911, 11, 11),
                    Contribuinte = Convert.ToString(123456700 + i),
                    Morada = "Sem Abrigo",
                    CodigoPostal = "1234",
                    Email = "a" + i + "@b.com",
                    Telemovel = Convert.ToString(913456700 + i),
                    CartaoCidadao = Convert.ToString(12345670 + i),
                    Iban = "1234567891234567891234567",
                    Password = "Ola123$",
                    CodigoPostalExt = "123",
                    EstadoFuncionario = "ativo"

                });

            }
            DbContext.SaveChanges();
        }

        //-------------------------------------------------
        //         CONTRATOS
        //   DADOS DE TESTE PARA PAGINAÇÃO E PESQUISA 
        //-------------------------------------------------

        private static void InsereDadosTesteContratos(UPtelContext DbContext)
        {
            if (DbContext.Contratos.Any()) return;
            
            Clientes clientes = DbContext.Clientes.FirstOrDefault(t => t.NomeCliente == "José Figueiras");
            Funcionarios funcionarios = DbContext.Funcionarios.FirstOrDefault(t => t.NomeFuncionario == "Mário");
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