CREATE PROC sp_AddPersonAddress
(
	@PersonId INT, 
	@Street VARCHAR(150),
	@Neighborhood VARCHAR(50), 
	@City VARCHAR(100), 
	@PostalCode VARCHAR(20), 
	@Country VARCHAR(50)
)
AS
BEGIN
	INSERT INTO PersonAddress(PersonId, Street, Neighborhood, City, PostalCode, Country)
	VALUES (@PersonId, @Street, @Neighborhood, @City, @PostalCode, @Country)

	SELECT SCOPE_IDENTITY() as Id
END