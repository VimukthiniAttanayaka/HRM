
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_internaluser'
let templatetype_base = 'translation'

export const columns = [
  {
    key: 'UserID',
    // label: '',
    // filter: false,
    // sorter: false, 
    _style: { width: '20%' },
  }, {
    key: 'FirstName',
    _style: { width: '20%' },
  },{
    key: 'EmployeeID',
    _style: { width: '20%' },
  },
  {
    key: 'LastName',
    _style: { width: '20%' },
  },
  {
    key: 'EmailAddress',
    _style: { width: '20%' },
  }, 
  {
    key: 'MobileNumber',
    _style: { width: '20%' }
  }, {
    key: 'status',
    _style: { width: '20%' }
  },

  {
    key: 'show_details',
    label: '',
    _style: { width: '1%' },
    filter: false,
    sorter: false,
  },
];

export const headers = [["UserID", "EmployeeID", "FirstName", "LastName", "EmailAddress", 
  "MobileNumber", "PhoneNumber", "Remarks", "ActiveFrom", "ActiveTo", "Status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.UserID,elt.EmployeeID,elt.FirstName, elt.LastName, elt.EmailAddress,
    elt.MobileNumber, elt.PhoneNumber, elt.Remarks, elt.ActiveFrom, elt.ActiveTo,
    elt.Status]);
}


export const columns_Access = [
  {
    key: 'AccessGroupName',
    label: 'Access Group Name',
    _style: { width: '20%' },
  },
  {
    key: 'status',
    label: getLabelText('Status', templatetype),
    _style: { width: '20%' }
  },
  {
    key: 'show_details',
    label: '',
    _style: { width: '1%' },
    filter: false,
    sorter: false,
  },
];