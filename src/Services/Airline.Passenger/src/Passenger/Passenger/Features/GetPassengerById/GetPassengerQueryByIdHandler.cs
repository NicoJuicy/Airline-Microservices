using BuildingBlocks.Domain;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Passenger.Data;
using Passenger.Passenger.Dtos;

namespace Passenger.Passenger.Features.GetPassengerById;

public class GetPassengerQueryByIdHandler : IRequestHandler<GetPassengerQueryById, PassengerResponseDto>
{
    private readonly PassengerDbContext _passengerDbContext;
    private readonly IMapper _mapper;

    public GetPassengerQueryByIdHandler(IEventProcessor eventProcessor, IMapper mapper, PassengerDbContext passengerDbContext)
    {
        _mapper = mapper;
        _passengerDbContext = passengerDbContext;
    }

    public async Task<PassengerResponseDto> Handle(GetPassengerQueryById query, CancellationToken cancellationToken)
    {
        var passenger =
            await _passengerDbContext.Passengers.SingleOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

        if (passenger is null)
            return new PassengerResponseDto();

        return _mapper.Map<PassengerResponseDto>(passenger);
    }
}
