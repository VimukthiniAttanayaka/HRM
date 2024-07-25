import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import BranchDataGrid from './BranchDataGrid'
import BranchPopup from './BranchPopup'

const Branch = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Branch List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <BranchPopup /> */}
          <BranchDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default Branch
