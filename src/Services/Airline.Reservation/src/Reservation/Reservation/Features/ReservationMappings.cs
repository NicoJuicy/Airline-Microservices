using AutoMapper;
using Reservation.Reservation.Dtos;

namespace Reservation.Reservation.Features;

public class ReservationMappings : Profile
{
    public ReservationMappings()
    {
        CreateMap<Models.Reservation, ReservationResponseDto>()
            .ForMember(d => d.Description, s => s.MapFrom(mf => mf.Journey.Description))
            .ForMember(d => d.Name, s => s.MapFrom(mf => mf.PassengerInfo.Name))
            .ForMember(d => d.PassengerId, s => s.MapFrom(mf => mf.PassengerInfo.PassengerId))
            .ForMember(d => d.ArriveDate, s => s.MapFrom(mf => mf.Journey.ArriveDate))
            .ForMember(d => d.ArriveAirportId, s => s.MapFrom(mf => mf.Journey.ArriveAirportId))
            .ForMember(d => d.DepartureDate, s => s.MapFrom(mf => mf.Journey.DepartureDate))
            .ForMember(d => d.DepartureAirportId, s => s.MapFrom(mf => mf.Journey.DepartureAirportId))
            .ForMember(d => d.Description, s => s.MapFrom(mf => mf.Journey.Description));
    }
}

