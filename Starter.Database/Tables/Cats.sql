Create table [dbo].[Cats]
(
	[Id] uniqueidentifier not null primary key default newid(), 
    [Name] nchar(100) not null, 
    [AbilityId] int not null
)
