
import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype = 'translation_department'
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
      key: 'ReportingManager',
      _style: { width: '20%' },
    },

    {
      key: 'AllocatedTeam',
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

export const headers = [["id", "ReportingManager", "AllocatedTeam", "status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.id, elt.ReportingManager, elt.AllocatedTeam, elt.status]);
}