drop table uzletek;

create table uzletek (
	id int not null,
	nev varchar2(200) not null,

	constraint pk_uzletek primary key(id)
)