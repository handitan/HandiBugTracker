CREATE TABLE [dbo].[Component]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [LastModifiedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [ProductId] INT NOT NULL, 
    CONSTRAINT [FK_Component_ToProduct] FOREIGN KEY (ProductId) REFERENCES [Product]([Id])
	
)
