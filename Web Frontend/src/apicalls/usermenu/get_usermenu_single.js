const apiUrl = process.env.REACT_APP_API_URL;

export class UserMenuDetail  {
  UUM_UserMenuID;
  UUM_UserMenu;
  UUM_LeaveAlotent;
  UUM_Status;
  UUM_CreatedBy;
  UUM_CreatedDateTime;
  UUM_ModifiedBy;
  UUM_ModifiedDateTime;
}
// console.log(apiUrl)
export const getUserMenuSingle = async (formData) => {
   
  let resw=new UserMenuDetail();
  const res = await fetch(apiUrl + 'usermenu/get_usermenu_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
  .then(response => response.json())
  .then(json => {
    let res1 = JSON.parse(JSON.stringify(json))
    resw=res1[0].UserMenu[0]
    // console.log(res2)
    // console.log(res1[0].UserMenu[0])
    // setUserMenuDetails(res1[0].UserMenu[0]);
    // handleOpenPopup()
  })
    
    return resw;
};