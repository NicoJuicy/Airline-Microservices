using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;
using Reservation.Reservation.Models.ValueObjects;

namespace Reservation.Reservation.Models;

public class Reservation : BaseAggregateRoot<long>
{
    public Reservation()
    {
    }

    public static Reservation Create(PassengerInfo passengerInfo, Trip trip, long? id = null)
    {
        var reservation = new Reservation()
        {
            Id = id ?? SnowFlakIdGenerator.NewId(), Trip = trip, PassengerInfo = passengerInfo
        };

        return reservation;
    }

    public Trip Trip { get; private set; }
    public PassengerInfo PassengerInfo { get; private set; }
}
