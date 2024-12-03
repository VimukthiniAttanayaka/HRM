
import { findAllByDisplayValue } from '@testing-library/react';
import {
    getMenu_HRM_MDSalaryType,
    getMenu_HRM_MDJobType,
} from '../MenuActivationModules/Payroll_Activation'


let MDSalaryType = getMenu_HRM_MDSalaryType();
let MDJobType = getMenu_HRM_MDJobType();


export const GetDisabled = (menuItem) => {
    // console.log(menuItem)
    switch (menuItem) {
               case 'getMenu_HRM_MDSalaryType':
            {
                return getMenu_HRM_MDSalaryType();
            }
        case 'getMenu_HRM_MDJobType':
            {
                return getMenu_HRM_MDJobType();
            }      
        default:
            return false;
    }
};
