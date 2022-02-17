using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;

namespace Flight.Models;

public class Airport: BaseAggregateRoot<long>
{
    public Airport()
    {
        
    }
    public Airport(string name, string address, string code, long? id = null)
    {
        Id = id ?? SnowFlakIdGenerator.NewId();
        Name = name;
        Address = address;
        Code = code;
    }
    
    public static Airport Create(string name, string address, string code, long? id = null)
    {
        var airport = new Airport(name, address, code, id);
        return airport;
    }
    
    public string Name { get; private set;}
    public string Address { get; private set;}
    public string Code { get; private set;}
}