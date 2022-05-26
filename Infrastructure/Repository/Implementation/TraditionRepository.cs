using Core.Entities;
using Core.Parameters;
using Infrastructure.Data;
using Infrastructure.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementation;

public class TraditionRepository: ITraditionRepository
{
    private readonly DataContext _context;

    public TraditionRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IReadOnlyList<Tradition>> GetTraditions(TraditionParameters parameters)
    {
        var query = _context.Traditions.Include(t => t.Region).AsQueryable();

        if (parameters.Region != null)
        {
            query = query.Where(t => t.Region.Name.ToLower().Equals(parameters.Region.ToLower()));
        }

        if (parameters.Search != null)
        {
            query = query.Where(t => t.Name.ToLower().Contains(parameters.Search.ToLower()));
        }

        if (parameters.Sort != null)
        {
            switch (parameters.Sort)
            {
                case "dateAsc":
                    query = query.OrderBy(t => t.PublishDate);
                    break;
                case "dateDesc":
                    query = query.OrderByDescending(t => t.PublishDate);
                    break;
                default:
                    query = query.OrderBy(t => t.Name);
                    break;
            }
        }

        query = query.Skip((parameters.PageIndex - 1) * parameters.PageSize).Take(parameters.PageSize);

        return await query.ToListAsync();
    }

    public async Task<Tradition> GetTradition(int id)
    {
        return await _context.Traditions.Include(t => t.Region).FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tradition> GetTraditionByName(string name)
    {
        return await _context.Traditions.Include(t => t.Region).FirstOrDefaultAsync(t => t.Name == name);
    }

    public async Task AddTradition(Tradition item)
    {
        await _context.Traditions.AddAsync(item);
    }

    public void UpdateTradition(Tradition item)
    {
        _context.Traditions.Update(item);
    }

    public void DeleteTradition(Tradition item)
    {
        _context.Traditions.Update(item);
    }
}