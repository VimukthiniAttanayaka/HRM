USE [Neelaka1]
GO

/****** Object:  StoredProcedure [dbo].[sp_removeaccess_UserMenu]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_removeaccess_UserMenu]
GO

/****** Object:  StoredProcedure [dbo].[sp_removeaccess_UserGroup]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_removeaccess_UserGroup]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_UserRole]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_UserRole]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_UserMenu]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_UserMenu]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_user_internal]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_user_internal]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_user_external]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_user_external]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_SalaryType]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_SalaryType]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_Location]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_Location]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_LeaveType]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_LeaveType]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_JobType]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_JobType]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_JobRole]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_JobRole]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_employeereportingmanager]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_employeereportingmanager]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_employeeleaveentitlement]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_employeeleaveentitlement]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_employeejobrole]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_employeejobrole]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_employeeContact]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_employeeContact]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_employee]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_employee]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_department]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_department]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_customer]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_customer]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_Country]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_Country]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_Branch]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_Branch]
GO

/****** Object:  StoredProcedure [dbo].[sp_modify_AccessGroup]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_modify_AccessGroup]
GO

/****** Object:  StoredProcedure [dbo].[sp_IntApi_InsertAuditLog]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_IntApi_InsertAuditLog]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_UserRole]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_UserRole]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_UserMenu]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_UserMenu]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_user_internal]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_user_internal]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_user_external]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_user_external]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_SalaryType]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_SalaryType]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_Location]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_Location]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_LeaveType]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_LeaveType]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_JobType]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_JobType]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_JobRole]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_JobRole]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_employeetermination]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_employeetermination]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_employeesalary]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_employeesalary]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_employeereportingmanager]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_employeereportingmanager]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_EmployeeLeaveEntitlement]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_EmployeeLeaveEntitlement]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_employeejobrole]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_employeejobrole]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_employeedocument]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_employeedocument]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_employeeContact]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_employeeContact]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_employee]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_employee]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_department]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_department]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_customer]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_customer]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_Country]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_Country]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_Branch]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_Branch]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_Attendance]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_Attendance]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_AccessGroup]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_insert_AccessGroup]
GO

/****** Object:  StoredProcedure [dbo].[sp_grantaccess_UserMenu]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_grantaccess_UserMenu]
GO

/****** Object:  StoredProcedure [dbo].[sp_grantaccess_UserGroup]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_grantaccess_UserGroup]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserRole_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_UserRole_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserRole_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_UserRole_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserMenu_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_UserMenu_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserMenu_all_ForAccessGroup]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_UserMenu_all_ForAccessGroup]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserMenu_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_UserMenu_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_login]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_user_login]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_internal_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_user_internal_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_internal_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_user_internal_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_external_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_user_external_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_external_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_user_external_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_SalaryType_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_SalaryType_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_SalaryType_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_SalaryType_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_location_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_location_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_location_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_location_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_LeaveType_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_LeaveType_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_LeaveType_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_LeaveType_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_JobTypes_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_JobTypes_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_JobType_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_JobType_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_JobRoles_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_JobRoles_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_JobRole_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_JobRole_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeSalary_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_EmployeeSalary_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeSalary_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_EmployeeSalary_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employees_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_employees_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeReportingManager_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_EmployeeReportingManager_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeReportingManager_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_EmployeeReportingManager_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeLeaveEntitlement_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_EmployeeLeaveEntitlement_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeLeaveEntitlement_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_EmployeeLeaveEntitlement_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeJobRole_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_EmployeeJobRole_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeJobRole_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_EmployeeJobRole_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employeeDocument_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_employeeDocument_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employeeDocument_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_employeeDocument_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeContact_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_EmployeeContact_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeContact_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_EmployeeContact_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employee_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_employee_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_department_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_department_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_department_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_department_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_customers_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_customers_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_customer_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_customer_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Countrys_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_Countrys_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Country_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_Country_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Branchs_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_Branchs_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Branch_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_Branch_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Attendance_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_Attendance_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Attendance_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_Attendance_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_AccessGroup_single]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_AccessGroup_single]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_AccessGroup_all_ForUserRole]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_AccessGroup_all_ForUserRole]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_AccessGroup_all]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_get_AccessGroup_all]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_Location]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_del_Location]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_JobRole]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_del_JobRole]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_employee]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_del_employee]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_department]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_del_department]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_customer]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_del_customer]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_Country]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_del_Country]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_Branch]    Script Date: 10/1/2024 11:47:05 PM ******/
DROP PROCEDURE [dbo].[sp_del_Branch]
GO

/****** Object:  StoredProcedure [dbo].[sp_del_Branch]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_Branch]
(@MDB_BranchID VARCHAR(10),@UD_UserID VARCHAR(10)) AS BEGIN
UPDATE tblBranch SET MDB_Status = 0, MDB_ModifiedBy = @UD_UserID, MDB_ModifiedDateTime =getDate() WHERE MDB_BranchID = @MDB_BranchID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_del_Country]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_Country]
(@MDCTY_CountryID VARCHAR(10),@UD_UserID VARCHAR(10)) AS BEGIN
UPDATE tblCountry SET MDCTY_Status = 0, MDCTY_ModifiedBy = @UD_UserID, MDCTY_ModifiedDateTime =getDate() WHERE MDCTY_CountryID = @MDCTY_CountryID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_del_customer]    Script Date: 10/1/2024 11:47:05 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_del_department]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_department]
(@MDD_DepartmentID VARCHAR(10),@UD_UserID VARCHAR(10)) AS BEGIN
UPDATE tblDepartment SET MDD_Status = 0, MDD_ModifiedBy = @UD_UserID, MDD_ModifiedDateTime =getDate() WHERE MDD_DepartmentID = @MDD_DepartmentID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_del_employee]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_employee]
(@EME_EmployeeID VARCHAR(10),@UD_UserID VARCHAR(10)) AS BEGIN
UPDATE tblEmployee SET EME_Status = 0, EME_ModifiedBy = @UD_UserID, EME_ModifiedDateTime =getDate() WHERE EME_EmployeeID = @EME_EmployeeID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_del_JobRole]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_JobRole]
(@MDJR_JobRoleID VARCHAR(10),@UD_UserID VARCHAR(10)) AS BEGIN
UPDATE tblJobRole SET MDJR_Status = 0, MDJR_ModifiedBy = @UD_UserID, MDJR_ModifiedDateTime =getDate() WHERE MDJR_JobRoleID = @MDJR_JobRoleID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_del_Location]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_del_Location]
(@MDL_LocationID VARCHAR(10),@UD_UserID VARCHAR(10)) AS BEGIN
UPDATE tblLocation SET MDL_Status = 0, MDL_ModifiedBy = @UD_UserID, MDL_ModifiedDateTime =getDate() WHERE MDL_LocationID = @MDL_LocationID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_AccessGroup_all]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_AccessGroup_all]
AS BEGIN
SELECT * FROM tblAccessGroup;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_AccessGroup_all_ForUserRole]    Script Date: 10/1/2024 11:47:05 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_get_AccessGroup_single]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_AccessGroup_single]
(@UAG_AccessGroupID VARCHAR(10)) AS BEGIN
SELECT * FROM tblAccessGroup WHERE UAG_AccessGroupID = @UAG_AccessGroupID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Attendance_all]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   procedure [dbo].[sp_get_Attendance_all] as begin 
select * from tblAttendance; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Attendance_single]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   procedure [dbo].[sp_get_Attendance_single] (@EAT_ID int ) as begin 
select * from tblAttendance where EAT_ID=@EAT_ID; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Branch_all]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_Branch_all] as begin 
select * from tblBranch; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Branchs_single]    Script Date: 10/1/2024 11:47:05 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_get_Country_all]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_Country_all] as 
begin 
select * from tblCountry; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_Countrys_single]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_Countrys_single] (@MDCTY_CountryID varchar(10)) as 
begin 
select * from tblCountry where MDCTY_CountryID = @MDCTY_CountryID; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_customer_all]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_customer_all] as begin 
select * from tblCustomer; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_customers_single]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_customers_single] (@CUS_ID varchar(20)) as 
begin 
select * from tblcustomer where CUS_ID = @CUS_ID
end
GO

/****** Object:  StoredProcedure [dbo].[sp_get_department_all]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_department_all]
AS BEGIN
SELECT * FROM tblDepartment;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_department_single]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_department_single] 
(@MDD_DepartmentID VARCHAR(50))AS BEGIN
SELECT * FROM tblDepartment WHERE MDD_DepartmentID = @MDD_DepartmentID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employee_all]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[sp_get_employee_all] as 
begin 
select * from tblEmployee 
end
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeContact_all]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_get_EmployeeContact_all] (@EEC_EmployeeID varchar(20))
AS BEGIN
SELECT * FROM tblEmployee_Contact where EEC_EmployeeID=@EEC_EmployeeID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeContact_single]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE       PROCEDURE [dbo].[sp_get_EmployeeContact_single]
(@EEC_ID VARCHAR(50))
AS BEGIN
SELECT * FROM tblEmployee_Contact WHERE EEC_ID = @EEC_ID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employeeDocument_all]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_employeeDocument_all]
(@EED_EmployeeID VARCHAR(50))
AS BEGIN
SELECT * FROM tblEmployee_Document WHERE EED_EmployeeID = @EED_EmployeeID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employeeDocument_single]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_employeeDocument_single]
(@EED_EmployeeDocumentID VARCHAR(50))
AS BEGIN
SELECT * FROM tblEmployee_Document WHERE EED_EmployeeDocumentID = @EED_EmployeeDocumentID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeJobRole_all]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_get_EmployeeJobRole_all] (@EEJR_EmployeeID varchar(20))
AS BEGIN
SELECT * FROM tblEmployee_JobRole  where EEJR_EmployeeID=@EEJR_EmployeeID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeJobRole_single]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create     PROCEDURE [dbo].[sp_get_EmployeeJobRole_single]
(@EEJR_ID VARCHAR(50))
AS BEGIN
SELECT * FROM tblEmployee_JobRole WHERE EEJR_ID = @EEJR_ID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeLeaveEntitlement_all]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_get_EmployeeLeaveEntitlement_all](@EELE_EmployeeID varchar(20))
AS BEGIN
SELECT * FROM tblEmployee_LeaveEntitlement  where EELE_EmployeeID=@EELE_EmployeeID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeLeaveEntitlement_single]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE       PROCEDURE [dbo].[sp_get_EmployeeLeaveEntitlement_single]
(@EELE_ID VARCHAR(50))
AS BEGIN
SELECT * FROM tblEmployee_LeaveEntitlement WHERE EELE_ID = @EELE_ID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeReportingManager_all]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_get_EmployeeReportingManager_all](@EERM_EmployeeID varchar(20))
AS BEGIN
SELECT * FROM tblEmployee_ReportingManager where EERM_EmployeeID=@EERM_EmployeeID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeReportingManager_single]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE       PROCEDURE [dbo].[sp_get_EmployeeReportingManager_single]
(@EERM_ID VARCHAR(50))
AS BEGIN
SELECT * FROM tblEmployee_ReportingManager where EERM_ID=@EERM_ID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_employees_single]    Script Date: 10/1/2024 11:47:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_employees_single] (@EME_EmployeeID varchar(10)) as 
begin 
select * from tblEmployee where EME_EmployeeID = @EME_EmployeeID; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeSalary_all]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_get_EmployeeSalary_all] (@EES_EmployeeID varchar(20))
AS BEGIN
SELECT * FROM tblEmployee_Salary where EES_EmployeeID=@EES_EmployeeID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_EmployeeSalary_single]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create       PROCEDURE [dbo].[sp_get_EmployeeSalary_single]
(@EES_ID VARCHAR(50))
AS BEGIN
SELECT * FROM tblEmployee_Salary WHERE EES_ID = @EES_ID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_JobRole_all]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_JobRole_all]
AS BEGIN
SELECT * FROM tblJobRole;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_JobRoles_single]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_JobRoles_single]
(@MDJR_JobRoleID VARCHAR(10)) AS BEGIN
SELECT *,(select top 1 MDJR_Description from tblJobRoleDescription where MDJR_JobRoleID=@MDJR_JobRoleID) as MDJR_Description FROM tblJobRole WHERE MDJR_JobRoleID = @MDJR_JobRoleID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_JobType_all]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_get_JobType_all]
AS BEGIN
SELECT * FROM tblJobType;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_JobTypes_single]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_get_JobTypes_single]
(@MDJT_JobTypeID VARCHAR(10)) AS BEGIN
SELECT * FROM tblJobType WHERE MDJT_JobTypeID = @MDJT_JobTypeID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_LeaveType_all]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     procedure [dbo].[sp_get_LeaveType_all] as 
begin 
select * from tblLeaveType; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_LeaveType_single]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     procedure [dbo].[sp_get_LeaveType_single] (@MDLT_LeaveTypeID varchar(10)) as 
begin 
select * from tblLeaveType where MDLT_LeaveTypeID = @MDLT_LeaveTypeID; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_location_all]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_location_all] as 
begin 
select * from tblLocation; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_location_single]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_get_location_single] (@MDL_LocationID varchar(10)) as 
begin 
select * from tblLocation where MDL_LocationID = @MDL_LocationID; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_SalaryType_all]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   procedure [dbo].[sp_get_SalaryType_all] as 
begin 
select * from tblSalaryType; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_SalaryType_single]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   procedure [dbo].[sp_get_SalaryType_single] (@MDST_SalaryTypeID varchar(10)) as 
begin 
select * from tblSalaryType where MDST_SalaryTypeID = @MDST_SalaryTypeID; 
end;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_external_all]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[sp_get_user_external_all]
as
begin

select UE_UserID, UE_FirstName, UE_LastName, UE_EmailAddress, UE_MobileNumber, UE_PhoneNumber, UE_Remarks, UE_ActiveFrom, UE_ActiveTo, UE_Status, UE_Pwd, UE_PwdSalt, UE_PwdLastResetDateTime, UE_CreatedBy, 
                  UE_CreatedDateTime, UE_ModifiedBy, UE_ModifiedDateTime, UE_Otp, UE_Otp_Generate_On,UE_UserRoleId
 from [dbo].[tbl_user_external]

end
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_external_single]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[sp_get_user_external_single](@UE_UserID varchar(50))
as
begin

SELECT UE_UserID, UE_FirstName, UE_LastName, UE_EmailAddress, UE_MobileNumber, UE_PhoneNumber, UE_Remarks, UE_ActiveFrom, UE_ActiveTo, UE_Status, UE_Pwd, UE_PwdSalt, UE_PwdLastResetDateTime, UE_CreatedBy, 
                  UE_CreatedDateTime, UE_ModifiedBy, UE_ModifiedDateTime, UE_Otp, UE_Otp_Generate_On,UE_UserRoleId
FROM     tbl_user_external where UE_UserID=@UE_UserID
end
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_internal_all]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[sp_get_user_internal_all]
as
begin

select UE_UserID, UE_FirstName, UE_LastName, UE_EmailAddress, UE_MobileNumber, UE_PhoneNumber, UE_Remarks, UE_ActiveFrom, UE_ActiveTo, UE_Status, UE_Pwd, UE_PwdSalt, UE_PwdLastResetDateTime, UE_CreatedBy, 
                  UE_CreatedDateTime, UE_ModifiedBy, UE_ModifiedDateTime, UE_Otp, UE_Otp_Generate_On,UE_EmployeeID,UE_UserRoleId
 from [dbo].[tbl_user_internal]

end
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_internal_single]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[sp_get_user_internal_single](@UE_UserID varchar(50))
as
begin

SELECT UE_UserID, UE_FirstName, UE_LastName, UE_EmailAddress, UE_MobileNumber, UE_PhoneNumber, UE_Remarks, UE_ActiveFrom, UE_ActiveTo, UE_Status, UE_Pwd, UE_PwdSalt, UE_PwdLastResetDateTime, UE_CreatedBy, 
                  UE_CreatedDateTime, UE_ModifiedBy, UE_ModifiedDateTime, UE_Otp, UE_Otp_Generate_On,UE_EmployeeID,UE_UserRoleId
FROM     tbl_user_internal where UE_UserID=@UE_UserID
end
GO

/****** Object:  StoredProcedure [dbo].[sp_get_user_login]    Script Date: 10/1/2024 11:47:06 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_get_UserMenu_all]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_UserMenu_all]
AS BEGIN
SELECT * FROM tblUserMenu;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserMenu_all_ForAccessGroup]    Script Date: 10/1/2024 11:47:06 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_get_UserMenu_single]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_UserMenu_single]
(@UUM_UserMenuID VARCHAR(10)) AS BEGIN
SELECT * FROM tblUserMenu WHERE UUM_UserMenuID = @UUM_UserMenuID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserRole_all]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_UserRole_all]
AS BEGIN
SELECT * FROM tblUserRole;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_get_UserRole_single]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_get_UserRole_single]
(@UUR_UserRoleID VARCHAR(10)) AS BEGIN
SELECT * FROM tblUserRole WHERE UUR_UserRoleID = @UUR_UserRoleID;
END;
GO

/****** Object:  StoredProcedure [dbo].[sp_grantaccess_UserGroup]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_grantaccess_UserGroup](@UURAG_AccessGroupID varchar(50),@UURAG_UserRoleID varchar(50),@ModifiedUser varchar(50)) as
begin
 BEGIN TRY

 if not exists(select * from tblUserRoleAccessGroup  WHERE [UURAG_UserRoleID] = @UURAG_UserRoleID AND UURAG_AccessGroupID=@UURAG_AccessGroupID)
 begin
 INSERT INTO [dbo].tblUserRoleAccessGroup
           ([UURAG_UserRoleID]
           ,UURAG_AccessGroupID
           ,[UURAG_Status]
           ,[UURAG_CreatedBy]
           ,[UURAG_CreatedDateTime])
     VALUES
           (@UURAG_UserRoleID
           ,@UURAG_AccessGroupID
           ,1
           ,@ModifiedUser
           ,getdate())

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'granted successfully' AS RTN_MSG;
end
else 
begin
  UPDATE [dbo].tblUserRoleAccessGroup
   SET [UURAG_Status] = 1
      ,[UURAG_ModifiedBy] = @ModifiedUser
      ,[UURAG_ModifiedDateTime] = getdate()
 WHERE [UURAG_UserRoleID] = @UURAG_UserRoleID AND UURAG_AccessGroupID=@UURAG_AccessGroupID

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

/****** Object:  StoredProcedure [dbo].[sp_grantaccess_UserMenu]    Script Date: 10/1/2024 11:47:06 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_insert_AccessGroup]    Script Date: 10/1/2024 11:47:06 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_insert_Attendance]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   procedure [dbo].[sp_insert_Attendance] 
(@EAT_EmployeeID VARCHAR(10), 
@EAT_Location_latitude VARCHAR(50), 
@EAT_Location_longitude VARCHAR(50),
@UD_UserID VARCHAR(10)
) 
AS BEGIN 

 BEGIN TRY
  
   if exists (select * from tblAttendance where EAT_EmployeeID=@EAT_EmployeeID and FORMAT (EAT_AttendanceDate,'yyyyMMdd')=FORMAT (getdate(),'yyyyMMdd'))
   begin
   update tblAttendance set EAT_OutTime=getDate() where EAT_EmployeeID=@EAT_EmployeeID and FORMAT (EAT_AttendanceDate,'yyyyMMdd')=FORMAT (getdate(),'yyyyMMdd')
   end
   else
   begin
	INSERT INTO tblAttendance ( EAT_EmployeeID, EAT_AttendanceDate,EAT_InTime, EAT_Location_latitude,EAT_Location_longitude, EAT_Status, EAT_CreatedBy, EAT_CreatedDateTime)
	VALUES (@EAT_EmployeeID, getDate(),getDate(), @EAT_Location_latitude,@EAT_Location_longitude, 1, @UD_UserID, getDate());
	end
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

/****** Object:  StoredProcedure [dbo].[sp_insert_Branch]    Script Date: 10/1/2024 11:47:06 PM ******/
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
 BEGIN TRY
  
   if exists (select * from tblBranch where MDB_BranchID=@MDB_BranchID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'branch exists' AS RTN_MSG;
	return

   end

INSERT INTO tblBranch (MDB_BranchID, MDB_Branch, MDB_Status, MDB_CreatedBy, MDB_CreatedDateTime)
VALUES (@MDB_BranchID, @MDB_Branch, @MDB_Status, @UD_UserID, getDate());

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

/****** Object:  StoredProcedure [dbo].[sp_insert_Country]    Script Date: 10/1/2024 11:47:06 PM ******/
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
 BEGIN TRY
  
   if exists (select * from tblCountry where MDCTY_CountryID=@MDCTY_CountryID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'country exists' AS RTN_MSG;
	return

   end

INSERT INTO tblCountry (MDCTY_CountryID, MDCTY_Country, MDCTY_Status, MDCTY_CreatedBy, MDCTY_CreatedDateTime)
VALUES (@MDCTY_CountryID, @MDCTY_Country, @MDCTY_Status, @UD_UserID, getDate());

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

/****** Object:  StoredProcedure [dbo].[sp_insert_customer]    Script Date: 10/1/2024 11:47:06 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_insert_department]    Script Date: 10/1/2024 11:47:06 PM ******/
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

 BEGIN TRY
  
   if exists (select * from tblDepartment where MDD_DepartmentID=@MDD_DepartmentID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'department exists' AS RTN_MSG;
	return

   end
INSERT INTO tblDepartment (MDD_DepartmentID, MDD_Department, MDD_LocationID, MDD_Status, MDD_CreatedBy, MDD_CreatedDateTime)
VALUES (@MDD_DepartmentID, @MDD_Department, @MDD_LocationID, @MDD_Status, @UD_UserID, getDate());

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

/****** Object:  StoredProcedure [dbo].[sp_insert_employee]    Script Date: 10/1/2024 11:47:06 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_insert_employeeContact]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_insert_employeeContact] 
(
@EEC_EmployeeID VARCHAR(20), 
@EEC_Address varchar(200),
@EEC_EmailAddress varchar(100), 
@EEC_MobileNumber varchar(20), 
@EEC_PhoneNumber1 varchar(20), 
@EEC_PhoneNumber2 varchar(20),
@EEC_Remarks VARCHAR(max), 
@EEC_Status BIT,
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
  BEGIN TRY

INSERT INTO [dbo].[tblEmployee_Contact]
           ([EEC_EmployeeID]        
			,EEC_Address
			,EEC_EmailAddress
			,EEC_MobileNumber
			,EEC_PhoneNumber1
			,EEC_PhoneNumber2
           ,[EEC_Status]
           ,[EEC_CreatedDateTime]
		   ,EEC_CreatedBy
           ,[EEC_Remarks])
     VALUES
           (@EEC_EmployeeID           
			,@EEC_Address
			,@EEC_EmailAddress
			,@EEC_MobileNumber
			,@EEC_PhoneNumber1
			,@EEC_PhoneNumber2
           ,@EEC_Status
           ,getdate()
		   ,@UD_UserID
           ,@EEC_Remarks)

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

/****** Object:  StoredProcedure [dbo].[sp_insert_employeedocument]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_insert_employeedocument] 
(
@EED_EmployeeID VARCHAR(50), 
@EED_DocumentData varchar(max),
@EED_DocumentType VARCHAR(50), 
@EED_DocumentName VARCHAR(50), 
@EED_Status BIT
) 
AS BEGIN 
  BEGIN TRY

INSERT INTO tblEmployee_Document (EED_EmployeeID, EED_DocumentData, EED_DocumentType, EED_DocumentName, EED_Status)
VALUES (@EED_EmployeeID, @EED_DocumentData, @EED_DocumentType, @EED_DocumentName, @EED_Status);

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

/****** Object:  StoredProcedure [dbo].[sp_insert_employeejobrole]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_insert_employeejobrole] 
(
@EEJR_EmployeeID VARCHAR(20), 
@EEJR_JobRoleID varchar(20),
@EEJR_ActiveFrom datetime,
@EEJR_ActiveTo datetime, 
@EEJR_Remarks VARCHAR(max), 
@EEJR_Status BIT,
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
  BEGIN TRY

INSERT INTO [dbo].[tblEmployee_JobRole]
           ([EEJR_EmployeeID]
           ,[EEJR_JobRoleID]
           ,[EEJR_ActiveFrom]
           ,[EEJR_ActiveTo]
           ,[EEJR_Status]
           ,[EEJR_CreatedDateTime]
		   ,EEJR_CreatedBy
           ,[EEJR_Remarks])
     VALUES
           (@EEJR_EmployeeID
           ,@EEJR_JobRoleID
           ,@EEJR_ActiveFrom
           ,@EEJR_ActiveTo
           ,@EEJR_Status
           ,getdate()
		   ,@UD_UserID
           ,@EEJR_Remarks)

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

/****** Object:  StoredProcedure [dbo].[sp_insert_EmployeeLeaveEntitlement]    Script Date: 10/1/2024 11:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create         PROCEDURE [dbo].[sp_insert_EmployeeLeaveEntitlement] 
(
@EELE_EmployeeID varchar(20)
,@EELE_LeaveTypeID  varchar(20)
,@EELE_LeaveAlotment int
,@EELE_ActiveFrom date
,@EELE_ActiveTo date
,@UD_UserID VARCHAR(10)
) 
AS BEGIN 
  BEGIN TRY

  INSERT INTO [dbo].tblEmployee_LeaveEntitlement
           (EELE_EmployeeID
           ,EELE_LeaveTypeID  
           ,EELE_LeaveAlotment  
		   ,EELE_ActiveFrom
		   ,EELE_ActiveTo
		   ,EELE_Remain
           ,[EELE_Status]
           ,[EELE_CreatedBy]
           ,[EELE_CreatedDateTime])
     VALUES        
		(@EELE_EmployeeID
           ,@EELE_LeaveTypeID 
           ,@EELE_LeaveAlotment
		   , @EELE_ActiveFrom
		   , @EELE_ActiveTo
		   ,@EELE_LeaveAlotment
           ,1 
           ,@UD_UserID 
           ,getdate()  )

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

/****** Object:  StoredProcedure [dbo].[sp_insert_employeereportingmanager]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_insert_employeereportingmanager] 
(
		@EERM_EmployeeID varchar(20)
           ,@EERM_ReportingManagerID varchar(20)
           ,@EERM_Status bit
           ,@EERM_Remarks varchar(max)
           ,@EERM_ActiveFrom date
           ,@EERM_ActiveTo date,
			@UD_UserID VARCHAR(10)
) 
AS BEGIN 
  BEGIN TRY

INSERT INTO [dbo].[tblEmployee_ReportingManager]
           ([EERM_EmployeeID]
           ,[EERM_ReportingManagerID]
           ,[EERM_Status]
           ,[EERM_Remarks]
           ,[EERM_ActiveFrom]
           ,[EERM_ActiveTo]
           ,[EERM_CreatedDateTime]
		   ,EERM_CreatedBy)
     VALUES
           (@EERM_EmployeeID
           ,@EERM_ReportingManagerID
           ,@EERM_Status
           ,@EERM_Remarks
           ,@EERM_ActiveFrom
           ,@EERM_ActiveTo
		   ,getdate()
		   ,@UD_UserID)

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

/****** Object:  StoredProcedure [dbo].[sp_insert_employeesalary]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_insert_employeesalary] 
(
@EES_EmployeeID varchar(20)
,@EES_Salary decimal(18,2)
,@EES_ActiveFrom date
,@EES_ActiveTo date
,@EES_Status bit
,@EES_Remarks varchar(max)
,@EES_SalaryType varchar(20)
,@UD_UserID VARCHAR(10)
) 
AS BEGIN 
  BEGIN TRY

INSERT INTO [dbo].[tblEmployee_Salary]
           ([EES_EmployeeID]
           ,[EES_Salary]
           ,[EES_ActiveFrom]
           ,[EES_ActiveTo]
           ,[EES_Status]
           ,[EES_CreatedBy]
           ,[EES_CreatedDateTime]
           ,[EES_Remarks]
           ,[EES_SalaryType])
     VALUES
           (@EES_EmployeeID 
           ,@EES_Salary 
           ,@EES_ActiveFrom 
           ,@EES_ActiveTo 
           ,@EES_Status 
           ,@UD_UserID 
           ,getdate() 
           ,@EES_Remarks 
           ,@EES_SalaryType )

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

/****** Object:  StoredProcedure [dbo].[sp_insert_employeetermination]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE       PROCEDURE [dbo].[sp_insert_employeetermination] 
(
@EET_EmployeeID varchar(20)
,@EET_IsForceTerminated bit
,@EET_IsBlackListed bit
,@EET_Remarks varchar(max)
,@UD_UserID VARCHAR(10)
) 
AS BEGIN 
  BEGIN TRY

  if exists (select * from tblEmployee_Termination where EET_Status=1)
  begin
  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'allready terminated employee' AS RTN_MSG;
			return
  end
  else 
  begin
INSERT INTO [dbo].tblEmployee_Termination
           ([EET_EmployeeID]
           ,EET_IsForceTerminated 
           ,EET_IsBlackListed 
           ,[EET_Status]
           ,[EET_CreatedBy]
           ,[EET_CreatedDateTime]
           ,[EET_Remarks])
     VALUES
           (@EET_EmployeeID 
           ,@EET_IsForceTerminated 
           ,@EET_IsBlackListed 
           ,1 
           ,@UD_UserID 
           ,getdate() 
           ,@EET_Remarks  )

  SELECT  1 AS RTN_TYPE ,
            'true' AS RTN_RESP ,
            'update successfully' AS RTN_MSG;
end
 END TRY
BEGIN CATCH

    SELECT  2 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            ERROR_MESSAGE() AS RTN_MSG;
END CATCH
end
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_JobRole]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_insert_JobRole] 
(@MDJR_JobRoleID VARCHAR(10), 
@MDJR_JobRole VARCHAR(50), 
@MDJR_Status BIT, 
@MDJR_Description text,
@UD_UserID VARCHAR(10)
) 
AS BEGIN 

 BEGIN TRY
  
   if exists (select * from tblJobRole where MDJR_JobRoleID=@MDJR_JobRoleID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'job role exists' AS RTN_MSG;
	return

   end
INSERT INTO tblJobRole (MDJR_JobRoleID, MDJR_JobRole, MDJR_Status, MDJR_CreatedBy, MDJR_CreatedDateTime)
VALUES (@MDJR_JobRoleID, @MDJR_JobRole, @MDJR_Status, @UD_UserID, getDate());

INSERT INTO tblJobRoleDescription (MDJR_JobRoleID, MDJR_Description)
VALUES (@MDJR_JobRoleID, @MDJR_Description);

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

/****** Object:  StoredProcedure [dbo].[sp_insert_JobType]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_insert_JobType] 
(@MDJT_JobTypeID VARCHAR(10), 
@MDJT_JobType VARCHAR(50), 
@MDJT_Status BIT, 
@MDJT_Description VARCHAR(200),
@UD_UserID VARCHAR(10)
) 
AS BEGIN 

 BEGIN TRY
  
   if exists (select * from tblJobType where MDJT_JobTypeID=@MDJT_JobTypeID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'job type exists' AS RTN_MSG;
	return

   end
INSERT INTO tblJobType (MDJT_JobTypeID, MDJT_JobType, MDJT_Status, MDJT_CreatedBy, MDJT_CreatedDateTime,MDJT_Description)
VALUES (@MDJT_JobTypeID, @MDJT_JobType, @MDJT_Status, @UD_UserID, getDate(),@MDJT_Description);

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

/****** Object:  StoredProcedure [dbo].[sp_insert_LeaveType]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_insert_LeaveType] 
(@MDLT_LeaveTypeID VARCHAR(10), 
@MDLT_LeaveType VARCHAR(50),  
@MDLT_Description VARCHAR(200),
@MDLT_LeaveAlotment int,
@MDLT_Duration int,
@MDLT_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
 BEGIN TRY
  
   if exists (select * from tblLeaveType where MDLT_LeaveTypeID=@MDLT_LeaveTypeID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'LeaveType exists' AS RTN_MSG;
	return

   end

INSERT INTO tblLeaveType (MDLT_LeaveTypeID, MDLT_LeaveType, MDLT_Status, MDLT_CreatedBy, MDLT_CreatedDateTime, MDLT_Description,MDLT_LeaveAlotment,MDLT_Duration)
VALUES (@MDLT_LeaveTypeID, @MDLT_LeaveType, @MDLT_Status, @UD_UserID, getDate(),@MDLT_Description,@MDLT_LeaveAlotment,@MDLT_Duration);

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

/****** Object:  StoredProcedure [dbo].[sp_insert_Location]    Script Date: 10/1/2024 11:47:07 PM ******/
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
 BEGIN TRY
  
   if exists (select * from tblLocation where MDL_LocationID=@MDL_LocationID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'location exists' AS RTN_MSG;
	return

   end

INSERT INTO tblLocation (MDL_LocationID, MDL_Location, MDL_Status, MDL_CreatedBy, MDL_CreatedDateTime)
VALUES (@MDL_LocationID, @MDL_Location, @MDL_Status, @UD_UserID, getDate());

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

/****** Object:  StoredProcedure [dbo].[sp_insert_SalaryType]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_insert_SalaryType] 
(@MDST_SalaryTypeID VARCHAR(10), 
@MDST_SalaryType VARCHAR(50),  
@MDST_Description VARCHAR(200), 
@MDST_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
 BEGIN TRY
  
   if exists (select * from tblSalaryType where MDST_SalaryTypeID=@MDST_SalaryTypeID)
   begin
   SELECT  1 AS RTN_TYPE ,
            'false' AS RTN_RESP ,
            'SalaryType exists' AS RTN_MSG;
	return

   end

INSERT INTO tblSalaryType (MDST_SalaryTypeID, MDST_SalaryType, MDST_Status, MDST_CreatedBy, MDST_CreatedDateTime, MDST_Description)
VALUES (@MDST_SalaryTypeID, @MDST_SalaryType, @MDST_Status, @UD_UserID, getDate(),@MDST_Description);

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

/****** Object:  StoredProcedure [dbo].[sp_insert_user_external]    Script Date: 10/1/2024 11:47:07 PM ******/
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
      ,@ModifiedUser varchar(50)
      ,@UE_UserRoleId varchar(20))
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
           ,[UE_ModifiedDateTime]
		   ,UE_UserRoleId)
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
           ,getdate()
		   ,@UE_UserRoleId)

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

/****** Object:  StoredProcedure [dbo].[sp_insert_user_internal]    Script Date: 10/1/2024 11:47:07 PM ******/
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
      ,@ModifiedUser varchar(50)
      ,@UE_UserRoleId varchar(20))
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
           ,[UE_ModifiedDateTime]
		   ,UE_UserRoleId)
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
           ,getdate()
		   ,@UE_UserRoleId)

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

/****** Object:  StoredProcedure [dbo].[sp_insert_UserMenu]    Script Date: 10/1/2024 11:47:07 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_insert_UserRole]    Script Date: 10/1/2024 11:47:07 PM ******/
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
            'user role exists' AS RTN_MSG;
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

/****** Object:  StoredProcedure [dbo].[sp_IntApi_InsertAuditLog]    Script Date: 10/1/2024 11:47:07 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_modify_AccessGroup]    Script Date: 10/1/2024 11:47:07 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_modify_Branch]    Script Date: 10/1/2024 11:47:07 PM ******/
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
 BEGIN TRY
  
UPDATE tblBranch SET MDB_Branch = @MDB_Branch, MDB_Status = @MDB_Status, MDB_ModifiedBy = @UD_UserID, MDB_ModifiedDateTime =getDate() WHERE MDB_BranchID = @MDB_BranchID;

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

/****** Object:  StoredProcedure [dbo].[sp_modify_Country]    Script Date: 10/1/2024 11:47:07 PM ******/
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
 BEGIN TRY
  
UPDATE tblCountry SET MDCTY_Country = @MDCTY_Country, MDCTY_Status = @MDCTY_Status, MDCTY_ModifiedBy = @UD_UserID, MDCTY_ModifiedDateTime =getDate() WHERE MDCTY_CountryID = @MDCTY_CountryID;

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

/****** Object:  StoredProcedure [dbo].[sp_modify_customer]    Script Date: 10/1/2024 11:47:07 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_modify_department]    Script Date: 10/1/2024 11:47:07 PM ******/
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
 BEGIN TRY
  
UPDATE tblDepartment SET MDD_Department = @MDD_Department, MDD_LocationID = @MDD_LocationID,  MDD_Status = @MDD_Status, MDD_ModifiedBy = @UD_UserID, MDD_ModifiedDateTime =getDate() WHERE MDD_DepartmentID = @MDD_DepartmentID;

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

/****** Object:  StoredProcedure [dbo].[sp_modify_employee]    Script Date: 10/1/2024 11:47:07 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_modify_employeeContact]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_modify_employeeContact]
(
@EEC_ID int,
@EEC_EmployeeID VARCHAR(20), 
@EEC_Address varchar(200),
@EEC_EmailAddress varchar(100), 
@EEC_MobileNumber varchar(20), 
@EEC_PhoneNumber1 varchar(20), 
@EEC_PhoneNumber2 varchar(20),
@EEC_Remarks VARCHAR(max), 
@EEC_Status BIT,
@UD_UserID VARCHAR(10)
) AS BEGIN
 BEGIN TRY
  
UPDATE [dbo].[tblEmployee_Contact]
   SET [EEC_EmployeeID] = @EEC_EmployeeID
      ,EEC_Address = @EEC_Address
      ,EEC_EmailAddress = @EEC_EmailAddress
      ,EEC_MobileNumber = @EEC_MobileNumber
	  ,EEC_PhoneNumber1=@EEC_PhoneNumber1
	  ,EEC_PhoneNumber2=@EEC_PhoneNumber2
      ,[EEC_Status] = @EEC_Status
      ,[EEC_ModifiedBy] = @UD_UserID
      ,[EEC_ModifiedDateTime] = getDate()
      ,[EEC_Remarks] = @EEC_Remarks
	  WHERE EEC_ID = @EEC_ID;

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

/****** Object:  StoredProcedure [dbo].[sp_modify_employeejobrole]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_modify_employeejobrole]
(
@EEJR_ID int,
@EEJR_EmployeeID VARCHAR(20), 
@EEJR_JobRoleID varchar(20),
@EEJR_ActiveFrom datetime,
@EEJR_ActiveTo datetime, 
@EEJR_Remarks VARCHAR(max), 
@EEJR_Status BIT,
@UD_UserID VARCHAR(10)
) AS BEGIN
 BEGIN TRY
  
UPDATE [dbo].[tblEmployee_JobRole]
   SET [EEJR_EmployeeID] = @EEJR_EmployeeID
      ,[EEJR_JobRoleID] = @EEJR_JobRoleID
      ,[EEJR_ActiveFrom] = @EEJR_ActiveFrom
      ,[EEJR_ActiveTo] = @EEJR_ActiveTo
      ,[EEJR_Status] = @EEJR_Status
      ,[EEJR_ModifiedBy] = @UD_UserID
      ,[EEJR_ModifiedDateTime] = getDate()
      ,[EEJR_Remarks] = @EEJR_Remarks
	  WHERE EEJR_ID = @EEJR_ID;

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

/****** Object:  StoredProcedure [dbo].[sp_modify_employeeleaveentitlement]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_modify_employeeleaveentitlement]
(
@EELE_ID int,
@EELE_EmployeeID varchar(20)
,@EELE_LeaveTypeID  varchar(20)
,@EELE_LeaveAlotment int
,@EELE_ActiveFrom date
,@EELE_ActiveTo date
,@EELE_Status bit
,@UD_UserID VARCHAR(10)
) AS BEGIN
 BEGIN TRY
  
UPDATE [dbo].[tblEmployee_LeaveType]
   SET [EELE_LeaveTypeID] = @EELE_LeaveTypeID
      ,[EELE_ActiveFrom] = @EELE_ActiveFrom
      ,[EELE_ActiveTo] = @EELE_ActiveTo
      ,[EELE_Status] = @EELE_Status
      ,[EELE_ModifiedBy] = @UD_UserID
	  ,EELE_LeaveAlotment=@EELE_LeaveAlotment
      ,[EELE_ModifiedDateTime] = getDate()
      --,[EELE_Remarks] = @EELE_Remarks
	  WHERE EELE_ID = @EELE_ID;

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

/****** Object:  StoredProcedure [dbo].[sp_modify_employeereportingmanager]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_modify_employeereportingmanager]
(
@EERM_ID int 
,@EERM_EmployeeID varchar(20)
,@EERM_ReportingManagerID varchar(20)
,@EERM_Status bit
,@EERM_Remarks varchar(max)
,@EERM_ActiveFrom date
,@EERM_ActiveTo date,
@UD_UserID VARCHAR(10)
) AS BEGIN
 BEGIN TRY
  
UPDATE [dbo].[tblEmployee_ReportingManager]
   SET [EERM_EmployeeID] = @EERM_EmployeeID
      ,[EERM_ReportingManagerID] = @EERM_ReportingManagerID
      ,[EERM_Status] = @EERM_Status
      ,[EERM_ModifiedBy] = @UD_UserID
      ,[EERM_ModifiedDateTime] =getdate()
      ,[EERM_Remarks] = @EERM_Remarks
      ,[EERM_ActiveFrom] = @EERM_ActiveFrom
      ,[EERM_ActiveTo] = @EERM_ActiveTo
	  
WHERE EERM_ID = @EERM_ID;

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

/****** Object:  StoredProcedure [dbo].[sp_modify_JobRole]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_modify_JobRole] 
(@MDJR_JobRoleID VARCHAR(10), 
@MDJR_JobRole VARCHAR(50), 
@MDJR_Status BIT, 
@MDJR_Description text,
@UD_UserID VARCHAR(10)
) 
AS BEGIN 

 BEGIN TRY
  
UPDATE tblJobRole SET MDJR_JobRole = @MDJR_JobRole, MDJR_Status = @MDJR_Status,
MDJR_ModifiedBy = @UD_UserID, MDJR_ModifiedDateTime =getDate()
WHERE MDJR_JobRoleID = @MDJR_JobRoleID;

if NOT exists (select * from tblJobRoleDescription where MDJR_JobRoleID=@MDJR_JobRoleID)
   begin   
INSERT INTO tblJobRoleDescription (MDJR_JobRoleID, MDJR_Description)
VALUES (@MDJR_JobRoleID, @MDJR_Description);
   end

UPDATE tblJobRoleDescription SET
MDJR_Description=@MDJR_Description
WHERE MDJR_JobRoleID = @MDJR_JobRoleID;

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

/****** Object:  StoredProcedure [dbo].[sp_modify_JobType]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_modify_JobType] 
(@MDJT_JobTypeID VARCHAR(10), 
@MDJT_JobType VARCHAR(50), 
@MDJT_Description VARCHAR(200), 
@MDJT_Status BIT,
@UD_UserID VARCHAR(10)
) 
AS BEGIN 

 BEGIN TRY
  
UPDATE tblJobType SET MDJT_JobType = @MDJT_JobType, MDJT_Status = @MDJT_Status,MDJT_Description=@MDJT_Description,
MDJT_ModifiedBy = @UD_UserID, MDJT_ModifiedDateTime =getDate()
WHERE MDJT_JobTypeID = @MDJT_JobTypeID;

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

/****** Object:  StoredProcedure [dbo].[sp_modify_LeaveType]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[sp_modify_LeaveType] 
(@MDLT_LeaveTypeID VARCHAR(10), 
@MDLT_LeaveType VARCHAR(50), 
@MDLT_Description VARCHAR(200), 
@MDLT_LeaveAlotment int,
@MDLT_Duration int,
@MDLT_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
 BEGIN TRY
  
UPDATE tblLeaveType SET MDLT_LeaveType = @MDLT_LeaveType, MDLT_Status = @MDLT_Status, MDLT_ModifiedBy = @UD_UserID, MDLT_ModifiedDateTime =getDate(),MDLT_Description=@MDLT_Description,
MDLT_LeaveAlotment=@MDLT_LeaveAlotment,MDLT_Duration=@MDLT_Duration
WHERE MDLT_LeaveTypeID = @MDLT_LeaveTypeID;

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

/****** Object:  StoredProcedure [dbo].[sp_modify_Location]    Script Date: 10/1/2024 11:47:07 PM ******/
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
 BEGIN TRY
  
UPDATE tblLocation SET MDL_Location = @MDL_Location, MDL_Status = @MDL_Status, MDL_ModifiedBy = @UD_UserID, MDL_ModifiedDateTime =getDate() WHERE MDL_LocationID = @MDL_LocationID;

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

/****** Object:  StoredProcedure [dbo].[sp_modify_SalaryType]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[sp_modify_SalaryType] 
(@MDST_SalaryTypeID VARCHAR(10), 
@MDST_SalaryType VARCHAR(50), 
@MDST_Description VARCHAR(200), 
@MDST_Status BIT, 
@UD_UserID VARCHAR(10)
) 
AS BEGIN 
 BEGIN TRY
  
UPDATE tblSalaryType SET MDST_SalaryType = @MDST_SalaryType, MDST_Status = @MDST_Status, MDST_ModifiedBy = @UD_UserID, MDST_ModifiedDateTime =getDate(),MDST_Description=@MDST_Description
WHERE MDST_SalaryTypeID = @MDST_SalaryTypeID;

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

/****** Object:  StoredProcedure [dbo].[sp_modify_user_external]    Script Date: 10/1/2024 11:47:07 PM ******/
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
      ,@UE_UserRoleId varchar(20)
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
	  ,UE_UserRoleId=@UE_UserRoleId
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

/****** Object:  StoredProcedure [dbo].[sp_modify_user_internal]    Script Date: 10/1/2024 11:47:07 PM ******/
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
      ,@UE_UserRoleId varchar(20)
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
	  ,UE_UserRoleId=@UE_UserRoleId
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

/****** Object:  StoredProcedure [dbo].[sp_modify_UserMenu]    Script Date: 10/1/2024 11:47:07 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_modify_UserRole]    Script Date: 10/1/2024 11:47:07 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_removeaccess_UserGroup]    Script Date: 10/1/2024 11:47:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_removeaccess_UserGroup](@UURAG_AccessGroupID varchar(50),@UURAG_UserRoleID varchar(50),@ModifiedUser varchar(50)) as
begin
 BEGIN TRY
 if exists(select * from tblUserRoleAccessGroup  WHERE [UURAG_UserRoleID] = @UURAG_UserRoleID AND UURAG_AccessGroupID=@UURAG_AccessGroupID)
 begin
 
 UPDATE [dbo].tblUserRoleAccessGroup
   SET [UURAG_Status] = 0
      ,[UURAG_ModifiedBy] = @ModifiedUser
      ,[UURAG_ModifiedDateTime] = getdate()
 WHERE [UURAG_UserRoleID] = @UURAG_UserRoleID AND UURAG_AccessGroupID=@UURAG_AccessGroupID

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

/****** Object:  StoredProcedure [dbo].[sp_removeaccess_UserMenu]    Script Date: 10/1/2024 11:47:08 PM ******/
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


