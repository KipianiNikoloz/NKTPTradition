using Core.Entities;
using Core.Parameters;

namespace Infrastructure.Repository.Abstraction;

public interface IHotelRepository
{
    public Task<IReadOnlyList<Hotel>> GetHotels();
    public Task<IReadOnlyList<Hotel>> GetFilteredHotels(HotelParameters hotelParameters);
    public Task<Hotel> GetHotelById(int id);
    public Task<Hotel> GetHotelByName(string name);
    public Task Add(Hotel hotel);
    public void Update(Hotel hotel);
    public void Delete(Hotel hotel);
}