using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flight.Data;
using Flight.Seat.Dtos;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flight.Seat.Features.GetAvailableSeats;

public class GetAvailableSeatsQueryHandler : IRequestHandler<GetAvailableSeatsQuery, IEnumerable<SeatResponseDto>>
{
    private readonly FlightDbContext _flightDbContext;
    private readonly IMapper _mapper;

    public GetAvailableSeatsQueryHandler(IMapper mapper, FlightDbContext flightDbContext)
    {
        _mapper = mapper;
        _flightDbContext = flightDbContext;
    }


    public async Task<IEnumerable<SeatResponseDto>> Handle(GetAvailableSeatsQuery query, CancellationToken cancellationToken)
    {
        var seats = await _flightDbContext.Seats.Where(x => x.FlightId == query.FlightId && !x.IsDeleted).ToListAsync(cancellationToken);

        if (!seats.Any())
            return new List<SeatResponseDto>();

        return _mapper.Map<List<SeatResponseDto>>(seats);
    }
}
