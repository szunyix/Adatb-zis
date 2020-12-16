create or replace procedure spInsert_novenyek(
	p_Id_noveny in novenyek.Id_noveny%type,
	p_viragzas in novenyek.viragzas%type,
	p_kor in novenyek.kor%type,
	p_fajta in novenyek.fajta%type,
	p_ar in novenyek.ar%type,
	p_uzletek_nev in uzletek.nev%type,

	p_out_rowcnt out int

)

authid definer 
as
	v_check_Id_noveny int;
begin
	p_out_rowcnt := 0;

	if v_check_Id_noveny = 1 then
		insert into novenyek
			(Id_noveny, viragzas , kor , fajta ,ar , uzletek.nev)
		values
			(p_Id_noveny , p_viragzas, p_kor ,p_fajta ,p_ar,p_uzletek_nev);
		p_out_rowcnt := SQL%rowcount;
		commit;
	end if;

end spInsert_novenyek;