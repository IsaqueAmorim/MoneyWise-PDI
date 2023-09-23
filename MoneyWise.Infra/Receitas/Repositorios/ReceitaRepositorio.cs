using Microsoft.EntityFrameworkCore;
using MoneyWise.Dominio.Receitas;
using MoneyWise.Dominio.Receitas.Repositorios;

namespace MoneyWise.Infra.Receitas.Repositorios
{
    public class ReceitaRepositorio : Repositorio<Receita>, IReceitaRepositorio
    {
        public ReceitaRepositorio(DbContext contexto) : base(contexto)
        {
        }
    }
}
