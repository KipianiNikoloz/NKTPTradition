using API.DTO;
using AutoMapper;
using Core.Entities;
using Infrastructure.Unit.Abstraction;
using MediatR;

namespace API.CQRS;

public static class GetHotelQuery
{
    public record Request(int id) : IRequest<Response>;

    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var hotel = await _unitOfWork.HotelRepository.GetHotelById(request.id);

            var item = _mapper.Map<Hotel, ReturnHotelDto>(hotel);

            return new Response(item);
        }
    };

    public record Response(ReturnHotelDto item);
}