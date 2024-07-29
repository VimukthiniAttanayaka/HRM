export const setMenu = (menuItem) => {
  return menuItem.map((item) => {
    console.log(item.menuName, item.active);
    localStorage.setItem(item.menuName, item.active);
  });
};

export const gettutorial1 = () => {
  return localStorage.getItem('tutorial1');
};

export const getMenu_HRM_employee = () => {
  let item1 = convertStringToBoolean(localStorage.getItem('HRM_employee'));
  return item1;
};
export const getMenu_HRM_customer = () => {
  let item1 = convertStringToBoolean(localStorage.getItem('HRM_Customer'));
  return item1;
};
export const getMenu_HRM_user = () => {
  return localStorage.getItem('HRM_user');
};
export const getMenu_Attendance = () => {
  return localStorage.getItem('Attendance');
};


export const convertStringToBoolean = (item) => {

  if (item === 'true') {
    return true;
  } else {
    return false;
  }
};
