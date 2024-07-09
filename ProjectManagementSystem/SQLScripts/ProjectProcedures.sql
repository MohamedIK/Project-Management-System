use ProjectManagementSystem;
GO
CREATE PROCEDURE ProcedureProjectAdd(
    @Name NVARCHAR(MAX),
    @Description NVARCHAR(MAX),
    @StartDate Date,
    @EndDate Date,
    @CreatedOn DATETIME,
    @UpdatedOn DATETIME,
    @ManagerId INT
)
AS
INSERT INTO Project(Name, Description, StartDate, EndDate, CreatedOn, UpdatedOn, ManagerId)
VALUES (@Name, @Description, @StartDate, @EndDate, @CreatedOn, @UpdatedOn, @ManagerId)
GO

CREATE PROCEDURE ProcedureProjectUpdate(
    @Id INT,
    @Name NVARCHAR(MAX),
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
GO

CREATE PROCEDURE ProcedureProjectDelete(
    @Id INT
)
AS
DELETE
FROM Project
WHERE Id = @Id;
GO