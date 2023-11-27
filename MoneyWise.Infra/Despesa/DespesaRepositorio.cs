using MoneyWise.Infra.Database.Contexto;
using MoneyWise.Servico.Interfaces;
using MoneyWise.Dominio.Entidades;
using MoneyWise.Infra;

namespace MoneyWise.Servico.Repositorios
{
    public class DespesaRepositorio : Repositorio<Despesa>, IDespesaRepositorio
    {
        private readonly SqlServerContexto _contexto;
        public DespesaRepositorio(SqlServerContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public List<Despesa> ObterPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return _contexto.Despesas.Where(x => x.DataDaTransacao >= dataInicial && x.DataDaTransacao <= dataFinal).ToList();
        }
    }
}
