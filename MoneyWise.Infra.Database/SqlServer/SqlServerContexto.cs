using Microsoft.EntityFrameworkCore;
using MoneyWise.Dominio.Receitas;

namespace MoneyWise.Infra.Database.SqlServer
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
        public DbSet<Receita> Receitas { get; set; }
    }
}
