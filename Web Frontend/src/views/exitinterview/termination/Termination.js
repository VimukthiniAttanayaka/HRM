import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'
import TerminationDataGrid from './TerminationDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'

const Termination = () => {
  let templatetype = 'translation_Termination'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>Termination List</strong> */}
          {getLabelText('Termination List', templatetype)}
        </CCardHeader>
        <CCardBody>
          <TerminationDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Termination
