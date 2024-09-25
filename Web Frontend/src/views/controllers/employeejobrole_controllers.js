
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_employeejobrole'
let templatetype_base = 'translation'

export const columns = [
  {
    key: 'id',
    label: 'ID',
    filter: false,
    sorter: false,
  },
  // {
  //   key: 'Employeeid',
  //   label: 'Employeeid',
  //   isVisible:false,
  //   _style: { width: '20%' },
  // },
    {
    key: 'JobRoleID',
    label: 'JobRoleID',
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
  },  {
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
    key: 'MobileNumber',
    label: 'Mobile Number',
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