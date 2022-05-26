using Core.Entities;

namespace Infrastructure.Repository.Abstraction;

public interface IRegionRepository
{
    public Task<IReadOnlyList<Region>> GetRegions();
    public Task<Region> GetRegion(int id);
    public Task<Region> GetRegionByName(string name);
    public Task AddRegion(Region item);
    public void UpdateRegion(Region item);
    public void DeleteRegion(Region item);
}