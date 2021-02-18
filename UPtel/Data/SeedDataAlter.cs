using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UPtel.Models;

namespace UPtel.Data
{
    public class SeedDataAlter
    {
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
                    //NomeCliente="José Ramos Figueiras",
                    FuncionarioId=7,
                    //NomeFuncionario="José Ferreira Pinto",
                    PromocaoId=0,
                   // NomePromocao="",
                    PacoteId=1,
                    //NomePacote="Premium",
                    DataInicio=new DateTime(2020,10,15),
                    Fidelizacao=2,
                    TempoPromocao=1,
                },
                new Contratos
                {
                    ClienteId=4,
                   // NomeCliente="Rui Pedro Santos",
                    FuncionarioId=9,
                    //NomeFuncionario="José Ferreira Pinto",
                    PromocaoId=1,
                    //NomePromocao="Promoção de Natal",
                    PacoteId=1,
                   // NomePacote="Premium",
                    DataInicio=new DateTime(2020,12,20),
                    Fidelizacao=5,
                    TempoPromocao=3,
                },
                new Contratos
                {
                    ClienteId=5,
                    //NomeCliente="Mariana Rute Guedes",
                    FuncionarioId=8,
                   // NomeFuncionario="Ana Gonçalves Gomes",
                    PromocaoId=2,
                   // NomePromocao="Promoção de BlackFriday",
                    PacoteId=1,
                   // NomePacote="Premium",
                    DataInicio=new DateTime(2020,11,23),
                    Fidelizacao=0,
                    TempoPromocao=3,
                },
                new Contratos
                {
                    ClienteId=4,
                   // NomeCliente="David Rui Pedroso",
                    FuncionarioId=7,
                    //NomeFuncionario="Ana Gonçalves Gomes",
                    PromocaoId=1,
                    //NomePromocao="Promoção de Natal",
                    PacoteId=2,
                    //NomePacote="Pacote de desporto",
                    DataInicio=new DateTime(2020,12,23),
                    Fidelizacao=2,
                    TempoPromocao=1,
                },
            });
            DbContext.SaveChanges();
        }


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

        internal static void InsereDadosTesteTodos(UPtelContext DbContext)


        {

            InsereDadosTesteTelevisao(DbContext);
            InsereDadosTesteFuncionarios(DbContext);
            InsereDadosTesteClientes(DbContext);
            InsereDadosTesteContratos(DbContext);


        }





    }
}
