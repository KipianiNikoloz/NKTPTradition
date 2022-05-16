using API.DTO;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class AutoMapperProfiles: Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Hotel, ReturnHotelDto>();
        CreateMap<AddHotelDto, Hotel>();
    }
}