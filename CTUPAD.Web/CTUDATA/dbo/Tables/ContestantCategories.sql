CREATE TABLE [dbo].[ContestantCategories] (
    [ContestCategoryID] INT IDENTITY (1, 1) NOT NULL,
    [ContestantID]      INT NOT NULL,
    [CategoryID]        INT NOT NULL,
    CONSTRAINT [PK_ContestantCategories] PRIMARY KEY CLUSTERED ([ContestCategoryID] ASC),
    CONSTRAINT [FK_ContestantCategories_Categories] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID]),
    CONSTRAINT [FK_ContestantCategories_Contestant] FOREIGN KEY ([ContestantID]) REFERENCES [dbo].[Contestant] ([ContestantID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ContestantCategories_ContestantID]
    ON [dbo].[ContestantCategories]([ContestantID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ContestantCategories_CategoryID]
    ON [dbo].[ContestantCategories]([CategoryID] ASC);

