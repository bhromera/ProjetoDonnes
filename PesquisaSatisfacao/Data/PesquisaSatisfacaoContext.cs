using Microsoft.EntityFrameworkCore;
using PesquisaSatisfacao.Application.Data.Models;

namespace PesquisaSatisfacao.API.Data
{
    public partial class PesquisaSatisfacaoContext : DbContext
    {
        public PesquisaSatisfacaoContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PesquisaSatisfacaoContext).Assembly);
        }
    }
}
