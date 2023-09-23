using MoneyWise.Dominio.Entidades;

namespace MoneyWise.Servico.Interfaces
{
    public interface IDespesaRepositorio
    {
        List<Despesa> PegarTodasPorIdUsuario(Guid idUsuario);
        List<Despesa> PegarTodasNoPeriodo(Guid idUsuario, DateTime dataInicial, DateTime dataFinal);
        List<Despesa> PegarTodasPorValor(Guid idUsuario, decimal valor);
        void Incluir(params Despesa[] despesaList);
        void Atualizar(params Despesa[] despesaList);
        void Remover(params Despesa[] despesaList);
    }
}
