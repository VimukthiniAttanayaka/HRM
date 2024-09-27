const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeReportingManagerDetail {
  constructor(id,
    EmployeeID,
    ReportingManagerID,
    AllocatedTeam,
    status) {
    this.EmployeeID = EmployeeID;
    this.ReportingManagerID = ReportingManagerID;
    this.AllocatedTeam = AllocatedTeam;
    this.id = id;
    // console.log(status)
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}

// console.log(apiUrl)
export const getEmployeeReportingManagerAll = async (formData) => {
  const EmployeeReportingManagerDetails = [];

  const res = await fetch(apiUrl + 'EmployeeReportingManager/get_EmployeeReportingManager_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      // for (let index = 0; index < res1[0].Employee.length; index++) {
      //   let element = res1[0].Employee[index]; 
      for (let index = 0; index < res1[0].EmployeeReportingManager.length; index++) {
        let element = res1[0].EmployeeReportingManager[index];
        // console.log(element)
        EmployeeReportingManagerDetails[index] = new EmployeeReportingManagerDetail(
          element.EERM_ID,
          element.EERM_EmployeeID,
          element.EERM_ReportingManagerID,
          // element.EERM_AllocatedTeam,
          element.EERM_Status);
      }
      // console.log(EmployeeReportingManagerDetails)
    })

  return EmployeeReportingManagerDetails;
};
