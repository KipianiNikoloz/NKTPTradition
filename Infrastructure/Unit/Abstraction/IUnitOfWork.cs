using Infrastructure.Repository.Abstraction;

namespace Infrastructure.Unit.Abstraction;

public interface IUnitOfWork
{
    IHotelRepository HotelRepository { get; }
    bool HasChanges();
    Task<bool> SaveChanges();
}