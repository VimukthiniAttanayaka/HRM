
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_department'
let templatetype_base = 'translation'

export  const columns = [
  {
    key: 'id',
    // label: '',
    // filter: false,
    // sorter: false,
  },
  {
    key: 'userrole',
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
];

export const headers = [["id", "branch", "status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.id, elt.branch, elt.status]);
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
