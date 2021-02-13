using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPtel.Models;

namespace UPtel.Data
{
    public class SeedData
    {
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
                    Designacao = "Empresarial",
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
        private static void InsereDadosTesteFuncionarios(UPtelContext DbContext)
        {
            if (DbContext.Funcionarios.Any()) return;
            DbContext.Funcionarios.AddRange(new Funcionarios[] {
                new Funcionarios
                {
                    NomeFuncionario = "José Ferreira Pinto",
                    CargoId=2,
                    NomeCargo="Operador(a)",
                    DataNascimento=new DateTime(1990,05,25),
                    Contribuinte="264815975",
                    Morada="Rua do Arsenal nº24 ",
                    CodigoPostal="1000",
                    CodigoPostalExt="009",
                    Email="JoseFP@uptel.pt",
                    Telemovel="915948752",
                    CartaoCidadao="56195348",
                    Iban="PT50 1234 5481 15487625934 72",
                    Password="JosePassword",
                    EstadoFuncionario="Ativo",
                },
                new Funcionarios
                {
                    NomeFuncionario = "Ana Gonçalves Gomes",
                    CargoId=2,
                    NomeCargo="Operador(a)",
                    DataNascimento=new DateTime(1994,10,5),
                    Contribuinte="97595487",
                    Morada="Rua da Oliveira ao Carmo nº7, 2º Direito ",
                    CodigoPostal="1000",
                    CodigoPostalExt="150",
                    Email="AnaGG@uptel.pt",
                    Telemovel="911485549",
                    CartaoCidadao="574952138",
                    Iban="PT50 5948 1254 34615798246 82",
                    Password="AnaPassword",
                    EstadoFuncionario="Ativo",
                },
                new Funcionarios
                {
                    NomeFuncionario = "Mário Simão Pacheco",
                    CargoId=1,
                    NomeCargo="Administrador(a)",
                    DataNascimento=new DateTime(1994,10,5),
                    Contribuinte="97595487",
                    Morada="Calçada do Poço dos Mouros nº18",
                    CodigoPostal="2500",
                    CodigoPostalExt="220",
                    Email="MarioSP@uptel.pt",
                    Telemovel="926479568",
                    CartaoCidadao="54276388",
                    Iban="PT50 5276 4724 27645972864 75",
                    Password="MarioPassword",
                    EstadoFuncionario="Ativo",
                },
            });
            DbContext.SaveChanges();
        }

        private static void InsereDadosTesteClientes(UPtelContext DbContext)
        {
            if (DbContext.Clientes.Any()) return;
            DbContext.Clientes.AddRange(new Clientes[] {
                new Clientes
                {
                    NomeCliente = "José Ramos Figueiras",
                    DataNascimento=new DateTime(1969,12,18),
                    CartaoCidadao="15485963",
                    Contribuinte="15496573",
                    Morada="Rua Júlio Cesár Machado nº14",
                    CodigoPostal="1500",
                    CodigoPostalExt="695",
                    Telefone="231584687",
                    Telemovel="961847659",
                    Email="José.Ramos.Figueiras@gmail.com",
                    Password="JoseRamos",
                    TipoClienteId=1,
                },
                new Clientes
                {
                    NomeCliente = "Rui Pedro Santos",
                    DataNascimento=new DateTime(1990,8,8),
                    CartaoCidadao="240452120",
                    Contribuinte="15778273",
                    Morada="Rua do Pinho Alto nº 25",
                    CodigoPostal="2300",
                    CodigoPostalExt="588",
                    Telefone="271598874",
                    Telemovel="927856988",
                    Email="Rui.Pedro.Santos@gmail.com",
                    Password="RuiPedro",
                    TipoClienteId=1,
                },
                new Clientes
                {
                    NomeCliente = "Mariana Rute Guedes",
                    DataNascimento=new DateTime(1987,11,7),
                    CartaoCidadao="15487986",
                    Contribuinte="16687495",
                    Morada="Rua do Comércio nº4",
                    CodigoPostal="1700",
                    CodigoPostalExt="708",
                    Telefone="234598777",
                    Telemovel="961155484",
                    Email="Mariana.Rute.Guedes@gmail.com",
                    Password="MarianaRute",
                    TipoClienteId=1,
                },
                new Clientes
                {
                    NomeCliente = "David Rui Pedroso",
                    DataNascimento=new DateTime(1985,1,20),
                    CartaoCidadao="34657986",
                    Contribuinte="37655497",
                    Morada="Rua de São Mamede nº10",
                    CodigoPostal="4000",
                    CodigoPostalExt="122",
                    Telefone="236459557",
                    Telemovel="915444789",
                    Email="David.Rui.Pedroso@gmail.com",
                    Password="DavidRui",
                    TipoClienteId=1,
                },

            });
            DbContext.SaveChanges();
        }

        private static void InsereDadosTesteContratos(UPtelContext DbContext) //Estão aqui algumas promoções, talvez seja preciso mudar
        {
            if (DbContext.Contratos.Any()) return;
            DbContext.Contratos.AddRange(new Contratos[] {
                new Contratos
                {
                    ClienteId=1,
                    NomeCliente="José Ramos Figueiras",
                    FuncionarioId=1,
                    NomeFuncionario="José Ferreira Pinto",
                    PromocaoId=0,
                    NomePromocao="",
                    PacoteId=1,
                    NomePacote="Premium",
                    DataInicio=new DateTime(2020,10,15),
                    Fidelizacao=2,
                    TempoPromocao=1,                   
                },
                new Contratos
                {
                    ClienteId=2,
                    NomeCliente="Rui Pedro Santos",
                    FuncionarioId=1,
                    NomeFuncionario="José Ferreira Pinto",
                    PromocaoId=1,
                    NomePromocao="Promoção de Natal",
                    PacoteId=1,
                    NomePacote="Premium",
                    DataInicio=new DateTime(2020,12,20),
                    Fidelizacao=5,
                    TempoPromocao=3,
                },
                new Contratos
                {
                    ClienteId=3,
                    NomeCliente="Mariana Rute Guedes",
                    FuncionarioId=2,
                    NomeFuncionario="Ana Gonçalves Gomes",
                    PromocaoId=2,
                    NomePromocao="Promoção de BlackFriday",
                    PacoteId=1,
                    NomePacote="Premium",
                    DataInicio=new DateTime(2020,11,23),
                    Fidelizacao=0,
                    TempoPromocao=3,
                },
                new Contratos
                {
                    ClienteId=4,
                    NomeCliente="David Rui Pedroso",
                    FuncionarioId=2,
                    NomeFuncionario="Ana Gonçalves Gomes",
                    PromocaoId=1,
                    NomePromocao="Promoção de Natal",
                    PacoteId=2,
                    NomePacote="Pacote de desporto",
                    DataInicio=new DateTime(2020,12,23),
                    Fidelizacao=2,
                    TempoPromocao=1,
                },
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

        internal static void InsereDadosTesteTodos(UPtelContext DbContext)
        {
            InsereDadosTesteCargos(DbContext);
            InsereDadosTesteTipoClientes(DbContext);
            InsereDadosTesteCanais(DbContext);
            InsereDadosTesteNetfixa(DbContext);
            InsereDadosTesteTelevisao(DbContext);
            InsereDadosTesteTelefone(DbContext);
            InsereDadosTesteTelemovel(DbContext);
            InsereDadosTestePromocoes(DbContext);
            InsereDadosTesteFuncionarios(DbContext);
            InsereDadosTesteClientes(DbContext);
            InsereDadosTesteContratos(DbContext);
            

        }

    }
}
