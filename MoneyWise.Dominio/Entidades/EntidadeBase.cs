using System.ComponentModel.DataAnnotations;

namespace MoneyWise.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
