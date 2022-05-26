using Infrastructure.Data;
using Infrastructure.Repository.Abstraction;
using Infrastructure.Repository.Implementation;
using Infrastructure.Unit.Abstraction;

namespace Infrastructure.Unit.Implementation;

public class UnitOfWork: IUnitOfWork
{
    private readonly DataContext _context;
    
    public UnitOfWork(DataContext context)
    {
        _context = context;
    }
    
    
    public IHotelRepository HotelRepository { get => new HotelRepository(_context); }
    public IRegionRepository RegionRepository { get => new RegionRepository(_context); }
    public ITraditionRepository TraditionRepository { get => new TraditionRepository(_context); }

    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}