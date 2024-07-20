import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import LeaveTypeDataGrid from './LeaveEntitlementDataGrid'
import LeaveTypePopup from './LeaveEntitlementPopup'

const LeaveEntitlement = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>LeaveEntitlement List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <LeaveTypePopup /> */}
          <LeaveTypeDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default LeaveEntitlement
