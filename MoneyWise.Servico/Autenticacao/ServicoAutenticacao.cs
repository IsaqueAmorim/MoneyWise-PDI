using MoneyWise.Dominio.Entidades;
using MoneyWise.Dominio.Repositorios.Usuarios;

namespace MoneyWise.Servico.Autenticacao
{
    public class ServicoAutenticacao
    {
        private readonly IUsuarioRepositorio _repositorio;

        public ServicoAutenticacao(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public string Autenticar(Usuario usuario)
        {
            var usuarioBanco = _repositorio.ObterUsuarioComEmailESenha(usuario.Email, usuario.Senha);

            return GeradorDeToken.GerarToken(usuarioBanco);
        }
    }
}
