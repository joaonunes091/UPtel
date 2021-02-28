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
    [Migration("20210228150037_alteracoesModelo2")]
    partial class alteracoesModelo2
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

                    b.HasKey("CanaisId");

                    b.ToTable("Canais");
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

                    b.Property<string>("Numeros")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("PacoteId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoContrato")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("PromocaoId")
                        .HasColumnType("int");

                    b.Property<int?>("TempoPromocao")
                        .HasColumnType("int");

                    b.HasKey("ContratoId");

                    b.HasIndex(new[] { "ClienteId" }, "IX_Contratos_ClienteId");

                    b.HasIndex(new[] { "FuncionarioId" }, "IX_Contratos_FuncionarioId");

                    b.HasIndex(new[] { "PacoteId" }, "IX_Contratos_PacoteId");

                    b.HasIndex(new[] { "PromocaoId" }, "IX_Contratos_PromocaoId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("UPtel.Models.NetFixa", b =>
                {
                    b.Property<int>("NetFixaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Limite")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<decimal>("PrecoMinutoInternacional")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal>("PrecoMinutoNacional")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal>("PrecoMms")
                        .HasColumnType("decimal(4,2)")
                        .HasColumnName("PrecoMMS");

                    b.Property<decimal>("PrecoPacoteTelemovel")
                        .HasColumnType("decimal(5,2)");

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

            modelBuilder.Entity("UPtel.Models.UserType", b =>
                {
                    b.Property<int>("TipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("TipoId")
                        .HasName("PK_TipoClientes");

                    b.ToTable("UserType");
                });

            modelBuilder.Entity("UPtel.Models.Users", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CartaoCidadao")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("CodigoPostalExt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Contribuinte")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Estado")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Fotografia")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Iban")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("IBAN");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.HasKey("UsersId");

                    b.HasIndex(new[] { "CartaoCidadao" }, "IX_CartaoCidadaoClientes")
                        .IsUnique()
                        .HasFilter("[CartaoCidadao] IS NOT NULL");

                    b.HasIndex(new[] { "TipoId" }, "IX_Clientes_TipoClienteId");

                    b.HasIndex(new[] { "Contribuinte" }, "IX_ContribuinteClientes")
                        .IsUnique();

                    b.HasIndex(new[] { "Nome" }, "IX_Nome_Users");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UPtel.Models.Contratos", b =>
                {
                    b.HasOne("UPtel.Models.Users", "Cliente")
                        .WithMany("ContratosCliente")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK_Cliente_Users")
                        .IsRequired();

                    b.HasOne("UPtel.Models.Users", "Funcionario")
                        .WithMany("ContratosFuncionario")
                        .HasForeignKey("FuncionarioId")
                        .HasConstraintName("FK_Funcionarios_Users")
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
                        .OnDelete(DeleteBehavior.Cascade)
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

            modelBuilder.Entity("UPtel.Models.Users", b =>
                {
                    b.HasOne("UPtel.Models.UserType", "Tipo")
                        .WithMany("Users")
                        .HasForeignKey("TipoId")
                        .HasConstraintName("FK_Users_UserType")
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("UPtel.Models.Canais", b =>
                {
                    b.Navigation("PacoteCanais");
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

            modelBuilder.Entity("UPtel.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("UPtel.Models.Users", b =>
                {
                    b.Navigation("ContratosCliente");

                    b.Navigation("ContratosFuncionario");
                });
#pragma warning restore 612, 618
        }
    }
}
