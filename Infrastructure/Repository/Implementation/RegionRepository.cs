using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementation;

public class RegionRepository: IRegionRepository
{
    private readonly DataContext _context;

    public RegionRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IReadOnlyList<Region>> GetRegions()
    {
        return await _context.Regions.ToListAsync();
    }

    public async Task<Region> GetRegion(int id)
    {
        return await _context.Regions.FindAsync(id);
    }

    public async Task<Region> GetRegionByName(string name)
    {
        return await _context.Regions.FirstOrDefaultAsync(r => r.Name == name);
    }

    public async Task AddRegion(Region item)
    {
        await _context.Regions.AddAsync(item);
    }

    public void UpdateRegion(Region item)
    {
        _context.Regions.Update(item);
    }

    public void DeleteRegion(Region item)
    {
        _context.Regions.Remove(item);
    }
}