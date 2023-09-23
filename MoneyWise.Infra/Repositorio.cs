using Microsoft.EntityFrameworkCore;
using MoneyWise.Dominio.Repositorios;

namespace MoneyWise.Infra
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly DbContext _contexto;
        
        public Repositorio(DbContext contexto)
        {
            _contexto = contexto;
        }

        public T Adicionar(T entidade)
        {
            _contexto.Set<T>().Add(entidade);
            _contexto.SaveChanges();

            return entidade;
        }

        public T Atualizar(T entidade)
        {
            _contexto.Set<T>().Update(entidade);
            _contexto.SaveChanges();

            return entidade;
        }

        public T ObterPorId(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new Exception("Informe o ID do registro.");
                }

                return _contexto.Set<T>().FirstOrDefault(x => (Guid)x.GetType().GetProperty("Id").GetValue(x, null) == id);

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public IEnumerable<T> ObterTodos()
        {
            return _contexto.Set<T>().ToList();
        }

        public int Remover(T entidade)
        {
            _contexto.Set<T>().Remove(entidade);
            
            return _contexto.SaveChanges();
        }
    }
}
