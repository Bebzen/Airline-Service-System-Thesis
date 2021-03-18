CREATE PROCEDURE [dbo].[EditReservation]
	@Id int,
	@isValid bit
AS
BEGIN
	UPDATE Reservations
	SET
	[isValid] = @IsValid
	WHERE [Id] = @Id
END
