
import { findAllByDisplayValue } from '@testing-library/react';
import {
    getMenu_HRM_ECustomer,
    getMenu_HRM_EEmployee,
    getMenu_HRM_EEmployeeJobDiscription,
    getMenu_HRM_EGroup,
    getMenu_HRM_AAttendanceSearch,
    getMenu_HRM_AMarkAttendance,
    getMenu_HRM_AGroup,
    getMenu_HRM_LGroup,
    getMenu_HRM_LLeaveSchedule,
    getMenu_HRM_LLeaveToApprove,
    getMenu_HRM_LLeaveEntitlement,
    getMenu_HRM_LLeaveType,
    getMenu_HRM_RPGroup,
    getMenu_HRM_RPHierarchyManagement,
    getMenu_HRM_RPReportingPerson,
    getMenu_HRM_RPReportingManagerSearch,
    getMenu_HRM_UMGroup,
    getMenu_HRM_UMInternalUser,
    getMenu_HRM_UMExternelUser,
    getMenu_HRM_UMUserRole,
    getMenu_HRM_UMAccessGroup,
    getMenu_HRM_UMMenuAccessGroup,
    getMenu_HRM_UMUserRoleAccessGroup,
    getMenu_HRM_UMUserMenu,
    getMenu_HRM_MDGroup,
    getMenu_HRM_MDBranch,
    getMenu_HRM_MDCountry,
    getMenu_HRM_MDDepartment,
    getMenu_HRM_MDJobRole,
} from './menuActivation'

export const GetDisabled = (menuItem) => {
    // console.log(menuItem)
    switch (menuItem) {
        case 'getMenu_HRM_AGroup':
            {
                return getMenu_HRM_AGroup();
            }
        case 'getMenu_HRM_AAttendanceSearch':
            {                
                return getMenu_HRM_AAttendanceSearch();
            }
        case 'dashboard':
            {
                return true;
            }
        case 'login':
            {
                return true;
            }
        case 'profile':
            {
                return true;
            }
        case 'ForgetPassword':
            {
                return true;
            }
        default:
            return false;
    }
};
