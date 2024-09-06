const apiUrl = process.env.REACT_APP_API_URL;

export class AttendanceDetail {
  constructor(InTime,
    OutTime,
    Reason,
    EndDate,
    Total,
    DateString,
    AttendanceDate,
    StartDate) {
    this.InTime = InTime;
    this.OutTime = OutTime;
    this.Reason = Reason;
    this.EndDate = EndDate;
    this.Total = Total;
    this.DateString = DateString;
    this.AttendanceDate = AttendanceDate;
    this.StartDate = StartDate;

    // if (status == true) { this.status = "Active"; }
    // else { this.status = "Inactive"; }
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

        AttendanceDetails[index] = new AttendanceDetail(element.InTime,
          element.OutTime,
          element.Reason,
          element.EndDate,
          element.Total,
          element.DateString,
          element.AttendanceDate,
          element.StartDate);
      }
      // console.log(AttendanceDetails)
    })

  return AttendanceDetails;
};

export const requestdata_Attendances_DropDowns_All = async (formData) => {

  const optionsAttendance = [];
  const res = await fetch(apiUrl + 'Attendance/get_Attendance_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].Attendance.length; index++) {
        const AttendanceData = {
          key: res1[0].Attendance[index].LVT_AttendanceID,
          value: res1[0].Attendance[index].LVT_Attendance
        };
        optionsAttendance[index] = AttendanceData
      }
      // console.log(optionsAttendance)
    })
  return optionsAttendance;
}