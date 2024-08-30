import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'
import ExitInterviewAnswwersDataGrid from './ExitInterviewAnswersDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'

const ExitInterviewAnswwers = () => {
  let templatetype = 'translation_department'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>Department List</strong> */}
          {getLabelText('Department List', templatetype)}
        </CCardHeader>
        <CCardBody>
          <ExitInterviewAnswwersDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default ExitInterviewAnswwers
