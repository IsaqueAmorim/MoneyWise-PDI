using System.Security.Cryptography;

namespace MoneyWise.Servico.Usuarios
{
    public static class HasherSenha
    {
        const string SEPARADOR = ";";
        const int TAMANHO_SALT = 16;
        const int NUMERO_DE_ITERACOES = 10000;
        const int TAMANHO_HASH = 32;

        public static string GerarHash(string senha)
        {
            var salt = RandomNumberGenerator.GetBytes(TAMANHO_SALT);
            var hash = Rfc2898DeriveBytes.Pbkdf2(senha, salt, NUMERO_DE_ITERACOES, HashAlgorithmName.SHA256, TAMANHO_HASH);

            return string.Join(SEPARADOR, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public static bool VerificarHash(string senhaInserida, string senhaSalva)
        {
            var elementos = senhaSalva.Split(SEPARADOR);
            var salt = Convert.FromBase64String(elementos[0]);
            var hashEsperado = Convert.FromBase64String(elementos[1]);

            var hash = Rfc2898DeriveBytes.Pbkdf2(senhaInserida, salt, NUMERO_DE_ITERACOES, HashAlgorithmName.SHA256, TAMANHO_HASH);

            return CryptographicOperations.FixedTimeEquals(hashEsperado, hash);
        }
    }
}
