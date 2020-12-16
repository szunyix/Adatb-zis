set serveroutput on;
declare
	c_call_Id_noveny int;
	v_Id_noveny novenyek.Id_noveny%type := '0001';
begin
	v_call_Id_noveny := sfcheck_Id_noveny(v_Id_noveny);

	if v_call_Id_noveny = 1 then 
		DBMS_OUTPUT.PUT_LINE('Az alábbi id helyes: '||v_Id_noveny);
    else
        DBMS_OUTPUT.PUT_LINE('Az alábbi id helytelen: '||v_Id_noveny);
    end if;
end;