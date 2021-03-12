CREATE TABLE [dbo].[Reservations]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FlightID] INT NOT NULL, 
    [UserID] INT NOT NULL, 
    [Price] DECIMAL(7, 2) NOT NULL, 
    [SeatNumber] NVARCHAR(4) NOT NULL, 
    [TransactionID] NVARCHAR(100) NOT NULL, 
    [IsValid] BIT NOT NULL, 
    CONSTRAINT [FK_ReservationFlightID_ToFlightID] FOREIGN KEY ([FlightID]) REFERENCES [Flights]([Id]), 
    CONSTRAINT [FK_ReservationsUserID_ToUserID] FOREIGN KEY ([UserID]) REFERENCES [Users]([Id])
)
