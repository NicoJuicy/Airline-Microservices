using AutoMapper;
using Mapster;
using Reservation.Reservation.Dtos;

namespace Reservation.Reservation.Features;

public class ReservationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Models.Reservation, ReservationResponseDto>()
            .Map(d => d.Name, s => s.PassengerInfo.Name)
            .Map(d => d.Description, s => s.Journey.Description)
            .Map(d => d.PassengerId, s => s.PassengerInfo.PassengerId)
            .Map(d => d.ArriveDate, s => s.Journey.ArriveDate)
            .Map(d => d.ArriveAirportId, s => s.Journey.ArriveAirportId)
            .Map(d => d.DepartureDate, s => s.Journey.DepartureDate)
            .Map(d => d.DepartureAirportId, s => s.Journey.DepartureAirportId)
            .Map(d => d.Description, s => s.Journey.Description);
    }
}
