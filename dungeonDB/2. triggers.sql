--	“риггеры, заполн€ющие таблицы св€зи тестовыми данными  --
create trigger RacesTraits_fill on Races after insert 
as 
	insert into RacesTraits values(1, 1), (1, 2),(1, 3),(1, 4),
		(1, 5),(1, 6),(1, 7),(1, 8);
	alter table Races disable trigger RacesTraits_fill;


create trigger CharSpells_fill on Characters after insert
as 
	insert into CharactersSpells values (1,1), (1,3), (1, 4),
		(5, 1), (5, 2),(5, 4),(5, 4),
		(7, 1),(7, 3),(7, 4),(7, 5);
	alter table Characters disable trigger CharSpells_fill;


create trigger SpellsClasses_fill on Classes after insert
as 
	insert into SpellsClasses values (1, 1), (1, 2), (1, 3), (1, 4), (1, 5);
	alter table Classes disable trigger SpellsClasses_fill;

------------------------------------------------------------------------------
create trigger Delete_Chars --сделать instead of delete
on Characters
instead of delete
as
begin
	delete from CharactersSpells
	where character_id in (select deleted.character_id from deleted)
	
	delete from Characters
	where character_id in (select character_id from deleted)
end;

