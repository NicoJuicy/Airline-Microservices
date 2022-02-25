using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Domain;
using Flight.Data;
using Flight.Flight.Exceptions;
using Flight.Seat.Dtos;
using Flight.Seat.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flight.Seat.Features.ReserveSeat;

public class ReserveSeatCommandHandler : IRequestHandler<ReserveSeatCommand, SeatResponseDto>
{
    private readonly IEventProcessor _eventProcessor;
    private readonly FlightDbContext _flightDbContext;
    private readonly IMapper _mapper;

    public ReserveSeatCommandHandler(IMapper mapper, FlightDbContext flightDbContext, IEventProcessor eventProcessor)
    {
        _mapper = mapper;
        _flightDbContext = flightDbContext;
        _eventProcessor = eventProcessor;
    }

    public async Task<SeatResponseDto> Handle(ReserveSeatCommand command, CancellationToken cancellationToken)
    {
        var seat = await _flightDbContext.Seats.SingleOrDefaultAsync(x => x.SeatNumber == command.SeatNumber && x.FlightId == command.FlightId
            && !x.IsDeleted, cancellationToken);

        if (seat is null)
            throw new SeatNumberIncorrectException();

        var reserveSeat = await seat.ReserveSeat(seat);

        var updatedSeat = _flightDbContext.Seats.Update(reserveSeat);

        await _eventProcessor.ProcessAsync(updatedSeat.Entity.Events, cancellationToken);

        await _flightDbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<SeatResponseDto>(updatedSeat.Entity);
    }
}
