const apiUrl = process.env.REACT_APP_API_URL;

// console.log(apiUrl)
export const getSalaryTypeAll = async (formData) => {
  const SalaryTypeDetails = [];
  // class JobHeader {
  //   constructor() { }
  //   // constructor(RC, Data) { RC = RC; Data = Data; }
  // }
  // const JobHeaders = new JobHeader();

  const res = await fetch(apiUrl + 'SalaryType/get_SalaryType_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
// console.log(res1);

      class SalaryTypeDetail {
        constructor(id, SalaryType, status) {
          this.SalaryType = SalaryType;
          this.id = id;
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      let RC = res1[0].RC;
      // console.log(RC);
      for (let index = 0; index < res1[0].SalaryType.length; index++) {
        let element = res1[0].SalaryType[index];
        // console.log(element)
        SalaryTypeDetails[index] = new SalaryTypeDetail(element.MDST_SalaryTypeID, element.MDST_SalaryType, element.MDST_Status);
      }
      // JobHeaders.RC=RC;
      // JobHeaders.Data=SalaryTypeDetails;
      // console.log(SalaryTypeDetails)
    })

  return SalaryTypeDetails;// SalaryTypeDetails;
};