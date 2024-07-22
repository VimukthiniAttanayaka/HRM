import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import AccessGroupDataGrid from './AccessGroupDataGrid'
import AccessGroupPopup from './AccessGroupPopup'

const AccessGroup = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Access Group List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <AccessGroupPopup /> */}
          <AccessGroupDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default AccessGroup
