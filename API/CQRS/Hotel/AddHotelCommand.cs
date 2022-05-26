using API.DTO;
using AutoMapper;
using Core.Entities;
using Infrastructure.Unit.Abstraction;
using MediatR;

namespace API.CQRS;

public static class AddHotelCommand
{
    public record Request(AddHotelDto item) : IRequest<Response>;

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
            var item = _mapper.Map<AddHotelDto, Hotel>(request.item);
            
            await _unitOfWork.HotelRepository.Add(item);

            bool result = false;
            if (_unitOfWork.HasChanges())
            {
                result = await _unitOfWork.SaveChanges();
            }

            return new Response(result);
        }
    }

    public record Response(bool result);
}