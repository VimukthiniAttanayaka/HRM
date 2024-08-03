import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import DepartmentDataGrid from './DepartmentDataGrid'

const Department = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Department List</strong>
        </CCardHeader>
        <CCardBody>
          <DepartmentDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Department
