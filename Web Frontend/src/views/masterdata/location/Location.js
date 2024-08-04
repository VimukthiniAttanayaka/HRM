import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import LocationDataGrid from './LocationDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'

const Location = () => {
  let templatetype = 'translation_location'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>    {getLabelText('Location List', templatetype)}</strong>
        </CCardHeader>
        <CCardBody>
          <LocationDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Location
