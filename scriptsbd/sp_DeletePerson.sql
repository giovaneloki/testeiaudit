CREATE PROC sp_DeletePerson
(
	@Id INT
)
AS
BEGIN
	DELETE FROM Person
	WHERE Id = @Id

	SELECT @Id Id
END