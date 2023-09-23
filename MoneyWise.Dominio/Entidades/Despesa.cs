using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Dominio.Entidades
{
    public class Despesa
    {
        public DateTime DataDaTransacao { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public string MetodoDePagamento { get; set; }
        public string Descricao { get; set; }
        public string StatusDePagamento { get; set; }
    }
}
