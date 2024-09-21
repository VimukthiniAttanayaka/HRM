import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CModal, CModalBody, CBadge, CDropdown, CCollapse, CDropdownItem, CDropdownMenu, CDropdownToggle, CRow, CCol, CSmartTable, CTabPanel, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';

import { getLabelText } from 'src/MultipleLanguageSheets'
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columnsMenu, headers } from '../../controllers/accessgroup_controllers.js';
import { getUserMenuListForAccessGroup } from '../../../apicalls/usermenu/get_all_list.js';
import { GrantAccessUserMenu, RemoveAccessUserMenu } from '../../../apicalls/usermenu/accessgrouprelated.js';

import PopUpAlert from '../../shared/PopUpAlert.js'

const AccessGroupPopup_Menus = ({ visible, onClose, onOpen, AccessGroupDetails }) => {
  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const [popupStatus, setPopupStatus] = useState('create')

  const [itemsPerPage, setItemsPerPage] = useState(5); // Default items per page
  const [currentPage, setCurrentPage] = useState(1);
  const [columnFilter, setColumnFilter] = useState([])
  const [tableFilter, setTableFilter] = useState([])

  const [userAccessDetails, setUserAccessDetails] = useState([])

  const [currentItems, setCurrentItems] = useState(data)
  const [AccessGroupId, setAccessGroupId] = useState('')

  useEffect(() => {
    console.log(AccessGroupDetails.UAG_AccessGroupID)
    setAccessGroupId(AccessGroupDetails.UAG_AccessGroupID)
    console.log(AccessGroupId)
    // setAccessGroup(AccessGroupDetails.UAG_AccessGroup)
    // setIsActive(StatusInDB)
  }, [AccessGroupDetails]);


  const toggleRemove = (index) => {
    setPopupStatus('remove')
    toggleDetails(index)
  }
  const toggleGrant = (index) => {
    setPopupStatus('grant')
    toggleDetails(index)
  }
  const toggleDetails = (index, action) => {
    console.log(index)
    const position = details.indexOf(index)
    let newDetails = details.slice()
    if (position !== -1) {
      newDetails.splice(position, 1)
    } else {
      newDetails = [...details, index]
      // loadDetails(newDetails[0], action)
      submitSelection(newDetails[0])
    }
    // setDetails(newDetails)
  }

  async function submitSelection(menuid) {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      UMA_AccessGroupID: AccessGroupId,
      UMA_UserMenuID: menuid,
      UD_UserID: staffId,
    }
    // console.log(formData)
    // console.log(popupStatus)
    if (popupStatus == 'remove') {
      const APIReturn = await RemoveAccessUserMenu(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'grant') {
      const APIReturn = await GrantAccessUserMenu(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  async function requestdata() {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      UMA_AccessGroupID: AccessGroupDetails.UAG_AccessGroupID// AccessGroupId
    }
    console.log(formData)
    const MenuList = await getUserMenuListForAccessGroup(formData)
    setData(MenuList);
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

  const [open, setOpen] = useState(false);

  const handleClose = () => {
    setOpen(false);
    requestdata();
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');
  return (
    <>
      <CTabPanel className="p-3" itemKey="menus">
        <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />
        <CCardBody>
          <CSmartTable
            cleaner
            clickableRows
            columns={columnsMenu}
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
                        toggleGrant(item.id)
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
                          toggleRemove(item.id)
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
export default AccessGroupPopup_Menus
