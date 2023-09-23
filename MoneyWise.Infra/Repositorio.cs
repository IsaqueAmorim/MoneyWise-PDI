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
        public T Adicionar(T Entity)
        {
            _contexto.Set<T>().Add(Entity);
            _contexto.SaveChanges();

            return Entity;
        }

        public T Atualizar(T Entity)
        {
            _contexto.Set<T>().Update(Entity);
            _contexto.SaveChanges();

            return Entity;
        }

        public T ObterPorId(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException();
                }

                return  _contexto.Set<T>().FirstOrDefault(x => (Guid) x.GetType().GetProperty("Id").GetValue(x, null) == id);

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

        public int Remover(T Entity)
        {
            _contexto.Set<T>().Remove(Entity);
            
            return _contexto.SaveChanges();
        }
    }
}
