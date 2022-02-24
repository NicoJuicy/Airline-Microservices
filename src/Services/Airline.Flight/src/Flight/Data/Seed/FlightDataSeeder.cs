using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.Persistence;
using Flight.Aircraft.Models;
using Flight.Flight.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight.Data.Seed;

public class FlightDataSeeder : IDataSeeder
{
    private readonly FlightDbContext _flightDbContext;

    public FlightDataSeeder(FlightDbContext flightDbContext)
    {
        _flightDbContext = flightDbContext;
    }

    public async Task SeedAllAsync()
    {
        await SeedAirportAsync();
        await SeedAircraftAsync();
        await SeedFlightAsync();
    }

    private async Task SeedAirportAsync()
    {
        if (!await _flightDbContext.Airports.AnyAsync())
        {
            var airports = new List<Airport.Models.Airport>
            {
                Airport.Models.Airport.Create("Lisbon International Airport", "LIS", "12988", 1),
                Airport.Models.Airport.Create("Sao Paulo International Airport", "BRZ", "11200", 2)
            };

            await _flightDbContext.Airports.AddRangeAsync(airports);
            await _flightDbContext.SaveChangesAsync();
        }
    }

    private async Task SeedAircraftAsync()
    {
        if (!await _flightDbContext.Aircraft.AnyAsync())
        {
            var aircrafts = new List<Aircraft.Models.Aircraft>
            {
                Aircraft.Models.Aircraft.Create("Boeing 737", "B737", 2005,
                    new List<Aircraft.Models.ValueObjects.Seat>()
                    {
                        new("12A", SeatType.Window, SeatClass.Economy, 1),
                        new("12B", SeatType.Window, SeatClass.Economy, 1),
                        new("12C", SeatType.Middle, SeatClass.Economy, 1),
                        new("12D", SeatType.Middle, SeatClass.Economy, 1),
                        new("12E", SeatType.Aisle, SeatClass.Economy, 1),
                        new("12F", SeatType.Aisle, SeatClass.Economy, 1),
                    }, 1),
                Aircraft.Models.Aircraft.Create("Airbus 300", "A300", 2000,
                    new List<Aircraft.Models.ValueObjects.Seat>()
                    {
                        new("12A", SeatType.Window, SeatClass.Economy, 2),
                        new("12B", SeatType.Window, SeatClass.Economy, 2),
                        new("12C", SeatType.Middle, SeatClass.Economy, 2),
                        new("12D", SeatType.Middle, SeatClass.Economy, 2),
                        new("12E", SeatType.Aisle, SeatClass.Economy, 2),
                        new("12F", SeatType.Aisle, SeatClass.Economy, 2),
                    }, 2),
                Aircraft.Models.Aircraft.Create("Airbus 320", "A320", 2003,
                    new List<Aircraft.Models.ValueObjects.Seat>()
                    {
                        new("12A", SeatType.Window, SeatClass.Economy, 3),
                        new("12B", SeatType.Window, SeatClass.Economy, 3),
                        new("12C", SeatType.Middle, SeatClass.Economy, 3),
                        new("12D", SeatType.Middle, SeatClass.Economy, 3),
                        new("12E", SeatType.Aisle, SeatClass.Economy, 3),
                        new("12F", SeatType.Aisle, SeatClass.Economy, 3),
                    }, 3)
            };

            await _flightDbContext.Aircraft.AddRangeAsync(aircrafts);
            await _flightDbContext.SaveChangesAsync();
        }
    }

    private async Task SeedFlightAsync()
    {
        if (!await _flightDbContext.Flights.AnyAsync())
        {
            var flights = new List<Flight.Models.Flight>
            {
                Flight.Models.Flight.Create("BD467", new Flight.Models.ValueObjects.Aircraft("Boeing 737", "B737"),
                    new Flight.Models.ValueObjects.Airport("Lisbon International Airport", "12988"),
                    new DateTime(2022, 1, 31, 12, 0, 0),
                    new DateTime(2022, 1, 31, 14, 0, 0),
                    new Flight.Models.ValueObjects.Airport("Sao Paulo International Airport", "11200"), 120m,
                    new DateTime(2022, 1, 31), FlightStatus.Completed,
                    8000, 1)
            };

            await _flightDbContext.Flights.AddRangeAsync(flights);
            await _flightDbContext.SaveChangesAsync();
        }
    }
}
