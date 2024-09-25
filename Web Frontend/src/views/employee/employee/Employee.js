import React, { useState } from 'react'
import { CCard, CCardHeader, CCardBody, CModal } from '@coreui/react-pro'
import { DocsExample } from 'src/components'
import { Translation } from 'react-i18next'
import EmployeeDataGrid from './EmployeeDataGrid'
import EmployeePopup from './EmployeePopup_Old'
import { getLabelText } from 'src/MultipleLanguageSheets'

const Employee = () => {
  let templatetype='translation_employee'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
   {/* <Translation ns={[templatetype]}>
{
  (t) => <strong>{t('Employee List 1', { ns: templatetype })}</strong>
}

</Translation> */}
{getLabelText('Employee List',templatetype)}

        </CCardHeader>
        <CCardBody>
          <EmployeeDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Employee
