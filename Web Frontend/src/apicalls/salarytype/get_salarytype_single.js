const apiUrl = process.env.REACT_APP_API_URL;

// export class SalaryTypeDetail {
//   constructor(id, SalaryType, status, Alotment) {
//     this.SalaryType = SalaryType;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class SalaryTypeDetail {
  MDST_SalaryTypeID;
  MDST_SalaryType;
  MDST_Description;
  MDST_Status;
  MDST_CreatedBy;
  MDST_CreatedDateTime;
  MDST_ModifiedBy;
  MDST_ModifiedDateTime;
}
// console.log(apiUrl)
export const getSalaryTypeSingle = async (formData) => {

  let resw = new SalaryTypeDetail();
  const res = await fetch(apiUrl + 'SalaryType/get_SalaryType_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].SalaryType[0]
      // console.log(res2)
      // console.log(res1[0].SalaryType[0])
      // setSalaryTypeDetails(res1[0].SalaryType[0]);
      // handleOpenPopup()
    })

  return resw;
};
