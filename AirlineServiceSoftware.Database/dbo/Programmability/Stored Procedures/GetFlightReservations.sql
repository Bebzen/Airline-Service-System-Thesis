CREATE PROCEDURE [dbo].[GetFlightReservations]
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
WHERE [FlightId] = @Id
END