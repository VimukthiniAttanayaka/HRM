const apiUrl = process.env.REACT_APP_API_URL;

// export class CompanyDetail {
//   constructor(id, Company, status, Alotment) {
//     this.Company = Company;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class CompanyDetail {
  EUR_CompanyID;
  EUR_Company;
  EUR_Status;
  EUR_CreatedBy;
  EUR_CreatedDateTime;
  EUR_ModifiedBy;
  EUR_ModifiedDateTime;
}
// console.log(apiUrl)
export const getCompanySingle = async (formData) => {
console.log('hi')
  let resw = new CompanyDetail();
  const res = await fetch(apiUrl + 'Customer/get_customers_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      // console.log(res1)
      resw = res1[0].Customer[0]
      // console.log(res1[0].Company[0])
      // setCompanyDetails(res1[0].Company[0]);
      // handleOpenPopup()
    })

  return resw;
};
