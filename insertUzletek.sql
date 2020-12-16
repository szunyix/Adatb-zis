create or replace procedure spInsert_uzletek(
	p_nev in novenyek.Id_noveny%type
)

authid definer
as 
	v_id int;
begin
	select max(id) into v_id from uzletek;

	if v_id is null then
		v_id :=0;
	end if;
	v_id := v_id +1;

	insert into uzletek
		(id, nev)
		values
		(v_id,p_nev);
end spInsert_uzletek;