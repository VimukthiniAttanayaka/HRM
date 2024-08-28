

import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_company'
let templatetype_base = 'translation'

export const columns = [
    {
      key: 'CUS_ID',
      label: 'ID',
      filter: false,
      sorter: false,
    },
    {
      key: 'CUS_CompanyName',
      label: getLabelText('Name', templatetype),
      _style: { width: '20%' },
    },
    {
      key: 'CUS_ContactPerson',
      label: getLabelText('Company', templatetype),
      _style: { width: '20%' },
    },
    {
      key: 'CUS_ContactNumber',
      label: getLabelText('Company', templatetype),
      _style: { width: '20%' },
    },
    // {
    //   key: 'alotment',
    //   _style: { width: '20%' }
    // },
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