const apiUrl = process.env.REACT_APP_API_URL;

// export class CurrencyDetail {
//   constructor(id, Currency, status, Alotment) {
//     this.Currency = Currency;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class CurrencyDetail {
  EUR_CurrencyID;
  EUR_Currency;
  EUR_Status;
  EUR_CreatedBy;
  EUR_CreatedDateTime;
  EUR_ModifiedBy;
  EUR_ModifiedDateTime;
}
// console.log(apiUrl)
export const getCurrencySingle = async (formData) => {

  let resw = new CurrencyDetail();
  const res = await fetch(apiUrl + 'Currency/get_Currency_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].Currency[0]
      // console.log(res2)
      console.log(res1[0].Currency[0])
      // setCurrencyDetails(res1[0].Currency[0]);
      // handleOpenPopup()
    })

  return resw;
};