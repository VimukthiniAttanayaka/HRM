const apiUrl = process.env.REACT_APP_API_URL;

// console.log(apiUrl)
export const getEmployeeEmploymentAll = async (formData) => {
  const EmployeeEmploymentDetails = [];

  const res = await fetch(apiUrl + 'EmployeeEmployment/get_EmployeeEmployment_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class EmployeeEmploymentDetail {
        constructor(id, EmployeeID,
          Address,
          EmailAddress,
          MobileNumber,
          PhoneNumber1,
          PhoneNumber2,
          status) {
          this.EmployeeID = EmployeeID;
          this.Address = Address;
          this.EmailAddress = EmailAddress;
          this.MobileNumber = MobileNumber;
          this.PhoneNumber1 = PhoneNumber1;
          this.PhoneNumber2 = PhoneNumber2;
          this.id = id;
          // console.log(status)
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].EmployeeEmployment.length; index++) {
        let element = res1[0].EmployeeEmployment[index];
        // console.log(element)
        EmployeeEmploymentDetails[index] = new EmployeeEmploymentDetail(element.EEC_ID,
          element.EEC_EmployeeID,
          element.EEC_Address,
          element.EEC_EmailAddress,
          element.EEC_MobileNumber,
          element.EEC_PhoneNumber1,
          element.EEC_PhoneNumber2,
          element.EEC_Status);
      }
      // console.log(EmployeeEmploymentDetails)
    })

  return EmployeeEmploymentDetails;
};