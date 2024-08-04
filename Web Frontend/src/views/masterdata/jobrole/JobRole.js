import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import JobRoleDataGrid from './JobRoleDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'

const JobRole = () => {
  let templatetype = 'translation_jobrole'
  let templatetype_base = 'translation'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>    {getLabelText('JobRole List', templatetype)}</strong>
        </CCardHeader>
        <CCardBody>
          <JobRoleDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default JobRole
