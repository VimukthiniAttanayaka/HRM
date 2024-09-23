import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CImage, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';
import { modifyEmployeeDocument } from '../../../apicalls/employeedocument/modify.js';
import { deleteEmployeeDocument } from '../../../apicalls/employeedocument/delete.js';
import { addNewEmployeeDocument } from '../../../apicalls/employeedocument/add_new.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import PopUpAlert from '../../shared/PopUpAlert.js'
import ImageLoader from 'react-image-loader';
import ImageDisplay from 'src/views/shared/ImageDisplay.js';

const EmployeePopupTab_Profile_Grid_Popup = ({ visible, onClose, onOpen,toggleAdd, EmployeeDocumentDetails, popupStatus, StatusInDB, clearlink }) => {
  let templatetype = 'translation_employeedocument'
  let templatetype_base = 'translation'
  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [DocumentName, setDocumentName] = useState('')
  const [Id, setId] = useState('')
  const [DocumentType, setDocumentType] = useState('')
  const [DocumentData, setDocumentData] = useState('')
  const [isActive, setIsActive] = useState(true)
  const [doctype, setdoctype] = useState('')

  const handleChangeDocumentName = (event) => { setDocumentName(event.target.value) }
  const handleChangeDocumentType = (event) => { setDocumentType(event.target.value) }
  const handleChangeIsActive = (event) => { setIsActive(event.target.checked) }

  const handleChangeDocType = (event) => { setdoctype(event.target.value) }

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
      UUM_EmployeeDocumentID: EmployeeDocumentId,
      UUM_EmployeeDocument: EmployeeDocument,
      USRED_Status: isActive,
      UD_UserID: staffId,
    }
    // console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyEmployeeDocument(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteEmployeeDocument(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewEmployeeDocument(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  useEffect(() => {
    setimageUrl('.')
    console.log(clearlink)
    clearlink = false
  }, [clearlink])

  useEffect(() => {
    setIsActive(StatusInDB)

    var imageData = "data:image/png;base64,"

    if (EmployeeDocumentDetails.USRED_DocumentData != undefined) {
      // console.log(imageData + EmployeeDocumentDetails.USRED_DocumentData)
      setimageUrl(imageData + EmployeeDocumentDetails.USRED_DocumentData)
    }

    setId(EmployeeDocumentDetails.USRED_EmployeeDocumentID)
    setDocumentType(EmployeeDocumentDetails.USRED_DocumentType)
    setDocumentName(EmployeeDocumentDetails.USRED_DocumentName)

  }, [EmployeeDocumentDetails]);

  // const imageUrl = createImageUrl(imageData);
  const [imageUrl, setimageUrl] = useState('');
  const [open, setOpen] = useState(false);
  const [openEmp_Popup, setOpenEmp_Popup] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose();
  };
  0
  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');
  // console.log(EmployeeDocumentDetails)

  const popupStatusSetup = (event) => {
    console.log(popupStatus)
    if (popupStatus == 'edit') {
      return getLabelText('Edit Document', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View Document', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete Document', templatetype)
    } else {
      return getLabelText('Create New Document', templatetype)
    }
  }

  const [selectedFileImage, setSelectedFileImage] = useState();

  function handleChangeImage(e) {
    setSelectedFileImage(e.target.files[0]);

    var reader = new FileReader();
    reader.readAsDataURL(e.target.files[0]);
    reader.onloadend = function () {
      var base64data = reader.result;
      console.log(base64data);
      setDocumentData(base64data)
      setimageUrl(base64data)
      setRefresh(!refresh);
    }
  }
  const [refresh, setRefresh] = useState(false);

  return (
    <>
      <CButton color="primary" onClick={() => { toggleAdd(); /*onOpen();*/setimageUrl('') ;setRefresh(!refresh); }}>New Document</CButton>
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
          {/* <CModalTitle id="TooltipsAndPopoverExample">Create New EmployeeDocument</CModalTitle> */}
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />

              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>DocumentType</h6>
                    </CInputGroupText>
                  </CCol>
                  {/* <CFormInput placeholder="DocumentType" name="DocumentType" value={DocumentType} onChange={handleChangeDocumentType}
                    disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                  /> */}
                  <CCol md={4} disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} >
                    <CFormCheck inline type="radio" name="doctype" id="inlineCheckbox1" value="jpg" label="Jpg" checked={doctype === 'jpg'}
                      onChange={handleChangeDocType} className='ms-4' />
                    <CFormCheck inline type="radio" name="doctype" id="inlineCheckbox2" value="pdf" label="pdf" checked={doctype === 'pdf'}
                      onChange={handleChangeDocType} />
                  </CCol>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>DocumentName</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormInput placeholder="DocumentName" name="DocumentName" value={DocumentName} onChange={handleChangeDocumentName}
                    disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                  />
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
                </CInputGroup>

                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Image</h6>
                    </CInputGroupText>
                  </CCol>
                  <CCol md={4}>
                    <input type="file" onChange={handleChangeImage}
                      disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
                    {/* {selectedFileImage && (
                      <img src={URL.createObjectURL(selectedFileImage)} alt="Preview" width={100} />
                    )} */}
                    {imageUrl && (
                      <img src={imageUrl} alt="Preview" width={100} />
                    )}
                    {/* <ImageDisplay refresh={refresh} selectedFileImage={selectedFileImage} imageUrl={imageUrl}></ImageDisplay> */}
                  </CCol>
                </CInputGroup>

                <div className="d-grid">
                  {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>{getLabelText('Delete', templatetype)}</CButton> :
                    <CButton color="success" type='submit'>{getLabelText('Submit', templatetype)}</CButton>)}
                </div>
              </CForm>
            </CCardBody>
          </CCard>
        </CModalBody>
      </CModal >
    </>
  )
}
export default EmployeePopupTab_Profile_Grid_Popup
