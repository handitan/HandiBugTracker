CREATE PROCEDURE [dbo].[spComponent_GetByProduct]
	@ProductId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], ProductId
	FROM dbo.Component
	WHERE ProductId = @ProductId
END