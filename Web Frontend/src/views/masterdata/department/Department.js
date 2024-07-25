import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import DepartmentDataGrid from './DepartmentDataGrid'
import DepartmentPopup from './DepartmentPopup'

const Department = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Department List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <DepartmentPopup /> */}
          <DepartmentDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default Department
