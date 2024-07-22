import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import ExternalUserDataGrid from './ExternalUserDataGrid'
import ExternalUserPopup from './ExternalUserPopup'

const ExternalUser = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Internal User List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <ExternalUserPopup /> */}
          <ExternalUserDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default ExternalUser
