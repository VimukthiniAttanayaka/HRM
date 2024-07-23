import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import UserMenuDataGrid from './UserMenuDataGrid'
import UserMenuPopup from './UserMenuPopup'

const UserMenu = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>UserMenu List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <UserMenuPopup /> */}
          <UserMenuDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default UserMenu
