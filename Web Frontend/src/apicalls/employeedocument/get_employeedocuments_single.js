const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeDetail {
  USRED_EmployeeID;
  USRED_EmployeeDocumentID;
  USRED_DocumentType;
  USRED_DocumentName;
  USRED_Status;
  USRED_CreatedBy;
  USRED_CreatedDateTime;
  USRED_ModifiedBy;
  USRED_ModifiedDateTime;
  USRED_DocumentData;
  USRED_DocumentDataByte;
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
