import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';

import { modifyDepartment } from '../../../apicalls/department/modify.js';
import { deleteDepartment } from '../../../apicalls/department/delete.js';
import { addNewDepartment } from '../../../apicalls/department/add_new.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import PopUpAlert from '../../shared/PopUpAlert.js'

const DepartmentPopup = ({ visible, onClose, onOpen, DepartmentDetails, popupStatus }) => {
  const apiUrl = process.env.REACT_APP_API_URL;
  let templatetype = 'translation_department'

  const [DepartmentId, setDepartmentId] = useState('')
  const [Department, setDepartment] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeDepartment = (event) => {
    setDepartment(event.target.value)
  }
  const handleChangeId = (event) => {
    setDepartmentId(event.target.value)
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
      MDD_DepartmentID: DepartmentId,
      MDD_Department: Department,
      MDD_Status: isActive,
      UD_UserID: staffId,
    }
    // console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyDepartment(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteDepartment(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewDepartment(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }


  const popupStatusSetup = (event) => {

    if (popupStatus == 'edit') {
      return getLabelText('Edit Department', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View Department', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete Department', templatetype)
    } else {
      return getLabelText('Create New Department', templatetype)
    }
  }

  useEffect(() => {
    setDepartmentId(DepartmentDetails.MDD_DepartmentID)
    setDepartment(DepartmentDetails.MDD_Department)
    setIsActive(DepartmentDetails.MDD_Status)
  }, [DepartmentDetails]);
  // console.log(DepartmentDetails)

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
      <CButton color="primary" onClick={onOpen}>  {getLabelText('New Department', templatetype)}
        {/* New Department */}
      </CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">{popupStatusSetup()}
            {/* {popupStatusSetup()} */}
          </CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('DepartmentID', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="DepartmentID" name="DepartmentID" value={DepartmentId} onChange={handleChangeId} disabled={popupStatus == 'create' ? false : true}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('Department', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="Department" name="Department" value={Department} onChange={handleChangeDepartment} disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}

                  // readOnly={isEditable,isAddNew,IsView}// value={addressBuildingName} onChange={handleChangeAddressBuildingName}
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
export default DepartmentPopup
