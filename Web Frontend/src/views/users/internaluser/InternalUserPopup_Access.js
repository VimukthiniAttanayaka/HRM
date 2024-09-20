import React, { useState, useEffect } from 'react'
import { CTooltip, CCollapse, CFormSelect, CButton, CModal, CModalBody, CBadge, CDropdownItem, CDropdown, CDropdownMenu, CDropdownToggle, CRow, CCol, CSmartTable, CTabPanel, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns_UserAccess, headers } from '../../controllers/accessgroup_controllers.js';
import { getAccessGroupAll_ForUser } from '../../../apicalls/accessgroup/get_all_list.js';

const InternalUserPopup_Access = ({ onClose, onOpen, InternalUserDetails, popupStatus }) => {
  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const [itemsPerPage, setItemsPerPage] = useState(5); // Default items per page
  const [currentPage, setCurrentPage] = useState(1);
  const [columnFilter, setColumnFilter] = useState([])
  const [tableFilter, setTableFilter] = useState([])

  const [userAccessDetails, setUserAccessDetails] = useState([])

  const [currentItems, setCurrentItems] = useState(data)
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

  async function requestdata() {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      USR_EmployeeID: 'sedcx'
    }

    const UserAccessGroup = await getAccessGroupAll_ForUser(formData)
    setData(UserAccessGroup);
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

  return (
    <>
      <CTabPanel className="p-3" itemKey="access">
        <CCardBody>
          <CSmartTable
            cleaner
            clickableRows
            columns={columns_UserAccess}
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
                  <td>
                    {item.status == 'Inactive' ? <CButton
                      color="success"
                      variant="outline"
                      shape="square"
                      size="sm"
                      onClick={() => {
                        toggleDelete(item.UserID)
                      }}
                    >
                      Grant
                    </CButton>
                      :
                      <CButton
                        color="danger"
                        variant="outline"
                        shape="square"
                        size="sm"
                        onClick={() => {
                          toggleDelete(item.UserID)
                        }}
                      >
                        Remove
                      </CButton>
                    }
                  </td>
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
