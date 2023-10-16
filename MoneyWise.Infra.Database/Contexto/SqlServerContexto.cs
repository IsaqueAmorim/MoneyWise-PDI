using Microsoft.EntityFrameworkCore;
using MoneyWise.Dominio.Entidades;

namespace MoneyWise.Infra.Database.Contexto
{
    public class SqlServerContexto : DbContext
    {
        public SqlServerContexto()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SQL_CONNECTION"));
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<Receita> Receitas { get; set; }
    }
}
