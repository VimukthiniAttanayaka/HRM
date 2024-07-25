const apiUrl = process.env.REACT_APP_API_URL;

// export class BranchDetail {
//   constructor(id, branch, status, Alotment) {
//     this.branch = branch;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class BranchDetail {
  MDB_BranchID;
  MDB_Branch;
  MDB_Status;
  MDB_CreatedBy;
  MDB_CreatedDateTime;
  MDB_ModifiedBy;
  MDB_ModifiedDateTime;
}
// console.log(apiUrl)
export const getBranchSingle = async (formData) => {

  let resw = new BranchDetail();
  const res = await fetch(apiUrl + 'branch/get_branch_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      // console.log(res1)
      resw = res1[0].Branch[0]
      // console.log(res2)
      // console.log(res1[0].Branch[0])
      // setBranchDetails(res1[0].Branch[0]);
      // handleOpenPopup()
    })

  return resw;
};