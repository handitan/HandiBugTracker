CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id,FirstName,LastName,EmailAddress FROM dbo.[User]
END
