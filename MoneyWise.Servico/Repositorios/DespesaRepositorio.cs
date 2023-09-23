using MoneyWise.Dominio.Entidades;
using MoneyWise.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Servico.Repositorios
{
    public class DespesaRepositorio : IDespesaRepositorio
    {
        public List<Despesa> PegarTodasNoPeriodo(Guid idUsuario, DateTime dataInicial, DateTime dataFinal)
        {
            throw new NotImplementedException();
        }

        public List<Despesa> PegarTodasPorIdUsuario(Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Despesa> PegarTodasPorValor(Guid idUsuario, decimal valor)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(params Despesa[] despesaList)
        {
            throw new NotImplementedException();
        }

        public void Incluir(params Despesa[] despesaList)
        {
            throw new NotImplementedException();
        }

        public void Remover(params Despesa[] despesaList)
        {
            throw new NotImplementedException();
        }
    }
}
