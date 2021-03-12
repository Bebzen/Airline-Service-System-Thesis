CREATE PROCEDURE [dbo].[GetUserReservations]
	@Id int
AS
BEGIN
	SELECT 
	[Id],
	[FlightID],
	[UserID],
	[Price],
	[SeatNumber],
	[TransactionID],
	[IsValid]
FROM Reservations
WHERE [UserID] = @Id
END