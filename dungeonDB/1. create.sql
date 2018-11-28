create table Users(
	user_id int identity(1,1),
	name varchar(20) not null unique,
	password varchar(32),
	mail varchar(32) unique,
	bio nvarchar(max),
	constraint pk_users primary key(user_id));


create table Spells(
	spell_id int not null,
	name nvarchar(70) not null,
	distance nvarchar(max),
	duration nvarchar(max),
	spellcasting_time nvarchar(max),
	level int,
	school nvarchar(max),
	description nvarchar(max),
	constraint pk_spells primary key(spell_id));


create table Races(
	race_id int not null,
	name nvarchar(70) not null,
	stats nvarchar(max),
	aligment nvarchar(max),
	speed varchar,
	size nvarchar(max),
	languages nvarchar(max),
	description nvarchar(max),
	constraint pk_races primary key(race_id));


create table Classes(
	class_id int not null,
	name nvarchar(70) not null,
	hitdice nvarchar(10),
	proficiences nvarchar(max),
	spellcasting varchar(40),
	description nvarchar(max),
	constraint pk_class primary key(class_id));


create table SpellsClasses(
	class_id int not null,
	spell_id int not null,
	constraint fk_spell_id foreign key(spell_id)
	references Spells(spell_id)
		on delete cascade on update cascade,
	constraint fk_class foreign key(class_id)
	references Classes(class_id)
		on delete cascade on update cascade);


create table Traits(
	trait_id int not null,
	name nvarchar(70) not null,
	description nvarchar(max) not null,
	constraint pk_traits primary key(trait_id))


create table RacesTraits(
	race_id int not null,
	trait_id int not null,
	constraint fk_race foreign key(race_id)
	references Races(race_id)
		on delete cascade on update cascade,
	constraint fk_traits foreign key(trait_id)
	references Traits(trait_id)
		on delete cascade on update cascade);


create table Characters(
	character_id int not null,
	user_id int,
	name nvarchar(70) not null default('Bob'),
	class_id int,
	race_id int,
	level int check(level >= 1) default(1),
	constraint pk_characters primary key(character_id),
	constraint fk_class_characters foreign key(class_id)
		references Classes(class_id),
	constraint fk_race_characters foreign key(race_id)
		references Races(race_id),
	constraint fk_users_characters foreign key(user_id)
		references Users(user_id));


create table CharactersSpells(
	character_id int,
	spell_id int,
	constraint fk_characrer_id foreign key(character_id)
		references Characters(character_id)
		on delete cascade on update cascade,
	constraint fk_spell  foreign key(spell_id) 
		references Spells(spell_id)
		on delete cascade on update cascade);


--drop table RacesTraits;
--drop table SpellsClasses;
--drop table Traits;
--drop table CharactersSpells;
--drop table Spells;
--drop table Characters
--drop table Races;
--drop table Classes;
--drop table Users;