CREATE TABLE [Company].[Plant] (
    [PlantId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (200) NOT NULL,
    [Address] NVARCHAR (200) NULL,
    [City]    NVARCHAR (200) NULL,
    [Phone]   NVARCHAR (20)  NULL,
    [Email]   NVARCHAR (200) NULL,
    CONSTRAINT [PK_Plant] PRIMARY KEY CLUSTERED ([PlantId] ASC)
);

