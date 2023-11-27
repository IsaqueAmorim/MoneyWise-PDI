namespace MoneyWise.Dominio.Entidades
{
    public class Usuario: EntidadeBase
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
