const apiUrl = process.env.REACT_APP_API_URL;

export class TerminationDetail {
  constructor(id, Termination, status) {
    this.Termination = Termination;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getTerminationAll = async (formData) => {
  const TerminationDetails = [];

  const res = await fetch(apiUrl + 'Termination/get_Termination_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      // console.log(res1)
      // class TerminationDetail {
      //   constructor(id, Termination, status) {
      //     this.Termination = Termination;
      //     this.id = id;
      //     if (status == true) { this.status = "Active"; }
      //     else { this.status = "Inactive"; }
      //   }
      // }

      for (let index = 0; index < res1[0].Termination.length; index++) {
        let element = res1[0].Termination[index];
        // console.log(element)
        TerminationDetails[index] = new TerminationDetail(element.MDB_TerminationID, element.MDB_Termination, element.MDB_Status);
      }
      // console.log(TerminationDetails)
    })

  return TerminationDetails;
};

export const requestdata_Terminations_DropDowns_All = async (formData) => {

  const optionsTermination = [];
  const res = await fetch(apiUrl + 'Termination/get_Termination_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].Termination.length; index++) {
        const TerminationData = {
          key: res1[0].Termination[index].MDB_TerminationID,
          value: res1[0].Termination[index].MDB_Termination
        };
        optionsTermination[index] = TerminationData
      }
    })
  return optionsTermination;
}
