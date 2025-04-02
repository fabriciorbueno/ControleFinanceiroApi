using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Data.Contexts
{
    public class ControleFinanceiroContext : DbContext
    {
        public ControleFinanceiroContext()
        {

        }

        public ControleFinanceiroContext(DbContextOptions<ControleFinanceiroContext> options)
            : base(options)
        {

        }

        #region ConnectionString
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=Asus-i7;Database=CONTROLE_FINANCEIRO;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
        #endregion ConnectionString


        #region DbSet
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        #endregion DbSet


        #region ModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<FichaPessoal>(entity =>
            //{
            //    entity.Property(e => e.FPNome).IsUnicode(false);

            //});

            //modelBuilder.Entity<Casos>(entity =>
            //{
            //    entity.HasOne(a => a.FichaPessoal)
            //    .WithMany(b => b.CasosAdo)
            //    .HasForeignKey(a => a.CasoCodFP);

            //    entity.HasOne(a => a.InfracaoData)
            //    .WithMany(b => b.Casos)
            //    .HasForeignKey(a => a.CasoCodInfra);

            //    entity.HasOne(a => a.SaidasData)
            //    .WithMany(b => b.Casos)
            //    .HasForeignKey(a => a.CasoCodSaida);

            //});

            //modelBuilder.Entity<Infracoes>(entity =>
            //{
            //    entity.Property(e => e.InfraDescr).IsUnicode(false);
            //});

            //modelBuilder.Entity<Saidas>(entity =>
            //{
            //    entity.Property(e => e.SaidaDescr).IsUnicode(false);
            //});

        }
        #endregion ModelCreating
    }
}
