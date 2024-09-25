const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeDetail {
  constructor(
    EED_EmployeeID,
    EED_EmployeeDocumentID,
    EED_DocumentType,
    EED_DocumentName,
    EED_Status,
    EED_DocumentData,
    EED_DocumentDataByte) {

    this.id = EED_EmployeeDocumentID;
    this.EmployeeID = EED_EmployeeID;
    this.DocumentType = EED_DocumentType;
    this.DocumentName = EED_DocumentName;
    this.DocumentData = EED_DocumentData;
    this.DocumentDataByte = EED_DocumentDataByte;
    if (EED_Status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}

// console.log(apiUrl)
export const getEmployeeDocumentsAll = async (formData) => {
  const EmployeeDetails = [];

  const res = await fetch(apiUrl + 'employeeDocument/get_employeeDocument_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      // for (let index = 0; index < res1[0].Employee.length; index++) {
      //   let element = res1[0].Employee[index]; 
      for (let index = 0; index < res1[0].EmployeeDocument.length; index++) {
        let element = res1[0].EmployeeDocument[index];
        // console.log(element)
        EmployeeDetails[index] = new EmployeeDetail(
          element.EED_EmployeeID,
          element.EED_EmployeeDocumentID,
          element.EED_DocumentType,
          element.EED_DocumentName,
          element.EED_Status,
          element.EED_DocumentData,
          element.EED_DocumentDataByte);
      }
      // console.log(EmployeeDetails)
    })

  return EmployeeDetails;
};
