const apiUrl = process.env.REACT_APP_API_URL;

export const Dropdowns_UserRole = async (formData) => {

  const optionsUserRole = [];
  const res = await fetch(apiUrl + 'userrole/get_userrole_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].UserRole.length; index++) {
        const UserRoleData = {
          key: res1[0].UserRole[index].UUR_UserRoleID,
          value: res1[0].UserRole[index].UUR_UserRole
        };
        optionsUserRole[index] = UserRoleData
      }
    })
  return optionsUserRole;
}
