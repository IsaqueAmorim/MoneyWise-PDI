using Microsoft.EntityFrameworkCore;
using MoneyWise.Dominio.Entidades;
using MoneyWise.Dominio.Repositorios.Usuarios;
using System.Text.RegularExpressions;

namespace MoneyWise.Infra.Usuarios
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly DbContext _contexto;

        public UsuarioRepositorio(DbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public bool VerificarSeEmailEhUtilizado(string email)
        {
            return _contexto.Set<Usuario>().Where(usuario => usuario.Email == email).Any();
        }
    }
}
