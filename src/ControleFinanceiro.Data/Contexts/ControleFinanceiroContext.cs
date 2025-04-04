using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleFinanceiro.Data.Contexts
{
    public class ControleFinanceiroContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ControleFinanceiroContext(IConfiguration configuration)
        {
            _configuration = configuration;
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
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ControleFinanceiro"));
            }
        }
        #endregion ConnectionString


        #region DbSet
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Destinatario> Destinatario { get; set; }
        public virtual DbSet<FormaPagamento> FormaPagamento { get; set; }
        public virtual DbSet<Instituicao> Instituicao { get; set; }
        public virtual DbSet<Gastos> Gastos { get; set; }
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
