use ProjectManagementSystem;
GO
CREATE PROCEDURE ProcedureProjectAdd(
    @Name nvarchar,
    @Description nvarchar,
    @StartDate Date,
    @EndDate Date,
    @CreatedOn DATETIME,
    @UpdatedOn DATETIME
)
AS
INSERT INTO Project(Name, Description, StartDate, EndDate, CreatedOn, UpdatedOn)
VALUES (@Name, @Description, @StartDate, @EndDate, @CreatedOn, @UpdatedOn)
GO;

CREATE PROCEDURE ProcedureProjectUpdate(
    @Id INT,
    @Name NVARCHAR,
    @Description NVARCHAR(MAX),
    @StartDate Date,
    @EndDate Date,
    @ManagerId INT,
    @UpdatedOn DATETIME
)
AS
UPDATE Project
SET Name        = @Name,
    Description = @Description,
    StartDate   = @StartDate,
    EndDate     = @EndDate,
    ManagerId   = @ManagerId,
    UpdatedOn   = @UpdatedOn
WHERE Id = @Id;
GO;

CREATE PROCEDURE ProcedureProjectDelete(
    @Id INT
)
AS
DELETE
FROM Project
WHERE Id = @Id;
GO;