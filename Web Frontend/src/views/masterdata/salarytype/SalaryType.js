import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import SalaryTypeDataGrid from './SalaryTypeDataGrid'
import SalaryTypePopup from './SalaryTypePopup'

const SalaryType = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>SalaryType List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <SalaryTypePopup /> */}
          <SalaryTypeDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default SalaryType
