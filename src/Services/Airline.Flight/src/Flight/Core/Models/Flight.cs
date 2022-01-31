using System;
using BuildingBlocks.Domain;
using Flight.Core.Events;

namespace Flight.Core.Models;

public class Flight: BaseAggregateRoot<long>
{
    public static Flight Create(string flightNumber, long aircraftId, long departureAirportId,
        DateTime departureDate, DateTime arriveDate, long arriveAirportId,
        decimal durationMinutes, DateTime flightDate, FlightStatus status, decimal price)
    {
        var flight = new Flight
        {
            FlightNumber = flightNumber,
            AircraftId = aircraftId,
            DepartureAirportId = departureAirportId,
            DepartureDate = departureDate,
            ArriveDate = arriveDate,
            ArriveAirportId = arriveAirportId,
            DurationMinutes = durationMinutes,
            FlightDate = flightDate,
            Status = status,
            Price = price
        };
        
        flight.AddEvent(new FlightCreatedDomainEvent(flight.FlightNumber));
        
        return flight;
    }
    
    public string FlightNumber { get; private set;}
    public long AircraftId { get; private set;}
    public DateTime DepartureDate { get; private set;}
    public long DepartureAirportId { get; private set;}
    public DateTime ArriveDate { get; private set;}
    public long ArriveAirportId { get; private set;}
    public decimal DurationMinutes { get; private set;}
    public DateTime FlightDate { get; private set;}
    public FlightStatus Status { get; private set;}
    public decimal Price { get; private set;}
}