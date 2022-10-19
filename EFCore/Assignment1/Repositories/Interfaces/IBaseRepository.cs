using System.Linq.Expressions;
using Assignment1.Models;

namespace Assignment1.Repositories;

public interface IBaseRepository<T> where T : BaseEntity<int>
{
    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    public T? Get(Expression<Func<T, bool>> predicate);
    public T Create(T entity);
    public T Update(T entity);
    public bool Delete(T entity);
    public int SaveChanges();
}