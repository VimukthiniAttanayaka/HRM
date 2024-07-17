import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'
import { DocsExample } from 'src/components'

import SmartTableDownloadableExample from './SmartTableDownloadableExample'

const Employee = () => {
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <strong>Employee List</strong>
        </CCardHeader>
        <CCardBody>
            <SmartTableDownloadableExample />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Employee
