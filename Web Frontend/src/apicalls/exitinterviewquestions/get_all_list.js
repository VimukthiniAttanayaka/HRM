const apiUrl = process.env.REACT_APP_API_URL;

export class ExitInterviewQuestionsDetail {
  constructor(id, Description, EntryType, status) {
    this.Description = Description;
    this.EntryType = EntryType;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getExitInterviewQuestionsAll = async (formData) => {
  const ExitInterviewQuestionsDetails = [];

  const res = await fetch(apiUrl + 'ExitInterviewQuestions/get_ExitInterviewQuestions_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      // console.log(res1)
      // class ExitInterviewQuestionsDetail {
      //   constructor(id, ExitInterviewQuestions, status) {
      //     this.ExitInterviewQuestions = ExitInterviewQuestions;
      //     this.id = id;
      //     if (status == true) { this.status = "Active"; }
      //     else { this.status = "Inactive"; }
      //   }
      // }

      for (let index = 0; index < res1[0].ExitInterviewQuestions.length; index++) {
        let element = res1[0].ExitInterviewQuestions[index];
        // console.log(element)
        ExitInterviewQuestionsDetails[index] = new ExitInterviewQuestionsDetail(element.EIEIQ_ID, element.EIEIQ_Description, element.EIEIQ_EntryType, element.MDB_Status);
      }
      // console.log(ExitInterviewQuestionsDetails)
    })

  return ExitInterviewQuestionsDetails;
};
