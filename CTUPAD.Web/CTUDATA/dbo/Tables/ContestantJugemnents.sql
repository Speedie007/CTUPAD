CREATE TABLE [dbo].[ContestantJugemnents] (
    [ContestantJugemnentID] INT            IDENTITY (1, 1) NOT NULL,
    [ContestantID]          INT            NOT NULL,
    [JugeID]                NVARCHAR (450) NOT NULL,
    [CategoryID]            INT            NOT NULL,
    [CategoryCriteariaID]   INT            NOT NULL,
    [Rating]                FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_ContestantJugemnents] PRIMARY KEY CLUSTERED ([ContestantJugemnentID] ASC),
    CONSTRAINT [FK_ContestantJugemnents_AspNetUsers] FOREIGN KEY ([JugeID]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_ContestantJugemnents_Categories] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID]),
    CONSTRAINT [FK_ContestantJugemnents_CategoryCritearia] FOREIGN KEY ([CategoryCriteariaID]) REFERENCES [dbo].[CategoryCritearia] ([CategoryCriteariaID]),
    CONSTRAINT [FK_ContestantJugemnents_Contestant] FOREIGN KEY ([ContestantID]) REFERENCES [dbo].[Contestant] ([ContestantID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ContestantJugemnents_JugeID]
    ON [dbo].[ContestantJugemnents]([JugeID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ContestantJugemnents_ContestantID]
    ON [dbo].[ContestantJugemnents]([ContestantID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ContestantJugemnents_CategoryID]
    ON [dbo].[ContestantJugemnents]([CategoryID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ContestantJugemnents_CategoryCriteariaID]
    ON [dbo].[ContestantJugemnents]([CategoryCriteariaID] ASC);

