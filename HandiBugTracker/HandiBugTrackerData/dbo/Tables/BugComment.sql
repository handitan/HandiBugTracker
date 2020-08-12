CREATE TABLE [dbo].[BugComment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] NVARCHAR(MAX) NOT NULL , 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [LastModifiedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [ComponentBugId] INT NOT NULL, 
    [ReporterId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [FK_BugComment_ToComponentBug] FOREIGN KEY ([ComponentBugId]) REFERENCES [ComponentBug]([Id]), 
    CONSTRAINT [FK_BugComment_ToUser] FOREIGN KEY ([ReporterId]) REFERENCES [User]([Id])
)
