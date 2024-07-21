import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import LeaveTypeDataGrid from './InternalUserDataGrid'
import LeaveTypePopup from './InternalUserPopup'

const LeaveType = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>LeaveType List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <LeaveTypePopup /> */}
          <LeaveTypeDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default InternalUser
