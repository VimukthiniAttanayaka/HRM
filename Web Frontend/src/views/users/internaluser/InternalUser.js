import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'
import InternalUserDataGrid from './InternalUserDataGrid'

const InternalUser = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Internal User List</strong>
        </CCardHeader>
        <CCardBody>
          <InternalUserDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default InternalUser
