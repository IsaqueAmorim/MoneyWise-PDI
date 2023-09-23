using MoneyWise.Dominio.Entidades;
using MoneyWise.Dominio.Repositorios;

namespace MoneyWise.Servico.Interfaces
{
    public interface IDespesaRepositorio : IRepositorio<Despesa>
    {
        List<Despesa> PegarTodasNoPeriodo(DateTime dataInicial, DateTime dataFinal);
        List<Despesa> PegarTodasPorValor(decimal valor);
    }
}
