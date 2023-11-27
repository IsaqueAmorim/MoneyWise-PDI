namespace MoneyWise.Dominio.Entidades
{
    public class Receita : EntidadeBase
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public enum Categoria { }
        public DateTime DataTrasacao { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario {get; set;}
    }
}
