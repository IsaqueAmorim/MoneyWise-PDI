namespace MoneyWise.Dominio.Repositorios
{
    public interface IRepositorio<T> where T: class
    {
        T Adicionar(T Entidade);
        int Remover(T Entidade);
        T Atualizar(T Entidade);
        T ObterPorId(Guid id);
        IEnumerable<T> ObterTodos();
    }
}
