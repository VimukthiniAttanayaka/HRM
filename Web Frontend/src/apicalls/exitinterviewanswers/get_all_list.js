const apiUrl = process.env.REACT_APP_API_URL;

export class ExitInterviewAnswersDetail {
  constructor(id, Description, EntryType, status) {
    this.Description = Description;
    this.EntryType = EntryType;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getExitInterviewAnswersAll = async (formData) => {
  const ExitInterviewAnswersDetails = [];

  const res = await fetch(apiUrl + 'ExitInterviewAnswers/get_ExitInterviewAnswers_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      // console.log(res1)
      // class ExitInterviewAnswersDetail {
      //   constructor(id, ExitInterviewAnswers, status) {
      //     this.ExitInterviewAnswers = ExitInterviewAnswers;
      //     this.id = id;
      //     if (status == true) { this.status = "Active"; }
      //     else { this.status = "Inactive"; }
      //   }
      // }

      for (let index = 0; index < res1[0].ExitInterviewAnswers.length; index++) {
        let element = res1[0].ExitInterviewAnswers[index];
        // console.log(element)
        ExitInterviewAnswersDetails[index] = new ExitInterviewAnswersDetail(element.EIEIQ_ID, element.EIEIQ_Description, element.EIEIQ_EntryType, element.MDB_Status);
      }
      // console.log(ExitInterviewAnswersDetails)
    })

  return ExitInterviewAnswersDetails;
};
