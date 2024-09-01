
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_department'
let templatetype_base = 'translation'

export const columns = [
  {
    key: 'UserName',
    // label: '',
    // filter: false,
    // sorter: false,
  },
  {
    key: 'EmailAddress',
    _style: { width: '20%' },
  },{
    key: 'EmployeeID',
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

export const headers = [["id", "branch", "status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.id, elt.branch, elt.status]);
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