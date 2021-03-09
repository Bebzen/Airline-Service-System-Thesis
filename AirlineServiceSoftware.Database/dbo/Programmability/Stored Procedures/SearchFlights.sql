CREATE PROCEDURE [dbo].[SearchFlights]
	@OriginAirport nvarchar(150),
	@DestinationAirport nvarchar(150),
	@DepartureDate date
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
	WHERE
	[StartingAirportName] = @OriginAirport AND
	[DestinationAirportName] = @DestinationAirport AND
	DATEDIFF(day,@DepartureDate,[FlightDate]) = 0 AND
	[IsApproved] = 1 AND
	[IsCompleted] = 0
END
