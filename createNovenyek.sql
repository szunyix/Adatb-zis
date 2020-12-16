drop table novenyek;

create table novenyek
(
	id_noveny char(4) not null,
	viragzas char(200) not null,
	kor char(20) not null,
	fajta char(20) not null,
	ar char(20) not null,
	uzletek_Id int not null,

	constraint pk_novenyek primary key(id_noveny),
	constraint ch_viragzas check(viragzas in ('Téli','Nyári','Öszi','Tavaszi')),
	constraint fk_uzletek foreign key(uzletek_Id) references uzletek(id)

)