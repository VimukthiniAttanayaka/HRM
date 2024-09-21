
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_userrole'
let templatetype_base = 'translation'

export const columns = [
  {
    key: 'id',
    _style: { width: '20%' },
    label: 'id',
    // filter: false,
    // sorter: false,
  },
  {
    key: 'userrole',
     label: 'user role',
    _style: { width: '20%' },
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
  {
    key: 'view',
    label: '',
    _style: { width: '1%' },
    filter: false,
    sorter: false,
  },
  {
    key: 'delete',
    label: '',
    _style: { width: '1%' },
    filter: false,
    sorter: false,
  },
];

export const headers = [["id", "userrole", "status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.id, elt.userrole, elt.status]);
}

export const columnsGroup = [
  {
    key: 'id',
    label: 'id',
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
