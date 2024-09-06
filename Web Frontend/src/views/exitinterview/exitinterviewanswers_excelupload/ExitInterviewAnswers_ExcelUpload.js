// import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import CompanyDataGrid from './ExitInterviewAnswers_ExcelUploadDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'
import ExcelFileReader from '../../shared/ExcelRelated/UploaderReader/ExcelFileReader.js'
import { getExitInterviewAnswersAll } from '../../../apicalls/exitinterviewquestions/get_all_list.js';
import { getExitInterviewAnswersSingle } from '../../../apicalls/exitinterviewquestions/get_exitinterviewquestions_single.js';
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns, headers } from '../../controllers/exitinterviewquestions_controllers.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';
import React, { createContext, useContext } from 'react';

window.classtype = 'ExitInterviewAnswerss'

const ExitInterviewAnswers_ExcelUpload = () => {
  let templatetype = 'translation_ExitInterviewAnswers'

  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>Department List</strong> */}
          {getLabelText('Company List', templatetype)}
        </CCardHeader>
        <CCardBody>
        <ExcelFileReader />
          <CompanyDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default ExitInterviewAnswers_ExcelUpload
