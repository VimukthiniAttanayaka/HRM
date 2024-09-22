const apiUrl = process.env.REACT_APP_API_URL;

// console.log(apiUrl)
export const getCompanyAll = async (formData) => {
  const CompanyDetails = [];

  const res = await fetch(apiUrl + 'Customer/get_customers_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      // console.log(res1)

      class CompanyDetail {
        constructor(
          CUS_ID,
          CUS_CompanyName,
          CUS_GroupCompany,
          CUS_Adrs_BlockBuildingNo,
          CUS_Adrs_BuildingName,
          CUS_Adrs_UnitNumber,
          CUS_Adrs_StreetName,
          CUS_Adrs_City,
          CUS_Adrs_CountryCode,
          CUS_Adrs_PostalCode,
          CUS_ContactPerson,
          CUS_ContactNumber,
          CUS_PinOrPwd,
          CUS_OTP_By_SMS,
          CUS_OTP_By_Email,
          CUS_Status,
        ) {

          this.ID = CUS_ID;
          this.CompanyName = CUS_CompanyName;
          this.GroupCompany = CUS_GroupCompany;
          this.Adrs_BlockBuildingNo = CUS_Adrs_BlockBuildingNo;
          this.Adrs_BuildingName = CUS_Adrs_BuildingName;
          this.Adrs_UnitNumber = CUS_Adrs_UnitNumber;
          this.Adrs_StreetName = CUS_Adrs_StreetName;
          this.Adrs_City = CUS_Adrs_City;
          this.Adrs_CountryCode = CUS_Adrs_CountryCode;
          this.Adrs_PostalCode = CUS_Adrs_PostalCode;
          this.ContactPerson = CUS_ContactPerson;
          this.ContactNumber = CUS_ContactNumber;
          this.PinOrPwd = CUS_PinOrPwd;
          this.OTP_By_SMS = CUS_OTP_By_SMS;
          this.OTP_By_Email = CUS_OTP_By_Email;
          if (CUS_Status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].Customer.length; index++) {
        let element = res1[0].Customer[index];

        CompanyDetails[index] = new CompanyDetail(element.CUS_ID,
          element.CUS_CompanyName,
          element.CUS_GroupCompany,
          element.CUS_Adrs_BlockBuildingNo,
          element.CUS_Adrs_BuildingName,
          element.CUS_Adrs_UnitNumber,
          element.CUS_Adrs_StreetName,
          element.CUS_Adrs_City,
          element.CUS_Adrs_CountryCode,
          element.CUS_Adrs_PostalCode,
          element.CUS_ContactPerson,
          element.CUS_ContactNumber,
          element.CUS_PinOrPwd,
          element.CUS_OTP_By_SMS,
          element.CUS_OTP_By_Email,
          element.CUS_Status,);
      }
      // console.log(CompanyDetails)
    })
  // console.log(CompanyDetails)
  return CompanyDetails;
};

export const requestdata_Companys_DropDowns_All = async (formData) => {

  const optionsCompany = [];
  const res = await fetch(apiUrl + 'Customer/get_customers_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].Company.length; index++) {
        const CompanyData = {
          key: res1[0].Company[index].MDD_CompanyID,
          value: res1[0].Company[index].MDD_Company
        };
        optionsCompany[index] = CompanyData
      }
    })
  return optionsCompany;
}
