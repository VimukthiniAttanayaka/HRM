const apiUrl = process.env.REACT_APP_API_URL;

export class LeaveScheduleDetail {
  constructor(id, leavetype, status, Alotment) {
    this.leavetype = leavetype;
    this.id = id;
    this.alotment = Alotment
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getEmployeeAll = async (formData) => {
  const LeaveTypeDetails = [];

  const res = await fetch(apiUrl + 'employee/get_employee_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class LeaveTypeDetail {
        constructor(id, leavetype, status, Alotment) {
          this.leavetype = leavetype;
          this.id = id;
          this.alotment = Alotment
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].LeaveType.length; index++) {
        let element = res1[0].LeaveType[index];
        // console.log(element)
        LeaveTypeDetails[index] = new LeaveTypeDetail(element.LVT_LeaveTypeID, element.LVT_LeaveType, element.LVT_Status, element.LVT_LeaveAlotment);
      }
      // console.log(LeaveTypeDetails)
    })

  return LeaveTypeDetails;
};

export const requestdata_Employee_DropDowns_All = async (formData) => {

  const optionsEmployee = [];
  const res = await fetch(apiUrl + 'employee/get_employee_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].Employee.length; index++) {
        const EmployeeData = {
          key: res1[0].Employee[index].USR_EmployeeID,
          value: res1[0].Employee[index].USR_PrefferedName
        };
        optionsEmployee[index] = EmployeeData
      }
      console.log(optionsEmployee)
    })
  return optionsEmployee;
}