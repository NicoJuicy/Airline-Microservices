using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;

namespace Flight.Airport.Models;

public class Airport : BaseAggregateRoot<long>
{
    public Airport()
    {
    }

    public static Airport Create(string name, string address, string code, long? id = null)
    {
        var airport = new Airport
        {
            Id = id ?? SnowFlakIdGenerator.NewId(),
            Name = name,
            Address = address,
            Code = code
        };
        return airport;
    }

    public string Name { get; private set; }
    public string Address { get; private set; }
    public string Code { get; private set; }
}
