﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UPtel.Data;

namespace UPtel.Migrations
{
    [DbContext(typeof(UPtelContext))]
    [Migration("20210216163334_ModelosNovos")]
    partial class ModelosNovos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UPtel.Models.Canais", b =>
                {
                    b.Property<int>("CanaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("NomeCanal")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("PrecoCanais")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("CanaisId");

                    b.ToTable("Canais");
                });

            modelBuilder.Entity("UPtel.Models.Cargos", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeCargo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CargoId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("UPtel.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CartaoCidadao")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("CodigoPostalExt")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Contribuinte")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("TipoClienteId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.HasIndex("TipoClienteId");

                    b.HasIndex(new[] { "CartaoCidadao" }, "IX_CartaoCidadaoClientes")
                        .IsUnique();

                    b.HasIndex(new[] { "Contribuinte" }, "IX_ContribuinteClientes")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("UPtel.Models.Contratos", b =>
                {
                    b.Property<int>("ContratoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("date");

                    b.Property<int?>("Fidelizacao")
                        .HasColumnType("int");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("NomeFuncionario")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("NomePacote")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomePromocao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PacoteId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoContrato")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("PromocaoId")
                        .HasColumnType("int");

                    b.Property<int?>("TempoPromocao")
                        .HasColumnType("int");

                    b.HasKey("ContratoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("PacoteId");

                    b.HasIndex("PromocaoId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("UPtel.Models.Funcionarios", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("CartaoCidadao")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("CodigoPostalExt")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Contribuinte")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EstadoFuncionario")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<byte[]>("Fotografia")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Iban")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("IBAN");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("NomeCargo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeFuncionario")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("FuncionarioId");

                    b.HasIndex("CargoId");

                    b.HasIndex(new[] { "CartaoCidadao" }, "IX_CartaoCidadaoFuncionarios")
                        .IsUnique();

                    b.HasIndex(new[] { "Contribuinte" }, "IX_ContribuinteFuncionarios")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "IX_EmailFuncionarios")
                        .IsUnique();

                    b.HasIndex(new[] { "Telemovel" }, "IX_TelemovelFuncionarios")
                        .IsUnique();

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("UPtel.Models.NetFixa", b =>
                {
                    b.Property<int>("NetFixaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Limite")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Notas")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("PrecoNetFixa")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("TipoConexao")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Velocidade")
                        .HasColumnType("int");

                    b.HasKey("NetFixaId");

                    b.ToTable("NetFixa");
                });

            modelBuilder.Entity("UPtel.Models.NetMovel", b =>
                {
                    b.Property<int>("NetMovelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Limite")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Notas")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("PrecoNetMovel")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("NetMovelId");

                    b.ToTable("NetMovel");
                });

            modelBuilder.Entity("UPtel.Models.PacoteCanais", b =>
                {
                    b.Property<int>("PacoteCanalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CanaisId")
                        .HasColumnType("int");

                    b.Property<int>("TelevisaoId")
                        .HasColumnType("int");

                    b.HasKey("PacoteCanalId");

                    b.HasIndex("CanaisId");

                    b.HasIndex("TelevisaoId");

                    b.ToTable("PacoteCanais");
                });

            modelBuilder.Entity("UPtel.Models.Pacotes", b =>
                {
                    b.Property<int>("PacoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NetIfixaId")
                        .HasColumnType("int")
                        .HasColumnName("NetIFixaId");

                    b.Property<int?>("NetMovelId")
                        .HasColumnType("int");

                    b.Property<string>("NomePacote")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PrecoTotal")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int?>("TelefoneId")
                        .HasColumnType("int");

                    b.Property<int?>("TelemovelId")
                        .HasColumnType("int");

                    b.Property<int?>("TelevisaoId")
                        .HasColumnType("int");

                    b.HasKey("PacoteId");

                    b.HasIndex("NetIfixaId");

                    b.HasIndex("NetMovelId");

                    b.HasIndex("TelefoneId");

                    b.HasIndex("TelemovelId");

                    b.HasIndex("TelevisaoId");

                    b.ToTable("Pacotes");
                });

            modelBuilder.Entity("UPtel.Models.Promocoes", b =>
                {
                    b.Property<int>("PromocaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Desconto")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomePromocao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PromoCanais")
                        .HasColumnType("int");

                    b.HasKey("PromocaoId");

                    b.ToTable("Promocoes");
                });

            modelBuilder.Entity("UPtel.Models.Telefone", b =>
                {
                    b.Property<int>("TelefoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Limite")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoMinutoInternacional")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal>("PrecoMinutoNacional")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal>("PrecoPacoteTelefone")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("TelefoneId");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("UPtel.Models.Telemovel", b =>
                {
                    b.Property<int>("TelemovelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LimiteMinutos")
                        .HasColumnType("int");

                    b.Property<int>("LimiteSms")
                        .HasColumnType("int")
                        .HasColumnName("LimiteSMS");

                    b.Property<decimal>("PrecoMinutoInternacional")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal>("PrecoMinutoNacional")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal>("PrecoMms")
                        .HasColumnType("decimal(4,2)")
                        .HasColumnName("PrecoMMS");

                    b.Property<decimal>("PrecoPacoteTelemovel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoSms")
                        .HasColumnType("decimal(4,2)")
                        .HasColumnName("PrecoSMS");

                    b.HasKey("TelemovelId");

                    b.ToTable("Telemovel");
                });

            modelBuilder.Entity("UPtel.Models.Televisao", b =>
                {
                    b.Property<int>("TelevisaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("PrecoPacoteTelevisao")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("TelevisaoId");

                    b.ToTable("Televisao");
                });

            modelBuilder.Entity("UPtel.Models.TipoClientes", b =>
                {
                    b.Property<int>("TipoClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designacao")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("TipoClienteId");

                    b.ToTable("TipoClientes");
                });

            modelBuilder.Entity("UPtel.Models.Clientes", b =>
                {
                    b.HasOne("UPtel.Models.TipoClientes", "TipoCliente")
                        .WithMany("Clientes")
                        .HasForeignKey("TipoClienteId")
                        .HasConstraintName("FK_Clientes_TipoClientes")
                        .IsRequired();

                    b.Navigation("TipoCliente");
                });

            modelBuilder.Entity("UPtel.Models.Contratos", b =>
                {
                    b.HasOne("UPtel.Models.Clientes", "Cliente")
                        .WithMany("Contratos")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK_Contratos_Clientes")
                        .IsRequired();

                    b.HasOne("UPtel.Models.Funcionarios", "Funcionario")
                        .WithMany("Contratos")
                        .HasForeignKey("FuncionarioId")
                        .HasConstraintName("FK_Contratos_Funcionarios")
                        .IsRequired();

                    b.HasOne("UPtel.Models.Pacotes", "Pacote")
                        .WithMany("Contratos")
                        .HasForeignKey("PacoteId")
                        .HasConstraintName("FK_Contratos_Pacotes")
                        .IsRequired();

                    b.HasOne("UPtel.Models.Promocoes", "Promocao")
                        .WithMany("Contratos")
                        .HasForeignKey("PromocaoId")
                        .HasConstraintName("FK_Contratos_Promocoes")
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");

                    b.Navigation("Pacote");

                    b.Navigation("Promocao");
                });

            modelBuilder.Entity("UPtel.Models.Funcionarios", b =>
                {
                    b.HasOne("UPtel.Models.Cargos", "Cargo")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CargoId")
                        .HasConstraintName("FK_Funcionarios_Cargos")
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("UPtel.Models.PacoteCanais", b =>
                {
                    b.HasOne("UPtel.Models.Canais", "Canais")
                        .WithMany("PacoteCanais")
                        .HasForeignKey("CanaisId")
                        .HasConstraintName("FK_PacoteCanais_Canais")
                        .IsRequired();

                    b.HasOne("UPtel.Models.Televisao", "Televisao")
                        .WithMany("PacoteCanais")
                        .HasForeignKey("TelevisaoId")
                        .HasConstraintName("FK_PacoteCanais_Televisao")
                        .IsRequired();

                    b.Navigation("Canais");

                    b.Navigation("Televisao");
                });

            modelBuilder.Entity("UPtel.Models.Pacotes", b =>
                {
                    b.HasOne("UPtel.Models.NetFixa", "NetIfixa")
                        .WithMany("Pacotes")
                        .HasForeignKey("NetIfixaId")
                        .HasConstraintName("FK_Pacotes_NetFixa1");

                    b.HasOne("UPtel.Models.NetMovel", "NetMovel")
                        .WithMany("Pacotes")
                        .HasForeignKey("NetMovelId")
                        .HasConstraintName("FK_Pacotes_NetMovel");

                    b.HasOne("UPtel.Models.Telefone", "Telefone")
                        .WithMany("Pacotes")
                        .HasForeignKey("TelefoneId")
                        .HasConstraintName("FK_Pacotes_Telemovel");

                    b.HasOne("UPtel.Models.Telemovel", "Telemovel")
                        .WithMany("Pacotes")
                        .HasForeignKey("TelemovelId")
                        .HasConstraintName("FK_Pacotes_Telefone");

                    b.HasOne("UPtel.Models.Televisao", "Televisao")
                        .WithMany("Pacotes")
                        .HasForeignKey("TelevisaoId")
                        .HasConstraintName("FK_Pacotes_Televisao1");

                    b.Navigation("NetIfixa");

                    b.Navigation("NetMovel");

                    b.Navigation("Telefone");

                    b.Navigation("Telemovel");

                    b.Navigation("Televisao");
                });

            modelBuilder.Entity("UPtel.Models.Canais", b =>
                {
                    b.Navigation("PacoteCanais");
                });

            modelBuilder.Entity("UPtel.Models.Cargos", b =>
                {
                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("UPtel.Models.Clientes", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("UPtel.Models.Funcionarios", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("UPtel.Models.NetFixa", b =>
                {
                    b.Navigation("Pacotes");
                });

            modelBuilder.Entity("UPtel.Models.NetMovel", b =>
                {
                    b.Navigation("Pacotes");
                });

            modelBuilder.Entity("UPtel.Models.Pacotes", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("UPtel.Models.Promocoes", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("UPtel.Models.Telefone", b =>
                {
                    b.Navigation("Pacotes");
                });

            modelBuilder.Entity("UPtel.Models.Telemovel", b =>
                {
                    b.Navigation("Pacotes");
                });

            modelBuilder.Entity("UPtel.Models.Televisao", b =>
                {
                    b.Navigation("PacoteCanais");

                    b.Navigation("Pacotes");
                });

            modelBuilder.Entity("UPtel.Models.TipoClientes", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
