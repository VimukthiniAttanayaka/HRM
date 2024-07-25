const apiUrl = process.env.REACT_APP_API_URL;

export class CountryDetail {
  constructor(id, Country, status) {
    this.Country = Country;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getCountryAll = async (formData) => {
  const CountryDetails = [];

  const res = await fetch(apiUrl + 'Country/get_Country_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class CountryDetail {
        constructor(id, Country, status) {
          this.Country = Country;
          this.id = id;
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].Country.length; index++) {
        let element = res1[0].Country[index];
        // console.log(element)
        CountryDetails[index] = new CountryDetail(element.MDCTY_CountryID, element.MDCTY_Country, element.MDCTY_Status);
      }
      // console.log(CountryDetails)
    })

  return CountryDetails;
};

export const requestdata_Countrys_DropDowns_All = async (formData) => {

  const optionsCountry = [];
  const res = await fetch(apiUrl + 'Country/get_Country_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].Country.length; index++) {
        const CountryData = {
          key: res1[0].Country[index].MDCTY_CountryID,
          value: res1[0].Country[index].MDCTY_Country
        };
        optionsCountry[index] = CountryData
      }
    })
  return optionsCountry;
}
