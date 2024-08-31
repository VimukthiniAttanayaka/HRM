import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'
import ExitInterviewQuestionsDataGrid from './ExitInterviewQuestionsDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'

const ExitInterviewQuestions = () => {
  let templatetype = 'translation_exitinterviewquestions'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>ExitInterviewQuestions List</strong> */}
          {getLabelText('Exit Interview Questions List', templatetype)}
        </CCardHeader>
        <CCardBody>
          <ExitInterviewQuestionsDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default ExitInterviewQuestions
