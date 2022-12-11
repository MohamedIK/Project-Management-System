CREATE DATABASE ProjectManagementSystem;

USE ProjectManagementSystem;

CREATE TABLE Project
(
    [Id]          INT PRIMARY KEY IDENTITY (1,1),
    [Name]        NVARCHAR,
    [Description] NVARCHAR(MAX),
    [StartDate]   DATE,
    [EndDate]     DATE,
    [CreatedOn]   DATETIME NOT NULL,
    [UpdatedOn]   DATETIME NOT NULL,
);

CREATE TABLE Task
(
    [Id]          INT PRIMARY KEY IDENTITY (1,1),
    [Name]        NVARCHAR UNIQUE NOT NULL,
    [Description] NVARCHAR(MAX),
    [State]       NVARCHAR        NOT NULL,
    [Priority]    INT             NOT NULL,
);

CREATE TABLE Developer
(
    [Id]           INT PRIMARY KEY IDENTITY (1,1),
    [Username]     NVARCHAR UNIQUE NOT NULL,
    [FullName]     NVARCHAR        NOT NULL,
    [Email]        NVARCHAR UNIQUE NOT NULL,
    [PasswordHash] NVARCHAR        NOT NULL,
    [PasswordSalt] NVARCHAR        NOT NULL,
    [Role]         INT             NOT NULL,
);

CREATE TABLE Bug
(
    [Id]          INT PRIMARY KEY IDENTITY (1,1),
    [Title]       NVARCHAR NOT NULL,
    [Description] NVARCHAR(MAX),
    [Status]      NVARCHAR NOT NULL,
    [CreatedOn]   DATETIME NOT NULL,
    [UpdatedOn]   DATETIME NOT NULL,
    [Priority]    INT      NOT NULL,
);

CREATE TABLE Comment
(
    [Id]        INT PRIMARY KEY IDENTITY (1,1),
    [CreatedOn] DATETIME,
    [Content]   NVARCHAR(MAX) NOT NULL,
);

-- Project Table Relationships
ALTER TABLE Project
    ADD ManagerId INT; -- Add new column.
ALTER TABLE Project
    ADD FOREIGN KEY (ManagerId) REFERENCES Developer (Id); -- Add the relationship

ALTER TABLE Project
    ADD DeveloperId INT;
ALTER TABLE Project
    ADD FOREIGN KEY (DeveloperId) REFERENCES Developer (Id);

ALTER TABLE Project
    ADD BugId INT;
ALTER TABLE Project
    ADD FOREIGN KEY (BugId) REFERENCES Bug (Id);

ALTER TABLE Project
    ADD TaskId INT;
ALTER TABLE Project
    ADD FOREIGN KEY (TaskId) REFERENCES Task (Id);

-- Task Table Relationships
ALTER TABLE Task
    ADD DeveloperId INT;
ALTER TABLE Task
    ADD FOREIGN KEY (DeveloperId) REFERENCES Developer (Id);

ALTER TABLE Task
    ADD ProjectId INT;
ALTER TABLE Task
    ADD FOREIGN KEY (ProjectId) REFERENCES Project (Id);

-- Developer Table Relationships
ALTER TABLE Developer
    ADD ProjectId INT;
ALTER TABLE Developer
    ADD FOREIGN KEY (ProjectId) REFERENCES Project (Id);

-- Bug Table Relationships
ALTER TABLE Bug
    ADD DeveloperId INT;
ALTER TABLE Bug
    ADD FOREIGN KEY (DeveloperId) REFERENCES Developer (Id);

ALTER TABLE Bug
    ADD ProjectId INT;
ALTER TABLE Bug
    ADD FOREIGN KEY (ProjectId) REFERENCES Project (Id);

-- Comment Table Relationships
ALTER TABLE Comment
    ADD AuthorId INT;
ALTER TABLE Comment
    ADD FOREIGN KEY (AuthorId) REFERENCES Developer (Id);

ALTER TABLE Comment
    ADD BugId INT;
ALTER TABLE Comment
    ADD FOREIGN KEY (BugId) REFERENCES Bug (Id);