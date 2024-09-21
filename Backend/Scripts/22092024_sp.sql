USE [Neelaka1]
GO

/****** Object:  StoredProcedure [dbo].[sp_upload_employee_documents]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_upload_employee_documents]
GO

/****** Object:  StoredProcedure [dbo].[sp_removeaccess_UserMenu]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_removeaccess_UserMenu]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_UserRole]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_modify_UserRole]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_UserMenu]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_modify_UserMenu]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_user_internal]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_modify_user_internal]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_user_external]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_modify_user_external]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_Location]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_modify_Location]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_JobRole]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_modify_JobRole]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_employee]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_modify_employee]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_department]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_modify_department]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_customer]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_modify_customer]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_Country]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_modify_Country]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_Branch]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_modify_Branch]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_AccessGroup]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_modify_AccessGroup]
GO

/****** Object:  StoredProcedure [dbo].[sp_IntApi_InsertAuditLog]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_IntApi_InsertAuditLog]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_UserRole]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_insert_UserRole]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_UserMenu]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_insert_UserMenu]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_user_internal]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_insert_user_internal]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_user_external]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_insert_user_external]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_Location]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_insert_Location]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_JobRole]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_insert_JobRole]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_employee]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_insert_employee]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_department]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_insert_department]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_customer]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_insert_customer]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_Country]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_insert_Country]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_Branch]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_insert_Branch]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_AccessGroup]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_insert_AccessGroup]
GO

/****** Object:  StoredProcedure [dbo].[sp_grantaccess_UserMenu]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_grantaccess_UserMenu]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserRole_single]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_UserRole_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserRole_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_UserRole_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserMenu_single]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_UserMenu_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserMenu_all_ForAccessGroup]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_UserMenu_all_ForAccessGroup]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserMenu_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_UserMenu_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_login]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_user_login]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_internal_single]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_user_internal_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_internal_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_user_internal_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_external_single]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_user_external_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_external_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_user_external_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_location_single]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_location_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_location_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_location_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_JobRoles_single]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_JobRoles_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_JobRole_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_JobRole_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employees_single]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_employees_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employeeDocument_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_employeeDocument_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employee_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_employee_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_department_single]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_department_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_department_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_department_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_customers_single]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_customers_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_customer_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_customer_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Countrys_single]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_Countrys_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Country_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_Country_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Branchs_single]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_Branchs_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Branch_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_Branch_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_AccessGroup_single]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_AccessGroup_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_AccessGroup_all_ForUserRole]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_AccessGroup_all_ForUserRole]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_AccessGroup_all]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_get_AccessGroup_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_Location]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_del_Location]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_JobRole]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_del_JobRole]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_employee]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_del_employee]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_department]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_del_department]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_customer]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_del_customer]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_Country]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_del_Country]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_Branch]    Script Date: 9/22/2024 4:58:16 AM ******/
DROP PROCEDURE [dbo].[sp_del_Branch]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_Branch]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_Branch]
(@MDB_BranchID VARCHAR(10),@UD_UserID VARCHAR(10)) AS BEGIN
UPDATE tblBranch SET MDB_Status = 0, MDB_ModifiedBy = @UD_UserID, MDB_ModifiedDateTime =getDate() WHERE MDB_BranchID = @MDB_BranchID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_del_Country]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_Country]
(@MDCTY_CountryID VARCHAR(10),@UD_UserID VARCHAR(10)) AS BEGIN
UPDATE tblCountry SET MDCTY_Status = 0, MDCTY_ModifiedBy = @UD_UserID, MDCTY_ModifiedDateTime =getDate() WHERE MDCTY_CountryID = @MDCTY_CountryID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_del_customer]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_customer]
    (@CUS_ID VARCHAR(10), @UD_UserID VARCHAR(10))
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tblCustomer SET
        CUS_Status = 0,
        CUS_ModifiedBy = @UD_UserID,
        CUS_ModifiedDateTime = GETDATE()
    WHERE CUS_ID = @CUS_ID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_del_department]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_department]
(@MDD_DepartmentID VARCHAR(10),@UD_UserID VARCHAR(10)) AS BEGIN
UPDATE tblDepartment SET MDD_Status = 0, MDD_ModifiedBy = @UD_UserID, MDD_ModifiedDateTime =getDate() WHERE MDD_DepartmentID = @MDD_DepartmentID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_del_employee]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_employee]
(@EME_EmployeeID VARCHAR(10),@UD_UserID VARCHAR(10)) AS BEGIN
UPDATE tblEmployee SET EME_Status = 0, EME_ModifiedBy = @UD_UserID, EME_ModifiedDateTime =getDate() WHERE EME_EmployeeID = @EME_EmployeeID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_del_JobRole]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_JobRole]
(@MDJR_JobRoleID VARCHAR(10),@UD_UserID VARCHAR(10)) AS BEGIN
UPDATE tblJobRole SET MDJR_Status = 0, MDJR_ModifiedBy = @UD_UserID, MDJR_ModifiedDateTime =getDate() WHERE MDJR_JobRoleID = @MDJR_JobRoleID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_del_Location]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_Location]
(@MDL_LocationID VARCHAR(10),@UD_UserID VARCHAR(10)) AS BEGIN
UPDATE tblLocation SET MDL_Status = 0, MDL_ModifiedBy = @UD_UserID, MDL_ModifiedDateTime =getDate() WHERE MDL_LocationID = @MDL_LocationID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_AccessGroup_all]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_AccessGroup_all]
AS BEGIN
SELECT * FROM tblAccessGroup;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_AccessGroup_all_ForUserRole]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_AccessGroup_all_ForUserRole] (@UUR_UserRoleID varchar(50))
AS BEGIN

select case a.UURAG_Status when 1 then 1
else 0 end as UAG_Status,UAG_AccessGroupID,UAG_AccessGroup from tblAccessGroup m left outer join tblUserRoleAccessGroup a 
on a.UURAG_AccessGroupID=m.UAG_AccessGroupID
--where isnull(a.UURAG_UserRoleID,@UUR_UserRoleID)=@UUR_UserRoleID

END;

GO

/****** Object:  StoredProcedure [dbo].[sp_get_AccessGroup_single]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_AccessGroup_single]
(@UAG_AccessGroupID VARCHAR(10)) AS BEGIN
SELECT * FROM tblAccessGroup WHERE UAG_AccessGroupID = @UAG_AccessGroupID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Branch_all]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_Branch_all] as begin 
select * from tblBranch; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Branchs_single]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_Branchs_single] (
@MDB_BranchID varchar(10)
) as begin 
select * from tblBranch where MDB_BranchID = @MDB_BranchID; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Country_all]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_Country_all] as 
begin 
select * from tblCountry; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Countrys_single]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_Countrys_single] (@MDCTY_CountryID varchar(10)) as 
begin 
select * from tblCountry where MDCTY_CountryID = @MDCTY_CountryID; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_customer_all]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_customer_all] as begin 
select * from tblCustomer; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_customers_single]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_customers_single] (@CUS_ID varchar(20)) as 
begin 
select * from tblcustomer where CUS_ID = @CUS_ID
end
GO

/****** Object:  StoredProcedure [dbo].[sp_get_department_all]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_department_all]
AS BEGIN
SELECT * FROM tblDepartment;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_department_single]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_department_single] 
(@MDD_DepartmentID VARCHAR(50))AS BEGIN
SELECT * FROM tblDepartment WHERE MDD_DepartmentID = @MDD_DepartmentID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employee_all]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[sp_get_employee_all] as 
begin 
select * from tblEmployee 
end
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employeeDocument_all]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_employeeDocument_all]
(@USRED_EmployeeID VARCHAR(50))
AS BEGIN
SELECT * FROM tblEmployee_EmployeeDocument WHERE USRED_EmployeeID = @USRED_EmployeeID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employees_single]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_employees_single] (@EME_EmployeeID varchar(10)) as 
begin 
select * from tblEmployee where EME_EmployeeID = @EME_EmployeeID; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_JobRole_all]    Script Date: 9/22/2024 4:58:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_JobRole_all]
AS BEGIN
SELECT * FROM tblJobRole;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_JobRoles_single]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_JobRoles_single]
(@MDJR_JobRoleID VARCHAR(10)) AS BEGIN
SELECT * FROM tblJobRole WHERE MDJR_JobRoleID = @MDJR_JobRoleID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_location_all]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_location_all] as 
begin 
select * from tblLocation; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_location_single]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_location_single] (@MDL_LocationID varchar(10)) as 
begin 
select * from tblLocation where MDL_LocationID = @MDL_LocationID; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_external_all]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[sp_get_user_external_all]
as
begin

select UE_UserID, UE_FirstName, UE_LastName, UE_EmailAddress, UE_MobileNumber, UE_PhoneNumber, UE_Remarks, UE_ActiveFrom, UE_ActiveTo, UE_Status, UE_Pwd, UE_PwdSalt, UE_PwdLastResetDateTime, UE_CreatedBy, 
                  UE_CreatedDateTime, UE_ModifiedBy, UE_ModifiedDateTime, UE_Otp, UE_Otp_Generate_On
 from [dbo].[tbl_user_external]

end
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_external_single]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create   procedure [dbo].[sp_get_user_external_single](@UE_UserID varchar(50))
as
begin

SELECT UE_UserID, UE_FirstName, UE_LastName, UE_EmailAddress, UE_MobileNumber, UE_PhoneNumber, UE_Remarks, UE_ActiveFrom, UE_ActiveTo, UE_Status, UE_Pwd, UE_PwdSalt, UE_PwdLastResetDateTime, UE_CreatedBy, 
                  UE_CreatedDateTime, UE_ModifiedBy, UE_ModifiedDateTime, UE_Otp, UE_Otp_Generate_On
FROM     tbl_user_external where UE_UserID=@UE_UserID
end
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_internal_all]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[sp_get_user_internal_all]
as
begin

select UE_UserID, UE_FirstName, UE_LastName, UE_EmailAddress, UE_MobileNumber, UE_PhoneNumber, UE_Remarks, UE_ActiveFrom, UE_ActiveTo, UE_Status, UE_Pwd, UE_PwdSalt, UE_PwdLastResetDateTime, UE_CreatedBy, 
                  UE_CreatedDateTime, UE_ModifiedBy, UE_ModifiedDateTime, UE_Otp, UE_Otp_Generate_On,UE_EmployeeID
 from [dbo].[tbl_user_internal]

end
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_internal_single]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[sp_get_user_internal_single](@UE_UserID varchar(50))
as
begin

SELECT UE_UserID, UE_FirstName, UE_LastName, UE_EmailAddress, UE_MobileNumber, UE_PhoneNumber, UE_Remarks, UE_ActiveFrom, UE_ActiveTo, UE_Status, UE_Pwd, UE_PwdSalt, UE_PwdLastResetDateTime, UE_CreatedBy, 
                  UE_CreatedDateTime, UE_ModifiedBy, UE_ModifiedDateTime, UE_Otp, UE_Otp_Generate_On,UE_EmployeeID
FROM     tbl_user_internal where UE_UserID=@UE_UserID
end
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_login]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_user_login] 
(@USER_ID VARCHAR(50),
@USER_PASSWORD VARCHAR(50) )AS BEGIN 

SELECT * FROM tblUserDetails INNER JOIN tblUserRole ON tblUserRole.UUR_UserRoleID = tblUserDetails.UD_UserRole AND (tblUserDetails.UD_UserID = @USER_ID OR tblUserDetails.UD_EmailAddress = @USER_ID);


SELECT * FROM tblUserRoleAccessGroup 
INNER JOIN tblUserRole ON tblUserRoleAccessGroup.UURAG_UserRoleID = tblUserRole.UUR_UserRoleID 
INNER JOIN tblAccessGroup ON tblUserRoleAccessGroup.UURAG_AccessGroupID = tblAccessGroup.UAG_AccessGroupID
WHERE UURAG_UserRoleID IN (SELECT UUR_UserRoleID FROM tblUserDetails INNER JOIN tblUserRole ON tblUserRole.UUR_UserRoleID = tblUserDetails.UD_UserRole AND (tblUserDetails.UD_UserID = @USER_ID OR tblUserDetails.UD_EmailAddress = @USER_ID))



SELECT * FROM tblMenuAccess 
INNER JOIN tblAccessGroup ON tblMenuAccess.UMA_AccessGroupID = tblAccessGroup.UAG_AccessGroup 
INNER JOIN tblUserMenu ON tblMenuAccess.UMA_UserMenuID = tblUserMenu.UUM_UserMenuID
WHERE UMA_AccessGroupID In (SELECT UURAG_AccessGroupID FROM tblUserRoleAccessGroup 
INNER JOIN tblUserRole ON tblUserRoleAccessGroup.UURAG_UserRoleID = tblUserRole.UUR_UserRoleID 
INNER JOIN tblAccessGroup ON tblUserRoleAccessGroup.UURAG_AccessGroupID = tblAccessGroup.UAG_AccessGroupID
WHERE UURAG_UserRoleID IN (SELECT UUR_UserRoleID FROM tblUserDetails INNER JOIN tblUserRole ON tblUserRole.UUR_UserRoleID = tblUserDetails.UD_UserRole AND (tblUserDetails.UD_UserID = @USER_ID OR tblUserDetails.UD_EmailAddress = @USER_ID)))

END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserMenu_all]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_UserMenu_all]
AS BEGIN
SELECT * FROM tblUserMenu;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserMenu_all_ForAccessGroup]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_UserMenu_all_ForAccessGroup] (@UMA_AccessGroupID varchar(50))
AS BEGIN

select case a.UMA_status when 1 then 1
else 0 end as UUM_Status,UUM_UserMenuID,UUM_UserMenu from tblUserMenu m left outer join [tblMenuAccess] a on a.[UMA_UserMenuID]=m.[UUM_UserMenuID]
where isnull(a.[UMA_AccessGroupID],@UMA_AccessGroupID)=@UMA_AccessGroupID
END;

GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserMenu_single]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_UserMenu_single]
(@UUM_UserMenuID VARCHAR(10)) AS BEGIN
SELECT * FROM tblUserMenu WHERE UUM_UserMenuID = @UUM_UserMenuID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserRole_all]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_UserRole_all]
AS BEGIN
SELECT * FROM tblUserRole;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserRole_single]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_UserRole_single]
(@UUR_UserRoleID VARCHAR(10)) AS BEGIN
SELECT * FROM tblUserRole WHERE UUR_UserRoleID = @UUR_UserRoleID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_grantaccess_UserMenu]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_grantaccess_UserMenu](@UMA_AccessGroupID varchar(50),@UMA_UserMenuID varchar(50),@ModifiedUser varchar(50)) as
begin
 BEGIN TRY

 if not exists(select * from [tblMenuAccess]  WHERE [UMA_UserMenuID] = @UMA_UserMenuID AND UMA_AccessGroupID=@UMA_AccessGroupID)
 begin
 INSERT INTO [dbo].[tblMenuAccess]
           ([UMA_UserMenuID]
           ,[UMA_AccessGroupID]
           ,[UMA_Status]
           ,[UMA_CreatedBy]
           ,[UMA_CreatedDateTime])
     VALUES
           (@UMA_UserMenuID
           ,@UMA_AccessGroupID
           ,1
           ,@ModifiedUser
           ,getdate())

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'granted successfully' AS RTN_MSG;
end
else 
begin
  UPDATE [dbo].tblMenuAccess
   SET [UMA_Status] = 1
      ,[UMA_ModifiedBy] = @ModifiedUser
      ,[UMA_ModifiedDateTime] = getdate()
 WHERE [UMA_UserMenuID] = @UMA_UserMenuID AND UMA_AccessGroupID=@UMA_AccessGroupID

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'granted successfully' AS RTN_MSG;
end
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
end
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_AccessGroup]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_insert_AccessGroup] 
(@UAG_AccessGroupID VARCHAR(10), 
@UAG_AccessGroup VARCHAR(50), 
@UAG_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
  BEGIN TRY
  
   if exists (select * from tblAccessGroup where UAG_AccessGroupID=@UAG_AccessGroupID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'user exists' AS RTN_MSG;
	return

   end

INSERT INTO tblAccessGroup (UAG_AccessGroupID, UAG_AccessGroup, UAG_Status, UAG_CreatedBy, UAG_CreatedDateTime)
VALUES (@UAG_AccessGroupID, @UAG_AccessGroup, @UAG_Status, @UD_UserID, getDate());

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'saved successfully' AS RTN_MSG;
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_Branch]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_insert_Branch] 
(@MDB_BranchID VARCHAR(10), 
@MDB_Branch VARCHAR(50), 
@MDB_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
INSERT INTO tblBranch (MDB_BranchID, MDB_Branch, MDB_Status, MDB_CreatedBy, MDB_CreatedDateTime)
VALUES (@MDB_BranchID, @MDB_Branch, @MDB_Status, @UD_UserID, getDate());
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_Country]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_insert_Country] 
(@MDCTY_CountryID VARCHAR(10), 
@MDCTY_Country VARCHAR(50), 
@MDCTY_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
INSERT INTO tblCountry (MDCTY_CountryID, MDCTY_Country, MDCTY_Status, MDCTY_CreatedBy, MDCTY_CreatedDateTime)
VALUES (@MDCTY_CountryID, @MDCTY_Country, @MDCTY_Status, @UD_UserID, getDate());
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_customer]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_insert_customer]
    (@UD_UserID VARCHAR(10),
     @CUS_ID VARCHAR(20),
     @CUS_CompanyName VARCHAR(100),
	 @CUS_GroupCompany VARCHAR(50),
     @CUS_Adrs_BlockBuildingNo VARCHAR(100),
     @CUS_Adrs_BuildingName VARCHAR(100),
     @CUS_Adrs_UnitNumber VARCHAR(20),
     @CUS_Adrs_StreetName VARCHAR(50),
     @CUS_Adrs_City VARCHAR(50),
     @CUS_Adrs_CountryCode VARCHAR(5),
     @CUS_Adrs_PostalCode VARCHAR(10),
     @CUS_ContactPerson VARCHAR(200),
     @CUS_ContactNumber VARCHAR(20),
     @CUS_PinOrPwd VARCHAR(3),
     @CUS_OTP_By_SMS BIT,
     @CUS_OTP_By_Email BIT,
     @CUS_Status BIT)
AS
BEGIN
    SET NOCOUNT ON;

   BEGIN TRY

   if exists (select * from tblCustomer where CUS_ID=@CUS_ID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'customer exists' AS RTN_MSG;
	return

   end

   INSERT INTO tblCustomer (
        CUS_ID,
        CUS_CompanyName,
		CUS_GroupCompany,
        CUS_Adrs_BlockBuildingNo,
        CUS_Adrs_BuildingName,
        CUS_Adrs_UnitNumber,
        CUS_Adrs_StreetName,
        CUS_Adrs_City,
        CUS_Adrs_CountryCode,
        CUS_Adrs_PostalCode,
        CUS_ContactPerson,
        CUS_ContactNumber,
        CUS_PinOrPwd,
        CUS_OTP_By_SMS,
        CUS_OTP_By_Email,
        CUS_Status,
        CUS_CreatedBy,
        CUS_CreatedDateTime
    )
    VALUES (
        @CUS_ID,
        @CUS_CompanyName,
		@CUS_GroupCompany,
        @CUS_Adrs_BlockBuildingNo,
        @CUS_Adrs_BuildingName,
        @CUS_Adrs_UnitNumber,
        @CUS_Adrs_StreetName,
        @CUS_Adrs_City,
        @CUS_Adrs_CountryCode,
        @CUS_Adrs_PostalCode,
        @CUS_ContactPerson,
        @CUS_ContactNumber,
        @CUS_PinOrPwd,
        @CUS_OTP_By_SMS,
        @CUS_OTP_By_Email,
        @CUS_Status,
        @UD_UserID,
        GETDATE()
    );

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'saved successfully' AS RTN_MSG;
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_department]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_insert_department] 
(@MDD_DepartmentID VARCHAR(10), 
@MDD_Department VARCHAR(50), 
@MDD_LocationID VARCHAR(50), 
@MDD_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
INSERT INTO tblDepartment (MDD_DepartmentID, MDD_Department, MDD_LocationID, MDD_Status, MDD_CreatedBy, MDD_CreatedDateTime)
VALUES (@MDD_DepartmentID, @MDD_Department, @MDD_LocationID, @MDD_Status, @UD_UserID, getDate());
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_employee]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_insert_employee] 
(@UD_UserID VARCHAR(10),@EME_CustomerID varchar(10),
           @EME_DepartmentID varchar(10),
           @EME_EmployeeID varchar(10),
           @EME_FirstName varchar(50),
           @EME_LastName varchar(50),
           @EME_Gender varchar(10),
           @EME_MaritalStatus varchar(10),
           @EME_Nationality varchar(10),
           @EME_BloodGroup varchar(5),
           @EME_NIC varchar(20),
           @EME_Passport varchar(20),
           @EME_DrivingLicense varchar(20),
           @EME_PrefferedName varchar(50),
           @EME_JobTitle_Code varchar(10),
           @EME_ReportingManager varchar(10),
           @EME_EmployeeType varchar(10),
           @EME_PayeeTaxNumber varchar(20),
           @EME_Salary decimal(18,2),
           @EME_Address varchar(100),
           @EME_EmailAddress varchar(50),
           @EME_MobileNumber varchar(10),
           @EME_PhoneNumber1 varchar(10),
           @EME_PhoneNumber2 varchar(10),
           @EME_Status bit,
           @EME_DateOfHire datetime,
           @EME_DateOfBirth datetime
) 
AS BEGIN 
INSERT INTO tblEmployee (
EME_CustomerID
           ,EME_DepartmentID
           ,EME_EmployeeID
           ,EME_FirstName
           ,EME_LastName
           ,EME_Gender
           ,EME_MaritalStatus
           ,EME_Nationality
           ,EME_BloodGroup
           ,EME_NIC
           ,EME_Passport
           ,EME_DrivingLicense
           ,EME_PrefferedName
           ,EME_JobTitle_Code
           ,EME_ReportingManager
           ,EME_EmployeeType
           ,EME_PayeeTaxNumber
           ,EME_Salary
           ,EME_Address
           ,EME_EmailAddress
           ,EME_MobileNumber
           ,EME_PhoneNumber1
           ,EME_PhoneNumber2
           ,EME_Status
           ,EME_CreatedBy
           ,EME_CreatedDateTime
           ,EME_DateOfHire
           ,EME_DateOfBirth)
VALUES (@EME_CustomerID
           ,@EME_DepartmentID
           ,@EME_EmployeeID
           ,@EME_FirstName
           ,@EME_LastName
           ,@EME_Gender
           ,@EME_MaritalStatus
           ,@EME_Nationality
           ,@EME_BloodGroup
           ,@EME_NIC
           ,@EME_Passport
           ,@EME_DrivingLicense
           ,@EME_PrefferedName
           ,@EME_JobTitle_Code
           ,@EME_ReportingManager
           ,@EME_EmployeeType
           ,@EME_PayeeTaxNumber
           ,@EME_Salary
           ,@EME_Address
           ,@EME_EmailAddress
           ,@EME_MobileNumber
           ,@EME_PhoneNumber1
           ,@EME_PhoneNumber2
           ,@EME_Status
           ,@UD_UserID, 
		   getDate()
           ,@EME_DateOfHire
           ,@EME_DateOfBirth);
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_JobRole]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_insert_JobRole] 
(@MDJR_JobRoleID VARCHAR(10), 
@MDJR_JobRole VARCHAR(50), 
@MDJR_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
INSERT INTO tblJobRole (MDJR_JobRoleID, MDJR_JobRole, MDJR_Status, MDJR_CreatedBy, MDJR_CreatedDateTime)
VALUES (@MDJR_JobRoleID, @MDJR_JobRole, @MDJR_Status, @UD_UserID, getDate());
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_Location]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_insert_Location] 
(@MDL_LocationID VARCHAR(10), 
@MDL_Location VARCHAR(50), 
@MDL_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
INSERT INTO tblLocation (MDL_LocationID, MDL_Location, MDL_Status, MDL_CreatedBy, MDL_CreatedDateTime)
VALUES (@MDL_LocationID, @MDL_Location, @MDL_Status, @UD_UserID, getDate());
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_user_external]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[sp_insert_user_external](@UE_UserID varchar(50)
      ,@UE_FirstName varchar(100)
      ,@UE_LastName varchar(100)
      ,@UE_EmailAddress varchar(100)
      ,@UE_MobileNumber varchar(20)
      ,@UE_PhoneNumber varchar(20)
      ,@UE_Remarks varchar(200)
      ,@UE_Status bit
      ,@ModifiedUser varchar(50))
as 
begin

  BEGIN TRY
  
   if exists (select * from [tbl_user_external] where [UE_UserID]=@UE_UserID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'user exists' AS RTN_MSG;
	return

   end
INSERT INTO [dbo].[tbl_user_external]
           ([UE_UserID]
           ,[UE_FirstName]
           ,[UE_LastName]
           ,[UE_EmailAddress]
           ,[UE_MobileNumber]
           ,[UE_PhoneNumber]
           ,[UE_Remarks]
           ,[UE_ActiveFrom]
           ,[UE_ActiveTo]
           ,[UE_Status]
           ,[UE_PwdLastResetDateTime]
           ,[UE_CreatedBy]
           ,[UE_CreatedDateTime]
           ,[UE_ModifiedBy]
           ,[UE_ModifiedDateTime])
     VALUES
           (@UE_UserID
           ,@UE_FirstName
           ,@UE_LastName
           ,@UE_EmailAddress
           ,@UE_MobileNumber
           ,@UE_PhoneNumber
           ,@UE_Remarks
           ,getdate()
           ,getdate()
           ,@UE_Status
           ,getdate()
           ,@ModifiedUser
           ,getdate()
           ,@ModifiedUser
           ,getdate())

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'saved successfully' AS RTN_MSG;
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
    ROLLBACK TRAN  
END CATCH
end
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_user_internal]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[sp_insert_user_internal](@UE_UserID varchar(50),@UE_EmployeeID varchar(50)
      ,@UE_FirstName varchar(100)
      ,@UE_LastName varchar(100)
      ,@UE_EmailAddress varchar(100)
      ,@UE_MobileNumber varchar(20)
      ,@UE_PhoneNumber varchar(20)
      ,@UE_Remarks varchar(200)
      ,@UE_Status bit
      ,@ModifiedUser varchar(50))
as 
begin

  BEGIN TRY
  
   if exists (select * from [tbl_user_internal] where [UE_UserID]=@UE_UserID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'user exists' AS RTN_MSG;
	return

   end
INSERT INTO [dbo].[tbl_user_internal]
           ([UE_UserID]
           ,UE_EmployeeID
           ,[UE_FirstName]
           ,[UE_LastName]
           ,[UE_EmailAddress]
           ,[UE_MobileNumber]
           ,[UE_PhoneNumber]
           ,[UE_Remarks]
           ,[UE_ActiveFrom]
           ,[UE_ActiveTo]
           ,[UE_Status]
           ,[UE_PwdLastResetDateTime]
           ,[UE_CreatedBy]
           ,[UE_CreatedDateTime]
           ,[UE_ModifiedBy]
           ,[UE_ModifiedDateTime])
     VALUES
           (@UE_UserID
           ,@UE_EmployeeID
           ,@UE_FirstName
           ,@UE_LastName
           ,@UE_EmailAddress
           ,@UE_MobileNumber
           ,@UE_PhoneNumber
           ,@UE_Remarks
           ,getdate()
           ,getdate()
           ,@UE_Status
           ,getdate()
           ,@ModifiedUser
           ,getdate()
           ,@ModifiedUser
           ,getdate())

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'saved successfully' AS RTN_MSG;
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
end
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_UserMenu]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_insert_UserMenu] 
(@UUM_UserMenuID VARCHAR(10), 
@UUM_UserMenu VARCHAR(50), 
@UUM_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
  BEGIN TRY
  
   if exists (select * from tblUserMenu where UUM_UserMenuID=@UUM_UserMenuID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'user menu exists' AS RTN_MSG;
	return

   end

INSERT INTO tblUserMenu (UUM_UserMenuID, UUM_UserMenu, UUM_Status, UUM_CreatedBy, UUM_CreatedDateTime)
VALUES (@UUM_UserMenuID, @UUM_UserMenu, @UUM_Status, @UD_UserID, getDate());

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'saved successfully' AS RTN_MSG;
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_UserRole]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_insert_UserRole] 
(@UUR_UserRoleID VARCHAR(10), 
@UUR_UserRole VARCHAR(50), 
@UUR_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
  BEGIN TRY
  
   if exists (select * from tblUserRole where UUR_UserRoleID=@UUR_UserRoleID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'user menu exists' AS RTN_MSG;
	return

   end

INSERT INTO tblUserRole (UUR_UserRoleID, UUR_UserRole, UUR_Status, UUR_CreatedBy, UUR_CreatedDateTime)
VALUES (@UUR_UserRoleID, @UUR_UserRole, @UUR_Status, @UD_UserID, getDate());

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'saved successfully' AS RTN_MSG;
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_IntApi_InsertAuditLog]    Script Date: 9/22/2024 4:58:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[sp_IntApi_InsertAuditLog](@Module varchar(255),
@Action varchar(255),
@Description varchar(MAX),
@CreatedBy varchar(255),
@ClientIP varchar(255),
@ActionType varchar(255),
@Controler varchar(255))
as
begin

declare @ID as varchar(10)
SELECT @ID=[ID]
FROM [dbo].[tbl_AuditLog_ActionMap] where [Module]=@Module and [Controller]=@Controler and [Action]=@Action

if @ID is not null
INSERT INTO [dbo].[tbl_auditlog]
           ([Module]
           ,[Action]
           ,[Description]
           ,[CreatedBy]
		   ,ClientIP
		   ,CreatedDateTime,ActionType,Controler,ActionMap_ID)
     VALUES
           (@Module,@Action,@Description,@CreatedBy,@ClientIP,getdate(),@ActionType,@Controler,@ID)
else
	set @ID=-1
	INSERT INTO [dbo].[tbl_auditlog]
           ([Module]
           ,[Action]
           ,[Description]
           ,[CreatedBy]
		   ,ClientIP
		   ,CreatedDateTime,ActionType,Controler,ActionMap_ID)
     VALUES
           (@Module,@Action,@Description,@CreatedBy,@ClientIP,getdate(),@ActionType,@Controler,@ID)
end


GO

/****** Object:  StoredProcedure [dbo].[sp_modify_AccessGroup]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_modify_AccessGroup] 
(@UAG_AccessGroupID VARCHAR(10), 
@UAG_AccessGroup VARCHAR(50), 
@UAG_Status BIT, 
@UD_UserID VARCHAR(10)


) 
AS BEGIN 
  BEGIN TRY
UPDATE tblAccessGroup SET UAG_AccessGroup = @UAG_AccessGroup, UAG_Status = @UAG_Status, UAG_ModifiedBy = @UD_UserID, UAG_ModifiedDateTime =getDate() WHERE UAG_AccessGroupID = @UAG_AccessGroupID;

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'update successfully' AS RTN_MSG;
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
end
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_Branch]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_modify_Branch] 
(@MDB_BranchID VARCHAR(10), 
@MDB_Branch VARCHAR(50), 
@MDB_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
UPDATE tblBranch SET MDB_Branch = @MDB_Branch, MDB_Status = @MDB_Status, MDB_ModifiedBy = @UD_UserID, MDB_ModifiedDateTime =getDate() WHERE MDB_BranchID = @MDB_BranchID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_Country]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_modify_Country] 
(@MDCTY_CountryID VARCHAR(10), 
@MDCTY_Country VARCHAR(50), 
@MDCTY_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
UPDATE tblCountry SET MDCTY_Country = @MDCTY_Country, MDCTY_Status = @MDCTY_Status, MDCTY_ModifiedBy = @UD_UserID, MDCTY_ModifiedDateTime =getDate() WHERE MDCTY_CountryID = @MDCTY_CountryID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_customer]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_modify_customer]
    (@UD_UserID VARCHAR(10),
     @CUS_ID VARCHAR(20),
     @CUS_CompanyName VARCHAR(100),
	 @CUS_GroupCompany VARCHAR(50),
     @CUS_Adrs_BlockBuildingNo VARCHAR(100),
     @CUS_Adrs_BuildingName VARCHAR(100),
     @CUS_Adrs_UnitNumber VARCHAR(20),
     @CUS_Adrs_StreetName VARCHAR(50),
     @CUS_Adrs_City VARCHAR(50),
     @CUS_Adrs_CountryCode VARCHAR(5),
     @CUS_Adrs_PostalCode VARCHAR(10),
     @CUS_ContactPerson VARCHAR(200),
     @CUS_ContactNumber VARCHAR(20),
     @CUS_PinOrPwd VARCHAR(3),
     @CUS_OTP_By_SMS BIT,
     @CUS_OTP_By_Email BIT,
     @CUS_Status BIT)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
	UPDATE tblCustomer SET
        CUS_CompanyName = @CUS_CompanyName,
		CUS_GroupCompany = @CUS_GroupCompany,
        CUS_Adrs_BlockBuildingNo = @CUS_Adrs_BlockBuildingNo,
        CUS_Adrs_BuildingName = @CUS_Adrs_BuildingName,
        CUS_Adrs_UnitNumber = @CUS_Adrs_UnitNumber,
        CUS_Adrs_StreetName = @CUS_Adrs_StreetName,
        CUS_Adrs_City = @CUS_Adrs_City,
        CUS_Adrs_CountryCode = @CUS_Adrs_CountryCode,
        CUS_Adrs_PostalCode = @CUS_Adrs_PostalCode,
        CUS_ContactPerson = @CUS_ContactPerson,
        CUS_ContactNumber = @CUS_ContactNumber,
        CUS_PinOrPwd = @CUS_PinOrPwd,
        CUS_OTP_By_SMS = @CUS_OTP_By_SMS,
        CUS_OTP_By_Email = @CUS_OTP_By_Email,
        CUS_Status = @CUS_Status,
        CUS_ModifiedBy = @UD_UserID,
        CUS_ModifiedDateTime = GETDATE()
    WHERE CUS_ID = @CUS_ID;
  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'saved successfully' AS RTN_MSG;
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_department]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_modify_department]
(@MDD_DepartmentID VARCHAR(10),
@MDD_Department VARCHAR(50),
@MDD_LocationID VARCHAR(50),
@MDD_Status BIT,
@UD_UserID VARCHAR(10)
) AS BEGIN
UPDATE tblDepartment SET MDD_Department = @MDD_Department, MDD_LocationID = @MDD_LocationID,  MDD_Status = @MDD_Status, MDD_ModifiedBy = @UD_UserID, MDD_ModifiedDateTime =getDate() WHERE MDD_DepartmentID = @MDD_DepartmentID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_employee]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_modify_employee]
(@UD_UserID VARCHAR(10),
@EME_CustomerID varchar(10),
           @EME_DepartmentID varchar(10),
           @EME_EmployeeID varchar(10),
           @EME_FirstName varchar(50),
           @EME_LastName varchar(50),
           @EME_Gender varchar(10),
           @EME_MaritalStatus varchar(10),
           @EME_Nationality varchar(10),
           @EME_BloodGroup varchar(5),
           @EME_NIC varchar(20),
           @EME_Passport varchar(20),
           @EME_DrivingLicense varchar(20),
           @EME_PrefferedName varchar(50),
           @EME_JobTitle_Code varchar(10),
           @EME_ReportingManager varchar(10),
           @EME_EmployeeType varchar(10),
           @EME_PayeeTaxNumber varchar(20),
           @EME_Salary decimal(18,2),
           @EME_Address varchar(100),
           @EME_EmailAddress varchar(50),
           @EME_MobileNumber varchar(10),
           @EME_PhoneNumber1 varchar(10),
           @EME_PhoneNumber2 varchar(10),
           @EME_Status bit,
           @EME_DateOfHire datetime,
           @EME_DateOfBirth datetime
) 
AS BEGIN 
UPDATE tblEmployee SET EME_CustomerID = @EME_CustomerID,
      EME_DepartmentID = @EME_DepartmentID, 
      EME_FirstName = @EME_FirstName, 
      EME_LastName = @EME_LastName,
      EME_Gender = @EME_Gender,
      EME_MaritalStatus = @EME_MaritalStatus,
      EME_Nationality = @EME_Nationality, 
      EME_BloodGroup = @EME_BloodGroup,
      EME_NIC = @EME_NIC, 
      EME_Passport = @EME_Passport, 
      EME_DrivingLicense = @EME_DrivingLicense, 
      EME_PrefferedName = @EME_PrefferedName, 
      EME_JobTitle_Code = @EME_JobTitle_Code, 
      EME_ReportingManager = @EME_ReportingManager, 
      EME_EmployeeType = @EME_EmployeeType,
      EME_PayeeTaxNumber = @EME_PayeeTaxNumber,
      EME_Salary = @EME_Salary, 
      EME_Address = @EME_Address,
      EME_EmailAddress = @EME_EmailAddress,
      EME_MobileNumber = @EME_MobileNumber,
      EME_PhoneNumber1 = @EME_PhoneNumber1,
      EME_PhoneNumber2 = @EME_PhoneNumber2, 
      EME_Status = @EME_Status,
      EME_ModifiedBy = @UD_UserID, 
      EME_ModifiedDateTime = getDate(),
      EME_DateOfHire = @EME_DateOfHire, 
      EME_DateOfBirth = @EME_DateOfBirth
	  WHERE EME_EmployeeID = @EME_EmployeeID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_JobRole]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_modify_JobRole] 
(@MDJR_JobRoleID VARCHAR(10), 
@MDJR_JobRole VARCHAR(50), 
@MDJR_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
UPDATE tblJobRole SET MDJR_JobRole = @MDJR_JobRole, MDJR_Status = @MDJR_Status, MDJR_ModifiedBy = @UD_UserID, MDJR_ModifiedDateTime =getDate() WHERE MDJR_JobRoleID = @MDJR_JobRoleID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_Location]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_modify_Location] 
(@MDL_LocationID VARCHAR(10), 
@MDL_Location VARCHAR(50), 
@MDL_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
UPDATE tblLocation SET MDL_Location = @MDL_Location, MDL_Status = @MDL_Status, MDL_ModifiedBy = @UD_UserID, MDL_ModifiedDateTime =getDate() WHERE MDL_LocationID = @MDL_LocationID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_user_external]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[sp_modify_user_external](@UE_UserID varchar(50)
      ,@UE_FirstName varchar(100)
      ,@UE_LastName varchar(100)
      ,@UE_EmailAddress varchar(100)
      ,@UE_MobileNumber varchar(20)
      ,@UE_PhoneNumber varchar(20)
      ,@UE_Remarks varchar(200)
      ,@UE_ActiveFrom datetime
      ,@UE_ActiveTo datetime
      ,@UE_Status bit
      ,@ModifiedUser varchar(50))
as 
begin

  BEGIN TRY
UPDATE [dbo].[tbl_user_external]
   SET [UE_FirstName] = @UE_FirstName
      ,[UE_LastName] = @UE_LastName
      ,[UE_EmailAddress] = @UE_EmailAddress
      ,[UE_MobileNumber] = @UE_MobileNumber
      ,[UE_PhoneNumber] = @UE_PhoneNumber
      ,[UE_Remarks] = @UE_Remarks
      ,[UE_Status] = @UE_Status
      ,[UE_ModifiedBy] = @ModifiedUser
      ,[UE_ModifiedDateTime] = GETDATE()
	  ,UE_ActiveFrom=@UE_ActiveFrom
	  ,UE_ActiveTo=@UE_ActiveTo
 WHERE [UE_UserID] = @UE_UserID

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'update successfully' AS RTN_MSG;
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
end
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_user_internal]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[sp_modify_user_internal](@UE_UserID varchar(50)
      ,@UE_FirstName varchar(100)
      ,@UE_LastName varchar(100)
      ,@UE_EmailAddress varchar(100)
      ,@UE_MobileNumber varchar(20)
      ,@UE_PhoneNumber varchar(20)
      ,@UE_Remarks varchar(200)
      ,@UE_ActiveFrom datetime
      ,@UE_ActiveTo datetime
      ,@UE_Status bit
      ,@UE_EmployeeID varchar(20)
      ,@ModifiedUser varchar(50))
as 
begin

  BEGIN TRY
UPDATE [dbo].[tbl_user_internal]
   SET [UE_FirstName] = @UE_FirstName
      ,[UE_LastName] = @UE_LastName
      ,[UE_EmailAddress] = @UE_EmailAddress
      ,[UE_MobileNumber] = @UE_MobileNumber
      ,[UE_PhoneNumber] = @UE_PhoneNumber
      ,[UE_Remarks] = @UE_Remarks
      ,[UE_Status] = @UE_Status
      ,[UE_ModifiedBy] = @ModifiedUser
      ,[UE_ModifiedDateTime] = GETDATE()
	  ,UE_ActiveFrom=@UE_ActiveFrom
	  ,UE_ActiveTo=@UE_ActiveTo
	  ,UE_EmployeeID=@UE_EmployeeID
 WHERE [UE_UserID] = @UE_UserID

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'update successfully' AS RTN_MSG;
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
end
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_UserMenu]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_modify_UserMenu] 
(@UUM_UserMenuID VARCHAR(10), 
@UUM_UserMenu VARCHAR(50), 
@UUM_Status BIT, 
@UD_UserID VARCHAR(10)


) 
AS BEGIN 
  BEGIN TRY
UPDATE tblUserMenu SET UUM_UserMenu = @UUM_UserMenu, UUM_Status = @UUM_Status, UUM_ModifiedBy = @UD_UserID, UUM_ModifiedDateTime =getDate() WHERE UUM_UserMenuID = @UUM_UserMenuID;

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'update successfully' AS RTN_MSG;
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
end
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_UserRole]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_modify_UserRole] 
(@UUR_UserRoleID VARCHAR(10), 
@UUR_UserRole VARCHAR(50), 
@UUR_Status BIT, 
@UD_UserID VARCHAR(10)


) 
AS BEGIN 
  BEGIN TRY
UPDATE tblUserRole SET UUR_UserRole = @UUR_UserRole, UUR_Status = @UUR_Status, UUR_ModifiedBy = @UD_UserID, UUR_ModifiedDateTime =getDate() WHERE UUR_UserRoleID = @UUR_UserRoleID;

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'update successfully' AS RTN_MSG;
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
end
GO

/****** Object:  StoredProcedure [dbo].[sp_removeaccess_UserMenu]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_removeaccess_UserMenu](@UMA_AccessGroupID varchar(50),@UMA_UserMenuID varchar(50),@ModifiedUser varchar(50)) as
begin
 BEGIN TRY
 if exists(select * from [tblMenuAccess]  WHERE [UMA_UserMenuID] = @UMA_UserMenuID AND UMA_AccessGroupID=@UMA_AccessGroupID)
 begin
 
 UPDATE [dbo].tblMenuAccess
   SET [UMA_Status] = 0
      ,[UMA_ModifiedBy] = @ModifiedUser
      ,[UMA_ModifiedDateTime] = getdate()
 WHERE [UMA_UserMenuID] = @UMA_UserMenuID AND UMA_AccessGroupID=@UMA_AccessGroupID

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'removed successfully' AS RTN_MSG;
end
else 
begin
 SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'record not exists' AS RTN_MSG;
end
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
end
GO

/****** Object:  StoredProcedure [dbo].[sp_upload_employee_documents]    Script Date: 9/22/2024 4:58:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_upload_employee_documents] 
(
@USRED_EmployeeID VARCHAR(50), 
@USRED_DocumentData varchar(max),
@USRED_DocumentType VARCHAR(50), 
@USRED_DocumentName VARCHAR(50), 
@USRED_Status BIT
) 
AS BEGIN 
INSERT INTO tblEmployee_EmployeeDocument (USRED_EmployeeID, USRED_DocumentData, USRED_DocumentType, USRED_DocumentName, USRED_Status)
VALUES (@USRED_EmployeeID, @USRED_DocumentData, @USRED_DocumentType, @USRED_DocumentName, @USRED_Status);
END;
GO


