using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;
using Reservation.Reservation.Models.ValueObjects;

namespace Reservation.Reservation.Models;

public class Reservation: BaseAggregateRoot<long>
{
    public Reservation()
    {

    }
    public Reservation(PassengerInfo passengerInfo, Journey journey, long? id = null)
    {
        Id = id ?? SnowFlakIdGenerator.NewId();
        Journey = journey;
        PassengerInfo = passengerInfo;
    }

    public static Reservation Create(PassengerInfo passengerInfo, Journey journey , long? id = null)
    {
        var reservation = new Reservation(passengerInfo, journey, id);
        return reservation;
    }
    
    public Journey Journey { get; private set; }
    public PassengerInfo PassengerInfo { get; private set; }
}