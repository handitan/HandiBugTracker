CREATE PROCEDURE [dbo].[spProductVersion_GetByProduct]
	@ProductId int = 0
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id,[Name],ProductId
	FROM dbo.ProductVersion
	WHERE ProductId = @ProductId
END