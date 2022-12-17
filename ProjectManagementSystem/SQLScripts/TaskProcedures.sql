USE ProjectManagementSystem;
GO
CREATE PROCEDURE ProcedureTaskAdd(
    @Title NVARCHAR(MAX),
    @Description NVARCHAR(MAX),
    @State INT,
    @Priority INT,
    @CreatedOn DateTime,
    @UpdatedOn DateTime,
    @ProjectId INT
)
AS
INSERT INTO Task(Title, Description, State, Priority, CreatedOn, UpdatedOn, ProjectId)
VALUES (@Title, @Description, @State, @Priority, @CreatedOn, @UpdatedOn, @ProjectId)
GO;

CREATE PROCEDURE ProcedureTaskUpdate(
    @Id INT,
    @Title NVARCHAR(MAX),
    @Description NVARCHAR(MAX),
    @State INT,
    @Priority INT,
    @UpdatedOn DATETIME
)
AS
UPDATE Task
SET Title       = @Title,
    Description = @Description,
    State       = @State,
    Priority    = @Priority,
    UpdatedOn   = @UpdatedOn
WHERE Id = @Id;
GO;

CREATE PROCEDURE ProcedureTaskDelete(
    @Id INT
)
AS
DELETE
FROM Task
WHERE Id = @Id;
GO;