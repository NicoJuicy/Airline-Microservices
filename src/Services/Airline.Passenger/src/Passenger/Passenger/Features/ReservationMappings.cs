using AutoMapper;
using Passenger.Passenger.Dtos;

namespace Passenger.Passenger.Features;

public class ReservationMappings: Profile
{
    public ReservationMappings()
    {
        CreateMap<Models.Passenger, PassengerResponseDto>();
    }
}
