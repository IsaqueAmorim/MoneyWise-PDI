using Microsoft.EntityFrameworkCore;
using MoneyWise.Dominio.Entidades;
using MoneyWise.Dominio.Repositorios.Usuarios;

namespace MoneyWise.Infra.Usuarios
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DbContext contexto) : base(contexto)
        {
        }
    }
}
