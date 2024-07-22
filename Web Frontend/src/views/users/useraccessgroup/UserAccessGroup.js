import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import UserAccessGroupDataGrid from './UserAccessGroupDataGrid'
import UserAccessGroupPopup from './UserAccessGroupPopup'

const UserRole = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>UserRole List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <UserRolePopup /> */}
          <UserAccessGroupDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default UserRole
