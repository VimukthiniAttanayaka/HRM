import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'
import { DocsExample } from 'src/components'

import SmartTableBasixExample from '../../smart-table/SmartTableBasixExample'

const Employee = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Employee List</strong>
        </CCardHeader>
        <CCardBody>
          <DocsExample href="components/smart-table/">
            <SmartTableBasixExample />
          </DocsExample>
        </CCardBody>
      </CCard>
    </>
  )
}

export default Employee
