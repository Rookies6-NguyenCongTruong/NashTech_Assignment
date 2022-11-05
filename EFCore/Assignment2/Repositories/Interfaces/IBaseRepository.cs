using System.Linq.Expressions;
using Assignment2.Repositories;

namespace Assignment1.Repositories;

public interface IBaseRepository<T> where T : class
{
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null);
    T? Get(Expression<Func<T, bool>>? predicate = null);
    T Create(T entity);
    T Update(T entity);
    bool Delete(T entity);
    int SaveChanges();
    IDatabaseTransaction DatabaseTransaction();
}