import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CModalTitle, CModalFooter, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
const LeaveTypePopup = () => {
  const [visible, setVisible] = useState(false)

  const handleSubmit = (event) => {
    event.preventDefault();

  };
  return (
    <>
      <CButton color="primary" onClick={() => setVisible(!visible)}>New Employee</CButton>
      <CModal
        alignment="center"
        visible={visible}
        onClose={() => setVisible(false)}
        aria-labelledby="TooltipsAndPopoverExample"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New Employee</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CFormInput placeholder="Company Id" name="customerId"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CFormInput placeholder="Company Name" name="companyName"
                  // value={companyName} onChange={handleChangeName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CFormInput placeholder="Block Building Number" name="blockBuildingNumber"
                  // value={blockBuildingNumber} onChange={handleChangeBlockBuildingNumber}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CFormInput placeholder="Address Building Name" name="addressBuildingName"
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CFormInput placeholder="Address Unit Number" name="addressUnitNumber"
                  // value={addressUnitNumber} onChange={handleChangeAddressUnitNumber}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CFormInput placeholder="Address Street Name" name="addressStreetName"
                  // value={addressStreetName} onChange={handleChangeAddressStreetName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CFormInput placeholder="Address City" name="addressCity"
                  // value={addressCity} onChange={handleChangeAddressCity}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CFormInput placeholder="Address Country Code" name="addressCountryCode"
                  // value={addressCountryCode} onChange={handleChangeAddressCountryCode}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CFormInput placeholder="Address Postal Code" name="addressPostalCode"
                  // value={addressPostalCode} onChange={handleChangeAddressPostalCode}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CFormInput placeholder="Contact Person" name="contactPerson"
                  // value={contactPerson} onChange={handleChangeContactPerson}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CFormInput placeholder="Contact Number" name="contactNumber"
                  // value={contactNumber} onChange={handleChangeContactNumber}
                  />
                </CInputGroup>
                <div className="d-grid">
                  <CButton color="success" type='submit'>Submit</CButton>
                </div>
              </CForm>
            </CCardBody>
          </CCard>
        </CModalBody>
      </CModal>
    </>
  )
}
export default LeaveTypePopup
