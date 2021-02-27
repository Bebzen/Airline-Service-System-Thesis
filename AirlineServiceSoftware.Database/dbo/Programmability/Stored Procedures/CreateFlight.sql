CREATE PROCEDURE [dbo].[CreateFlight]
@CrewId int,
@FlightNumber nvarchar(6),
@StartingAirportName nvarchar(150),
@DestinationAirportName nvarchar(150),
@FlightDate date,
@TakeoffHour time(7),
@LandingHour time(7),
@PlaneType nvarchar(25),
@TotalSeats int,
@RemainingSeats int,
@IsApproved bit,
@IsCompleted bit
AS
BEGIN
	INSERT INTO Flights
	(
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
	)
	VALUES
	(
	@CrewId,
	@FlightNumber,
	@StartingAirportName,
	@DestinationAirportName,
	@FlightDate,
	@TakeoffHour,
	@LandingHour,
	@PlaneType,
	@TotalSeats,
	@RemainingSeats,
	@IsApproved,
	@IsCompleted
	)
END