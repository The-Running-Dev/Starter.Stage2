create procedure dbo.AddCat
	@name      nvarchar(100),
	@abilityId int
as
begin

insert	into Cats
(
		Name,
		AbilityId
)
values
(
	   @name,
	   @abilityId
)

end