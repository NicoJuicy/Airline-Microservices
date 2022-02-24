using System.Collections.Generic;
using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;

namespace Flight.Aircraft.Models;

public class Aircraft : BaseAggregateRoot<long>
{
    public Aircraft()
    {
    }

    public static Aircraft Create(string name, string model, int manufacturingYear, IList<ValueObjects.Seat> seats = null, long? id = null)
    {
        var aircraft = new Aircraft
        {
            Id = id ?? SnowFlakIdGenerator.NewId(),
            Name = name, Model = model, ManufacturingYear = manufacturingYear, Seats = seats
        };
        return aircraft;
    }

    public string Name { get; private set; }
    public string Model { get; private set; }
    public int ManufacturingYear { get; private set; }
    public IEnumerable<ValueObjects.Seat> Seats { get; private set; }
}
