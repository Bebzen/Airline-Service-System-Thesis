CREATE PROCEDURE [dbo].[EditReservation]
	@Id int,
	@isValid bit
AS
BEGIN
	UPDATE Reservations
	SET
	[IsValid] = @IsValid
	WHERE [Id] = @Id
END
