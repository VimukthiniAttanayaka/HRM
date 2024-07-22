import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import InternalUserDataGrid from './InternalUserDataGrid'
import InternalUserPopup from './InternalUserPopup'

const InternalUser = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Internal User List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <InternalUserPopup /> */}
          <InternalUserDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default InternalUser
