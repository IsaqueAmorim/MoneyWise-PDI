using MoneyWise.Dominio.Entidades;
using MoneyWise.Dominio.Repositorios.ReceitaRepositorio;
using MoneyWise.Infra.Database.Contexto;

namespace MoneyWise.Infra.Receitas
{
    public class ReceitaRepositorio : Repositorio<Receita>, IReceitaRepositorio
    {
        private readonly SqlServerContexto _contexto;
        public ReceitaRepositorio(SqlServerContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public List<Receita> ObterReceitasPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
             return _contexto.Receitas.Where(x => x.DataTrasacao >= dataInicial && x.DataTrasacao <= dataFinal).ToList();
        }
    }
}
