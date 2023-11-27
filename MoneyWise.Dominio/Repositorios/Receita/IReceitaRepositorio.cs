using MoneyWise.Dominio.Entidades;

namespace MoneyWise.Dominio.Repositorios.ReceitaRepositorio
{
    public interface IReceitaRepositorio : IRepositorio<Receita>
    {
        List<Receita> ObterReceitasPorPeriodo(DateTime dataInicial, DateTime dataFinal);
    }
}
