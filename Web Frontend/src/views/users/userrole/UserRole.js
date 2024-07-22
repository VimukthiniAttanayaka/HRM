import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import UserRoleDataGrid from './UserRoleDataGrid'
import UserRolePopup from './UserRolePopup'

const UserRole = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>UserRole List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <UserRolePopup /> */}
          <UserRoleDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default UserRole
