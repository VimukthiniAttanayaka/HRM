import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormText, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker, CFormTextarea } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { Dropdowns_JobRole } from '../../../apicalls/jobrole/dropdowns.js';
import { Dropdowns_JobType } from '../../../apicalls/jobtype/dropdowns.js';
import { Dropdowns_Department } from '../../../apicalls/department/dropdowns.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import { modifyEmployeeJobRole } from '../../../apicalls/employeejobrole/modify.js';
import { deleteEmployeeJobRole } from '../../../apicalls/employeejobrole/delete.js';
import { addNewEmployeeJobRole } from '../../../apicalls/employeejobrole/add_new.js';

import PopUpAlert from '../../shared/PopUpAlert.js'
import { format, parse } from 'date-fns'

const EmployeePopupTab_JobRole_Grid_PopUp = ({ toggleCreate, EmployeeDetails, popupStatus, visible1, onClose1, onOpen1, StatusInDB, EmployeeJobRoleDetails, employeeId }) => {
  let templatetype = 'translation_employeejobrole'
  let templatetype_base = 'translation'

  const apiUrl = process.env.REACT_APP_API_URL;

  const [selectedJobRole, setSelectedJobRole] = useState(null);
  const [optionsJobRole, setOptionsJobRole] = useState([]);
  const [optionsJobType, setOptionsJobType] = useState([]);
  const [optionsDepartment, setOptionsDepartment] = useState([]);
  const [selectedOptionJobRole, setSelectedOptionJobRole] = useState('');
  const [selectedOptionJobType, setSelectedOptionJobType] = useState('');
  const [selectedOptionDepartment, setSelectedOptionDepartment] = useState('');
  const [Remarks, setRemarks] = useState('');
  const [id, setID] = useState(0);
  const [ActiveFrom, setActiveFrom] = useState(new Date())
  const [ActiveTo, setActiveTo] = useState(new Date())
  const [isActive, setIsActive] = useState(true)

  const handleChangeIsActive = (event) => { StatusInDB = event.target.checked; setIsActive(event.target.checked) }

  const handleSubmit = async (event) => {
    event.preventDefault();

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EME_CustomerID: "string",
      EEJR_ID: id,
      EEJR_EmployeeID: employeeId,
      EEJR_JobRoleID: selectedOptionJobRole,
      EEJR_JobType: selectedOptionJobType,
      EEJR_Department: selectedOptionDepartment,
      EEJR_ActiveFrom: ActiveFrom.toJSON(),
      EEJR_ActiveTo: ActiveTo.toJSON(),
      EEJR_Status: isActive,
      EEJR_Remarks: Remarks

    }

    console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyEmployeeJobRole(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteEmployeeJobRole(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewEmployeeJobRole(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      console.log(APIReturn.msg)
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  async function requestdata() {
    const formData = {
      USR_EmployeeID: 'sedcx'
    }

    const JobRoleDetails = await Dropdowns_JobRole(formData)
    setOptionsJobRole(JobRoleDetails);

    const JobTypeDetails = await Dropdowns_JobType(formData)
    setOptionsJobType(JobTypeDetails);
    console.log(JobTypeDetails)

    const DepartmentDetails = await Dropdowns_Department(formData)
    setOptionsDepartment(DepartmentDetails);

  }

  const popupStatusSetup = (event) => {

    if (popupStatus == 'edit') {
      return getLabelText('Edit JobRole', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View JobRole', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete JobRole', templatetype)
    } else {
      return getLabelText('Assign New JobRole', templatetype)
    }
  }

  useEffect(() => {
    if (popupStatus == 'create') {
      setID(0)
      setSelectedOptionJobRole('')
      setSelectedOptionJobType('')
      setSelectedOptionDepartment('')
      setActiveFrom(new Date())
      setActiveTo(new Date())
      setIsActive(true)
      setRemarks('')
    }
    else {
      // console.log(EmployeeJobRoleDetails)
      setID(EmployeeJobRoleDetails.EEJR_ID)
      setSelectedOptionJobRole(EmployeeJobRoleDetails.EEJR_JobRoleID)
      setSelectedOptionJobType(EmployeeJobRoleDetails.EEJR_JobType)
      setSelectedOptionDepartment(EmployeeJobRoleDetails.EEJR_Department)
      setActiveFrom(EmployeeJobRoleDetails.EEJR_ActiveFrom)
      setActiveTo(EmployeeJobRoleDetails.EEJR_ActiveTo)
      setIsActive(EmployeeJobRoleDetails.EEJR_Status)
      setRemarks(EmployeeJobRoleDetails.EEJR_Remarks)
    }
  }, [EmployeeJobRoleDetails]);

  useEffect(() => {
    requestdata();
  }, []);


  const [open, setOpen] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose1();
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');


  return (
    <>

      <CButton color="primary" onClick={() => { toggleCreate();/*onOpen1*/ }}>Assign Job Role</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible1}
        onClose={onClose1}
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
                      <h6>JobRole</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect required
                    disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                    value={selectedOptionJobRole} onChange={(e) => setSelectedOptionJobRole(e.target.value)}>
                    {optionsJobRole.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>JobType</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect required
                    disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                    value={selectedOptionJobType} onChange={(e) => setSelectedOptionJobType(e.target.value)}>
                    {optionsJobType.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
                </CInputGroup> <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Department</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect required
                    disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                    value={selectedOptionDepartment} onChange={(e) => setSelectedOptionDepartment(e.target.value)}>
                    {optionsDepartment.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>ActiveFrom</h6>
                    </CInputGroupText>
                  </CCol>
                  {(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ?
                    <CFormInput placeholder="ActiveFrom" name="ActiveFrom" value={ActiveFrom}
                      disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                      format="YYYY-MM-DD" /> :
                    <CDatePicker placeholder="ActiveFrom" name="ActiveFrom" date={ActiveFrom}
                      onDateChange={(date) => { setActiveFrom(date) }}
                      inputDateParse={(date) => parse(date, 'dd-MMM-yyyy', new Date())}
                      inputDateFormat={(date) => format(new Date(date), 'dd-MMM-yyyy')}
                    />}
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>ActiveTo</h6>
                    </CInputGroupText>
                  </CCol>
                  {(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ?
                    <CFormInput placeholder="ActiveTo" name="ActiveTo" value={ActiveTo}
                      disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                      format="YYYY-MM-DD" /> :
                    <CDatePicker placeholder="ActiveTo" name="ActiveTo" date={ActiveTo}
                      onDateChange={(date) => { setActiveTo(date) }}
                      inputDateParse={(date) => parse(date, 'dd-MMM-yyyy', new Date())}
                      inputDateFormat={(date) => format(new Date(date), 'dd-MMM-yyyy')}
                    />}
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Remarks</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormTextarea placeholder="Remarks" name="Remarks" value={Remarks}
                    onChange={(e) => setRemarks(e.target.value)}
                    disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                    required>
                  </CFormTextarea>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck checked={isActive} onChange={handleChangeIsActive} label="Status"
                    disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                  />
                </CInputGroup>  <div className="d-grid">
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
export default EmployeePopupTab_JobRole_Grid_PopUp
