import { IMenuAccess } from "./components/types/LMSTypes";

export const setMenu = (menuItem: IMenuAccess[]) => {
    return menuItem.map((item: IMenuAccess) => {
        localStorage.setItem(item.name, item.active.valueOf().toString());
    });
};

export const gettutorial1 = () => {
    return localStorage.getItem('tutorial1');
};

export const getHRM_employee = () => {
    return localStorage.getItem('HRM_employee');
};
export const getHRM_customer = () => {
    return localStorage.getItem('HRM_customer');
};
export const getHRM_user = () => {
    return localStorage.getItem('HRM_user');
};
export const getAttendance = () => {
    return localStorage.getItem('Attendance');
};