CREATE PROCEDURE [dbo].[CreateFirstAdmin]
AS
INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[Role]
           ,[FirstName]
           ,[LastName]
           ,[PhoneNumber]
           ,[Email]
           ,[PESEL]
           ,[DocumentID])
     VALUES
           ('admin',
           '$2a$11$YwLY0OvnSYelGdZZqpqkReFxeFU.tC3EwcPSxRCvsaJNIw9i8u/Te',
           'Admin',
           'Admin',
           'Admin',
           0,
           'admin@gmail.com',
           '123',
           '123')
GO
