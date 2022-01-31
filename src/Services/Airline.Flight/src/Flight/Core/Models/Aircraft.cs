using BuildingBlocks.Domain;

namespace Flight.Core.Models;

public class Aircraft: BaseAggregateRoot<long>
{
    public Aircraft(string name, string model, int manufacturingYear)
    {
        Name = name;
        Model = model;
        ManufacturingYear = manufacturingYear;
    }
    
    public static Aircraft Create(string name, string model, int manufacturingYear)
    {
        var aircraft = new Aircraft(name, model, manufacturingYear);
        return aircraft;
    }
    
    public string Name { get; private set; }
    public string Model { get; private set;}
    public int ManufacturingYear { get; private set;}
}