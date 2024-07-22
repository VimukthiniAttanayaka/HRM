const apiUrl = process.env.REACT_APP_API_URL;

// export class LeaveScheduleDetail {
//   constructor(id, leavetype, status, Alotment) {
//     this.leavetype = leavetype;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class ReportingManagerDetail {
  RM_ID;
  RM_ReportingManagerID;
  RM_EmployeeID;
  RM_Status;
  RM_CreatedBy;
  RM_CreatedDateTime;
  RM_ModifiedBy;
  RM_ModifiedDateTime;
}
// console.log(apiUrl)
export const getReportingManagerSingle = async (formData) => {

  let resw = new ReportingManagerDetail();
  const res = await fetch(apiUrl + 'ReportingManager/get_ReportingManager_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].ReportingManager[0]
      // console.log(res2)
      // console.log(res1[0].LeaveType[0])
      // setLeaveTypeDetails(res1[0].LeaveType[0]);
      // handleOpenPopup()
    })

  return resw;
};