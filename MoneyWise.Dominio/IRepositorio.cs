namespace MoneyWise.Infra
{
    public interface IRepositorio<T>
    {
        T Adicionar(T Entity);
        int Remover(T Entity);
        T Atualizar(T Entity);
        T ObterPorId(Guid id);
        IEnumerable<T> ObterTodos();
    }
}
