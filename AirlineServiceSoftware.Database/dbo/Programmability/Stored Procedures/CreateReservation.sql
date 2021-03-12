CREATE PROCEDURE [dbo].[CreateReservation]
	@FlightId int,
	@UserId int,
	@Price decimal(7,2),
	@SeatNumber nvarchar(4),
	@TransactionId nvarchar(100),
	@IsValid bit
AS
BEGIN
	INSERT INTO Reservations
	(
	[FlightID],
	[UserID],
	[Price],
	[SeatNumber],
	[TransactionID],
	[IsValid]
	)
	VALUES
	(
	@FlightId,
	@UserId,
	@Price,
	@SeatNumber,
	@TransactionId,
	@IsValid
	)
END