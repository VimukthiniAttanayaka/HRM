const apiUrl = process.env.REACT_APP_API_URL;

export class AttendanceDetail {
  constructor(id, AttendanceDate, InTime,
    OutTime,
    Total,
    Reason
  ) {
    this.id = id;
    this.InTime = InTime;
    this.OutTime = OutTime;
    this.Reason = Reason;
    this.Total = Total;
    this.AttendanceDate = AttendanceDate;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getAttendanceAll = async (formData) => {
  const AttendanceDetails = [];

  const res = await fetch(apiUrl + 'Attendance/get_Attendance_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      // console.log(res1)
      for (let index = 0; index < res1[0].Attendance.length; index++) {
        let element = res1[0].Attendance[index];

        AttendanceDetails[index] = new AttendanceDetail(
          element.EAT_ID,
          element.EAT_AttendanceDate,
          element.EAT_InTime,
          element.EAT_OutTime,
          element.EAT_Reason,
          element.EAT_Total_TimeSpan);
      }
      // console.log(AttendanceDetails)
    })

  return AttendanceDetails;
};