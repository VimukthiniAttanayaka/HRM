const apiUrl = process.env.REACT_APP_API_URL;

export class LeaveScheduleDetail  {
  LVT_LeaveTypeID;
  LVT_LeaveType;
  LVT_LeaveAlotent;
  LVT_Status;
  LVT_CreatedBy;
  LVT_CreatedDateTime;
  LVT_ModifiedBy;
  LVT_ModifiedDateTime;
}
// console.log(apiUrl)
export const getEmployeeSingle = async (formData) => {
   
  let resw=new LeaveScheduleDetail();
  const res = await fetch(apiUrl + 'employee/get_employee_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
  .then(response => response.json())
  .then(json => {
    let res1 = JSON.parse(JSON.stringify(json))
    resw=res1[0].Employee[0]
    // console.log(res2)
    // console.log(res1[0].Employee[0])
    // setLeaveTypeDetails(res1[0].LeaveType[0]);
    // handleOpenPopup()
  })
    
    return resw;
};