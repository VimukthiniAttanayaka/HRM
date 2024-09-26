const apiUrl = process.env.REACT_APP_API_URL;

// console.log(apiUrl)
export const getEmployeeContactAll = async (formData) => {
  const EmployeeContactDetails = [];

  const res = await fetch(apiUrl + 'EmployeeContact/get_EmployeeContact_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class EmployeeContactDetail {
        constructor(id, Employeeid, ContactID, ActiveFrom, ActiveTo, status) {
          // this.Employeeid = Employeeid;
          this.ContactID = ContactID;
          this.ActiveFrom = ActiveFrom;
          this.ActiveTo = ActiveTo;
          this.id = id;
          // console.log(status)
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].EmployeeContact.length; index++) {
        let element = res1[0].EmployeeContact[index];
        // console.log(element)
        EmployeeContactDetails[index] = new EmployeeContactDetail(element.EEJR_ID, element.EEJR_EmployeeID,element.EEJR_ContactID,
          element.EEJR_ContactID, element.EEJR_ActiveFrom, element.EEJR_ActiveTo,element.EEJR_Status);
      }
      // console.log(EmployeeContactDetails)
    })

  return EmployeeContactDetails;
};

export const requestdata_EmployeeContacts_DropDowns_All = async (formData) => {

  const optionsEmployeeContact = [];
  const res = await fetch(apiUrl + 'EmployeeContact/get_EmployeeContact_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      // for (let index = 0; index < res1[0].EmployeeContact.length; index++) {
      //   const EmployeeContactData = {
      //     key: res1[0].EmployeeContact[index].EEJ_EmployeeContactID,
      //     value: res1[0].EmployeeContact[index].EEJ_EmployeeContact
      //   };
      //   optionsEmployeeContact[index] = EmployeeContactData
      // }
    })
  return optionsEmployeeContact;
}
