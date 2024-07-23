const apiUrl = process.env.REACT_APP_API_URL;

export class AccessGroupDetail {
  constructor(id, acessgroup, status) {
    this.acessgroup = acessgroup;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getAccessGroupAll = async (formData) => {
  const AccessGroupDetails = [];

  const res = await fetch(apiUrl + 'accessgroup/get_accessgroup_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class AccessGroupDetail {
        constructor(id, AccessGroup, status) {
          this.AccessGroup = AccessGroup;
          this.id = id;
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].AccessGroup.length; index++) {
        let element = res1[0].AccessGroup[index];
        // console.log(element)
        AccessGroupDetails[index] = new AccessGroupDetail(element.UAG_AccessGroupID, element.UAG_AccessGroup, element.UAG_Status);
      }
      // console.log(AccessGroupDetails)
    })

  return AccessGroupDetails;
};

export const requestdata_AccessGroup_DropDowns_All = async (formData) => {

  const optionsaccessgroup = [];
  const res = await fetch(apiUrl + 'accessgroup/get_accessgroup_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].AccessGroup.length; index++) {
        const accessgroupData = {
          key: res1[0].AccessGroup[index].USR_accessgroupID,
          value: res1[0].AccessGroup[index].USR_PrefferedName
        };
        optionsaccessgroup[index] = accessgroupData
      }
      // console.log(optionsaccessgroup)
    })
  return optionsaccessgroup;
}