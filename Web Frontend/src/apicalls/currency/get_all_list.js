const apiUrl = process.env.REACT_APP_API_URL;

export class CurrencyDetail {
  constructor(id, Currency, status) {
    this.Currency = Currency;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getCurrencyAll = async (formData) => {
  const CurrencyDetails = [];

  const res = await fetch(apiUrl + 'Currency/get_Currency_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class CurrencyDetail {
        constructor(id, Currency, status) {
          this.Currency = Currency;
          this.id = id;
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].Currency.length; index++) {
        let element = res1[0].Currency[index];
        // console.log(element)
        CurrencyDetails[index] = new CurrencyDetail(element.EUR_CurrencyID, element.EUR_Currency, element.EUR_Status);
      }
      // console.log(CurrencyDetails)
    })

  return CurrencyDetails;
};

export const requestdata_Currencys_DropDowns_All = async (formData) => {

  const optionsCurrency = [];
  const res = await fetch(apiUrl + 'Currency/get_Currency_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].Currency.length; index++) {
        const CurrencyData = {
          key: res1[0].Currency[index].EUR_CurrencyID,
          value: res1[0].Currency[index].EUR_Currency
        };
        optionsCurrency[index] = CurrencyData
      }
    })
  return optionsCurrency;
}
