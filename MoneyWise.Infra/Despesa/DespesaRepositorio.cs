using Microsoft.EntityFrameworkCore;
using MoneyWise.Dominio.Entidades;
using MoneyWise.Dominio.Repositorios;
using MoneyWise.Infra;
using MoneyWise.Servico.Interfaces;

namespace MoneyWise.Servico.Repositorios
{
    public class DespesaRepositorio : Repositorio<Despesa>, IDespesaRepositorio
    {
        private readonly DbContext _contexto;
        public DespesaRepositorio(DbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public List<Despesa> PegarTodasNoPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return _contexto.Set<Despesa>()
                .Where(despesa => despesa.DataDaTransacao >= dataInicial && despesa.DataDaTransacao <= dataFinal)
                .ToList();
        }

        public List<Despesa> PegarTodasPorValor(decimal valor)
        {
            return _contexto.Set<Despesa>()
                .Where(despesa => despesa.Valor <= valor)
                .ToList();
        }
    }
}
