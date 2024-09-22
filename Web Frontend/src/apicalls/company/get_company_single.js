const apiUrl = process.env.REACT_APP_API_URL;

export class CompanyDetail {
  CUS_ID;
  CUS_CompanyName;
  CUS_Adrs_BlockBuildingNo;
  CUS_Adrs_BuildingName;
  CUS_Adrs_UnitNumber;
  CUS_Adrs_StreetName;
  CUS_Adrs_City;
  CUS_Adrs_CountryCode;
  CUS_Adrs_PostalCode;
  CUS_ContactPerson;
  CUS_ContactNumber;
  CUS_PinOrPwd;
  CUS_OTP_By_SMS;
  CUS_OTP_By_Email;
  CUS_Status;
  CUS_CreatedBy;
  CUS_CreatedDateTime;
  CUS_ModifiedBy;
  CUS_ModifiedDateTime;
  CUS_GroupCompany;

}
// console.log(apiUrl)
export const getCompanySingle = async (formData) => {
  console.log(formData)
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
