using System.Linq.Expressions;
using API.Application.Constants.Repositories;
using API.Domain.Common;
using API.Infrastructure.Utilities.Date;
using API.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace API.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly BaseDbContext _context;
    private readonly DbSet<T> _entities;

    public BaseRepository(BaseDbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public List<T> GetAll(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> queryable = _entities;

        if (include is not null)
        {
            queryable = include(queryable);
        }

        if (predicate is not null)
        {
            queryable = queryable.Where(predicate);
        }

        return orderBy is not null ? orderBy(queryable).ToList() : queryable.ToList();
    }

    public T Get(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> queryable = _entities;

        if (include is not null)
        {
            queryable = include(queryable);
        }

        return queryable.FirstOrDefault(predicate);
    }

    public void Create(T entity)
    {
        entity.CreatedAt = CalculateDate.GetCurrentDate();
        entity.UpdatedAt = CalculateDate.GetCurrentDate();
        _entities.Add(entity);
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = CalculateDate.GetCurrentDate();
        _entities.Update(entity);
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }
}