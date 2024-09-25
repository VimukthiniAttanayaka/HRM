const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeReportingManager {
  EERM_ID;
  EERM_EmployeeID;
  EERM_ReportingManagerID;
  EERM_Status;
  EERM_CreatedBy;
  EERM_CreatedDateTime;
  EERM_ModifiedBy;
  EERM_ModifiedDateTime;
}
// console.log(apiUrl)
export const getEmployeeReportingManagerSingle = async (formData) => {
  console.log(formData)
  let resw = new EmployeeReportingManager();
  const res = await fetch(apiUrl + 'employeereportingmanager/get_employeereportingmanager_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      // console.log(json)
      let res1 = JSON.parse(JSON.stringify(json))
      // console.log(res1)
      resw = res1[0].EmployeeReportingManager[0]

      // console.log(res1[0].Employee[0])
      // setLeaveTypeDetails(res1[0].LeaveType[0]);
      // handleOpenPopup()
    })

  return resw;
};
