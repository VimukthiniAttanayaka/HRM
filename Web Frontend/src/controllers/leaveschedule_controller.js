

import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_leaveschedule'
let templatetype_base = 'translation'

export const columns = [
  {
    key: 'id',
    label: '',
    filter: false,
    sorter: false,
  },
  {
    key: 'entitlement',
    _style: { width: '20%' },
  },
  // 'leavetype',
  {
    key: 'leavetype',
    _style: { width: '20%' }
  }, {
    key: 'startdate',
    _style: { width: '20%' }
  }, {
    key: 'enddate',
    _style: { width: '20%' }
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