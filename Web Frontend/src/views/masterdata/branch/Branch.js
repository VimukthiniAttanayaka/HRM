import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import BranchDataGrid from './BranchDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'

const Branch = () => {
  let templatetype = 'translation_branch'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>{getLabelText('Branch List', templatetype)}</strong>
        </CCardHeader>
        <CCardBody>
          <BranchDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Branch
