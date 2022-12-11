USE ProjectManagementSystem;
GO
CREATE PROCEDURE ProcedureDeveloperAdd(
    @FullName NVARCHAR,
    @Email NVARCHAR,
    @Username NVARCHAR,
    @PasswordHash NVARCHAR,
    @PasswordSalt NVARCHAR,
    @Role INT
)
AS
INSERT INTO Developer(FullName, Email, Username, PasswordHash, PasswordSalt, Role)
VALUES (@FullName, @Email, @Username, @PasswordHash, @PasswordSalt, @Role)
GO;

CREATE PROCEDURE ProcedureDeveloperUpdate(
    @Id INT,
    @FullName NVARCHAR,
    @Username NVARCHAR,
    @Role INT
)
AS
UPDATE Developer
SET FullName = @FullName,
    Username = @Username,
    Role     = @Role
WHERE Id = @Id;
GO;

CREATE PROCEDURE ProcedureDeveloperDelete(
    @Id INT
)
AS
DELETE
FROM Developer
WHERE Id = @Id;
GO;