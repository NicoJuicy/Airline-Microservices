using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;

namespace Passenger.Models;

public class Passenger: BaseAggregateRoot<long>
{
    public Passenger()
    {
        
    }
    public Passenger(string name, string passportNumber, PassengerType passengerType, int age, string email, long? id = null)
    {
        Id = id ?? SnowFlakIdGenerator.NewId();
        Name = name;
        PassengerType = passengerType;
        Age = age;
        PassportNumber = passportNumber;
        Email = email;
    }

    public static Passenger Create(string name, string passportNumber, PassengerType passengerType, int age, string email, long? id = null)
    {
        var passenger = new Passenger(name, passportNumber, passengerType, age, email, id);
        return passenger;
    }
    
    public string PassportNumber { get; private set; }
    public string Name { get; private set; }
    public PassengerType PassengerType { get; private set; }
    public int Age { get; private set; }
    public string Email { get; private set; }
}