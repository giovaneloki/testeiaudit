CREATE PROC sp_GetAllPersons
AS
BEGIN
	SELECT 
		p.*,
		(
			SELECT 
				* 
			FROM PersonAddress pa 
			WHERE pa.PersonId = p.Id 
			FOR JSON PATH
		) _personAddressesJson
	FROM Person p
END
