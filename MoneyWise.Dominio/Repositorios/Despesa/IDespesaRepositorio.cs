using MoneyWise.Dominio.Entidades;
using MoneyWise.Dominio.Repositorios;

namespace MoneyWise.Servico.Interfaces
{
    public interface IDespesaRepositorio : IRepositorio<Despesa>
    {
        List<Despesa> ObterPorPeriodo(DateTime dataInicial, DateTime dataFinal);
    }
}
