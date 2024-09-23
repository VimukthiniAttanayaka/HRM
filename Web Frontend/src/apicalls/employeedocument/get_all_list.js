const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeDetail {
  constructor(
    USRED_EmployeeID,
    USRED_EmployeeDocumentID,
    USRED_DocumentType,
    USRED_DocumentName,
    USRED_Status,
    USRED_DocumentData,
    USRED_DocumentDataByte) {

      this.id = USRED_EmployeeDocumentID;
        this.EmployeeID = USRED_EmployeeID;

    this.DocumentType = USRED_DocumentType;
    this.DocumentName = USRED_DocumentName;
    this.DocumentData = USRED_DocumentData;
    this.DocumentDataByte = USRED_DocumentDataByte;
    if (USRED_Status == true) { this.status = "Active"; }
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
          element.USRED_EmployeeID,
          element.USRED_EmployeeDocumentID,
          element.USRED_DocumentType,
          element.USRED_DocumentName,
          element.USRED_Status,
          element.USRED_DocumentData,
          element.USRED_DocumentDataByte);
      }
      // console.log(EmployeeDetails)
    })

  return EmployeeDetails;
};
