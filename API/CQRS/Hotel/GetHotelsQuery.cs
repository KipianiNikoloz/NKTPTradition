using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Parameters;
using Infrastructure.Helpers;
using Infrastructure.Unit.Abstraction;
using MediatR;

namespace API.CQRS;

public static class GetHotelsQuery
{
    public record Query(HotelParameters HotelParameters) : IRequest<Response>;

    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.HotelRepository.GetFilteredHotels(request.HotelParameters);

            var result = _mapper.Map<IReadOnlyList<Hotel>, IReadOnlyList<ReturnHotelDto>>(data);

            var pagination = new Pagination<ReturnHotelDto>(request.HotelParameters.PageIndex,
                request.HotelParameters.PageSize, result.Count, result);
            
            return new Response(pagination);
        }
    }

    public record Response(Pagination<ReturnHotelDto> data);
}