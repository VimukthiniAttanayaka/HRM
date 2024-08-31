import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const ExitInterviewQuestionsPopup = ({ visible, onClose, onOpen, ExitInterviewQuestionsDetails, popupStatus }) => {
  const apiUrl = process.env.REACT_APP_API_URL;
  let templatetype = 'translation_exitinterviewquestions'

  const [ExitInterviewQuestionsId, setExitInterviewQuestionsId] = useState('')
  const [ExitInterviewQuestions, setExitInterviewQuestions] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeExitInterviewQuestions = (event) => {
    setExitInterviewQuestions(event.target.value)
  }
  const handleChangeId = (event) => {
    setExitInterviewQuestionsId(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }
  const handleCreate = async (event) => {

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDD_ExitInterviewQuestionsID: ExitInterviewQuestionsId,
      MDD_ExitInterviewQuestions: ExitInterviewQuestions,
      MDD_LocationID: "string",
      MDD_Status: isActive
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'ExitInterviewQuestions/add_new_ExitInterviewQuestions', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('ExitInterviewQuestions data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting ExitInterviewQuestions data:', response.statusText)
    }
  }
  const handleEdit = async (event) => {
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDD_ExitInterviewQuestionsID: ExitInterviewQuestionsId,
      MDD_ExitInterviewQuestions: ExitInterviewQuestions,
      MDD_LocationID: "string",
      MDD_Status: isActive
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'ExitInterviewQuestions/modify_ExitInterviewQuestions', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('ExitInterviewQuestions data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting ExitInterviewQuestions data:', response.statusText)
    }
  }
  const handleDelete = async (event) => {
    console.log('Delete ExitInterviewQuestions')
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDD_ExitInterviewQuestionsID: ExitInterviewQuestionsId
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'ExitInterviewQuestions/inactivate_ExitInterviewQuestions', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('ExitInterviewQuestions data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting ExitInterviewQuestions data:', response.statusText)
    }
  }

  const handleSubmit = async (event) => {
    event.preventDefault()

    if (popupStatus == 'create') {
      handleCreate(event)
    } else if (popupStatus == 'edit') {
      handleEdit(event)
    } else if (popupStatus == 'delete') {
      handleDelete(event)
    }
    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

  }

  const popupStatusSetup = (event) => {

    if (popupStatus == 'edit') {
      return getLabelText('Edit ExitInterviewQuestions', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View ExitInterviewQuestions', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete ExitInterviewQuestions', templatetype)
    } else {
      return getLabelText('Create New ExitInterviewQuestions', templatetype)
    }
  }

  useEffect(() => {
    setExitInterviewQuestionsId(ExitInterviewQuestionsDetails.MDD_ExitInterviewQuestionsID)
    setExitInterviewQuestions(ExitInterviewQuestionsDetails.MDD_ExitInterviewQuestions)
    setIsActive(ExitInterviewQuestionsDetails.MDD_Status)
  }, [ExitInterviewQuestionsDetails]);
  // console.log(ExitInterviewQuestionsDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>  {getLabelText('New Exit Interview Questions', templatetype)}
        {/* New ExitInterviewQuestions */}
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
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('ExitInterviewQuestionsID', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="ExitInterviewQuestionsID" name="ExitInterviewQuestionsID" value={ExitInterviewQuestionsDetails.MDD_ExitInterviewQuestionsID} onChange={handleChangeId} disabled={popupStatus == 'create' ? false : true}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('ExitInterviewQuestions', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="ExitInterviewQuestions" name="ExitInterviewQuestions" value={ExitInterviewQuestions} onChange={handleChangeExitInterviewQuestions} disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}

                  // readOnly={isEditable,isAddNew,IsView}// value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('Status', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck checked={isActive} onChange={handleChangeStatus} label="Status" disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
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
export default ExitInterviewQuestionsPopup
