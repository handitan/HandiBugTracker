CREATE TABLE [dbo].[BugStatusSubState]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY ,
	[Name] NVARCHAR(100) NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [LastModifiedDate] DATETIME2 NOT NULL DEFAULT getutcdate() 
)
