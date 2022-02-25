using System;
using System.Threading.Tasks;
using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;
using Flight.Flight.Exceptions;

namespace Flight.Flight.Models;

public class Seat : BaseAggregateRoot<long>
{
    public static Seat Create(string seatNumber, SeatType type, SeatClass @class, long flightId ,long? id = null)
    {
        var seat = new Seat()
        {
            Id = id ?? SnowFlakIdGenerator.NewId(),
            Class = @class,
            Type = type,
            SeatNumber = seatNumber,
            FlightId = flightId
        };

        return seat;
    }

    public Task<Seat> ReserveSeat(Seat seat)
    {
        seat.IsDeleted = true;
        seat.LastModified = DateTime.Now;
        return Task.FromResult(this);
    }

    public string SeatNumber { get; private set; }
    public SeatType Type { get; private set; }
    public SeatClass Class { get; private set; }
    public long FlightId { get; private set; }
}
