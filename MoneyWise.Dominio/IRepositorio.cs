namespace MoneyWise.Infra
{
    public interface IRepositorio
    {
        T Adicionar<T>(T Entity);
        int Remover<T>(T Entity);
        T Atualizar<T>(T Entity);
        T ObterPorId<T>(int id);
        T ObterTodos<T>();
    }
}
