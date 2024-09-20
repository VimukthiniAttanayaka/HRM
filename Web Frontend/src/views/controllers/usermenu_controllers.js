
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_usermenu'
let templatetype_base = 'translation'

export 
const columns = [
  {
    key: 'id',
    // label: '',
    // filter: false,
    // sorter: false,
  },
  {
    key: 'usermenu',
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

export const headers = [["id", "usermenu", "status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.id, elt.usermenu, elt.status]);
}

export const columns_AccessGroup = [
  {
    key: 'UserMenu',
    label: 'Menu Name',
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