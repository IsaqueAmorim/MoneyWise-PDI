using MoneyWise.Dominio.Entidades;

namespace MoneyWise.Test.Unitario.Usuarios
{
    public static class TestDataHelper
    {
        public static Usuario ObterUsuario()
        {
            return new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Usuario",
                    Email = "usuario@gmail.com",
                    Senha = "hash"
                };
        }

        public static IEnumerable<Usuario> ObterListaUsuarios()
        {
            return new List<Usuario>
            {
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Usuario",
                    Email = "usuario@gmail.com",
                    Senha = "hash"
                },
                new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Usuario",
                    Email = "usuario@gmail.com",
                    Senha = "hash"
                }
            };
        }
    }
}
