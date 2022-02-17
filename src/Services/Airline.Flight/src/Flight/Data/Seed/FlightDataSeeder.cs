using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.Persistence;
using Flight.Flight.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight.Data.Seed
{
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
                var airports = new List<Airport>
                {
                    new Airport("Lisbon International Airport", "LIS", "12988", 1),
                    new Airport("Sao Paulo International Airport", "BRZ", "11200", 2),
                };

                await _flightDbContext.Airports.AddRangeAsync(airports);
                await _flightDbContext.SaveChangesAsync();
            }
        }

        private async Task SeedAircraftAsync()
        {
            if (!await _flightDbContext.Aircraft.AnyAsync())
            {
                var aircrafts = new List<Aircraft>
                {
                    new Aircraft("Boeing 737", "B737", 2005, 1),
                    new Aircraft("Airbus 320", "A320", 2000, 2)
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
                    Flight.Models.Flight.Create("BD467",1, 1, new DateTime(2022, 1, 31, 12, 0, 0),
                        new DateTime(2022, 1, 31, 14, 0, 0), 2, 120m, new DateTime(2022, 1, 31),
                        FlightStatus.Completed, 8000, 1)
                };
                
                await _flightDbContext.Flights.AddRangeAsync(flights);
                await _flightDbContext.SaveChangesAsync();
            }
        }
    }
}