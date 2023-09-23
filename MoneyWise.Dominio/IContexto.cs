namespace MoneyWise.Dominio
{
    public interface IContexto
    {
        T ObterContexto<T>(T Contexto);
    }
}
