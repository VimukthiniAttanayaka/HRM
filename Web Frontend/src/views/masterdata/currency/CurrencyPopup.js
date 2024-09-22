import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';

import { modifyCurrency } from '../../../apicalls/currency/modify.js';
import { deleteCurrency } from '../../../apicalls/currency/delete.js';
import { addNewCurrency } from '../../../apicalls/currency/add_new.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import PopUpAlert from '../../shared/PopUpAlert.js'

const CurrencyPopup = ({ visible, onClose, onOpen, CurrencyDetails }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [CurrencyId, setCurrencyId] = useState('')
  const [Currency, setCurrency] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeAlotment = (event) => {
    setLeaveAlotmentId(event.target.value)
  }
  const handleChangeCurrency = (event) => {
    setCurrency(event.target.value)
  }
  const handleChangeId = (event) => {
    setCurrencyId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    // console.log(isActive)
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      MDCCY_CurrencyID: CurrencyId,
      MDCCY_Currency: Currency,
      MDCCY_Status: isActive,
      UD_UserID: staffId,
    }
    // console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyCurrency(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteCurrency(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewCurrency(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  useEffect(() => {
    setCurrencyId(CurrencyDetails.MDCCY_CurrencyID)
    setCurrency(CurrencyDetails.MDCCY_Currency)
    setIsActive(CurrencyDetails.MDCCY_Status)
  }, [CurrencyDetails]);
  console.log(CurrencyDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>{getLabelText('New Currency', templatetype)}</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New Currency</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>CurrencyID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="CurrencyID" name="CurrencyID" value={CurrencyId} onChange={handleChangeId}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Currency</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="Currency" name="Currency" value={Currency} onChange={handleChangeCurrency}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck label="Status" defaultChecked />
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
export default CurrencyPopup
