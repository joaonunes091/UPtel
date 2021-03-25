using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UPtel.Models;

#nullable disable

namespace UPtel.Data
{
    public partial class UPtelContext : DbContext
    {
        public UPtelContext()
        {
        }

        public UPtelContext(DbContextOptions<UPtelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Canais> Canais { get; set; }
        //public virtual DbSet<UserType> Tipo { get; set; } 
        //public virtual DbSet<Users> Clientes { get; set; }
        //public virtual DbSet<Users> Funcionarios { get; set; }
        public virtual DbSet<Contratos> Contratos { get; set; }
        public virtual DbSet<NetFixa> NetFixa { get; set; }
        public virtual DbSet<NetMovel> NetMovel { get; set; }
        public virtual DbSet<PacoteCanais> PacoteCanais { get; set; }
        public virtual DbSet<Pacotes> Pacotes { get; set; }
        //public virtual DbSet<Promocoes> Promocoes { get; set; }
        public virtual DbSet<Telefone> Telefone { get; set; }
        public virtual DbSet<Telemovel> Telemovel { get; set; }
        public virtual DbSet<Televisao> Televisao { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<FaturaCliente> Faturas { get; set; }

        public virtual DbSet<PromoTelemovel> PromoTelemovel { get; set; }
        public virtual DbSet<PromoTelefone> PromoTelefone { get; set; }
        public virtual DbSet<PromoNetFixa> PromoNetFixa { get; set; }
        public virtual DbSet<PromoNetMovel> PromoNetMovel { get; set; }
        public virtual DbSet<PromoTelevisao> PromoTelevisao { get; set; }

        public virtual DbSet<ContratoPromoNetFixa> ContratoPromoNetFixa { get; set; }
        public virtual DbSet<ContratoPromoNetMovel> ContratoPromoNetMovel { get; set; }
        public virtual DbSet<ContratoPromoTelevisao> ContratoPromoTelevisao { get; set; }
        public virtual DbSet<ContratoPromoTelemovel> ContratoPromoTelemovel { get; set; }
        public virtual DbSet<ContratoPromoTelefone> ContratoPromoTelefone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            /*modelBuilder.Entity<Users>(entity =>
            {
                entity.HasOne(d => d.TipoUtilizador)
                    .WithMany(p => p.TipoUtilizador)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Tipo");
            });*/

            modelBuilder.Entity<Contratos>(entity =>
            {
                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.ContratosCliente)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Users");

                entity.HasOne(d => d.Funcionario)
                    .WithMany(p => p.ContratosFuncionario)
                    .HasForeignKey(d => d.FuncionarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionarios_Users");

                entity.HasOne(d => d.Pacote)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.PacoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratos_Pacotes");

                entity.HasOne(d => d.DistritoNome)
                   .WithMany(p => p.Contratos)
                   .HasForeignKey(d => d.DistritoId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Contratos_Distrito");


                //entity.HasOne(d => d.Promocao)
                //    .WithMany(p => p.Contratos)
                //    .HasForeignKey(d => d.PromocaoId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Contratos_Promocoes");
            });

            modelBuilder.Entity<FaturaCliente>(entity =>
            {
                entity.HasOne(d => d.Fatura)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.ContratoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratos_Fatura");
            });

            modelBuilder.Entity<PacoteCanais>(entity =>
            {
                entity.HasOne(d => d.Canais)
                    .WithMany(p => p.PacoteCanais)
                    .HasForeignKey(d => d.CanaisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacoteCanais_Canais");

                entity.HasOne(d => d.Televisao)
                    .WithMany(p => p.PacoteCanais)
                    .HasForeignKey(d => d.TelevisaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PacoteCanais_Televisao");
            });

            modelBuilder.Entity<Pacotes>(entity =>
            {
                entity.HasOne(d => d.NetIfixa)
                    .WithMany(p => p.Pacotes)
                    .HasForeignKey(d => d.NetIfixaId)
                    .HasConstraintName("FK_Pacotes_NetFixa1");

                entity.HasOne(d => d.NetMovel)
                    .WithMany(p => p.Pacotes)
                    .HasForeignKey(d => d.NetMovelId)
                    .HasConstraintName("FK_Pacotes_NetMovel");

                entity.HasOne(d => d.Telemovel)
                    .WithMany(p => p.Pacotes)
                    .HasForeignKey(d => d.TelemovelId)
                    .HasConstraintName("FK_Pacotes_Telefone");

                entity.HasOne(d => d.Telefone)
                    .WithMany(p => p.Pacotes)
                    .HasForeignKey(d => d.TelefoneId)
                    .HasConstraintName("FK_Pacotes_Telemovel");

                entity.HasOne(d => d.Televisao)
                    .WithMany(p => p.Pacotes)
                    .HasForeignKey(d => d.TelevisaoId)
                    .HasConstraintName("FK_Pacotes_Televisao1");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.TipoId)
                    .HasName("PK_TipoClientes");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.DistritoId)
                    .HasName("PK_DistritoNome");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.CodigoPostalExt).HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UserType");

                entity.HasOne(d => d.DistritoNome)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Distrito");
            });

            modelBuilder.Entity<PromoNetFixa>(entity =>
            {
                entity.HasOne(d => d.DistritoNome)
                    .WithMany(p => p.PromoNetFixa)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromoNetFixa_Distrito");
            });

            modelBuilder.Entity<PromoNetMovel>(entity =>
            {
                entity.HasOne(d => d.DistritoNome)
                    .WithMany(p => p.PromoNetMovel)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromoNetMovel_Distrito");
            });

            modelBuilder.Entity<PromoTelefone>(entity =>
            {
                entity.HasOne(d => d.DistritoNome)
                    .WithMany(p => p.PromoTelefone)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromoTelefone_Distrito");
            });

            modelBuilder.Entity<PromoTelemovel>(entity =>
            {
                entity.HasOne(d => d.DistritoNome)
                    .WithMany(p => p.PromoTelemovel)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromoTelemovel_Distrito");
            });

            modelBuilder.Entity<PromoTelevisao>(entity =>
            {
                entity.HasOne(d => d.DistritoNome)
                    .WithMany(p => p.PromoTelevisao)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromoTelevisao_Distrito");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<UPtel.Models.ClientesViewModel> ClientesViewModel { get; set; }

        public DbSet<UPtel.Models.Reclamacao> Reclamacao { get; set; }

        public DbSet<UPtel.Models.OperadorViewModel> OperadorViewModel { get; set; }
    }
}
