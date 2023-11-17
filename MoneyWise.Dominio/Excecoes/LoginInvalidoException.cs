namespace MoneyWise.Dominio.Excecoes
{
    public class LoginInvalidoException : Exception
    {
        private const string MENSAGEM = "Login ou senha inválidos.";

        public LoginInvalidoException()
            : this(MENSAGEM)
        {
        }

        private LoginInvalidoException(string mensagem)
            : base(mensagem)
        {
        }
    }
}
