import React, { useState } from 'react'
import { CCard, CCardHeader, CCardBody, CModal } from '@coreui/react-pro'
import { DocsExample } from 'src/components'

import EmployeeJobDescriptionDataGrid from './EmployeeJobDescriptionDataGrid'
import EmployeeJobDescriptionPopup from './EmployeeJobDescriptionPopup'

const EmployeeJobDescription = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Employee Job Description List</strong>
        </CCardHeader>
        <CCardBody>
          <EmployeeJobDescriptionDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default EmployeeJobDescription
