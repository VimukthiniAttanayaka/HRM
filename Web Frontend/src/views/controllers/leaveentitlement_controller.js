

import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_leaveschedule'
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
    key: 'leavetype',
    _style: { width: '20%' },
  },

  {
    key: 'alotment',
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

export const headers = [["id", "JobRole", "status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.id, elt.JobRole, elt.status]);
}