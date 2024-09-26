import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CSmartTable, CBadge, CCollapse, CModal, CTabs, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { getEmployeeContactAll } from '../../../apicalls/employeecontact/get_all_list.js';
import { getEmployeeContactSingle } from '../../../apicalls/employeecontact/get_employeecontact_single.js';
import EmployeePopupTab_Contact_Grid_PopUp from './EmployeePopupTab_Contact_Grid_Popup.js';
import { getBadge } from '../../shared/gridviewconstants.js';

import { columns, headers } from '../../controllers/employeecontact_controllers.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const EmployeePopupTab_Contact_Grid = ({ EmployeeDetails, popupStatus, employeeId }) => {

  let templatetype = 'translation_employeecontact'
  let templatetype_base = 'translation'

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const [StatusInDB, setStatusInDB] = useState(true)
  const [popupStatus1, setPopupStatus1] = useState('create')

  const toggleCreate = (index) => {
    setPopupStatus1('create')
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
      loadDetails(newDetails[0])
      // handleOpenPopup1()
    }
    // setDetails(newDetails)
  }
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
    const EmployeeContactDetails = await getEmployeeContactAll(formData)
    // console.log(EmployeeContactDetails)
    setData(EmployeeContactDetails);
  }


  useEffect(() => {
    requestdata(EmployeeDetails.EME_EmployeeID);
  }, [EmployeeDetails]);



  async function loadDetails(item, action) {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      EEC_ID: item
    }

    console.log(formData)
    const EmployeeContactDetails = await getEmployeeContactSingle(formData)
    setEmployeeContactDetails(EmployeeContactDetails);
    handleOpenPopup1()
  }

  const [EmployeeContactDetails, setEmployeeContactDetails] = useState([])
  const [currentItems, setCurrentItems] = useState(data)

  const [visible1, setVisible1] = useState(false);

  const handleOpenPopup1 = () => {
    setVisible1(true);
    requestdata(EmployeeDetails.EME_EmployeeID)
  };

  const handleClosePopup1 = () => {
    setVisible1(false);
    requestdata(EmployeeDetails.EME_EmployeeID)
  };

  return (
    <>
      <CTabPanel className="p-3" itemKey="contact">
        <CCardBody>
          <CRow>
            <CCol className='d-flex justify-content-end'>
              <EmployeePopupTab_Contact_Grid_PopUp popupStatus={popupStatus1} onClose1={handleClosePopup1}
                StatusInDB={StatusInDB} visible1={visible1} onOpen1={handleOpenPopup1} toggleCreate={toggleCreate}
                EmployeeContactDetails={EmployeeContactDetails} 
                employeeId={EmployeeDetails.EME_EmployeeID} />
            </CCol>
          </CRow>
          <CSmartTable
            cleaner
            // clickableRows
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
              // console.log(items)
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
                    <CButton
                      color="primary"
                      variant="outline"
                      shape="square"
                      size="sm"
                      onClick={() => {
                        toggleEdit(item.id)
                      }}
                    >
                      {getLabelText('Edit', templatetype_base)}
                    </CButton>
                  </td>
                )
              },
              view: (item) => (
                <td>
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
                  </CButton>

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
                      toggleView(item.id)
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
        </CCardBody>
      </CTabPanel> </>
  )
}
export default EmployeePopupTab_Contact_Grid
