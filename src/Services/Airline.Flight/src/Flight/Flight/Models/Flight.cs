using System;
using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;
using Flight.Flight.Events.Domain;

namespace Flight.Flight.Models;

public class Flight : BaseAggregateRoot<long>
{
    public Flight()
    {
    }

    public static Flight Create(string flightNumber, ValueObjects.Aircraft aircraft, ValueObjects.Airport departureAirport, DateTime departureDate, DateTime arriveDate,
        ValueObjects.Airport arriveAirport, decimal durationMinutes, DateTime flightDate, FlightStatus status, decimal price, long? id = null)
    {
        var flight = new Flight
        {
            Id = id ?? SnowFlakIdGenerator.NewId(),
            FlightNumber = flightNumber,
            Aircraft = aircraft,
            DepartureAirport = departureAirport,
            DepartureDate = departureDate,
            ArriveDate = arriveDate,
            ArriveAirport = arriveAirport,
            DurationMinutes = durationMinutes,
            FlightDate = flightDate,
            Status = status,
            Price = price
        };

        flight.AddEvent(new FlightCreatedDomainEvent(flight.FlightNumber));

        return flight;
    }

    public string FlightNumber { get; private set; }
    public ValueObjects.Aircraft Aircraft { get; private set; }
    public DateTime DepartureDate { get; private set; }
    public ValueObjects.Airport DepartureAirport { get; private set; }
    public DateTime ArriveDate { get; private set; }
    public ValueObjects.Airport ArriveAirport { get; private set; }
    public decimal DurationMinutes { get; private set; }
    public DateTime FlightDate { get; private set; }
    public FlightStatus Status { get; private set; }
    public decimal Price { get; private set; }
}
