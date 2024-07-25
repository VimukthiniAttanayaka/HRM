const apiUrl = process.env.REACT_APP_API_URL;

// export class CountryDetail {
//   constructor(id, Country, status, Alotment) {
//     this.Country = Country;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class CountryDetail {
  MDCTY_CountryID;
  MDCTY_Country;
  MDCTY_Status;
  MDCTY_CreatedBy;
  MDCTY_CreatedDateTime;
  MDCTY_ModifiedBy;
  MDCTY_ModifiedDateTime;
}
// console.log(apiUrl)
export const getCountrySingle = async (formData) => {

  let resw = new CountryDetail();
  const res = await fetch(apiUrl + 'Country/get_Country_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].Country[0]
      // console.log(res2)
      console.log(res1[0].Country[0])
      // setCountryDetails(res1[0].Country[0]);
      // handleOpenPopup()
    })

  return resw;
};