CREATE PROCEDURE [dbo].[GetFlight]
	@Id int
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
	WHERE [Id] = @Id
END