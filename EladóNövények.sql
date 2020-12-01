drop table novenyek;

create table novenyek
(
	Id_noveny char(4) not null,
	viragzas char(200) not null,
	kor char(20) not null,
	fajta char(20) not null,
	szin char(20) not null,
	bolti_Id char not null,

	constraint pk_novenyek primary key(Id_noveny),
	constraint ch_viragzas check(viragzas in ('téli','nyári','öszi','tavaszi')),
	constraint fk_boltok foreign key(bolti_Id) references boltok(Id);

)