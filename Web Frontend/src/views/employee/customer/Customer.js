import React from 'react'
import {
  CButton,
  CCard,
  CCardBody,
  CCol,
  CContainer,
  CForm,
  CFormInput,
  CInputGroup,
  CInputGroupText,
  CRow,
  CFormCheck,
  CFormSelect,
} from '@coreui/react-pro'
import CIcon from '@coreui/icons-react'
import { cilLockLocked, cilUser } from '@coreui/icons'

const Customer = () => {
  return (
    <div className="bg-body-tertiary min-vh-100 d-flex flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md={9} lg={7} xl={6}>
            <CCard className="mx-4">
              <CCardBody className="p-4">
                <CForm>
                  <h1>Edit</h1>
                  <p className="text-body-secondary">Edit Your Company Details</p>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Customer Id" autoComplete="username" />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Company Name" autoComplete="username" />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Block Building Number" autoComplete="username" />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Address Building Name" autoComplete="username" />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Address Unit Number" autoComplete="username" />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Address Street Name" autoComplete="username" />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Address City" autoComplete="username" />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Address Country Code" autoComplete="username" />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Address Postal Code" autoComplete="username" />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Contact Person" autoComplete="username" />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Contact Number" autoComplete="username" />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CFormSelect>
                      <option>Pin or Password</option>
                      <option value="PIN">Pin</option>
                      <option value="PWD">Password</option>
                    </CFormSelect>
                  </CInputGroup>
                  <CInputGroup className="mb-4">
                    <CFormCheck label="OTP by sms" defaultChecked />
                  </CInputGroup>
                  <CInputGroup className="mb-4">
                    <CFormCheck label="OTP by email" defaultChecked />
                  </CInputGroup>
                  <CInputGroup className="mb-4">
                    <CFormCheck label="Status" defaultChecked />
                  </CInputGroup>
                  <div className="d-grid">
                    <CButton color="success">Submit</CButton>
                  </div>
                </CForm>
              </CCardBody>
            </CCard>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default Customer
