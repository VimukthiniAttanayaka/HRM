import React from 'react'
import { CCard, CCardHeader, CCardBody,CModal } from '@coreui/react-pro'
import { DocsExample } from 'src/components'

import EmployeeDataGrid from './EmployeeDataGrid'
import EmployeePopup from './EmployeePopup'

const Employee = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Employee List</strong>
        </CCardHeader>
        <CCardBody>
        <EmployeePopup />
            <EmployeeDataGrid />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Employee
