
import { findAllByDisplayValue } from '@testing-library/react';
import {
    getMenu_HRM_ECustomer,
    getMenu_HRM_EEmployee,
    getMenu_HRM_EEmployeeJobDescription,
    getMenu_HRM_EGroup,
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
    getMenu_HRM_MDLocation,
    getMenu_HRM_MDJobType
} from '../MenuActivationModules/BaseModule_Activation'


let EGroup = getMenu_HRM_EGroup();
let ECustomer = getMenu_HRM_ECustomer();
let EEmployee = getMenu_HRM_EEmployee();
let EEmployeeJobDescription = getMenu_HRM_EEmployeeJobDescription();
let UMGroup = getMenu_HRM_UMGroup();
let UMInternalUser = getMenu_HRM_UMInternalUser();
let UMExternalUser = getMenu_HRM_UMExternelUser();
let UMUserRole = getMenu_HRM_UMUserRole();
let UMAccessGroup = getMenu_HRM_UMAccessGroup();
let UMMenuAccessGroup = getMenu_HRM_UMMenuAccessGroup();
let UMUserAccessGroup = getMenu_HRM_UMUserRoleAccessGroup();
let UMUserMenu = getMenu_HRM_UMUserMenu();
let MDGroup = getMenu_HRM_MDGroup();
let MDBranch = getMenu_HRM_MDBranch();
let MDCountry = getMenu_HRM_MDCountry();
let MDDepartment = getMenu_HRM_MDDepartment();
let MDJobRole = getMenu_HRM_MDJobRole();
let MDLocation = getMenu_HRM_MDLocation();
let MDJobType = getMenu_HRM_MDJobType();


export const GetDisabled = (menuItem) => {
    // console.log(menuItem)
    switch (menuItem) {
        case 'getMenu_HRM_MDBranch':
            {
                return getMenu_HRM_MDBranch();
            }
        case 'getMenu_HRM_ECustomer':
            {
                return getMenu_HRM_ECustomer();
            }
        case 'getMenu_HRM_EEmployee':
            {
                return getMenu_HRM_EEmployee();
            }
        case 'getMenu_HRM_EGroup':
            {
                return getMenu_HRM_EGroup();
            }
        case 'getMenu_HRM_MDCountry':
            {
                return getMenu_HRM_MDCountry();
            }
        case 'getMenu_HRM_MDDepartment':
            {
                return getMenu_HRM_MDDepartment();
            }
        case 'getMenu_HRM_MDLocation':
            {
                return getMenu_HRM_MDLocation();
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
