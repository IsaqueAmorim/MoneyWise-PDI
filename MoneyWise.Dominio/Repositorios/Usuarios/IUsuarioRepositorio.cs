using MoneyWise.Dominio.Entidades;

namespace MoneyWise.Dominio.Repositorios.Usuarios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        bool VerificarSeEmailEhUtilizado(string email);
    }
}
