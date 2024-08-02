const apiUrl = process.env.REACT_APP_API_URL;

// export class LocationDetail {
//   constructor(id, Location, status, Alotment) {
//     this.Location = Location;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class LocationDetail {
  MDL_LocationID;
  MDL_Location;
  MDL_Status;
  MDL_CreatedBy;
  MDL_CreatedDateTime;
  MDL_ModifiedBy;
  MDL_ModifiedDateTime;
}
// console.log(apiUrl)
export const getLocationSingle = async (formData) => {

  let resw = new LocationDetail();
  const res = await fetch(apiUrl + 'Location/get_Location_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].Location[0]
      // console.log(res2)
      console.log(res1[0].Location[0])
      // setLocationDetails(res1[0].Location[0]);
      // handleOpenPopup()
    })

  return resw;
};
