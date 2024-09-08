
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_accessgroup'
let templatetype_base = 'translation'

export 
const columns = [
   {
    key: 'InTime',
    label: 'InTime',
    filter: false,
    sorter: false,
  },
   {
    key: 'OutTime',
    label: 'OutTime',
    filter: false,
    sorter: false,
  },
   {
    key: 'Reason',
    label: 'Reason',
    filter: false,
    sorter: false,
  },
   {
    key: 'EndDate',
    label: 'EndDate',
    filter: false,
    sorter: false,
  },
   {
    key: 'Total',
    label: 'Total',
    filter: false,
    sorter: false,
  },
   {
    key: 'DateString',
    label: 'DateString',
    filter: false,
    sorter: false,
  },
   {
    key: 'AttendanceDate',
    label: 'AttendanceDate',
    filter: false,
    sorter: false,
  },
   {
    key: 'StartDate',
    label: 'StartDate',
    filter: false,
    sorter: false,
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
