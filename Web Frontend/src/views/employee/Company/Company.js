import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import CompanyDataGrid from './CompanyDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'

const Customer = () => {
  let templatetype = 'translation_company'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>Department List</strong> */}
          {getLabelText('Company List', templatetype)}
        </CCardHeader>
        <CCardBody>
          <CompanyDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Customer
