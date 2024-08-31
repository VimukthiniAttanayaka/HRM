const apiUrl = process.env.REACT_APP_API_URL;

// export class TerminationDetail {
//   constructor(id, Termination, status, Alotment) {
//     this.Termination = Termination;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class TerminationDetail {
  MDB_TerminationID;
  MDB_Termination;
  MDB_Status;
  MDB_CreatedBy;
  MDB_CreatedDateTime;
  MDB_ModifiedBy;
  MDB_ModifiedDateTime;
}
// console.log(apiUrl)
export const getTerminationSingle = async (formData) => {

  let resw = new TerminationDetail();
  const res = await fetch(apiUrl + 'Termination/get_Termination_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      // console.log(res1)
      resw = res1[0].Termination[0]
      // console.log(res2)
      // console.log(res1[0].Termination[0])
      // setTerminationDetails(res1[0].Termination[0]);
      // handleOpenPopup()
    })

  return resw;
};