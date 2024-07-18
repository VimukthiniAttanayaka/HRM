import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import AttendanceDataGrid from './AttendanceDataGrid'
import AttendancePopup from './AttendancePopup'

const Attendance = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>LeaveType List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <AttendancePopup/> */}
            {/* <AttendanceDataGrid /> */}
        </CCardBody>
      </CCard>
    </>
  )
}

export default Attendance
