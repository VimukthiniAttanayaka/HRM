import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';

import { modifyLocation } from '../../../apicalls/location/modify.js';
import { deleteLocation } from '../../../apicalls/location/delete.js';
import { addNewLocation } from '../../../apicalls/location/add_new.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import PopUpAlert from '../../shared/PopUpAlert.js'

const LocationPopup = ({ visible, onClose, onOpen, LocationDetails, popupStatus, StatusInDB }) => {

  let templatetype = 'translation_location'
  let templatetype_base = 'translation'
  const apiUrl = process.env.REACT_APP_API_URL;

  const [LocationId, setLocationId] = useState('')
  const [Location, setLocation] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeLocation = (event) => {
    setLocation(event.target.value)
  }
  const handleChangeId = (event) => {
    setLocationId(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }
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
      MDL_LocationID: LocationId,
      MDL_Location: Location,
      MDL_Status: isActive,
      UD_UserID: staffId,
    }
    // console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyLocation(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteLocation(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewLocation(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }


  const popupStatusSetup = (event) => {
    if (popupStatus == 'edit') {
      return getLabelText('Edit Location', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View Location', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete Location', templatetype)
    } else {
      return getLabelText('Create New Location', templatetype)
    }
  }

  useEffect(() => {
    setLocationId(LocationDetails.MDL_LocationID)
    setLocation(LocationDetails.MDL_Location)
    setIsActive(LocationDetails.MDL_Status)
  }, [LocationDetails]);
  // console.log(LocationDetails)

  const [open, setOpen] = useState(false);
  const [openEmp_Popup, setOpenEmp_Popup] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose();
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');
  // console.log(UserMenuDetails)

  return (
    <>
      <CButton color="primary" onClick={onOpen}>{getLabelText('New Location', templatetype)}</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">{popupStatusSetup()}</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('LocationID', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="LocationID" name="LocationID" value={LocationId} onChange={handleChangeId} disabled={popupStatus == 'create' ? false : true}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('Location', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="Location" name="Location" value={Location} onChange={handleChangeLocation} disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('Status', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck checked={isActive} defaultChecked onChange={handleChangeStatus} label="Status" disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
                </CInputGroup>
                <div className="d-grid">
                  {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>{getLabelText('Delete', templatetype)}</CButton> :
                    <CButton color="success" type='submit'>{getLabelText('Submit', templatetype)}</CButton>)}
                </div>
              </CForm>
            </CCardBody>
          </CCard>
        </CModalBody>
      </CModal>
    </>
  )
}
export default LocationPopup
