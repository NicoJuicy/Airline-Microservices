using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;

namespace Flight.Flight.Models;

public class Aircraft: BaseAggregateRoot<long>
{
    public Aircraft()
    {
        
    }
    public Aircraft(string name, string model, int manufacturingYear, long? id = null)
    {
        Id = id ?? SnowFlakIdGenerator.NewId();
        Name = name;
        Model = model;
        ManufacturingYear = manufacturingYear;
    }
    
    public static Aircraft Create(string name, string model, int manufacturingYear, long? id = null)
    {
        var aircraft = new Aircraft(name, model, manufacturingYear, id);
        return aircraft;
    }
    
    public string Name { get; private set; }
    public string Model { get; private set;}
    public int ManufacturingYear { get; private set;}
}