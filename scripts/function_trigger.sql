CREATE OR REPLACE FUNCTION increment_calc_simian() RETURNS TRIGGER AS
$BODY$
declare existRegister integer default 0;
begin
	if(select 1 from simiancalc where id = CURRENT_DATE) = 1 then 
		if new.is_simian = true  then
			update simiancalc set total = total + 1, count_is_simian = count_is_simian + 1, updated_at = now() where id = CURRENT_DATE;
		else 
			update simiancalc set total = total + 1, count_is_not_simian = count_is_not_simian + 1, updated_at = now() where id = CURRENT_DATE;
		end if; 
	else 
		if new.is_simian = true then 
			insert into simiancalc (id, total, count_is_simian , count_is_not_simian)VALUES (CURRENT_DATE, 1, 1, 0);
		else 
			insert into simiancalc (id, total, count_is_simian , count_is_not_simian)VALUES (CURRENT_DATE, 1, 0, 1);
		end if;
	end if;
RETURN new;
END;
$BODY$
language plpgsql;


CREATE TRIGGER trig_simian
     AFTER INSERT ON simian
     FOR EACH ROW
     EXECUTE PROCEDURE increment_calc_simian();
