using BuildingBlocks.Domain;

namespace Flight.Flight.Models;

public class Airport: BaseAggregateRoot<long>
{
    public Airport(string name, string address, string code)
    {
        Name = name;
        Address = address;
        Code = code;
    }
    
    public static Airport Create(string name, string address, string code)
    {
        var airport = new Airport(name, address, code);
        return airport;
    }
    
    public string Name { get; private set;}
    public string Address { get; private set;}
    public string Code { get; private set;}
}