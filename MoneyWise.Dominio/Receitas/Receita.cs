namespace MoneyWise.Dominio.Receitas
{
    public class Receita
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public enum Categoria { }
        public DateTime DataTrasacao { get; set; }
        
        public Guid UserId {get; set;}
        //public User User {get; set;}
    }
}
