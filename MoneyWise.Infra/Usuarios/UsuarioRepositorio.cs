using Microsoft.EntityFrameworkCore;
using MoneyWise.Comum;
using MoneyWise.Dominio.Entidades;
using MoneyWise.Dominio.Excecoes;
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

        public Usuario ObterUsuarioComEmailESenha(string email, string senha)
        {
            var usuario = _contexto.Set<Usuario>().FirstOrDefault(usuario => usuario.Email == email) ?? throw new LoginInvalidoException();

            var loginEhValido = HasherSenha.VerificarHash(senha, usuario.Senha);

            if (!loginEhValido)
                throw new LoginInvalidoException();

            return usuario;
        }

        public bool VerificarSeEmailEhUtilizado(string email)
        {
            return _contexto.Set<Usuario>().Where(usuario => usuario.Email == email).Any();
        }
    }
}
