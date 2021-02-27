CREATE PROCEDURE [dbo].[GetAllFlights]
AS
BEGIN 
	SELECT
	[Id],
	[CrewID],
	[FlightNumber],
	[StartingAirportName],
	[DestinationAirportName],
	[FlightDate],
	[TakeoffHour],
	[LandingHour],
	[PlaneType],
	[TotalSeats],
	[RemainingSeats],
	[IsApproved],
	[IsCompleted]
	FROM Flights
END