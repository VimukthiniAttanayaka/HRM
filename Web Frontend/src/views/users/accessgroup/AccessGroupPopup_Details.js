import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CModal, CModalBody, CBadge, CDropdown, CDropdownItem, CDropdownMenu, CDropdownToggle, CRow, CCol, CSmartTable, CTabPanel, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const AccessGroupPopup_Details = ({ visible, onClose, onOpen, AccessGroupDetails, checkMenuListItems, StatusInDB }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [AccessGroupId, setAccessGroupId] = useState('')
  const [AccessGroup, setAccessGroup] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeAccessGroup = (event) => {
    setAccessGroup(event.target.value)
  }
  const handleChangeId = (event) => {
    setAccessGroupId(event.target.value)
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
      UUM_AccessGroupID: AccessGroupId,
      UUM_AccessGroup: AccessGroup,
      UUM_Status: isActive,
      UD_UserID: staffId,
    }
    console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyAccessGroup(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteAccessGroup(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewAccessGroup(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  useEffect(() => {
    // console.log(AccessGroupDetails)
    setAccessGroupId(AccessGroupDetails.UUM_AccessGroupID)
    setAccessGroup(AccessGroupDetails.UUM_AccessGroup)
    setIsActive(StatusInDB)
  }, [AccessGroupDetails]);

  const [open, setOpen] = useState(false);
  const [openEmp_Popup, setOpenEmp_Popup] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose();
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');
 
  return (
    <>
      <CTabPanel className="p-3" itemKey="general">
        {/* <CButton color="primary" onClick={onOpen}>New Access Group</CButton> */}

        <CForm onSubmit={handleSubmit}>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>AccessGroupID</h6>
              </CInputGroupText>
            </CCol>   <CFormInput placeholder="AccessGroupID" name="AccessGroupID" value={AccessGroupDetails.UAG_AccessGroupID} onChange={handleChangeId}
            // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
            />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>AccessGroup</h6>
              </CInputGroupText>
            </CCol>    <CFormInput placeholder="AccessGroup" name="AccessGroup" value={AccessGroupDetails.UAG_AccessGroup} onChange={handleChangeAccessGroup}
            // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
            />
          </CInputGroup>
          {/* <CInputGroup className="mb-3"> */}
          {/* <CCol md={4}>
            <CInputGroupText>
              <h6>Available Menus</h6>
            </CInputGroupText>
          </CCol> */}

          {/* {checkMenuListItems.map((option) => (
                    <CFormCheck
                      key={option.value}
                      type="checkbox"
                      label={option.label}
                      value={option.value}
                      // checked={checkedItems.includes(option.value)}
                      checked={option.Ischecked}
                      onChange={handleCheckboxChange}
                    />
                  ))} */}
          {/* </CInputGroup> */}
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

      </CTabPanel>
    </>
  )
}
export default AccessGroupPopup_Details
