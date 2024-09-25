const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeDetail {
  EED_EmployeeID;
  EED_EmployeeDocumentID;
  EED_DocumentType;
  EED_DocumentName;
  EED_Status;
  EED_CreatedBy;
  EED_CreatedDateTime;
  EED_ModifiedBy;
  EED_ModifiedDateTime;
  EED_DocumentData;
  EED_DocumentDataByte;
}
// console.log(apiUrl)
export const getEmployeeDocumentSingle = async (formData) => {
  console.log(formData)
  let resw = new EmployeeDetail();
  const res = await fetch(apiUrl + 'employeeDocument/get_employeeDocument_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      // console.log(json)
      let res1 = JSON.parse(JSON.stringify(json))
      // console.log(res1)
      resw = res1[0].EmployeeDocument[0]

      // console.log(res1[0].Employee[0])
      // setLeaveTypeDetails(res1[0].LeaveType[0]);
      // handleOpenPopup()
    })

  return resw;
};
