const apiUrl = process.env.REACT_APP_API_URL;

export class BranchDetail {
  constructor(id, branch, status) {
    this.branch = branch;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getBranchAll = async (formData) => {
  const BranchDetails = [];

  const res = await fetch(apiUrl + 'branch/get_branch_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      // console.log(res1)
      // class BranchDetail {
      //   constructor(id, branch, status) {
      //     this.branch = branch;
      //     this.id = id;
      //     if (status == true) { this.status = "Active"; }
      //     else { this.status = "Inactive"; }
      //   }
      // }

      for (let index = 0; index < res1[0].Branch.length; index++) {
        let element = res1[0].Branch[index];
        // console.log(element)
        BranchDetails[index] = new BranchDetail(element.MDB_BranchID, element.MDB_Branch, element.MDB_Status);
      }
      // console.log(BranchDetails)
    })

  return BranchDetails;
};

export const requestdata_Branchs_DropDowns_All = async (formData) => {

  const optionsBranch = [];
  const res = await fetch(apiUrl + 'branch/get_branch_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].Branch.length; index++) {
        const BranchData = {
          key: res1[0].Branch[index].MDB_BranchID,
          value: res1[0].Branch[index].MDB_Branch
        };
        optionsBranch[index] = BranchData
      }
    })
  return optionsBranch;
}
