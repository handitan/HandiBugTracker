CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id,Name FROM dbo.Product
END

