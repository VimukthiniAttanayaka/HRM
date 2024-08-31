
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_employee'
let templatetype_base = 'translation'

export const columns = [
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
  },  {
    key: 'LastName',
    label: 'LastName',
    _style: { width: '20%' },
  },
  {
    key: 'EmployeeType',
    label: 'Employee Type',
    _style: { width: '25%' }
  },
  {
    key: 'PrefferedName',
    label: 'Preffered Name',
    _style: { width: '25%' }
  },
  {
    key: 'ReportingManager',
    label: 'Reporting Manager',
    _style: { width: '25%' }
  },
  {
    key: 'MobileNumber',
    label: 'Mobile Number',
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

export const headers = [["id", "FirstName", "LastName", "EmployeeType", "PrefferedName", "ReportingManager", "MobileNumber", "status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.id, elt.FirstName, elt.LastName, elt.EmployeeType, elt.PrefferedName, elt.ReportingManager, elt.MobileNumber, elt.status]);
}