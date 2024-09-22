const apiUrl = process.env.REACT_APP_API_URL;

export const Dropdowns_Location = async (formData) => {

  const optionsLocation = [];
  const res = await fetch(apiUrl + 'location/get_location_all', {
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
