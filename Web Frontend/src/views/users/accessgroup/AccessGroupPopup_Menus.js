import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CModal, CModalBody, CBadge, CDropdown,CCollapse , CDropdownItem, CDropdownMenu, CDropdownToggle, CRow, CCol, CSmartTable, CTabPanel, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

import { getLabelText } from 'src/MultipleLanguageSheets'
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columnsMenu, headers } from '../../controllers/useraccessgroup_controllers.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';
import { UserMenu_DropDowns_All_Selectable, getUserMenuListForAccessGroup } from '../../../apicalls/usermenu/get_all_list.js';

const AccessGroupPopup_Menus = ({ visible, onClose, onOpen, AccessGroupDetails }) => {

  useEffect(() => {
    requestdata();
  }, []);

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const [AccessGroupId, setAccessGroupId] = useState('')
  const [AccessGroup, setAccessGroup] = useState('')
  const [isActive, setIsActive] = useState(true)

  const [UserMenuDetails, setUserMenuDetails] = useState([])

  const [itemsPerPage, setItemsPerPage] = useState(5); // Default items per page
  const [currentPage, setCurrentPage] = useState(1);
  const [columnFilter, setColumnFilter] = useState([])
  const [tableFilter, setTableFilter] = useState([])

  // const [checkMenuListItems, setcheckMenuListItems] = useState([]);

  const handleChangeAlotment = (event) => {
    setLeaveAlotmentId(event.target.value)
  }
  const handleChangeAccessGroup = (event) => {
    setAccessGroup(event.target.value)
  }
  const handleChangeId = (event) => {
    setAccessGroupId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      UAG_AccessGroupID: AccessGroupId,
      UAG_AccessGroup: AccessGroup,
      UAG_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'AccessGroup/add_new_AccessGroup', {
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

    // const config = {
    //   headers: { Authorization: `Bearer ${auth}` }
    // };

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      // UAG_AccessGroupID: item
    }

  
    const UserMenuDetails = await getUserMenuListForAccessGroup(formData)
    console.log(UserMenuDetails)
    setUserMenuDetails(UserMenuDetails);
  }
  // async function requestDefaultData() {
  //   const formData = {
  //     // UD_StaffID: staffId,
  //     // AUD_notificationToken: token,
  //     UAG_AccessGroupID: ""
  //   }
  //   const MenuList = await UserMenu_DropDowns_All_Selectable(formData)

  //   setcheckMenuListItems(MenuList);

  // }

  const handleItemsPerPageChange = (newItemsPerPage) => {
    console.log(newItemsPerPage);
    setItemsPerPage(newItemsPerPage);
  };

  const handlePageChange = (page) => {
    setCurrentPage(page);
    // Fetch data for the new page
  };


  const [currentItems, setCurrentItems] = useState(data)

  // console.log(UserRoleDetails)
  const [checkedItems, setCheckedItems] = useState([]);
  // const [checkMenuListItems, setcheckMenuListItems] = useState([]);

  const handleCheckboxChange = (event) => {
    const { checked, value } = event.target;
    if (checked) {
      setCheckedItems([...checkedItems, value]);
    } else {
      setCheckedItems(checkedItems.filter(item => item !== value));
    }
  };

  const options = [
    { value: 'option1', label: 'Option 1', checked: true },
    { value: 'option2', label: 'Option 2', checked: true },
    { value: 'option3', label: 'Option 3', checked: true },
  ];

  useEffect(() => {
  }, []);

  const csvContent = currentItems.map((item) => Object.values(item).join(',')).join('\n')

  const csvCode = 'data:text/csv;charset=utf-8,SEP=,%0A' + encodeURIComponent(csvContent)

  const [visible1, setVisible1] = useState(false);

  const handleOpenPopup = () => {
    setVisible1(true);
    // requestDefaultData();
  };

  const handleClosePopup = () => {
    setVisible1(false);
    // setAccessGroupDetails([]);
  };

  return (
    <>
      <CTabPanel className="p-3" itemKey="menus">
        <CRow>
          <CCol>
            <CDropdown>
              <CDropdownToggle color="secondary">Export Data</CDropdownToggle>
              <CDropdownMenu>
                <CDropdownItem><CButton
                  color="primary"
                  className="mb-2"
                  href={csvCode}
                  download="accessgroupmenus.csv"
                  target="_blank"
                >
                  Download items as .csv
                </CButton></CDropdownItem>
                <CDropdownItem><ExcelExport data={data} fileName="accessgroupmenus" headers={headers} /></CDropdownItem>
                <CDropdownItem>
                  <CSmartGridPDF data={data} headers={headers} filename="accessgroupmenus" title="accessgroupmenus" />
                </CDropdownItem>
              </CDropdownMenu>
            </CDropdown>
          </CCol>        
        </CRow>
        <CSmartTable
          cleaner
          clickableRows
          columns={columnsMenu}
          columnFilter
          columnSorter
          // footer
          items={UserMenuDetails}
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
      </CTabPanel>
    </>
  )
}
export default AccessGroupPopup_Menus
