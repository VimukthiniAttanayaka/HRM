
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_jobrole'
let templatetype_base = 'translation'

export const columns = [
  {
    key: 'id',
    label: getLabelText('ID', templatetype),
    // label: '',
    // filter: false,
    // sorter: false,
    _style: { width: '20%' },
  },
  {
    key: 'JobRole',
    label: getLabelText('JobRole', templatetype),
    _style: { width: '20%' },
  },

  // {
  //   key: 'alotment',
  //   _style: { width: '20%' }
  // },
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