import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import MenuAccessGroupPopup from './MenuAccessGroupPopup'
import MenuAccessGroupDataGrid from './MenuAccessGroupDataGrid'

const UserRole = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>UserRole List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <UserRolePopup /> */}
          <MenuAccessGroupDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default UserRole
