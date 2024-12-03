import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import LeaveToApproveDataGrid from './LeaveToApproveDataGrid'
import LeaveToApprovePopup from './LeaveToApprovePopup'

const LeaveToApprove = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Leaves To Approve</strong>
        </CCardHeader>
        <CCardBody>
  {/* <LeaveToApprovePopup/> */}
            <LeaveToApproveDataGrid onOpen={() => handleOpenPopup} />
          
        </CCardBody>
      </CCard>
    </>
  )
}

export default LeaveToApprove
