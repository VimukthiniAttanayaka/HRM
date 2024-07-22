const apiUrl = process.env.REACT_APP_API_URL;

export class LeaveScheduleDetail {
  constructor(id, ReportingManager, status, employeeid) {
    this.ReportingManager = ReportingManager;
    this.id = id;
    this.employeeid = employeeid
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getReportingManagerAll = async (formData) => {
  const ReportingManagerDetails = [];

  const res = await fetch(apiUrl + 'ReportingManager/get_ReportingManager_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      console.log(res1)

      class ReportingManagerDetail {
        constructor(id, ReportingManager, status, employeeid) {
          this.ReportingManager = ReportingManager;
          this.id = id;
          this.employeeid = employeeid
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].ReportingManager.length; index++) {
        let element = res1[0].ReportingManager[index];
        console.log(element)
        ReportingManagerDetails[index] = new ReportingManagerDetail(element.RM_ID, element.RM_ReportingManagerID, element.RM_Status, element.RM_EmployeeID);
      }
      // console.log(ReportingManagerDetails)
    })

  return ReportingManagerDetails;
};

export const requestdata_ReportingManagers_DropDowns_All = async (formData) => {

  const optionsReportingManager = [];
  const res = await fetch(apiUrl + 'ReportingManager/get_ReportingManager_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].ReportingManager.length; index++) {
        const ReportingManagerData = {
          key: res1[0].ReportingManager[index].RM_ID,
          value: res1[0].ReportingManager[index].RM_EmployeeID
        };
        optionsReportingManager[index] = ReportingManagerData
      }
      // console.log(optionsReportingManager)
    })
  return optionsReportingManager;
}