// import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import ExitInterviewQuestionsDataGrid from './ExitInterviewQuestions_ExcelUploadDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'
import ExcelFileReader from '../../shared/ExcelRelated/UploaderReader/ExcelFileReader.js'
import { getExitInterviewQuestionsAll } from '../../../apicalls/exitinterviewquestions/get_all_list.js';
import { getExitInterviewQuestionsSingle } from '../../../apicalls/exitinterviewquestions/get_exitinterviewquestions_single.js';
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns, headers } from '../../controllers/exitinterviewquestions_controllers.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';
import React, { createContext, useContext } from 'react';

window.classtype = 'ExitInterviewQuestionss'

const ExitInterviewQuestions_ExcelUpload = () => {
  let templatetype = 'translation_ExitInterviewQuestions'

  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>Department List</strong> */}
          {getLabelText('ExitInterviewQuestions List', templatetype)}
        </CCardHeader>
        <CCardBody>
        <ExcelFileReader />
          <ExitInterviewQuestionsDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default ExitInterviewQuestions_ExcelUpload
