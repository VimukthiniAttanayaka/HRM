import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import JobTypeDataGrid from './JobTypeDataGrid'
import JobTypePopup from './JobTypePopup'

const JobType = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>JobType List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <JobTypePopup /> */}
          <JobTypeDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default JobType
