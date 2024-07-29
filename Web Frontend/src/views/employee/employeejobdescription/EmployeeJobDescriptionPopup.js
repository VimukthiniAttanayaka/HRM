import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CModal, CCol, CInputGroupText, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
import { requestdata_LeaveTypes_DropDowns_All } from '../../../apicalls/leavetype/get_all_list.js';

const EmployeeJobDescriptionPopup = ({ visible, onClose, onOpen }) => {
  const [selectedJobDescription, setSelectedJobDescription] = useState(null);
  const [optionsJobDescription, setOptionsJobDescription] = useState([]);

  const handleSubmit = (event) => {
    event.preventDefault();

  };

  async function requestdata() {
    const formData = {
      USR_EmployeeID: 'sedcx'
    }

    const JobDescriptionDetails = await requestdata_LeaveTypes_DropDowns_All(formData)
    setOptionsJobDescription(JobDescriptionDetails);

  }

  useEffect(() => {
    requestdata();
  }, []);
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New Employee Job Description</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New Employee Job Description</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4" md={9}>
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Department Id</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect value={selectedJobDescription} onChange={(e) => setSelectedJobDescription(e.target.value)}>
                    {optionsJobDescription.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Employee ID</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect value={selectedJobDescription} onChange={(e) => setSelectedJobDescription(e.target.value)}>
                    {optionsJobDescription.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>JobTitle_Code</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect value={selectedJobDescription} onChange={(e) => setSelectedJobDescription(e.target.value)}>
                    {optionsJobDescription.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
                </CInputGroup>
                {/* <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Department Id</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormInput placeholder="Department Id" name="DepartmentId"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>

                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Employee ID</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Employee ID" name="EmployeeID"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>JobTitle_Code</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="JobTitle_Code" name="JobTitle_Code"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>*/}
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>ActiveFrom</h6>
                    </CInputGroupText>
                  </CCol> <CDatePicker placeholder="ActiveFrom" name="ActiveFrom"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>ActiveTo</h6>
                    </CInputGroupText>
                  </CCol> <CDatePicker placeholder="ActiveTo" name="ActiveTo"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol><CFormCheck label="Status" defaultChecked />
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
export default EmployeeJobDescriptionPopup
