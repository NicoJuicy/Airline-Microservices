using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.Domain;
using Flight.Data;
using Flight.Flight.Dtos;
using Flight.Flight.Exceptions;
using Flight.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flight.Flight.Features.CreateFlight;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, CreateFlightResponseDto>
{
    private readonly IEventProcessor _eventProcessor;
    private readonly FlightDbContext _flightDbContext;
    private readonly IMapper _mapper;

    public CreateFlightCommandHandler(IEventProcessor eventProcessor, IMapper mapper, FlightDbContext flightDbContext)
    {
        _eventProcessor = eventProcessor;
        _mapper = mapper;
        _flightDbContext = flightDbContext;
    }

    public async Task<CreateFlightResponseDto> Handle(CreateFlightCommand command, CancellationToken cancellationToken)
    {
        var flight = await _flightDbContext.Flights.SingleOrDefaultAsync(x => x.FlightNumber == command.FlightNumber,
            cancellationToken);

        if (flight is not null)
            throw new FlightAlreadyExistException();

        var flightEntity = Models.Flight.Create(command.FlightNumber, command.AircraftId,
            command.ArriveAirportId, command.DepartureDate,
            command.ArriveDate, command.ArriveAirportId, command.DurationMinutes, command.FlightDate, FlightStatus.Completed, command.Price);

        var newFlight = await _flightDbContext.Flights.AddAsync(flightEntity, cancellationToken);

        await _eventProcessor.ProcessAsync(newFlight.Entity.Events);

        await _flightDbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CreateFlightResponseDto>(newFlight.Entity);
    }
}