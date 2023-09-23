using System.ComponentModel.DataAnnotations;

namespace MoneyWise.Dominio.Entidades
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        
        public required string Nome { get; set; }
        
        public required string Email { get; set; }
        
        public required string Senha { get; set; }
    }
}
