CREATE PROCEDURE [dbo].[EditFlight]
	@Id int,
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
	UPDATE Flights
	SET
	[CrewID] = @CrewId,
	[FlightNumber] = @FlightNumber,
	[StartingAirportName] = @StartingAirportName,
	[DestinationAirportName] = @DestinationAirportName,
	[FlightDate] = @FlightDate,
	[TakeoffHour] = @TakeoffHour,
	[LandingHour] = @LandingHour,
	[PlaneType] = @PlaneType,
	[TotalSeats] = @TotalSeats,
	[RemainingSeats] = @RemainingSeats,
	[IsApproved] = @IsApproved,
	[IsCompleted] = @IsCompleted
	WHERE [Id] = @Id
END