CREATE PROCEDURE [dbo].[spProductVersion_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id,[Name],ProductId FROM dbo.ProductVersion
END