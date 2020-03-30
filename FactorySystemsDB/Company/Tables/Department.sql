CREATE TABLE [Company].[Department] (
    [DepartmentId] INT             IDENTITY (1, 1) NOT NULL,
    [PlantId]      INT             NOT NULL,
    [Name]         NVARCHAR (200)  NOT NULL,
    [Description]  NVARCHAR (4000) NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([DepartmentId] ASC),
    CONSTRAINT [FK_Department_Plant] FOREIGN KEY ([PlantId]) REFERENCES [Company].[Plant] ([PlantId])
);

