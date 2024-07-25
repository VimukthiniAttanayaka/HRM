import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import CurrencyDataGrid from './CurrencyDataGrid'
import CurrencyPopup from './CurrencyPopup'

const Currency = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Currency List</strong>
        </CCardHeader>
        <CCardBody>
          {/* <CurrencyPopup /> */}
          <CurrencyDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default Currency
