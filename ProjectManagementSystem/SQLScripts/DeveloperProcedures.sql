USE ProjectManagementSystem;
GO
CREATE PROCEDURE ProcedureDeveloperAdd(
    @FullName NVARCHAR(MAX),
    @Email NVARCHAR(MAX),
    @Username NVARCHAR(MAX),
    @PasswordHash NVARCHAR(MAX),
    @PasswordSalt NVARCHAR(MAX),
    @Role INT
)
AS
INSERT INTO Developer(FullName, Email, Username, PasswordHash, PasswordSalt, Role)
VALUES (@FullName, @Email, @Username, @PasswordHash, @PasswordSalt, @Role)
GO

CREATE PROCEDURE ProcedureDeveloperUpdate(
    @Id INT,
    @FullName NVARCHAR(MAX),
    @Username NVARCHAR(MAX),
    @Role INT
)
AS
UPDATE Developer
SET FullName = @FullName,
    Username = @Username,
    Role     = @Role
WHERE Id = @Id;
GO

CREATE PROCEDURE ProcedureDeveloperDelete(
    @Id INT
)
AS
DELETE
FROM Developer
WHERE Id = @Id;
GO