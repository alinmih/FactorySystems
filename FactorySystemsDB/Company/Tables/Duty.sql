CREATE TABLE [Company].[Duty] (
    [DutyId]   INT            IDENTITY (1, 1) NOT NULL,
    [DutyName] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Duty] PRIMARY KEY CLUSTERED ([DutyId] ASC)
);

