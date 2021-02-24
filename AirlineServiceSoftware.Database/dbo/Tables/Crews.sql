CREATE TABLE [dbo].[Crews]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [CrewName] NVARCHAR(50) NOT NULL, 
    [CaptainID] INT NOT NULL, 
    [FirstOfficerID] INT NOT NULL, 
    [SecondOfficerID] INT NOT NULL, 
    CONSTRAINT [FK_CaptainID_UserID] FOREIGN KEY ([CaptainID]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_FirstOfficerID_UserID]  FOREIGN KEY ([FirstOfficerID]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_SecondOfficerID_UserID] FOREIGN KEY ([SecondOfficerID]) REFERENCES [Users]([Id])
    
)
