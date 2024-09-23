import React, { useState, useEffect } from 'react'
import { CCardBody, CTabPanel, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge, CDropdownToggle, CDropdown, CDropdownMenu, CDropdownItem } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
// import EmployeeDocumentPopup from './EmployeeDocumentPopup.js';
// // import loadDetails from './EmployeeDocumentPopup.js';
import { getEmployeeDocumentsAll } from '../../../apicalls/employeedocument/get_all_list.js';
import { getEmployeeDocumentSingle } from '../../../apicalls/employeedocument/get_employeedocuments_single.js';
import EmployeePopupTab_Profile_Grid_Popup from './EmployeePopupTab_Profile_Grid_Popup'

import { getLabelText } from 'src/MultipleLanguageSheets'
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns, headers } from '../../controllers/employeedocument_controllers.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';


const EmployeePopupTab_Profile_Grid = ({ onClose, onOpen, EmployeeDetails, popupStatus }) => {

  let templatetype = 'translation_employeedocument'
  let templatetype_base = 'translation'

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])
  const [popupStatus1, setPopupStatus1] = useState([])

  const [EmployeeDocumentDetails, setEmployeeDocumentDetails] = useState([])
  // const [EmployeeDocumentId, setEmployeeDocumentId] = useState('')
  const handleChangeId = (event) => {
    setEmployeeDocumentId(event.target.value)
  }

  async function loadDetails(item) {
    if (item == undefined) return;

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    // const config = {
    //   headers: { Authorization: `Bearer ${auth}` }
    // };

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      USRED_EmployeeDocumentID: item
    }
    // console.log(formData)
    const EmployeeDocumentDetails = await getEmployeeDocumentSingle(formData)
    // console.log(EmployeeDocumentDetails)
    setEmployeeDocumentDetails(EmployeeDocumentDetails);
    setStatusInDB(EmployeeDocumentDetails.USRED_Status)
  }

  const toggleAdd = (index) => {
    setPopupStatus1('add')
    toggleDetails(index)
  }
  const toggleEdit = (index) => {
    setPopupStatus1('edit')
    toggleDetails(index)
  }
  const toggleDelete = (index) => {
    setPopupStatus1('delete')
    toggleDetails(index)
  }
  const toggleView = (index) => {
    setPopupStatus1('view')
    toggleDetails(index)
  }

  const toggleDetails = (index) => {

    const position = details.indexOf(index)
    let newDetails = details.slice()
    if (position !== -1) {
      newDetails.splice(position, 1)
    } else {
      newDetails = [...details, index]
      // alert(newDetails[newDetails.length - 1])
      loadDetails(newDetails[0])
      console.log(newDetails[0])

      handleOpenPopup()
    }
    // setDetails(newDetails)
  }

  // setCustomerId(res1[0].Customer[0].CUS_ID);}
  const apiUrl = process.env.REACT_APP_API_URL;

  async function requestdata(employeeId) {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();
    // const config = {
    //   headers: { Authorization: `Bearer ${auth}` }
    // };
    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      EME_EmployeeID: employeeId
    }

    const EmployeeDocumentDetails = await getEmployeeDocumentsAll(formData)
    // console.log(EmployeeDocumentDetails)
    setData(EmployeeDocumentDetails);
  }
  useEffect(() => {
    requestdata(EmployeeDetails.EME_EmployeeID);
  }, [EmployeeDetails]);


  const [currentItems, setCurrentItems] = useState(data)
  const [visible, setVisible] = useState(false);

  const handleOpenPopup = () => {
    setVisible(true);
  };

  const handleClosePopup = () => {
    setVisible(false);
    requestdata(EmployeeDetails.EME_EmployeeID) 
    setclearlink(false);
    setclearlink(true);
  };
  const [StatusInDB, setStatusInDB] = useState(true)
  const [clearlink, setclearlink] = useState(true)

  function downloadFileFromBase64(base64String, filename) {
    const link = document.createElement('a');
    link.href = `data:application/octet-stream;base64,${base64String}`;
    link.download = filename;
    link.click();
  }

  const handleDownload = (item) => {
    loadDetails(item);
    var base64Data = EmployeeDocumentDetails.USRED_DocumentData
    var filename = EmployeeDocumentDetails.USRED_DocumentName + '.' + EmployeeDocumentDetails.USRED_DocumentType
    if (filename == undefined || base64Data == undefined)
      return
    downloadFileFromBase64(base64Data, filename);
  };

  return (
    <CTabPanel className="p-3" itemKey="profile"> <CCardBody>
      <CRow>
        <CCol className='d-flex justify-content-end'>
          <EmployeePopupTab_Profile_Grid_Popup onClose={handleClosePopup} USRED_EmployeeID={EmployeeDetails.EME_EmployeeID} toggleAdd={toggleAdd} clearlink={clearlink} visible={visible} popupStatus={popupStatus1} onOpen={handleOpenPopup} StatusInDB={StatusInDB} EmployeeDocumentDetails={EmployeeDocumentDetails} />
        </CCol>
      </CRow>
      <CSmartTable
        cleaner
        clickableRows
        columns={columns}
        // columnFilter
        // columnSorter
        // footer
        items={data}
        itemsPerPageSelect
        itemsPerPage={5}
        onFilteredItemsChange={setCurrentItems}
        pagination
        // onFilteredItemsChange={(items) => {
        //   console.log(items)
        // }}
        onSelectedItemsChange={(items) => {
          console.log(items)
        }}
        scopedColumns={{
          status: (item) => (
            <td>
              <CBadge color={getBadge(item.status)}>{item.status}</CBadge>
            </td>
          ),
          show_details: (item) => {
            return (
              <td className="py-2">
                {/* <CButton
                  color="primary"
                  variant="outline"
                  shape="square"
                  size="sm"
                  onClick={() => {
                    toggleEdit(item.id)
                  }}
                >
                  {getLabelText('Edit', templatetype_base)}
                </CButton> */}
              </td>
            )
          },
          view: (item) => (
            <td>
              {item.DocumentType == 'jpg' ?
                <CButton
                  color="success"
                  variant="outline"
                  shape="square"
                  size="sm"
                  onClick={() => {
                    toggleView(item.id)
                  }}
                >
                  {getLabelText('View', templatetype_base)}
                </CButton> : ''
              }
            </td>
          ),
          delete: (item) => (
            <td>
              <CButton
                color="danger"
                variant="outline"
                shape="square"
                size="sm"
                onClick={() => {
                  toggleDelete(item.id)
                }}
              >
                {getLabelText('Delete', templatetype_base)}
              </CButton>
            </td>
          ), download: (item) => (
            <td>
              <CButton
                color="success"
                variant="outline"
                shape="square"
                size="sm"
                onClick={() => {
                  // toggleView(item.id)
                  handleDownload(item.id)
                }}
              >Download File
              </CButton>
            </td>
          ),
          details: (item) => {
            return (
              <CCollapse visible={details.includes(item.UserID)}>
                <CCardBody className="p-3">
                  <h4>{item.username}</h4>
                  <p className="text-muted">User since: {item.registered}</p>
                  <CButton size="sm" color="info">
                    User Settings
                  </CButton>
                  <CButton size="sm" color="danger" className="ml-1">
                    Delete
                  </CButton>
                </CCardBody>
              </CCollapse>
            )
          },
        }}
        // selectable
        sorterValue={{ column: 'status', state: 'asc' }}
        // tableFilter
        tableProps={{
          className: 'add-this-class',
          responsive: true,
          striped: true,
          hover: true,
        }}
        tableBodyProps={{
          className: 'align-middle'
        }} />
    </CCardBody></CTabPanel>
  )
}

export default EmployeePopupTab_Profile_Grid
