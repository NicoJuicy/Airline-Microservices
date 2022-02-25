using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Domain;
using Flight.Aircraft.Exceptions;
using Flight.Data;
using Flight.Flight.Dtos;
using Flight.Flight.Exceptions;
using Flight.Flight.Models;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flight.Flight.Features.CreateFlight;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, FlightResponseDto>
{
    private readonly FlightDbContext _flightDbContext;
    private readonly IEventProcessor _eventProcessor;
    private readonly IMapper _mapper;

    public CreateFlightCommandHandler(IMapper mapper, FlightDbContext flightDbContext, IEventProcessor eventProcessor)
    {
        _mapper = mapper;
        _flightDbContext = flightDbContext;
        _eventProcessor = eventProcessor;
    }

    public async Task<FlightResponseDto> Handle(CreateFlightCommand command, CancellationToken cancellationToken)
    {
        var flight = await _flightDbContext.Flights.SingleOrDefaultAsync(x => x.FlightNumber == command.FlightNumber,
            cancellationToken);

        if (flight is not null)
            throw new FlightAlreadyExistException();

        var flightEntity = Models.Flight.Create(command.FlightNumber, command.AircraftId, command.DepartureAirportId, command.DepartureDate,
            command.ArriveDate, command.ArriveAirportId, command.DurationMinutes, command.FlightDate, FlightStatus.Completed, command.Price, true);

        var newFlight = await _flightDbContext.Flights.AddAsync(flightEntity, cancellationToken);

        await _eventProcessor.ProcessAsync(newFlight.Entity.Events, cancellationToken);

        await _flightDbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<FlightResponseDto>(newFlight.Entity);
    }
}
