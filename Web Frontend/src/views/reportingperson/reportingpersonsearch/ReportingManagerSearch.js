import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import ReportingManagerSearchDataGrid from './ReportingManagerSearchDataGrid'
import ReportingManagerSearchPopup from './ReportingManagerSearchPopup'

const ReportingManagerSearch = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>ReportingManagerSearch List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <ReportingManagerSearchPopup /> */}
          <ReportingManagerSearchDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default ReportingManagerSearch
