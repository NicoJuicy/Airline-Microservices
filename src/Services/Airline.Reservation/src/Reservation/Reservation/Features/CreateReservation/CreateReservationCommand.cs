using MediatR;
using Reservation.Reservation.Dtos;

namespace Reservation.Reservation.Features.CreateReservation;

public record CreateReservationCommand
    (long PassengerId, long FlightId, string Description) : IRequest<ReservationResponseDto>;
