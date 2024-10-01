
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_employeeleaveentitlement'
let templatetype_base = 'translation'

export const columns = [
  {
    key: 'id',
    label: 'ID',
    filter: false,
    sorter: false,
  },
  {
    key: 'LeaveType',
    label: 'LeaveType',
    _style: { width: '20%' },
  },
  {
    key: 'ActiveFrom',
    label: 'ActiveFrom',
    _style: { width: '25%' }
  },
  {
    key: 'ActiveTo',
    label: 'ActiveTo',
    _style: { width: '25%' }
  },
  {
    key: 'LeaveAlotment',
    label: 'LeaveAlotment',
    _style: { width: '20%' },
  }, {
    key: 'Remain',
    label: 'Remain',
    _style: { width: '25%' }
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


export const columns_search = [
  {
    key: 'id',
    label: 'ID',
    filter: false,
    sorter: false,
  },
  {
    key: 'FirstName',
    label: 'FirstName',
    _style: { width: '20%' },
  }, {
    key: 'LastName',
    label: 'LastName',
    _style: { width: '20%' },
  },
  {
    key: 'PrefferedName',
    label: 'Preffered Name',
    _style: { width: '25%' }
  },
  {
    key: 'SalaryType',
    label: 'SalaryType',
    _style: { width: '25%' }
  },
  {
    key: 'status',
    _style: { width: '20%' }
  },
  {
    key: 'select',
    _style: { width: '20%' }
  },
];


export const headers = [["id", "FirstName", "LastName", "EmployeeType", "PrefferedName", "ReportingManager", "MobileNumber", "status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.id, elt.FirstName, elt.LastName, elt.EmployeeType, elt.PrefferedName, elt.ReportingManager, elt.MobileNumber, elt.status]);
}