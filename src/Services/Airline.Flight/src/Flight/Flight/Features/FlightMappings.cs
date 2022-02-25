using System.Linq;
using Flight.Flight.Dtos;
using Flight.Flight.Models;
using Mapster;

namespace Flight.Flight.Features;

public class FlightMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Models.Flight, FlightResponseDto>();

        config.NewConfig<Seat, SeatResponseDto>();
    }
}
