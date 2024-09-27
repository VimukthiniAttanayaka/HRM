import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CFormTextarea, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { Dropdowns_SalaryType } from '../../../apicalls/salarytype/dropdowns.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import { modifyEmployeeSalary } from '../../../apicalls/employeesalary/modify.js';
import { deleteEmployeeSalary } from '../../../apicalls/employeesalary/delete.js';
import { addNewEmployeeSalary } from '../../../apicalls/employeesalary/add_new.js';

import PopUpAlert from '../../shared/PopUpAlert.js'
import { format, parse } from 'date-fns'

const EmployeePopupTab_Salary_Grid_Popup = ({ toggleCreate, EmployeeDetails, popupStatus, visible1, onClose1,
  onOpen1, StatusInDB, EmployeeSalaryDetails, employeeId }) => {
  let templatetype = 'translation_employeesalary'
  let templatetype_base = 'translation'
  const apiUrl = process.env.REACT_APP_API_URL;

  // const [employeeId, setEmployeeId] = useState()
  const [id, setID] = useState(0);
  const [remarks, setRemarks] = useState('manageesnt')
  const [activeFrom, setActiveFrom] = useState('2024-01-01')
  const [activeTo, setActiveTo] = useState('2024-01-01')
  const [salaryType, setSalaryType] = useState('fullTime')
  const [salary, setSalary] = useState(0)
  const [isActive, setIsActive] = useState(true)
  const [optionsSalaryType, setOptionsSalaryType] = useState([]);

  const [selectedOptionSalaryType, setSelectedOptionSalaryType] = useState('');

  const handleChangeRemarks = (event) => {
    setRemarks(event.target.value)
  }
  const handleChangeActiveFrom = (event) => {
    setActiveFrom(event.target.value)
  }
  const handleChangeActiveTo = (event) => {
    setActiveTo(event.target.value)
  }
  const handleChangeSalaryType = (event) => {
    setSalaryType(event.target.value)
  }
  const handleChangeSalary = (event) => {
    setSalary(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }


  const handleSubmit = async (event) => {
    event.preventDefault();

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EEC_CustomerID: "string",
      EES_EmployeeID: employeeId,
      EES_ID: id,
      EES_Salary: salary,
      EES_ActiveFrom: activeFrom.toJSON(),
      EES_ActiveTo: activeFromctiveTo.toJSON(),
      EES_SalaryType: selectedOptionSalaryType,
      EES_Remarks: remarks,
      EES_Status: isActive,
    }

    console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyEmployeeSalary(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteEmployeeSalary(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewEmployeeSalary(formData)
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

    const SalaryTypeDetails = await Dropdowns_SalaryType(formData)
    setOptionsSalaryType(SalaryTypeDetails);
    // console.log(SalaryTypeDetails)
  }
  const popupStatusSetup = (event) => {

    if (popupStatus == 'edit') {
      return getLabelText('Edit Salary', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View Salary', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete Salary', templatetype)
    } else {
      return getLabelText('Create New Salary', templatetype)
    }
  }
  useEffect(() => {
    if (popupStatus == 'create') {
      setID(0)
      setSalary('')
      setActiveFrom('')
      setActiveTo('')
      setSelectedOptionSalaryType('')
      setRemarks('')
      setIsActive(true)
    }
    else {
      setID(EmployeeSalaryDetails.EES_ID)
      // console.log(EmployeeSalaryDetails)
      setSalary(EmployeeSalaryDetails.EES_Salary)
      setActiveFrom(EmployeeSalaryDetails.EES_ActiveFrom)
      setActiveTo(EmployeeSalaryDetails.EES_ActiveTo)
      setSelectedOptionSalaryType(EmployeeSalaryDetails.EES_SalaryType)
      setRemarks(EmployeeSalaryDetails.EES_Remarks)
      setIsActive(EmployeeSalaryDetails.EES_Status)
    }
  }, [EmployeeSalaryDetails]);

  const [open, setOpen] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose1();
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');

  useEffect(() => {
    requestdata();
  }, []);


  return (
    <>
      <CButton color="primary" onClick={() => { toggleCreate();/*onOpen1*/ }}>Assign Salary</CButton>
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
                      <h6>Salary Type</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect required
                    disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                    value={selectedOptionSalaryType} onChange={(e) => setSelectedOptionSalaryType(e.target.value)}>
                    {optionsSalaryType.map((option) => (
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
                    <CFormInput placeholder="ActiveFrom" name="ActiveFrom" value={activeFrom}
                      disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                      format="YYYY-MM-DD" /> :
                    <CDatePicker placeholder="ActiveFrom" name="ActiveFrom" date={activeFrom}
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
                    <CFormInput placeholder="ActiveTo" name="ActiveTo" value={activeTo}
                      disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                      format="YYYY-MM-DD" /> :
                    <CDatePicker placeholder="ActiveTo" name="ActiveTo" date={activeTo}
                      onDateChange={(date) => { setActiveTo(date) }}
                      inputDateParse={(date) => parse(date, 'dd-MMM-yyyy', new Date())}
                      inputDateFormat={(date) => format(new Date(date), 'dd-MMM-yyyy')}
                    />}
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Salary</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Salary" name="salary" type='number'
                    value={salary} onChange={handleChangeSalary}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Remarks</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormTextarea placeholder="Remarks" name="Remarks" value={remarks}
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
                  <CFormCheck checked={isActive} onChange={handleChangeStatus} label="Status" disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
                </CInputGroup>
                <div className="d-grid">
                  {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>Delete</CButton> :
                    <CButton color="success" type='submit'>Submit</CButton>)}
                </div>
              </CForm>
            </CCardBody>
          </CCard>
        </CModalBody>
      </CModal>
    </>
  )
}
export default EmployeePopupTab_Salary_Grid_Popup
