
import { findAllByDisplayValue } from '@testing-library/react';
import {
    getMenu_HRM_AAttendanceSearch,
    getMenu_HRM_AMarkAttendance,
    getMenu_HRM_AGroup,
} from '../MenuActivationModules/Attendance_Activation'


let AGroup = getMenu_HRM_AGroup();
let AAttendanceSearch = getMenu_HRM_AAttendanceSearch();
let AMarkAttendance = getMenu_HRM_AMarkAttendance();

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
        case 'getMenu_HRM_AMarkAttendance':
            {
                return getMenu_HRM_AMarkAttendance();
            }
        default:
            return false;
    }
};
