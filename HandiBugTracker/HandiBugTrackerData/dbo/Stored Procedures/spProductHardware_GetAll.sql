CREATE PROCEDURE [dbo].[spProductHardware_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Name FROM dbo.ProductHardware
END