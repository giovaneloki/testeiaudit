CREATE PROC sp_UpdatePerson
(
	@Name varchar(50),
	@Document varchar(20),
	@Phone varchar(20),
	@DateBirthday datetime,
	@Id INT
)
AS
BEGIN
	UPDATE Person
	SET
		Name = @Name,
		Document = @Document,
		Phone = @Phone,
		DateBirthday = @DateBirthday
	WHERE Id = @Id

	SELECT @Id Id
END