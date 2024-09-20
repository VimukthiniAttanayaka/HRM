
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_accessgroup'
let templatetype_base = 'translation'

export const columns = [
  {
    key: 'id',
    // label: '',
    // filter: false,
    // sorter: false,
    _style: { width: '20%' },
  },
  {
    key: 'AccessGroup',
    _style: { width: '80%' },
  },
  {
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

export const headers = [["id", "AccessGroup", "status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.id, elt.AccessGroup, elt.status]);
}

export const columnsMenu = [
  {
    key: 'id',
    label: 'id',
    // filter: false,
    // sorter: false,
    _style: { width: '20%' },
  },
  {
    key: 'usermenu',
    _style: { width: '80%' },
  },
  {
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

export const columns_UserAccess = [
  {
    key: 'AccessGroup',
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