CREATE TABLE [dbo].[Flights]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [CrewID] INT NOT NULL, 
    [FlightNumber] NVARCHAR(6) NOT NULL, 
    [StartingAirportName] NVARCHAR(150) NOT NULL, 
    [DestinationAirportName] NVARCHAR(150) NOT NULL, 
    [FlightDate] DATE NOT NULL, 
    [TakeoffHour] VARCHAR(8) NOT NULL, 
    [LandingHour] VARCHAR(8) NOT NULL, 
    [PlaneType] NVARCHAR(25) NOT NULL, 
    [TotalSeats] INT NOT NULL, 
    [IsApproved] BIT NOT NULL, 
    [IsCompleted] BIT NOT NULL, 
    CONSTRAINT [FK_CrewID_CrewID] FOREIGN KEY ([CrewID]) REFERENCES [Crews]([Id])
)
