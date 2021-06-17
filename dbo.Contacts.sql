CREATE TABLE [dbo].[Contacts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [PhoneNumber] NVARCHAR(10) NULL, 
    [Active] BIT NOT NULL
)
