import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CModal, CModalBody, CBadge, CDropdownItem, CDropdown, CDropdownMenu, CDropdownToggle, CRow, CCol, CSmartTable, CTabPanel, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
import { Dropdowns_UserRole } from '../../../apicalls/userrole/dropdowns.js';
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns_Access, headers } from '../../controllers/internaluser_controllers.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';
import InternalUserPopup_AccessPopup from './InternalUserPopup_AccessPopup.js';

const InternalUserPopup_Access = ({ onClose, onOpen, InternalUserDetails, popupStatus }) => {
  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const [itemsPerPage, setItemsPerPage] = useState(5); // Default items per page
  const [currentPage, setCurrentPage] = useState(1);
  const [columnFilter, setColumnFilter] = useState([])
  const [tableFilter, setTableFilter] = useState([])

  const [userAccessDetails, setUserAccessDetails] = useState([])

  const [currentItems, setCurrentItems] = useState(data)

  const csvContent = currentItems.map((item) => Object.values(item).join(',')).join('\n')

  const csvCode = 'data:text/csv;charset=utf-8,SEP=,%0A' + encodeURIComponent(csvContent)

  const [selectedOptionUserRole, setSelectedOptionUserRole] = useState('');
  const [FirstName, setFirstName] = useState('')
  const [LastName, setLastName] = useState('')
  const [EmailAddress, setEmailAddress] = useState('')
  const [MobileNumber, setMobileNumber] = useState('')
  const [Remarks, setRemarks] = useState('')
  const [EmployeeID, setEmployeeID] = useState('')
  const [PhoneNumber, setPhoneNumber] = useState('')
  const [UserName, setUserName] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeIsActive = (event) => { }
  const handleChangeEmployeeID = (event) => {
    setEmployeeID(event.target.value)
  }
  const handleChangeFirstName = (event) => {
    setFirstName(event.target.value)
  }
  const handleChangeLastName = (event) => {
    setLastName(event.target.value)
  }
  const handleChangeEmailAddress = (event) => {
    setEmailAddress(event.target.value)
  }
  const handleChangeMobileNumber = (event) => {
    setMobileNumber(event.target.value)
  }
  const handleChangeRemarks = (event) => {
    setRemarks(event.target.value)
  }
  const handleChangePhoneNumber = (event) => {
    setPhoneNumber(event.target.value)
  }
  const handleChangeUserName = (event) => {
    setUserName(event.target.value)
  }

  const [visible, setVisible] = useState(false);

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      LVT_ExternalUserID: InternalUserId,
      LVT_LeaveAlotment: leaveAlotmentId,
      LVT_ExternalUser: InternalUser,
      LVT_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'ExternalUser/add_new_ExternalUser', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Leave Type data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Leave Type data:', response.statusText)
    }
  }

  const [selectedOptionEmployeeID, setSelectedOptionEmployeeID] = useState('');

  // console.log(ExternalUserDetails)
  const [optionsUserRole, setOptionsUserRole] = useState([]);

  async function requestdata() {
    const formData = {
      USR_EmployeeID: 'sedcx'
    }

    const UserRoleDetails = await Dropdowns_UserRole(formData)

    setOptionsUserRole(UserRoleDetails);

  }

  const handleItemsPerPageChange = (newItemsPerPage) => {
    console.log(newItemsPerPage);
    setItemsPerPage(newItemsPerPage);
  };

  const handlePageChange = (page) => {
    setCurrentPage(page);
    // Fetch data for the new page
  };
  useEffect(() => {
    requestdata();
  }, []);

  const handleOpenPopup = () => {
    setVisible(true);
  };

  const handleClosePopup = () => {
    setVisible(false);
    setCountryDetails([]);
    setPopupStatus('create')
  };
  return (
    <>
      <CTabPanel className="p-3" itemKey="access">
        <CCardBody>
          <CRow>
            <CCol md={6}>
              <CDropdown>
                <CDropdownToggle color="secondary">Export Data</CDropdownToggle>
                <CDropdownMenu>
                  <CDropdownItem><CButton
                    color="primary"
                    className="mb-2"
                    href={csvCode}
                    download="internaluseraccess.csv"
                    target="_blank"
                  >
                    Download items as .csv
                  </CButton></CDropdownItem>
                  <CDropdownItem><ExcelExport data={data} fileName="internaluseraccess" headers={headers} /></CDropdownItem>
                  <CDropdownItem>
                    <CSmartGridPDF data={data} headers={headers} filename="internaluseraccess" title="internaluseraccess" />
                  </CDropdownItem>
                </CDropdownMenu>
              </CDropdown>
            </CCol>
            <CCol className='d-flex justify-content-end'>
              <InternalUserPopup_AccessPopup popupStatus={popupStatus} onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} userAccessDetails={userAccessDetails} />
            </CCol>
          </CRow>
          <CSmartTable
            cleaner
            clickableRows
            columns={columns}
            columnFilter
            columnSorter
            // footer
            items={data}
            itemsPerPageSelect
            itemsPerPage={5}
            onFilteredItemsChange={setCurrentItems}
            pagination={<div> <Pagination
              totalItems={data.RC}
              currentPage={currentPage}
              setCurrentPage={handlePageChange}
              itemsPerPage={itemsPerPage}
            /></div>}
            // onFilteredItemsChange={(items) => {
            //   console.log(items)
            // }}
            onSelectedItemsChange={(items) => {
              console.log(items)
            }}
            scopedColumns={{
              // avatar: (item) => (
              //   <td>
              //     {/* <CAvatar src={`/images/avatars/${item.avatar}`} /> */}
              //   </td>
              // ),
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
                        toggleDetails(item.id)
                      }}
                    >
                      {details.includes(item.id) ? 'Hide' : 'Show'}
                    </CButton>
                  </td>
                )
              },
              details: (item) => {
                return (
                  <CCollapse visible={details.includes(item.id)}>
                    <CCardBody className="p-3">
                      <h4>{item.username}</h4>
                      {/* <p className="text-muted">User since: {item.registered}</p> */}
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
            tableFilter
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
      </CTabPanel>
    </>
  )
}
export default InternalUserPopup_Access
