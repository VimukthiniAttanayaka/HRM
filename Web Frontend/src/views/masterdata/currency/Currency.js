import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import CurrencyDataGrid from './CurrencyDataGrid'
import CurrencyPopup from './CurrencyPopup'
import { getLabelText } from 'src/MultipleLanguageSheets'

const Currency = () => {
  let templatetype = 'translation_currency'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>{getLabelText('Currency List', templatetype)}</strong>
        </CCardHeader>
        <CCardBody>
          {/* <CurrencyPopup /> */}
          <CurrencyDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Currency
