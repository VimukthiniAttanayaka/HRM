import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import CountryDataGrid from './CountryDataGrid'

const Country = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Country List</strong>
        </CCardHeader>
        <CCardBody>
          <CountryDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Country
