CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Username] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(250) NOT NULL, 
    [Role] VARCHAR(15) NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [PhoneNumber] INT NULL, 
    [Email] VARCHAR(50) NULL, 
    [PESEL] CHAR(11) NULL, 
    [DocumentID] CHAR(9) NULL 
)
