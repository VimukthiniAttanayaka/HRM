const apiUrl = process.env.REACT_APP_API_URL;

// console.log(apiUrl)
export const getEmployeeTerminationAll = async (formData) => {
  const EmployeeTerminationDetails = [];

  const res = await fetch(apiUrl + 'EmployeeTermination/get_EmployeeTermination_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class EmployeeTerminationDetail {
        constructor(id, EmployeeID,
          LeaveAlotment,
          ActiveFrom,
          ActiveTo,
          Remain,
          LeaveType,
          status) {
          this.EmployeeID = EmployeeID;
          this.LeaveAlotment = LeaveAlotment;
          this.ActiveFrom = ActiveFrom;
          this.ActiveTo = ActiveTo;
          this.Remain = Remain;
          this.LeaveType = LeaveType;
          this.id = id;
          // console.log(status)
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].EmployeeTermination.length; index++) {
        let element = res1[0].EmployeeTermination[index];
        // console.log(element)
        EmployeeTerminationDetails[index] = new EmployeeTerminationDetail(element.EELE_ID,
          element.EELE_EmployeeID,
          element.EELE_LeaveAlotment,
          element.EELE_ActiveFrom,
          element.EELE_ActiveTo,
          element.EELE_Remain,
          element.EELE_LeaveTypeID,
          element.EELE_Status);
      }
      // console.log(EmployeeTerminationDetails)
    })

  return EmployeeTerminationDetails;
};