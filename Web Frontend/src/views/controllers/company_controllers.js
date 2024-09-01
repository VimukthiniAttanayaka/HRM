

import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_company'
let templatetype_base = 'translation'

export const columns = [
  {
    key: 'ID',
    label: 'ID',
    filter: false,
    sorter: false,
  },
  {
    key: 'CompanyName',
    label: getLabelText('CompanyName', templatetype),
    _style: { width: '20%' },
  },
  {
    key: 'GroupCompany',
    label: getLabelText('GroupCompany', templatetype),
    _style: { width: '20%' },
  },
  {
    key: 'ContactPerson',
    label: getLabelText('ContactPerson', templatetype),
    _style: { width: '20%' },
  },
  {
    key: 'ContactNumber',
    label: getLabelText('ContactNumber', templatetype),
    _style: { width: '20%' },
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


export const headers = [["id", "CompanyName", "GroupCompany", "ContactPerson", "ContactNumber", "status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.id, elt.CompanyName, elt.GroupCompany, elt.ContactPerson, elt.ContactNumber, elt.status]);
}