import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'
import { DocsExample } from 'src/components'

import SmartTableBasixExample from '../../smart-table/SmartTableBasixExample'

const Leavetype = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Leavetype List</strong>
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

export default Leavetype
