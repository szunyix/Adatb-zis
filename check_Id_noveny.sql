create or replace function sfcheck_Id_noveny (
	p_Id_noveny in novenyek.Id_noveny%type
)
return int 
deterministic
as 
	v_Id_noveny int(1);
	v_i int;
begin
	if p_Id_noveny is null then
    return 0;
    end if;
    if length(trim(p_Id_noveny)) = 4 then
        v_i := 1;
        while v_i <= 4 loop
            v_Id_noveny := substr(p_Id_noveny, v_i, 1);
            if not (ascii('0') <= ascii(v_Id_noveny) and ascii(v_Id_noveny) <= ascii('9')) then
            return 0;
            end if;
            v_i := v_i + 1;
        end loop;
        return 1;
    end if;
    return 0;
end sfcheck_idszam;