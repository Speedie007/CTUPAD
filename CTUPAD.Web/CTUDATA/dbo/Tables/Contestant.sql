CREATE TABLE [dbo].[Contestant] (
    [ContestantID]        INT           IDENTITY (1, 1) NOT NULL,
    [ContestantFirstName] VARCHAR (100) NULL,
    [ContestantLastName]  VARCHAR (100) NULL,
    CONSTRAINT [PK_Contestant] PRIMARY KEY CLUSTERED ([ContestantID] ASC)
);

