import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import ReportingManagerSearchDataGrid from './ReportingManagerDataGrid'
import ReportingManagerSearchPopup from './ReportingManagerSearchPopup'

const ReportingManagerSearch = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Reporting Manager Search</strong>
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
