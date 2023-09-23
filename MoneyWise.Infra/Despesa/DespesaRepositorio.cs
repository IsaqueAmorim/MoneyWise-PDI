using Microsoft.EntityFrameworkCore;
using MoneyWise.Dominio.Entidades;
using MoneyWise.Infra;

namespace MoneyWise.Servico.Repositorios
{
    public class DespesaRepositorio : Repositorio<Despesa>
    {
        private readonly DbContext _contexto;
        public DespesaRepositorio(DbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
