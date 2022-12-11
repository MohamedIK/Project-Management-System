USE ProjectManagementSystem;

CREATE PROCEDURE ProcedureBugAdd
(
    @Title NVARCHAR,
    @Description NVARCHAR,
    @Status INT,
    @Priority INT,
    @CreatedOn DateTime,
    @UpdatedOn DateTime,
    @ProjectId INT
)
AS
    INSERT INTO Bug(Title, Description, Status, Priority, CreatedOn, UpdatedOn, ProjectId)
    VALUES(@Title, @Description, @Status, @Priority, @CreatedOn, @UpdatedOn, @ProjectId)
GO;

CREATE PROCEDURE ProcedureBugUpdate
(
    @Id INT,
    @Title NVARCHAR,
    @Description NVARCHAR,
    @Status INT,
    @Priority INT,
    @UpdatedOn DATETIME
)
AS
    UPDATE Bug
    SET Id = @Id, Title = @Title, Description = @Description, Status = @Status, Priority = @Priority, UpdatedOn = @UpdatedOn
    WHERE Id = @Id;
GO;

CREATE PROCEDURE ProcedureBugDelete
(
    @Id INT
)
AS
    DELETE FROM Bug
    WHERE Id = @Id;
GO;