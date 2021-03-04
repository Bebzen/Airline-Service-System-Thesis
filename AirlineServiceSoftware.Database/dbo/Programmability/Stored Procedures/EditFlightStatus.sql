CREATE PROCEDURE [dbo].[EditFlightStatus]
	@Id int,
	@DestinationAirportName nvarchar(150),
	@TakeoffHour time(7),
	@LandingHour time(7),
	@IsCompleted bit
AS
BEGIN
	UPDATE Flights
	SET
	[DestinationAirportName] = @DestinationAirportName,
	[TakeoffHour] = @TakeoffHour,
	[LandingHour] = @LandingHour,
	[IsCompleted] = @IsCompleted
	WHERE [Id] = @Id
END
