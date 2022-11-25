USE [dbAPI]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 25/11/2022 17:59:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Document] [varchar](20) NULL,
	[Phone] [varchar](20) NULL,
	[DateBirthday] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonAddress]    Script Date: 25/11/2022 17:59:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonAddress](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NULL,
	[Street] [varchar](150) NULL,
	[Neighborhood] [varchar](50) NULL,
	[City] [varchar](100) NULL,
	[PostalCode] [varchar](20) NULL,
	[Country] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddPerson]    Script Date: 25/11/2022 17:59:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_AddPerson]
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
GO
/****** Object:  StoredProcedure [dbo].[sp_AddPersonAddress]    Script Date: 25/11/2022 17:59:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_AddPersonAddress]
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
GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePerson]    Script Date: 25/11/2022 17:59:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DeletePerson]
(
	@Id INT
)
AS
BEGIN
	DELETE FROM Person
	WHERE Id = @Id

	SELECT @Id Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePersonAddress]    Script Date: 25/11/2022 17:59:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DeletePersonAddress]
(
	@Id INT
)
AS
BEGIN
	DELETE FROM PersonAddress
	WHERE Id = @Id

	SELECT @Id Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllPersons]    Script Date: 25/11/2022 17:59:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_GetAllPersons]
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
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePerson]    Script Date: 25/11/2022 17:59:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_UpdatePerson]
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
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePersonAddress]    Script Date: 25/11/2022 17:59:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_UpdatePersonAddress]
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

	SELECT @Id Id
END
GO
