create procedure sp_get_employees_single (@USR_EmployeeID varchar(20)) as 
begin 
select * from tblEmployee where USR_EmployeeID = @USR_EmployeeID
end