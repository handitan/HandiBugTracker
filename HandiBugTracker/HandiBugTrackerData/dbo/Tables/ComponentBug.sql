﻿CREATE TABLE [dbo].[ComponentBug]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1000,1),
	[Name] NVARCHAR(256) NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [LastModifiedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [ReporterId] NVARCHAR(128) NOT NULL,
    [AssigneeId] NVARCHAR(128) NOT NULL,
    [QAContactId] NVARCHAR(128) NOT NULL,
    [ProductId] int NOT NULL,
    [ProductVersionId] int NOT NULL,
    [BugStatusId] int NOT NULL,
    [BugStatusSubStateId] int NOT NULL,
    [BugPriorityId] int NOT NULL,
    [BugSeverityId] int NOT NULL,
    [BugTypeId] int NOT NULL,
    [ProductHardwareId] int NOT NULL,
    [ProductOSId] int NOT NULL, 
    [ComponentId] INT NOT NULL, 
    CONSTRAINT [FK_ComponentBug_ToProductOS] FOREIGN KEY ([ProductOSId]) REFERENCES [ProductOS]([Id]), 
    CONSTRAINT [FK_ComponentBug_ToProductHardware] FOREIGN KEY ([ProductHardwareId]) REFERENCES [ProductHardware]([Id]), 
    CONSTRAINT [FK_ComponentBug_ToBugType] FOREIGN KEY ([BugTypeId]) REFERENCES [BugType]([Id]), 
    CONSTRAINT [FK_ComponentBug_ToBugSeverity] FOREIGN KEY ([BugSeverityId]) REFERENCES [BugSeverity]([Id]), 
    CONSTRAINT [FK_ComponentBug_ToBugPriority] FOREIGN KEY ([BugPriorityId]) REFERENCES [BugPriority]([Id]), 
    CONSTRAINT [FK_ComponentBug_ToBugStatusSubState] FOREIGN KEY ([BugStatusSubStateId]) REFERENCES [BugStatusSubState]([Id]), 
    CONSTRAINT [FK_ComponentBug_ToBugStatus] FOREIGN KEY ([BugStatusId]) REFERENCES [BugStatus]([Id]), 
    CONSTRAINT [FK_ComponentBug_ToProductVersion] FOREIGN KEY ([ProductVersionId]) REFERENCES [ProductVersion]([Id]), 
    CONSTRAINT [FK_ComponentBug_ToProduct] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_ComponentBug_QAContact_ToUser] FOREIGN KEY ([QAContactId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_ComponentBug_Assignee_ToUser] FOREIGN KEY ([AssigneeId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_ComponentBug_Reporter_ToUser] FOREIGN KEY ([ReporterId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_ComponentBug_ToComponent] FOREIGN KEY (ComponentId) REFERENCES [Component]([Id]) 
)
