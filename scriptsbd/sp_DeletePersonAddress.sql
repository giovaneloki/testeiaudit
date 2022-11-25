CREATE PROC sp_DeletePersonAddress
(
	@Id INT
)
AS
BEGIN
	DELETE FROM PersonAddress
	WHERE Id = @Id

	SELECT @Id Id
END