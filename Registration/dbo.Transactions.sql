CREATE TABLE [dbo].[Transactions] (
    [TransactionID] INT           IDENTITY (1, 1) NOT NULL,
    [Email]         NVARCHAR (50) NOT NULL,
    [OfferID]       INT           NOT NULL,
    [Costs] INT NOT NULL, 
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    CONSTRAINT [FK_Transactions_ToTable] FOREIGN KEY ([Email]) REFERENCES [dbo].[Customer] ([Email]),
    CONSTRAINT [FK_Transactions_ToTable_1] FOREIGN KEY ([OfferID]) REFERENCES [dbo].[Offers] ([OfferID])
);

