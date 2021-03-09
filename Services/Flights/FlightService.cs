using AirlineServiceSoftware.Entities;
using AirlineServiceSoftware.Mediators.MediatorsRequests.Flights;
using MediatR;
using System.Collections.Generic;

namespace AirlineServiceSoftware.Services.Flights
{
    public class FlightService : IFlightService
    {
        private readonly IMediator _mediator;

        public FlightService(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public bool CreateFlight(Flight newFlight)
        {
            var result = _mediator.Send(new CreateFlightRequest()
            {
                Crew = newFlight.Crew,
                FlightNumber = newFlight.FlightNumber,
                StartingAirportName = newFlight.StartingAirportName,
                DestinationAirportName = newFlight.DestinationAirportName,
                FlightDate = newFlight.FlightDate,
                TakeoffHour = newFlight.TakeoffHour,
                LandingHour = newFlight.LandingHour,
                PlaneType = newFlight.PlaneType,
                TotalSeats = newFlight.TotalSeats,
                RemainingSeats = newFlight.RemainingSeats,
                IsApproved = newFlight.IsApproved,
                IsCompleted = newFlight.IsCompleted,
            }).Result;

            return result;
        }

        public bool DeleteFlight(int Id)
        {
            var result = _mediator.Send(new DeleteFlightRequest()
            {
                Id = Id
            }).Result;

            return result;
        }

        public bool EditFlight(Flight editFlight)
        {
            var result = _mediator.Send(new EditFlightRequest()
            {
                Crew = editFlight.Crew,
                FlightNumber = editFlight.FlightNumber,
                StartingAirportName = editFlight.StartingAirportName,
                DestinationAirportName = editFlight.DestinationAirportName,
                FlightDate = editFlight.FlightDate,
                TakeoffHour = editFlight.TakeoffHour,
                LandingHour = editFlight.LandingHour,
                PlaneType = editFlight.PlaneType,
                TotalSeats = editFlight.TotalSeats,
                RemainingSeats = editFlight.RemainingSeats,
                IsApproved = editFlight.IsApproved,
                IsCompleted = editFlight.IsCompleted,
            }).Result;

            return result;
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            var flights = _mediator.Send(new GetAllFlightsRequest()).Result;
            return flights;
        }

        public IEnumerable<Flight> GetPilotFlights(int Id)
        {
            var flights = _mediator.Send(new GetPilotFlightsRequest()
            {
                Id = Id
            }).Result;

            return flights;
        }

        public bool EditFlightStatus(Flight editFlight)
        {
            var result = _mediator.Send(new EditFlightStatusRequest()
            {
                Id = editFlight.Id,
                DestinationAirportName = editFlight.DestinationAirportName,
                TakeoffHour = editFlight.TakeoffHour,
                LandingHour = editFlight.LandingHour,
                IsCompleted = editFlight.IsCompleted
            }).Result;

            return result;
        }

        public IEnumerable<Flight> SearchFlights(SearchParameters searchParameters)
        {
            var flights = _mediator.Send(new SearchFlightsRequest()
            {
                OriginAirport = searchParameters.OriginAirport,
                DestinationAirport = searchParameters.DestinationAirport,
                DepartureDate = searchParameters.DepartureDate
            }).Result;

            return flights;
        }
    }
}
