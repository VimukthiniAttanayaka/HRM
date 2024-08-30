import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'
import ExitInterviewQuestionsDataGrid from './ExitInterviewQuestionsDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'

const ExitInterviewQuestions = () => {
  let templatetype = 'translation_department'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>Department List</strong> */}
          {getLabelText('Department List', templatetype)}
        </CCardHeader>
        <CCardBody>
          <ExitInterviewQuestionsDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default ExitInterviewQuestions
