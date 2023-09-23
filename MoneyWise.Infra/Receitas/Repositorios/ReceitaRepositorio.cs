using Microsoft.EntityFrameworkCore;
using MoneyWise.Dominio.Entidades;
using MoneyWise.Dominio.Repositorios.ReceitaRepositorio;

namespace MoneyWise.Infra.Receitas.Repositorios
{
    public class ReceitaRepositorio : Repositorio<Receita>, IReceitaRepositorio
    {
        private readonly DbContext _contexto;
        public ReceitaRepositorio(DbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
