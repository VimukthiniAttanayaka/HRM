import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import DepartmentDataGrid from './CompanyDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'

const Customer = () => {
  let templatetype = 'translation_department'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>Department List</strong> */}
          {getLabelText('Department List', templatetype)}
        </CCardHeader>
        <CCardBody>
          <DepartmentDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Customer
