const apiUrl = process.env.REACT_APP_API_URL;

// export class DepartmentDetail {
//   constructor(id, Department, status, Alotment) {
//     this.Department = Department;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class DepartmentDetail {
  EUR_DepartmentID;
  EUR_Department;
  EUR_Status;
  EUR_CreatedBy;
  EUR_CreatedDateTime;
  EUR_ModifiedBy;
  EUR_ModifiedDateTime;
}
// console.log(apiUrl)
export const getDepartmentSingle = async (formData) => {

  let resw = new DepartmentDetail();
  const res = await fetch(apiUrl + 'Department/get_Department_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      console.log(res1)
      resw = res1[0].Department[0]
      console.log(res1[0].Department[0])
      // setDepartmentDetails(res1[0].Department[0]);
      // handleOpenPopup()
    })

  return resw;
};
