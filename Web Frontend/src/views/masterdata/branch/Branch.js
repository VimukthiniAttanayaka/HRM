import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import BranchDataGrid from './BranchDataGrid'

const Branch = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Branch List</strong>
        </CCardHeader>
        <CCardBody>
          <BranchDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default Branch
