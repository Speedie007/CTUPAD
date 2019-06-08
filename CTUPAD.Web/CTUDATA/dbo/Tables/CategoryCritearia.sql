CREATE TABLE [dbo].[CategoryCritearia] (
    [CategoryCriteariaID]   INT           IDENTITY (1, 1) NOT NULL,
    [CategoryID]            INT           NOT NULL,
    [CategoryCriteariaName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_CategoryCritearia] PRIMARY KEY CLUSTERED ([CategoryCriteariaID] ASC),
    CONSTRAINT [FK_CategoryItems_Categories] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID])
);


GO
CREATE NONCLUSTERED INDEX [IX_CategoryCritearia_CategoryID]
    ON [dbo].[CategoryCritearia]([CategoryID] ASC);

