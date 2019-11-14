create procedure [dbo].[GetCatById]
	@id UniqueIdentifier
as
	select	c.Id, c.Name, c.AbilityId, a.Name
	from	Cats as c
			inner join
			Abilities as a
			on c.AbilityId = a.Id
	where	c.Id = @id
return 0
