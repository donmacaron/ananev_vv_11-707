--create procedure CharsPerUser @name nvarchar(20), @output int out
--as
--	select @output=count(c.character_id) from Characters c
--	join Users u on u.user_id = c.user_id
--	where u.name = @name;

-- Выполнение процедуры --
--declare @chars_users int
--exec CharsPerUser 'BAN_MSTER_9000', @chars_users out
--select @chars_users
-- Выполнили, молодцы --


create procedure ShowCharSpells
as
begin
	declare @table table(
		character nvarchar(20),
		spell nvarchar(70),
		level int
	)
	insert @table select c.name, s.name, s.level from Characters c
	join CharactersSpells cs on c.character_id = cs.character_id
	join Spells s on s.spell_id = cs.spell_id
	select * from @table
end

-- вуц ше1 --
declare @CharSpells table(character nvarchar(20), spell nvarchar(70), level int)
insert @CharSpells exec ShowCharSpells
select * from @CharSpells
-- гтдшьшеув зщцук! --

create procedure ShowRaceTraits
as
begin 
	declare @table table(
		race nvarchar(20),
		spell nvarchar(70)
	)
	insert @table select r.name, t.name  from Races r
	join RacesTraits rt on r.race_id = rt.race_id
	join Traits t on rt.trait_id= t.trait_id
	select * from @table
end

-- выполняем процедуру --
declare @RacesTraits table(race nvarchar(20), trait nvarchar(70))
insert @RacesTraits exec ShowRaceTraits
select * from @RacesTraits
-- выполнили, молодцы --


create procedure ShowClassSpells
as
begin
	declare @table table(
		class nvarchar(20),
		spell nvarchar(20)
	)
	insert @table select c.name, s.name  from Spells s
	join SpellsClasses sp on s.spell_id = sp.spell_id
	join Classes c on sp.class_id = c.class_id
	
	select * from @table
end

-- выполняем процедуру --
declare @ClassSpells table(class nvarchar(20), spell nvarchar(20))
insert @ClassSpells exec ShowClassSpells
select * from @ClassSpells
-- выполнили, молодцы --



create function CharsPerUser (@name nvarchar(20))
returns int
begin
	declare @output int
	select @output=count(c.character_id) from Characters c
	join Users u on u.user_id = c.user_id
	where u.name = @name
	return @output
end;

-- выполняем функцию --
select dbo.CharsPerUser('Doris')
-- выполнили, молодцы --