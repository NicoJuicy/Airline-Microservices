using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flight.Data;
using Flight.Flight.Dtos;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flight.Flight.Features.GetAvailableFlights;

public class GetAvailableFlightsQueryHandler : IRequestHandler<GetAvailableFlightsQuery, IEnumerable<FlightResponseDto>>
{
    private readonly FlightDbContext _flightDbContext;
    private readonly IMapper _mapper;

    public GetAvailableFlightsQueryHandler(IMapper mapper, FlightDbContext flightDbContext)
    {
        _mapper = mapper;
        _flightDbContext = flightDbContext;
    }

    public async Task<IEnumerable<FlightResponseDto>> Handle(GetAvailableFlightsQuery request,
        CancellationToken cancellationToken)
    {
        var flight = await _flightDbContext.Flights.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);

        if (flight.Count > 0)
            return new List<FlightResponseDto>();

        return _mapper.Map<List<FlightResponseDto>>(flight);
    }
}
