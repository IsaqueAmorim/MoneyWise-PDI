using MoneyWise.Servico.Usuarios;

namespace MoneyWise.Test.Unitario.Usuarios
{
    [Collection("Coleção de Testes do Hasher de Senhas")]
    public class Testes_Do_Hasher_De_Senhas
    {
        [Fact]
        public void VerificarHash_deve_retornar_true()
        {
            // Arrange
            const string SENHA_INSERIDA = "123456";
            const string SENHA_SALVA = "GtHDqXKy91E1a5Z3V9zBdQ==;RjBrSxtPSiwnkMHDwmeOIjSHFV05ujv0dmH8BfRXJPE=";

            // Act
            var senha = HasherSenha.VerificarHash(SENHA_INSERIDA, SENHA_SALVA);

            // Assert
            Assert.True(senha);
        }

        [Fact]
        public void VerificarHash_deve_retornar_false()
        {
            // Arrange
            const string SENHA_INSERIDA = "12345678";
            const string SENHA_SALVA = "GtHDqXKy91E1a5Z3V9zBdQ==;RjBrSxtPSiwnkMHDwmeOIjSHFV05ujv0dmH8BfRXJPE=";

            // Act
            var senha = HasherSenha.VerificarHash(SENHA_INSERIDA, SENHA_SALVA);

            // Assert
            Assert.False(senha);
        }
    }
}