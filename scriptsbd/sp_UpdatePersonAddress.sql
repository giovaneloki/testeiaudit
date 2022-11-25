CREATE PROC sp_UpdatePersonAddress
(
	@PersonId INT, 
	@Street VARCHAR(150),
	@Neighborhood VARCHAR(50), 
	@City VARCHAR(100), 
	@PostalCode VARCHAR(20), 
	@Country VARCHAR(50),
	@Id INT
)
AS
BEGIN
	UPDATE PersonAddress
	SET
		PersonId = @PersonId,
		Street = @Street,
		Neighborhood = @Neighborhood,
		City = @City,
		PostalCode = @PostalCode,
		Country = @Country		
	WHERE Id = @Id

	SELECT SCOPE_IDENTITY() as Id
END