USE ProjectManagementSystem;

CREATE PROCEDURE ProcedureDeveloperAdd
(
    @Name NVARCHAR,
    @Email NVARCHAR,
    @Username NVARCHAR,
    @PasswordHash NVARCHAR,
    @PasswordSalt NVARCHAR,
    @Role INT
)
AS
    INSERT INTO Developer(Name, Email, Username, PasswordHash, PasswordSalt, Role)
    VALUES(@Name, @Email, @Username, @PasswordHash, @PasswordSalt, @Role)
GO;

CREATE PROCEDURE ProcedureDeveloperUpdate
(
    @Id INT,
    @Name NVARCHAR,
    @Username NVARCHAR,
    @Role INT
)
AS
    UPDATE Developer
    SET Name = @Name, Username = @Username, Role = @Role
    WHERE Id = @Id;
GO;

CREATE PROCEDURE ProcedureDeveloperDelete
(
    @Id INT
)
AS
    DELETE  Developer
    WHERE Id = @Id;
GO;