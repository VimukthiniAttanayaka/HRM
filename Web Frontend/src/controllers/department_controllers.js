
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_department'
let templatetype_base = 'translation'

export  const columns = [
  {
    key: 'id',
    // label: '',
    label: getLabelText('ID', templatetype),
    // filter: false,
    // sorter: false,
    _style: { width: '20%' },
  },
  {
    key: 'Department',
    label: getLabelText('Department', templatetype),
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
