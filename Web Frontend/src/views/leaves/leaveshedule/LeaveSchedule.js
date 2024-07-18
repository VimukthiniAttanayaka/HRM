import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import LeaveScheduleDataGrid from './LeaveScheduleDataGrid'
import LeaveSchedulePopup from './LeaveSchedulePopup'

const LeaveSchedule = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>LeaveSchedule List</strong>
        </CCardHeader>
        <CCardBody>
  <LeaveSchedulePopup/>
            <LeaveScheduleDataGrid />
          
        </CCardBody>
      </CCard>
    </>
  )
}

export default LeaveSchedule
