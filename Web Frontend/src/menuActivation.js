
export const setMenu = (menuItem) => {
  return menuItem.map((item) => {
    localStorage.setItem(item.name, item.active.valueOf().toString());
  });
};

export const gettutorial1 = () => {
  return localStorage.getItem('tutorial1');
};

export const getMenu_HRM_employee = () => {
  return localStorage.getItem('HRM_employee');
};
export const getMenu_HRM_customer = () => {
  return localStorage.getItem('HRM_customer');
};
export const getMenu_HRM_user = () => {
  return localStorage.getItem('HRM_user');
};
export const getMenu_Attendance = () => {
  return localStorage.getItem('Attendance');
};
