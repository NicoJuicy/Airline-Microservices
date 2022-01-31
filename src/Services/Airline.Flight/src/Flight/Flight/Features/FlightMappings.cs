using AutoMapper;
using Flight.Flight.Dtos;
using Flight.Flight.Features.CreateFlight;

namespace Flight.Flight.Features;

public class FlightMappings : Profile
{
    public FlightMappings()
    {
        CreateMap<Core.Models.Flight, CreateFlightResponseDto>();
    }
}