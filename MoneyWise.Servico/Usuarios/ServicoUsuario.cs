using MoneyWise.Comum;
using MoneyWise.Dominio.Entidades;
using MoneyWise.Dominio.Repositorios.Usuarios;
using System.Text.RegularExpressions;

namespace MoneyWise.Servico.Usuarios
{
    public class ServicoUsuario
    {
        private readonly IUsuarioRepositorio _repositorio;

        public ServicoUsuario(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Usuario Adicionar(Usuario entidade)
        {
            ValidarEmail(entidade.Email);

            entidade.Senha = HasherSenha.GerarHash(entidade.Senha);

            return _repositorio.Adicionar(entidade);
        }

        private void ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new Exception("E-mail não informado.");

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception("E-mail inválido.");

            if (_repositorio.VerificarSeEmailEhUtilizado(email))
                throw new Exception("E-mail já utilizado.");
        }

        public Usuario Atualizar(Usuario entidade)
        {
            return _repositorio.Atualizar(entidade);
        }

        public Usuario ObterPorId(Guid id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public int Remover(Usuario entidade)
        {
            return _repositorio.Remover(entidade);
        }
    }
}
