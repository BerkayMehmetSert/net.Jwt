using API.Application.Constants.Repositories;
using API.Domain.Entities;
using API.Persistence.Context;

namespace API.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BaseDbContext _context;
    private bool _disposed = false;

    public IBaseRepository<Product> ProductRepository { get; private set; }
    public IBaseRepository<User> UserRepository { get; private set; }

    public UnitOfWork(BaseDbContext context)
    {
        _context = context;
        ProductRepository = new BaseRepository<Product>(context);
        UserRepository = new BaseRepository<User>(context);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
    
    protected virtual void Clean(bool disposing)
    {
        if (_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        GC.SuppressFinalize(this);
        _disposed = true;
    }

    public void Dispose()
    {
        Clean(true);
    }
}