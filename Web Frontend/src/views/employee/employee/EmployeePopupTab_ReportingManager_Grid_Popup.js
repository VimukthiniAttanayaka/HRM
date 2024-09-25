import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormText, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker, CFormTextarea } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import { modifyEmployeeReportingManager } from '../../../apicalls/employeereportingmanager/modify.js';
import { deleteEmployeeReportingManager } from '../../../apicalls/employeereportingmanager/delete.js';
import { addNewEmployeeReportingManager } from '../../../apicalls/employeereportingmanager/add_new.js';

import { getEmployeeSingle } from '../../../apicalls/employee/get_employee_single.js';

import EmployeeGridModel from '../../sharedgridselectables/EmployeeGridModel.js';

import PopUpAlert from '../../shared/PopUpAlert.js'
import { format, parse } from 'date-fns'

const EmployeePopupTab_ReportingManager_Grid_Popup = ({ toggleCreate, EmployeeDetails, popupStatus, visible1, onClose1,
  onOpen1, StatusInDB, EmployeeReportingManagerDetails, employeeId }) => {
  let templatetype = 'translation_employeereportingmanager'
  let templatetype_base = 'translation'

  const apiUrl = process.env.REACT_APP_API_URL;

  const [Remarks, setRemarks] = useState('');
  const [id, setID] = useState(0);
  const [ActiveFrom, setActiveFrom] = useState(new Date())
  const [ActiveTo, setActiveTo] = useState(new Date())
  const [isActive, setIsActive] = useState(true)
  const [EmployeeID, setEmployeeID] = useState('')
  const [EmployeeName, setEmployeeName] = useState('')

  const handleChangeIsActive = (event) => { StatusInDB = event.target.checked; setIsActive(event.target.checked) }

  const handleSubmit = async (event) => {
    event.preventDefault();

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EME_CustomerID: "string",
      EERM_ID: id,
      EERM_EmployeeID: employeeId,
      EERM_ReportingManagerID: EmployeeID,//selected from popup search
      EERM_ActiveFrom: ActiveFrom.toJSON(),
      EERM_ActiveTo: ActiveTo.toJSON(),
      EERM_Status: isActive,
      EERM_Remarks: Remarks

    }

    console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyEmployeeReportingManager(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteEmployeeReportingManager(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewEmployeeReportingManager(formData)
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

    // const ReportingManagerDetails = await Dropdowns_ReportingManager(formData)
    // setOptionsReportingManager(ReportingManagerDetails);

  }

  const popupStatusSetup = (event) => {

    if (popupStatus == 'edit') {
      return getLabelText('Edit ReportingManager', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View ReportingManager', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete ReportingManager', templatetype)
    } else {
      return getLabelText('Assign New ReportingManager', templatetype)
    }
  }

  useEffect(() => {
    if (popupStatus == 'create') {
      setID(0)
      setActiveFrom(new Date())
      setActiveTo(new Date())
      setIsActive(true)
      setRemarks('')
    }
    else {
      console.log(EmployeeReportingManagerDetails)
      setID(EmployeeReportingManagerDetails.EERM_ID)
      loadDetails_Employee(EmployeeReportingManagerDetails.EERM_ReportingManagerID)
      setActiveFrom(EmployeeReportingManagerDetails.EERM_ActiveFrom)
      setActiveTo(EmployeeReportingManagerDetails.EERM_ActiveTo)
      setIsActive(EmployeeReportingManagerDetails.EERM_Status)
      setRemarks(EmployeeReportingManagerDetails.EERM_Remarks)
    }
  }, [EmployeeReportingManagerDetails]);

  useEffect(() => {
    requestdata();
  }, []);


  const [open, setOpen] = useState(false);
  const [openEmp_Popup, setOpenEmp_Popup] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose1();
  };
  const handleCloseEmp_Popup = () => {
    setOpenEmp_Popup(false);
  };

  const EmployeeSearchOnClick = () => {
    // console.log(true)
    setOpenEmp_Popup(true);
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');



  async function loadDetails_Employee(item) {
    if (item !== undefined) {
      // console.log(item)
      const token = getJWTToken();
      const staffId = getStaffID();
      const customerId = getCustomerID();

      const formData = {
        // UD_StaffID: staffId,
        // AUD_notificationToken: token,
        EME_EmployeeID: item
      }
      const EmployeeDetails = await getEmployeeSingle(formData)
      // console.log(EmployeeDetails)
      setEmployeeID(EmployeeDetails.EME_EmployeeID)
      setEmployeeName(EmployeeDetails.EME_PrefferedName)
      handleCloseEmp_Popup();
    }
  }

  return (
    <>

      <CButton color="primary" onClick={() => { toggleCreate();/*onOpen1*/ }}>Assign Reporting Manager</CButton>
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

              <EmployeeGridModel open={openEmp_Popup} handleClose={handleCloseEmp_Popup} loadDetails={loadDetails_Employee}></EmployeeGridModel>
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>ReportingManager</h6>
                    </CInputGroupText>
                  </CCol>
                  {/* <CFormSelect required
                    disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                    value={selectedOptionReportingManager} onChange={(e) => setSelectedOptionReportingManager(e.target.value)}>
                    {optionsReportingManager.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect> */}

                  <CFormInput placeholder="EmployeeName" name="EmployeeName" value={EmployeeName} disabled />

                  <CButton color="success" onClick={EmployeeSearchOnClick}>{getLabelText('Search', templatetype)}</CButton>
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
export default EmployeePopupTab_ReportingManager_Grid_Popup
