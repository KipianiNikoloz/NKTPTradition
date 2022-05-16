using AutoMapper;
using Infrastructure.Unit.Abstraction;
using MediatR;

namespace API.CQRS;

public static class DeleteHotelCommand
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

            if (hotel != null) _unitOfWork.HotelRepository.Delete(hotel);

            bool result = false;

            if (_unitOfWork.HasChanges()) result = await _unitOfWork.SaveChanges();

            return new Response(result);
        }
    }
    
    public record Response(bool result);
}