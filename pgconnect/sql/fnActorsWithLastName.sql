create or replace function actorswithlastname(
 lastname varchar(45)
)
returns TABLE ( 
  actor_id integer ,
  first_name character varying(45),
  last_name character varying(45)  
 ) as
 $$
 DECLARE
	success BOOLEAN;
 BEGIN
  if (lastname is null) then 
	select 'false' into success;
  else
	return query
	select actor.actor_id, actor.first_name, actor.last_name from actor where actor.last_name = lastname;
  end if;
END;  
 $$ LANGUAGE PLPGSQL  