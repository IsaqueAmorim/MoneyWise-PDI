using System.ComponentModel.DataAnnotations;

namespace MoneyWise.Dominio.Entidades
{
    public class Cartao
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string NomeCartao { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public string NomeTitular { get; set; }
        public decimal ValorMinimoFatura { get; set; }
        public string CodigoSeguranca { get; set; }
        public decimal LimiteCredito { get; set; }
        public string Bandeira { get; set; }
        public string InstituicaoFinanceira { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataVencimentoFatura { get; set; }
        public List<Despesa> DespesasCartao { get; set; }
    }
}
