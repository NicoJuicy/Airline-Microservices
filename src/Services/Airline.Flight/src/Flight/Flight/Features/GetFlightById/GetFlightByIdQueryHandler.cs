using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Flight.Data;
using Flight.Flight.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flight.Flight.Features.GetFlightById;

public class GetFlightByIdQueryHandler : IRequestHandler<GetFlightByIdQuery, FlightResponseDto>
{
    private readonly FlightDbContext _flightDbContext;
    private readonly IMapper _mapper;

    public GetFlightByIdQueryHandler(IMapper mapper, FlightDbContext flightDbContext)
    {
        _mapper = mapper;
        _flightDbContext = flightDbContext;
    }

    public async Task<FlightResponseDto> Handle(GetFlightByIdQuery query, CancellationToken cancellationToken)
    {
        var flight = await _flightDbContext.Flights.SingleOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

        return _mapper.Map<FlightResponseDto>(flight);
    }
}