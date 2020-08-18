CREATE PROCEDURE [dbo].[spComponent_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], ProductId FROM dbo.Component
END
