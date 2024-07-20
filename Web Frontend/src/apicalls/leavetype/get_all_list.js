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
export const getLeaveTypeAll = async (formData) => {
  const LeaveTypeDetails = [];
  
  const res = await fetch(apiUrl + 'leavetype/get_leavetype_all', {
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