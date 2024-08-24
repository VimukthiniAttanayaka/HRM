
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_employee'
let templatetype_base = 'translation'

export const columns = [
    {
      key: 'EME_EmployeeID',
      label: 'ID',
      filter: false,
      sorter: false,
    },
    {
      key: 'EME_FirstName',
      label: 'Name',
      _style: { width: '20%' },
    },
    {
      key: 'EME_EmployeeType',
      label: 'Employee Type',
      _style: { width: '25%' }
    },
    {
      key: 'EME_PrefferedName',
      label: 'Preffered Name',
      _style: { width: '25%' }
    },
    {
      key: 'EME_ReportingManager',
      label: 'Reporting Manager',
      _style: { width: '25%' }
    },
    {
      key: 'EME_MobileNumber',
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
 