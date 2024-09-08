// import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import AnswersApprovalDataGrid from './AnswersApprovalDataGrid.js'
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

window.classtype = 'LeaveEntitlement'

const AnswersList_ExcelUpload = () => {
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
          <AnswersApprovalDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default AnswersList_ExcelUpload
