const apiUrl = process.env.REACT_APP_API_URL;

export class LeaveScheduleDetail {
  constructor(id, Location, status) {
    this.Location = Location;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getLocationAll = async (formData) => {
  const LocationDetails = [];

  const res = await fetch(apiUrl + 'location/get_location_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      class LocationDetail {
        constructor(id, Location, status) {
          this.Location = Location;
          this.id = id;
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].location.length; index++) {
        let element = res1[0].location[index];
        // console.log(element)
        LocationDetails[index] = new LocationDetail(element.MDL_LocationID, element.MDL_Location, element.MDL_Status);
      }
      // console.log(LocationDetails)
    })

  return LocationDetails;
};

export const requestdata_Locations_DropDowns_All = async (formData) => {

  const optionsLocation = [];
  const res = await fetch(apiUrl + 'Location/get_Location_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].Location.length; index++) {
        const LocationData = {
          key: res1[0].Location[index].MDL_LocationID,
          value: res1[0].Location[index].MDL_Location
        };
        optionsLocation[index] = LocationData
      }
    })
  return optionsLocation;
}
