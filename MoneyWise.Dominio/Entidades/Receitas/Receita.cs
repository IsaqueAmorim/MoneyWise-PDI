using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyWise.Dominio.Entidades.Receitas
{
    public class Receita
    {
        [Key]
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public enum Categoria { }
        public DateTime DataTrasacao { get; set; }

        public Guid UserId { get; set; }
        //public User User {get; set;}
    }
}
