using AutoMapper;
using BuildingBlocks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Passenger.Data;
using Passenger.Passenger.Dtos;
using Passenger.Passenger.Exceptions;

namespace Passenger.Passenger.Features.CreatePassenger;

public class CreatePassengerCommandHandler: IRequestHandler<CreatePassengerCommand, CreatePassengerResponseDto>
{
    private readonly IEventProcessor _eventProcessor;
    private readonly IMapper _mapper;
    private readonly PassengerDbContext _passengerDbContext;

    public CreatePassengerCommandHandler(IEventProcessor eventProcessor, IMapper mapper, PassengerDbContext passengerDbContext)
    {
        _eventProcessor = eventProcessor;
        _mapper = mapper;
        _passengerDbContext = passengerDbContext;
    }

    public async Task<CreatePassengerResponseDto> Handle(CreatePassengerCommand command, CancellationToken cancellationToken)
    {
        var flight = await _passengerDbContext.Passengers.SingleOrDefaultAsync(x => x.PassportNumber == command.PassportNumber,
            cancellationToken);

        if (flight is not null)
            throw new PassengerAlreadyExist();

        var passengerEntity = Models.Passenger.Create(command.Name, command.PassportNumber, command.PassengerType, command.Age, command.Email);

        var newPassenger = await _passengerDbContext.Passengers.AddAsync(passengerEntity, cancellationToken);

        await _eventProcessor.ProcessAsync(newPassenger.Entity.Events);

        await _passengerDbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CreatePassengerResponseDto>(newPassenger.Entity);
    }
}