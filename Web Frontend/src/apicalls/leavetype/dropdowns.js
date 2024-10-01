const apiUrl = process.env.REACT_APP_API_URL;

export const Dropdowns_LeaveType = async (formData) => {

    const optionsLeaveType = [];
    const res = await fetch(apiUrl + 'leavetype/get_leavetype_all', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })
      .then(response => response.json())
      .then(json => {
        let res1 = JSON.parse(JSON.stringify(json))
  
        for (let index = 0; index < res1[0].LeaveType.length; index++) {
          const LeaveTypeData = {
            key: res1[0].LeaveType[index].MDLT_LeaveTypeID,
            value: res1[0].LeaveType[index].MDLT_LeaveType
          };
          optionsLeaveType[index] = LeaveTypeData
        }
        // console.log(optionsLeaveType)
      })
    return optionsLeaveType;
  }