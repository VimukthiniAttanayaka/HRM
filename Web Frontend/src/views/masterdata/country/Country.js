import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import CountryDataGrid from './CountryDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'

const Country = () => {
  let templatetype = 'translation_country'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>{getLabelText('Country List', templatetype)}</strong>
        </CCardHeader>
        <CCardBody>
          <CountryDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Country
