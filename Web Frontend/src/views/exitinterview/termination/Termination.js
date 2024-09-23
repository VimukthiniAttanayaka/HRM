import React from 'react'
import { CCard, CCardHeader, CCardBody, CRow, CCol, CInputGroupText, CFormInput, CInputGroup, CButton } from '@coreui/react-pro'
import { getLabelText } from 'src/MultipleLanguageSheets'

const Termination = () => {
  let templatetype = 'translation_Termination'
  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>Termination List</strong> */}
          {getLabelText('Termination List', templatetype)}
        </CCardHeader>
        <CCardBody>
          <CRow><CCol>
            <CInputGroup className="mb-3">
              <CCol md={4}>
                <CInputGroupText>
                  <h6>Employee ID</h6>
                </CInputGroupText>
              </CCol>
              <CCol md={4}>
                <CFormInput maxLength={20} placeholder="Employee ID" name="EmployeeID" />
              </CCol>
              <CCol md={4}>
                <CButton color="primary"
                  className="mb-2">Search</CButton>
              </CCol>   </CInputGroup>
          </CCol></CRow>
          <CRow><CCol>
            <CInputGroup className="mb-3">
              <CCol md={4}>
                <CInputGroupText>
                  <h6>NIC</h6>
                </CInputGroupText>
              </CCol>
              <CCol md={4}>
                <CFormInput readOnly maxLength={20} placeholder="NIC" name="NIC" />
              </CCol>
              <CCol md={4}>   </CCol>
            </CInputGroup>
          </CCol></CRow>
          <CRow>
            <CCol>
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>Passport</h6>
                  </CInputGroupText>
                </CCol>
                <CCol md={4}><CFormInput readOnly maxLength={20} placeholder="Passport" name="Passport" />
                </CCol>
                <CCol md={4}>   </CCol>
              </CInputGroup>
            </CCol></CRow>
          <CRow>
            <CCol>
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>FirstName</h6>
                  </CInputGroupText>
                </CCol>
                <CCol md={4}><CFormInput readOnly placeholder="FirstName" name="FirstName" />
                </CCol>
                <CCol md={4}>   </CCol>
              </CInputGroup>
            </CCol></CRow>
          <CRow>
            <CCol>
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>LastName</h6>
                  </CInputGroupText>
                </CCol>
                <CCol md={4}><CFormInput readOnly placeholder="LastName" name="LastName" />
                </CCol>
                <CCol md={4}>   </CCol>
              </CInputGroup>
            </CCol>
          </CRow>
          <CRow><CCol>
            <CInputGroup className="mb-3">
              <CCol md={4}>   </CCol>
              <CCol md={4}>  <CButton color="primary"
                className="mb-2">Confirm Termination</CButton></CCol>
              <CCol md={4}>   </CCol>
            </CInputGroup>
          </CCol>
          </CRow>
        </CCardBody >
      </CCard >
    </>
  )
}

export default Termination
