const apiUrl = process.env.REACT_APP_API_URL;

export class AttendanceDetail {
  EAT_ID; EAT_EmployeeID;
  EAT_Status; EAT_CreatedBy;
  EAT_CreatedDateTime;
  EAT_ModifiedBy;
  EAT_ModifiedDateTime;
  EAT_Remarks;
  EAT_ApprovedBy;
  EAT_RejectedBy;
  EAT_ApprovedDateTime;
  EAT_ApprovedReason;
  EAT_RejectedDateTime;
  EAT_RejectedReason;
  EAT_AttendanceDate;
  EAT_OutTime;
  EAT_InTime;
  EAT_Location_latitude;
  EAT_Location_longitude;

}
// console.log(apiUrl)
export const getAttendanceSingle = async (formData) => {

  let resw = new AttendanceDetail();
  const res = await fetch(apiUrl + 'Attendance/get_attendance_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].Attendance[0]
      console.log(res1)
      // console.log(res1[0].Attendance[0])
      // setAttendanceDetails(res1[0].Attendance[0]);
      // handleOpenPopup()
    })

  return resw;
};