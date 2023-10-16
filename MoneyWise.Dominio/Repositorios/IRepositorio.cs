namespace MoneyWise.Dominio.Repositorios
{
    public interface IRepositorio<T> where T: class
    {
        T Adicionar(T entidade);
        
        int Remover(T entidade);
        
        T Atualizar(T entidade);
        
        T ObterPorId(Guid id);

        IEnumerable<T> ObterTodos();
    }
}
