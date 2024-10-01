
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_leavetype'
let templatetype_base = 'translation'

export  const columns = [
  {
    key: 'id',
    // label: '',
    label:  getLabelText('ID', templatetype),
     // filter: false,
    // sorter: false,
    _style: { width: '20%' },
  },
  {
    key: 'leavetype',
    label:  getLabelText('LeaveType', templatetype),
      _style: { width: '20%' },
  },
  {
    key: 'alotment',
    label:  getLabelText('alotment', templatetype),
      _style: { width: '20%' },
  }, {
    key: 'duration',
    label:  getLabelText('duration', templatetype),
      _style: { width: '20%' },
  },
  {
    key: 'status',
    label:  getLabelText('Status', templatetype),
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

export const headers = [["id", "location", "status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.id, elt.location, elt.status]);
}