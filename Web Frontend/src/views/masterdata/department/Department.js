import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import DepartmentDataGrid from './DepartmentDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'
import { Translation } from 'react-i18next'

const Department = () => {
  let templatetype='translation_department'
   return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>Department List</strong> */}
          {getLabelText('Department List',templatetype)}
        </CCardHeader>
        <CCardBody>
          <DepartmentDataGrid  onOpen={() => handleOpenPopup}/>
        </CCardBody>
      </CCard>
    </>
  )
}

export default Department
