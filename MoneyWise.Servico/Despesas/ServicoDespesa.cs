using MoneyWise.Dominio.Entidades;
using MoneyWise.Servico.Interfaces;

namespace MoneyWise.Servico.Despesas
{
    public class ServicoDespesa
    {
        private readonly IDespesaRepositorio _repositorio;
        public ServicoDespesa(IDespesaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Despesa Adicionar(Despesa despesa)
        {
            return _repositorio.Adicionar(despesa);
        }

        public Despesa Atualizar(Despesa despesa)
        {
            return _repositorio.Atualizar(despesa);
        }

        public Despesa ObterPorId(Guid id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<Despesa> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public List<Despesa> ObterDespesasPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return _repositorio.ObterPorPeriodo(dataInicial, dataFinal);
        }

        public int Remover(Despesa despesa)
        {
            return _repositorio.Remover(despesa);
        }
    }
}
