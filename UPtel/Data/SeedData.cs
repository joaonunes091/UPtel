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
        private const string PASSWORD_UTILIZADOR_ADMIN_PADRAO = "ADMIN123";

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
                    CargoId=4,
                    NomeCargo="Operador(a)",
                    DataNascimento=new DateTime(1990,05,25),
                    Contribuinte="264815975",
                    Morada="Rua do Arsenal nº24 ",
                    CodigoPostal="1000",
                    CodigoPostalExt="009",
                    Email="JoseFP@uptel.pt",
                    Telemovel="915948752",
                    CartaoCidadao="56195348",
                    Iban="PT50123454811548762593472",
                    Password="JosePassword",
                    EstadoFuncionario="Ativo",
                },
                new Funcionarios
                {
                    NomeFuncionario = "Ana Gonçalves Gomes",
                    CargoId=5,
                    NomeCargo="Operador(a)",
                    DataNascimento=new DateTime(1994,10,5),
                    Contribuinte="9759548",
                    Morada="Rua da Oliveira ao Carmo nº7, 2º Direito ",
                    CodigoPostal="1000",
                    CodigoPostalExt="150",
                    Email="AnaGG@uptel.pt",
                    Telemovel="911485549",
                    CartaoCidadao="574952138",
                    Iban="PT50594812543461579824682",
                    Password="AnaPassword",
                    EstadoFuncionario="Ativo",
                },
                new Funcionarios
                {
                    NomeFuncionario = "Mário Simão Pacheco",
                    CargoId=4,
                    NomeCargo="Administrador(a)",
                    DataNascimento=new DateTime(1994,10,5),
                    Contribuinte="97595487",
                    Morada="Calçada do Poço dos Mouros nº18",
                    CodigoPostal="2500",
                    CodigoPostalExt="220",
                    Email="MarioSP@uptel.pt",
                    Telemovel="926479568",
                    CartaoCidadao="54276388",
                    Iban="PT50527647242764597286475",
                    Password="MarioPassword",
                    EstadoFuncionario="Ativo",
                }
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
                    TipoClienteId=5,
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
                    TipoClienteId=4,
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
                    TipoClienteId=5,
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
                    TipoClienteId=4,
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
                    ClienteId=6,
                    NomeCliente="José Ramos Figueiras",
                    FuncionarioId=7,
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
                    ClienteId=4,
                    NomeCliente="Rui Pedro Santos",
                    FuncionarioId=9,
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
                    ClienteId=5,
                    NomeCliente="Mariana Rute Guedes",
                    FuncionarioId=8,
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
                    FuncionarioId=7,
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

            InsereCanaisFicticiosParaTestarPaginacao(DbContext);
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
