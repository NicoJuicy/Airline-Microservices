using System.Linq;
using Flight.Flight.Dtos;
using Flight.Flight.Models;
using Flight.Seat.Dtos;
using Mapster;

namespace Flight.Flight.Features;

public class FlightMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Models.Flight, FlightResponseDto>();
    }
}
