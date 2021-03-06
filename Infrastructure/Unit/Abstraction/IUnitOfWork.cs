using Infrastructure.Repository.Abstraction;

namespace Infrastructure.Unit.Abstraction;

public interface IUnitOfWork
{
    IHotelRepository HotelRepository { get; }
    IRegionRepository RegionRepository { get; }
    ITraditionRepository TraditionRepository { get; }
    bool HasChanges();
    Task<bool> SaveChanges();
}