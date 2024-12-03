
import { findAllByDisplayValue } from '@testing-library/react';
import {
    getMenu_HRM_LGroup,
    getMenu_HRM_LLeaveSchedule,
    getMenu_HRM_LLeaveToApprove,
    getMenu_HRM_LLeaveEntitlement,
    getMenu_HRM_MDLeaveType
} from '../MenuActivationModules/Leave_Activation'


let LGroup = getMenu_HRM_LGroup();
let LLeaveSchedule = getMenu_HRM_LLeaveSchedule();
let LLeaveToApprove = getMenu_HRM_LLeaveToApprove();
let LLeaveEntitlement = getMenu_HRM_LLeaveEntitlement();
let MDLeaveType = getMenu_HRM_MDLeaveType();

export const GetDisabled = (menuItem) => {
    // console.log(menuItem)
    switch (menuItem) {
        case 'getMenu_HRM_MDLeaveType':
            {
                return getMenu_HRM_MDLeaveType();
            }
        case 'getMenu_HRM_LGroup':
            {
                return getMenu_HRM_LGroup();
            }
        case 'getMenu_HRM_LLeaveSchedule':
            {
                return getMenu_HRM_LLeaveSchedule();
            }
        case 'getMenu_HRM_LLeaveToApprove':
            {
                return getMenu_HRM_LLeaveToApprove();
            }
        case 'getMenu_HRM_LLeaveEntitlement':
            {
                return getMenu_HRM_LLeaveEntitlement();
            }
        default:
            return false;
    }
};
