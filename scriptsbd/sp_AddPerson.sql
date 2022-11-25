CREATE PROC sp_AddPerson
(
	@Name varchar(50),
	@Document varchar(20),
	@Phone varchar(20),
	@DateBirthday datetime
)
AS
BEGIN
	INSERT INTO Person (Name, Document, Phone, DateBirthday)
	VALUES (@Name, @Document, @Phone, @DateBirthday)

	SELECT SCOPE_IDENTITY() as Id
END