// import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import QuestionsDataGrid from './QuestionsDataGrid.js'
import { getLabelText } from 'src/MultipleLanguageSheets'
import ExcelFileReader from '../../shared/ExcelRelated/UploaderReader/ExcelFileReader.js'
// import { getLeaveEntitlementAll } from '../../../apicalls/LeaveEntitlement/get_all_list.js';
// import { getLeaveEntitlementSingle } from '../../../apicalls/LeaveEntitlement/get_LeaveEntitlement_single.js';
// import Pagination from '../../shared/Pagination.js'
// import { getBadge } from '../../shared/gridviewconstants.js';
// import { columns, headers } from '../../controllers/LeaveEntitlement_controllers.js';
// import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
// import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';
import React, { createContext, useContext } from 'react';

window.classtype = 'Questions'

const Questions = () => {
  let templatetype = 'translation_employee'

  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>Department List</strong> */}
          {getLabelText('Company List', templatetype)}
        </CCardHeader>
        <CCardBody>
        <ExcelFileReader />
          <QuestionsDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Questions
