using API.Controllers.Base;
using API.CQRS;
using API.DTO;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Parameters;
using Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class HotelController: BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HotelController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<Pagination<ReturnHotelDto>>> GetHotels([FromQuery] HotelParameters hotelParameters)
    {
        var response = await _mediator.Send(new GetHotelsQuery.Query(hotelParameters));

        if (response.data != null) return Ok(response.data);

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReturnHotelDto>> GetHotel(int id)
    {
        var response = await _mediator.Send(new GetHotelQuery.Request(id));

        if (response != null) return Ok(response.item);

        return BadRequest();
    }

    [HttpPost]
    public async Task<ActionResult> AddHotel([FromBody] AddHotelDto item)
    {
        var response = await _mediator.Send(new AddHotelCommand.Request(item));

        if (response.result) return Ok();

        return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateHotel([FromBody] UpdateHotelDto item, int id)
    {
        var response = await _mediator.Send(new UpdateHotelCommand.Request(item, id));

        if (response.result) return Ok();

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteHotel(int id)
    {
        var response = await _mediator.Send(new DeleteHotelCommand.Request(id));

        if (response.result) return Ok();

        return BadRequest();
    }
}