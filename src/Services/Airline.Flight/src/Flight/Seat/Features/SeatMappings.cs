using Flight.Seat.Dtos;
using Mapster;

namespace Flight.Seat.Features;

public class SeatMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Flight.Models.Seat, SeatResponseDto>();
    }
}

