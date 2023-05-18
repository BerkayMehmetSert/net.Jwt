using API.Domain.Entities;

namespace API.Application.Constants.Repositories;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<Product> ProductRepository { get; }
    IBaseRepository<User> UserRepository { get; }
    void SaveChanges();
}