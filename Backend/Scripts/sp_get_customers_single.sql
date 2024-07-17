create procedure sp_get_customers_single (@CUS_ID varchar(20)) as 
begin 
select * from tbl_customer where CUS_ID = @CUS_ID
end