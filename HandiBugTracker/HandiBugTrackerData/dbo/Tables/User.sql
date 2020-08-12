CREATE TABLE [dbo].[User]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [FirstName] NCHAR(10) NOT NULL, 
    [LastName] NCHAR(10) NOT NULL, 
    [EmailAddress] NCHAR(10) NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [LastModifiedDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
