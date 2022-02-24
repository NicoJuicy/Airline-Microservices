using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;

namespace Passenger.Passenger.Models;

public class Passenger : BaseAggregateRoot<long>
{
    public static Passenger Create(string name, string passportNumber, PassengerType passengerType, int age,
        string email, long? id = null)
    {
        var passenger = new Passenger
        {
            Name = name,
            PassportNumber = passportNumber,
            PassengerType = passengerType,
            Age = age,
            Email = email,
            Id = id ?? SnowFlakIdGenerator.NewId()
        };
        return passenger;
    }


    public static Passenger Create(string name, long? id = null)
    {
        var passenger = new Passenger {Name = name, Id = id ?? SnowFlakIdGenerator.NewId()};
        return passenger;
    }


    public string PassportNumber { get; private set; }
    public string Name { get; private set; }
    public PassengerType PassengerType { get; private set; }
    public int Age { get; private set; }
    public string Email { get; private set; }
}
