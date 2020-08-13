CREATE PROCEDURE [dbo].[spComponent_GetByProduct]
	@ProductId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name]
	FROM dbo.Component
	WHERE ProductId = @ProductId
END