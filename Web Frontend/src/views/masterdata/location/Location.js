import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import LocationDataGrid from './LocationDataGrid'

const Location = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Location List</strong>
        </CCardHeader>
        <CCardBody>
          <LocationDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Location
