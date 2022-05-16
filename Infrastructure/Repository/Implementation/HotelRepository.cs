using Core.Entities;
using Core.Parameters;
using Infrastructure.Data;
using Infrastructure.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementation;

public class HotelRepository: IHotelRepository
{
    private readonly DataContext _context;

    public HotelRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IReadOnlyList<Hotel>> GetHotels()
    {
        var hotels = await _context.Hotels.ToListAsync();

        return hotels;
    }

    public async Task<IReadOnlyList<Hotel>> GetFilteredHotels(HotelParameters hotelParameters)
    {
        var query = _context.Hotels.AsQueryable();

        if (hotelParameters.MaxPrice != null) query = query.Where(hotel => hotel.Price <= hotelParameters.MaxPrice);

        if (hotelParameters.MinPrice != null) query = query.Where(hotel => hotel.Price >= hotelParameters.MinPrice);

        if (hotelParameters.Location != null)
            query = query.Where(hotel => hotel.Location.ToLower() == hotelParameters.Location.ToLower());

        if (hotelParameters.Search != null) query = query.Where(hotel => hotel.Name.ToLower().Contains(hotelParameters.Search.ToLower()));

        switch (hotelParameters.Sort)
        {
            case "orderByPriceAsc":
                query = query.OrderBy(hotel => hotel.Price);
                break;
            case "orderByPriceDesc":
                query = query.OrderByDescending(hotel => hotel.Price);
                break;
            default:
                query = query.OrderBy(hotel => hotel.Name);
                break;
        }

        if (hotelParameters.PageIndex != null && hotelParameters.PageSize != null)
            query = query.Skip((hotelParameters.PageIndex - 1) * hotelParameters.PageSize).Take(hotelParameters.PageSize);

        return await query.ToListAsync();
    }

    public async Task<Hotel> GetHotelById(int id)
    {
        return await _context.Hotels.FindAsync(id);
    }

    public async Task<Hotel> GetHotelByName(string name)
    {
        return await _context.Hotels.FirstOrDefaultAsync(hotel => hotel.Name.ToLower().Equals(name.ToLower()));
    }

    public async Task Add(Hotel hotel)
    {
        await _context.Hotels.AddAsync(hotel);
    }

    public void Update(Hotel hotel)
    {
        _context.Hotels.Update(hotel);
    }

    public void Delete(Hotel hotel)
    {
        _context.Hotels.Remove(hotel);
    }
}