import React, { useState, useEffect } from 'react'
import { CCard, CCardHeader, CCardBody, CRow, CCol, CInputGroupText, CFormInput, CFormCheck, CInputGroup, CButton } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';

import { getEmployeeSingle } from '../../../apicalls/employee/get_employee_single.js';
import { addNewTermination } from '../../../apicalls/termination/add_new.js';

import { getLabelText } from 'src/MultipleLanguageSheets'

import PopUpAlert from '../../shared/PopUpAlert.js'

const Termination = () => {
  let templatetype = 'translation_Termination'
  let templatetype_base = 'translation'

  const [EmployeeID, setEmployeeID] = useState('')
  const [NIC, setNIC] = useState('')
  const [Passport, setPassport] = useState('')
  const [LastName, setLastName] = useState('')
  const [FirstName, setFirstName] = useState('')
  const [Remarks, setRemarks] = useState('')
  const [IsBlackListed, setIsBlackListed] = useState(false)
  const [IsForceTerminated, setIsForceTerminated] = useState(false)
  const handleChangeEmployeeID = (event) => { setEmployeeID(event.target.value) }
  const handleChangeIsBlackListed = (event) => { setIsBlackListed(event.target.checked) }
  const handleChangeIsForceTerminated = (event) => { setIsForceTerminated(event.target.checked) }
  const handleChangeRemarks = (event) => { setRemarks(event.target.value) }

  async function loadDetails(item) {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      EME_EmployeeID: EmployeeID
    }

    const EmployeeDetails = await getEmployeeSingle(formData)
    // console.log(EmployeeDetails)
    setNIC(EmployeeDetails.EME_NIC)
    setPassport(EmployeeDetails.EME_Passport)
    setLastName(EmployeeDetails.EME_LastName)
    setFirstName(EmployeeDetails.EME_FirstName)
  }

  async function confirmTermination(item) {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      UD_UserID: staffId,
      // AUD_notificationToken: token,
      EET_EmployeeID: EmployeeID,
      EET_Remarks: Remarks,
      EET_IsBlackListed: IsBlackListed,
      EET_IsForceTerminated: IsForceTerminated
    }
    const APIReturn = await addNewTermination(formData)
    if (APIReturn.resp === false) { setDialogTitle("Alert"); }
    else { setDialogTitle("Message"); }
    setDialogContent(APIReturn.msg);
    setOpen(true);
  }

  const [open, setOpen] = useState(false);

  const handleClose = () => {
    setOpen(false);
    clearForm();
  };

  const clearForm = () => {
    setNIC('')
    setPassport('')
    setLastName('')
    setFirstName('')
    setEmployeeID('')
    setRemarks('')
    setIsBlackListed(false)
    setIsForceTerminated(false)
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');
  // console.log(UserMenuDetails)

  return (
    <>
      <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />
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
                <CFormInput maxLength={20} placeholder="Employee ID" name="EmployeeID" value={EmployeeID} onChange={handleChangeEmployeeID} />
              </CCol>
              <CCol md={4}>
                <CButton color="primary"
                  className="mb-2"
                  onClick={() => {
                    loadDetails(EmployeeID)
                  }}>Search</CButton>
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
                <CFormInput readOnly maxLength={20} placeholder="NIC" name="NIC" value={NIC} />
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
                <CCol md={4}><CFormInput readOnly maxLength={20} placeholder="Passport" name="Passport" value={Passport} />
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
                <CCol md={4}><CFormInput readOnly placeholder="FirstName" name="FirstName" value={FirstName} />
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
                <CCol md={4}><CFormInput readOnly placeholder="LastName" name="LastName" value={LastName} />
                </CCol>
                <CCol md={4}>   </CCol>
              </CInputGroup>
            </CCol>
          </CRow>
          <CRow>
            <CCol>
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>Remarks</h6>
                  </CInputGroupText>
                </CCol>
                <CCol md={4}>
                  <CFormInput required placeholder="Remarks" name="Remarks" value={Remarks} onChange={handleChangeRemarks} />
                </CCol>
                <CCol md={4}>   </CCol>
              </CInputGroup>
            </CCol>
          </CRow>
          <CRow>
            <CCol>
              <CInputGroup className="mb-3">
                {/* <CCol md={4}>
                <CInputGroupText>
                  <h6>{getLabelText('IsBlackListed', templatetype)}</h6>
                </CInputGroupText>
              </CCol> */}
                <CFormCheck color="danger" checked={IsBlackListed} onChange={handleChangeIsBlackListed} label="IsBlackListed" />
              </CInputGroup>
            </CCol>
            <CCol>
              <CInputGroup className="mb-3">
                {/* <CCol md={4}>
                <CInputGroupText>
                  <h6>{getLabelText('IsForceTerminated', templatetype)}</h6>
                </CInputGroupText>
              </CCol> */}
                <CFormCheck color="danger" checked={IsForceTerminated} onChange={handleChangeIsForceTerminated} label="IsForceTerminated" />
              </CInputGroup>
            </CCol></CRow>
          <CRow>
            <CCol>
              <CInputGroup className="mb-3">
                <CCol md={4}>   </CCol>
                <CCol md={4}>
                  <CButton color="primary"
                    className="mb-2" onClick={() => {
                      confirmTermination()
                    }}>Confirm Termination</CButton></CCol>
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
