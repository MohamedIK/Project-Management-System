USE ProjectManagementSystem;
GO
CREATE PROCEDURE ProcedureCommentAdd(
    @Content NVARCHAR(MAX),
    @CreatedOn DateTime,
    @BugId INT,
    @AuthorId INT
)
AS
INSERT INTO Comment(Content, CreatedOn, BugId, AuthorId)
VALUES (@Content, @CreatedOn, @BugId, @AuthorId)
GO

CREATE PROCEDURE ProcedureCommentDelete(
    @Id INT
)
AS
DELETE
FROM Comment
WHERE Id = @Id;
GO