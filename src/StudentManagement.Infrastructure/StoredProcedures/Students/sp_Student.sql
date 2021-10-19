--UPDATE STUDENT--
CREATE PROC sp_UpdateStudent
			@id uniqueidentifier,
			@name nvarchar(500),
			@year date,
			@address nvarchar(500),
			@email nvarchar(500)
AS
BEGIN
	UPDATE Student set Name = @name,
					   Year = @year,
					   Address = @address,
					   Email = @email
	WHERE Id = @id
END
GO

--DELETE STUDENT--
CREATE PROC sp_DeleteStudent
			@id uniqueidentifier
AS
BEGIN
	DELETE Student
	WHERE Id = @id
END
GO
