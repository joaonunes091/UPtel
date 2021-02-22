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
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Contratos> Contratos { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<NetFixa> NetFixa { get; set; }
        public virtual DbSet<NetMovel> NetMovel { get; set; }
        public virtual DbSet<PacoteCanais> PacoteCanais { get; set; }
        public virtual DbSet<Pacotes> Pacotes { get; set; }
        public virtual DbSet<Promocoes> Promocoes { get; set; }
        public virtual DbSet<Telefone> Telefone { get; set; }
        public virtual DbSet<Telemovel> Telemovel { get; set; }
        public virtual DbSet<Televisao> Televisao { get; set; }
        public virtual DbSet<TipoClientes> TipoClientes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasOne(d => d.TipoCliente)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.TipoClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_TipoClientes");
            });

            modelBuilder.Entity<Contratos>(entity =>
            {
                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratos_Clientes");

                entity.HasOne(d => d.Funcionario)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.FuncionarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratos_Funcionarios");

                entity.HasOne(d => d.Pacote)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.PacoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratos_Pacotes");

                entity.HasOne(d => d.Promocao)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.PromocaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratos_Promocoes");
            });

            modelBuilder.Entity<Funcionarios>(entity =>
            {
                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.CargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionarios_Cargos");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
