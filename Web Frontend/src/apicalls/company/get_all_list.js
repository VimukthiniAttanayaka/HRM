const apiUrl = process.env.REACT_APP_API_URL;

export class CompanyDetail {
  constructor(id, Company, status) {
    this.Company = Company;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
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
console.log(res1)

      class CompanyDetail {
        constructor(
        CUS_ID,
        CUS_CompanyName,
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
          this.CUS_ID = CUS_ID;
            this.CUS_CompanyName = CUS_CompanyName;
          this.CUS_Adrs_BlockBuildingNo = CUS_Adrs_BlockBuildingNo;
          this.CUS_Adrs_BuildingName = CUS_Adrs_BuildingName;
          this.CUS_Adrs_UnitNumber = CUS_Adrs_UnitNumber;
          this.CUS_Adrs_StreetName = CUS_Adrs_StreetName;
          this.CUS_Adrs_City = CUS_Adrs_City;
          this.CUS_Adrs_CountryCode = CUS_Adrs_CountryCode;
          this.CUS_Adrs_PostalCode = CUS_Adrs_PostalCode;
          this.CUS_ContactPerson = CUS_ContactPerson;
          this.CUS_ContactNumber = CUS_ContactNumber;
          this.CUS_PinOrPwd = CUS_PinOrPwd;
          this.CUS_OTP_By_SMS = CUS_OTP_By_SMS;
          this.CUS_OTP_By_Email = CUS_OTP_By_Email;
          if (CUS_Status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].Customer.length; index++) {
        let element = res1[0].Customer[index];
        // console.log(element)
        CompanyDetails[index] = new CompanyDetail(element.CUS_ID,
          element.CUS_CompanyName,
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
