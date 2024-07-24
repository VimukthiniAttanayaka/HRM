const apiUrl = process.env.REACT_APP_API_URL;

export class UserMenuDetail {
  constructor(id, usermenu, status, Alotment) {
    this.usermenu = usermenu;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getUserMenuAll = async (formData) => {
  const UserMenuDetails = [];

  const res = await fetch(apiUrl + 'usermenu/get_usermenu_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class UserMenuDetail {
        constructor(id, usermenu, status, Alotment) {
          this.usermenu = usermenu;
          this.id = id;
          this.alotment = Alotment
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].UserMenu.length; index++) {
        let element = res1[0].UserMenu[index];
        // console.log(element)
        UserMenuDetails[index] = new UserMenuDetail(element.UUM_UserMenuID, element.UUM_UserMenu, element.UUM_Status, element.UUM_LeaveAlotment);
      }
      // console.log(UserMenuDetails)
    })

  return UserMenuDetails;
};

export const requestdata_UserMenu_DropDowns_All = async (formData) => {

  const optionsUserMenu = [];
  const res = await fetch(apiUrl + 'usermenu/get_usermenu_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].UserMenu.length; index++) {
        const UserMenuData = {
          key: res1[0].UserMenu[index].USR_UserMenuID,
          value: res1[0].UserMenu[index].USR_PrefferedName
        };
        optionsUserMenu[index] = UserMenuData
      }
      console.log(optionsUserMenu)
    })
  return optionsUserMenu;
}


export const requestdata_UserMenu_SelectBox = async (formData) => {

  const optionsUserMenu = [];
  const res = await fetch(apiUrl + 'usermenu/get_usermenu_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].UserMenu.length; index++) {
        const UserMenuData = {
          key: res1[0].UserMenu[index].UUM_UserMenuID,
          value: res1[0].UserMenu[index].UUM_UserMenu,
          label: res1[0].UserMenu[index].UUM_UserMenu,
          Ischecked: false
        };
        optionsUserMenu[index] = UserMenuData
      }
      console.log(optionsUserMenu)
    })
  return optionsUserMenu;
}