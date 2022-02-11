using BuildingBlocks.Domain;
using Reservation.Models.ValueObjects;

namespace Reservation.Models;

public class Reservation: BaseAggregateRoot<long>
{ 
    public Reservation(PassengerInfo passengerInfo, Journey journey)
    {
        Journey = journey;
        PassengerInfo = passengerInfo;
    }

    public static Reservation Create(PassengerInfo passengerInfo, Journey journey)
    {
        var reservation = new Reservation(passengerInfo, journey);
        return reservation;
    }
    
    public Journey Journey { get; private set; }
    public PassengerInfo PassengerInfo { get; private set; }
}