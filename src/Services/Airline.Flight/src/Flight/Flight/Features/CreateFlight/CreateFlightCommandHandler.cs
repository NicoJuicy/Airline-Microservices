using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.Domain;
using BuildingBlocks.Exception;
using Flight.Flight.Dtos;
using Flight.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flight.Flight.Features.CreateFlight;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, CreateFlightResponseDto>
{
    private readonly FlightDbContext _flightDbContext;
    private readonly IMapper _mapper;
    private readonly IEventProcessor _eventProcessor;

    public CreateFlightCommandHandler(FlightDbContext flightDbContext, IMapper mapper, IEventProcessor eventProcessor)
    {
        _flightDbContext = flightDbContext;
        _mapper = mapper;
        _eventProcessor = eventProcessor;
    }


    public async Task<CreateFlightResponseDto> Handle(CreateFlightCommand command, CancellationToken cancellationToken)
    {
        var flight = await _flightDbContext.Flights.SingleOrDefaultAsync(x => x.FlightNumber == command.FlightNumber,
                cancellationToken);

        if (flight != null)
            throw new ConflictException("Flight already exists");

        var flightEntity = Core.Models.Flight.Create(command.FlightNumber, command.AircraftId, command.ArriveAirportId, command.DepartureDate, command.ArriveDate,
            command.ArriveAirportId, command.DurationMinutes, command.FlightDate, command.Status, command.Price);

        var newFlight = await _flightDbContext.Flights.AddAsync(flightEntity, cancellationToken);
        await _flightDbContext.SaveChangesAsync(cancellationToken);
        
        await _eventProcessor.ProcessAsync(newFlight.Entity.Events);

        return _mapper.Map<CreateFlightResponseDto>(newFlight.Entity);
    }
}