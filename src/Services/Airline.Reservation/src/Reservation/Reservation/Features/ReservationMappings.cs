using Mapster;
using Reservation.Reservation.Dtos;

namespace Reservation.Reservation.Features;

public class ReservationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // config.NewConfig<Models.Reservation, ReservationResponseDto>()
        //     .Map(d => d.Name, s => s.PassengerInfo.Name)
        //     .Map(d => d.Description, s => s.Trip.Description)
        //     .Map(d => d.PassengerId, s => s.PassengerInfo)
        //     .Map(d => d.ArriveAirportId, s => s.Trip.ArriveAirportId)
        //     .Map(d => d.DepartureAirportId, s => s.Trip.DepartureAirportId)
        //     .Map(d => d.Description, s => s.Trip.Description);
    }
}
