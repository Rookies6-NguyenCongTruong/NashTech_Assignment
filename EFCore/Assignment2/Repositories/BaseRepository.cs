using System.Linq.Expressions;
using Assignment2.Models;
using Assignment2.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    private readonly ProductStoreContext _context;

    public BaseRepository(ProductStoreContext context)
    {
        _dbSet = context.Set<T>();
        _context = context;
    }

    public T Create(T entity)
    {
        return _dbSet.Add(entity).Entity;
    }

    public IDatabaseTransaction DatabaseTransaction()
    {
        return new EntityDatabaseTransaction(_context);
    }

    public bool Delete(T entity)
    {
        _dbSet.Remove(entity);

        return true;
    }

    public T? Get(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate == null ? _dbSet.FirstOrDefault() : _dbSet.FirstOrDefault(predicate);
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate == null ? _dbSet : _dbSet.Where(predicate);

    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public T Update(T entity)
    {
        return _dbSet.Update(entity).Entity;
    }
}