using API.DTO;
using AutoMapper;
using Infrastructure.Unit.Abstraction;
using MediatR;

namespace API.CQRS;

public static class UpdateHotelCommand
{
    public record Request(UpdateHotelDto item, int id) : IRequest<Response>;

    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.HotelRepository.GetHotelById(request.id);

            if (item != null)
            {
                _mapper.Map(request.item, item);
                
                _unitOfWork.HotelRepository.Update(item);
            }

            bool result = false;
            
            if (_unitOfWork.HasChanges()) result = await _unitOfWork.SaveChanges();

            return new Response(result);
        }
    }

    public record Response(bool result);
}