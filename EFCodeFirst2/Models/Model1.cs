namespace EFCodeFirst2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<ITEM> ITEM { get; set; }
        public virtual DbSet<ITEM_EXECUTADO> ITEM_EXECUTADO { get; set; }
        public virtual DbSet<ORCAMENTO> ORCAMENTO { get; set; }
        public virtual DbSet<PROJETO> PROJETO { get; set; }
        public virtual DbSet<UNIDADE_MEDIDA> UNIDADE_MEDIDA { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.CATEGORIA_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA>()
                .HasMany(e => e.ITEM)
                .WithRequired(e => e.CATEGORIA)
                .HasForeignKey(e => e.CATEGORIA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.ITEM_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.ITEM_QUANTIDADE)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.ITEM_VALOR_UNITARIO)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.ITEM_VALOR_TOTAL)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.ITEM_VALOR_SALDO)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.ITEM_EXECUTADO)
                .WithRequired(e => e.ITEM)
                .HasForeignKey(e => e.ITEM_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM_EXECUTADO>()
                .Property(e => e.ITEM_EXECUTADO_QUANTIDADE)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ITEM_EXECUTADO>()
                .Property(e => e.ITEM_EXECUTADO_VALOR_UNITARIO)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ITEM_EXECUTADO>()
                .Property(e => e.ITEM_EXECUTADO_VALOR_TOTAL)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ORCAMENTO>()
                .Property(e => e.ORCAMENTO_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<ORCAMENTO>()
                .HasMany(e => e.ITEM)
                .WithRequired(e => e.ORCAMENTO)
                .HasForeignKey(e => e.ORCAMENTO_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROJETO>()
                .Property(e => e.PROJETO_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<PROJETO>()
                .HasMany(e => e.ORCAMENTO)
                .WithOptional(e => e.PROJETO)
                .HasForeignKey(e => e.PROJETO_ID);

            modelBuilder.Entity<UNIDADE_MEDIDA>()
                .Property(e => e.UNIDADE_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<UNIDADE_MEDIDA>()
                .Property(e => e.UNIDADE_SIGLA)
                .IsUnicode(false);

            modelBuilder.Entity<UNIDADE_MEDIDA>()
                .HasMany(e => e.ITEM)
                .WithRequired(e => e.UNIDADE_MEDIDA)
                .HasForeignKey(e => e.UNIDADE_MEDIDA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.USUARIO_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.SENHA_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.PROJETO)
                .WithOptional(e => e.USUARIO)
                .HasForeignKey(e => e.USUARIO_ID);
        }
    }
}
