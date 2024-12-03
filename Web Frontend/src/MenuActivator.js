
import { findAllByDisplayValue } from '@testing-library/react';
import { GetDisabled as GetDisabled_Attendance } from './MenuActivatorModules/Attendance_Activator.js'
import { GetDisabled as GetDisabled_Base } from './MenuActivatorModules/BaseModule_Activator.js'
import { GetDisabled as GetDisabled_Leave } from './MenuActivatorModules/Leave_Activator.js'
import { GetDisabled as GetDisabled_Payroll } from './MenuActivatorModules/Payroll_Activator.js'
import { GetDisabled as GetDisabled_ReportingPerson } from './MenuActivatorModules/ReportingPerson_Activator.js'

export const GetDisabled = (menuItem) => {
    let activated = false;
    if (activated === false)
        activated = GetDisabled_Attendance(menuItem);
    if (activated === false)
        activated = GetDisabled_Base(menuItem);
    if (activated === false)
        activated = GetDisabled_Leave(menuItem);
    if (activated === false)
        activated = GetDisabled_Payroll(menuItem);
    if (activated === false)
        activated = GetDisabled_ReportingPerson(menuItem);
    return activated;
};
