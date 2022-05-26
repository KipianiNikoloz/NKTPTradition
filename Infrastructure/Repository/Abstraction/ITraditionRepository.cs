using Core.Entities;
using Core.Parameters;

namespace Infrastructure.Repository.Abstraction;

public interface ITraditionRepository
{
    public Task<IReadOnlyList<Tradition>> GetTraditions(TraditionParameters parameters);
    public Task<Tradition> GetTradition(int id);
    public Task<Tradition> GetTraditionByName(string name);
    public Task AddTradition(Tradition item);
    public void UpdateTradition(Tradition item);
    public void DeleteTradition(Tradition item);
}