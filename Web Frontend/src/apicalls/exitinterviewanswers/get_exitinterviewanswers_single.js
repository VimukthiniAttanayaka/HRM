const apiUrl = process.env.REACT_APP_API_URL;

// export class ExitInterviewQuestionsDetail {
//   constructor(id, ExitInterviewQuestions, status, Alotment) {
//     this.ExitInterviewQuestions = ExitInterviewQuestions;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class ExitInterviewQuestionsDetail {
  EIEIQ_ID;
  MDB_ExitInterviewQuestions;
  MDB_Status;
  MDB_CreatedBy;
  MDB_CreatedDateTime;
  MDB_ModifiedBy;
  MDB_ModifiedDateTime;
}
// console.log(apiUrl)
export const getExitInterviewQuestionsSingle = async (formData) => {

  let resw = new ExitInterviewQuestionsDetail();
  const res = await fetch(apiUrl + 'ExitInterviewQuestions/get_ExitInterviewQuestions_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      // console.log(res1)
      resw = res1[0].ExitInterviewQuestions[0]
      // console.log(res2)
      // console.log(res1[0].ExitInterviewQuestions[0])
      // setExitInterviewQuestionsDetails(res1[0].ExitInterviewQuestions[0]);
      // handleOpenPopup()
    })

  return resw;
};