CREATE PROCEDURE [dbo].[GetTakenSeats]
	@Id int
AS
BEGIN
	SELECT 
	[SeatNumber]
FROM Reservations
WHERE [FlightID] = @Id
END
