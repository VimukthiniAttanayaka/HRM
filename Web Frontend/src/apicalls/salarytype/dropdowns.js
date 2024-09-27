const apiUrl = process.env.REACT_APP_API_URL;

export const Dropdowns_SalaryType = async (formData) => {

  const optionsSalaryType = [];
  const res = await fetch(apiUrl + 'salarytype/get_salarytype_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].SalaryType.length; index++) {
        const SalaryTypeData = {
          key: res1[0].SalaryType[index].MDST_SalaryTypeID,
          value: res1[0].SalaryType[index].MDST_SalaryType
        };
        optionsSalaryType[index] = SalaryTypeData
      }
    })
  return optionsSalaryType;
}
