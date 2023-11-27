namespace MoneyWise.Dominio.Entidades
{
    public class Despesa : EntidadeBase
    {
        public DateTime DataDaTransacao { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public string MetodoDePagamento { get; set; }
        public string Descricao { get; set; }
        public string StatusDePagamento { get; set; }
        
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set;}
    }
}
