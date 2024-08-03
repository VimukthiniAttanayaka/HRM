import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import JobRoleDataGrid from './JobRoleDataGrid'

const JobRole = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>JobRole List</strong>
        </CCardHeader>
        <CCardBody>
          <JobRoleDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default JobRole
