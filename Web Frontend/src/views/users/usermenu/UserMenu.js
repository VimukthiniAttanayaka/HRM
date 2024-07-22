import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import UserMenuDataGrid from './UserMenuDataGrid'
import UserMenuPopup from './UserMenuPopup'

const UserRole = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>UserRole List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <UserRolePopup /> */}
          <UserMenuDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default UserRole
