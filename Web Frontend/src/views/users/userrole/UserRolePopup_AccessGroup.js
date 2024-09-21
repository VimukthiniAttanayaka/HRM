import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CModal, CModalBody, CBadge, CDropdown, CCollapse, CDropdownItem, CDropdownMenu, CDropdownToggle, CRow, CCol, CSmartTable, CTabPanel, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';

import { getLabelText } from 'src/MultipleLanguageSheets'
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columnsGroup, headers } from '../../controllers/userrole_controllers.js';
import { getAccessGroupListForUserRole } from '../../../apicalls/userrole/get_all_list.js';
import { GrantAccessUserGroup, RemoveAccessUserGroup } from '../../../apicalls/userrole/accessgrouprelated.js';

import PopUpAlert from '../../shared/PopUpAlert.js'

const UserRolePopup_AccessGroup = ({ visible, onClose, onOpen, UserRoleDetails }) => {
  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const [popupStatus, setPopupStatus] = useState('create')

  const [itemsPerPage, setItemsPerPage] = useState(5); // Default items per page
  const [currentPage, setCurrentPage] = useState(1);
  const [columnFilter, setColumnFilter] = useState([])
  const [tableFilter, setTableFilter] = useState([])

  const [currentItems, setCurrentItems] = useState(data)  
  const [UserRoleId, setUserRoleId] = useState('')

  useEffect(() => {
    setUserRoleId(UserRoleDetails.UUR_UserRoleID)
    requestAccessGroupData(UserRoleDetails.UUR_UserRoleID) 
  }, [UserRoleDetails]);


  const toggleRemove = (index) => {
    setPopupStatus('remove')
    toggleDetails(index, 'remove')
  }
  const toggleGrant = (index) => {
    setPopupStatus('grant')
    toggleDetails(index, 'grant')
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
      submitSelection(newDetails[0], action)
    }
    // setDetails(newDetails)
  }

  async function submitSelection(groupid, action) {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      UURAG_AccessGroupID: groupid,
      UURAG_UserRoleID: UserRoleId,
      UD_UserID: staffId,
    }
    // console.log(formData)
    // console.log(popupStatus)
    if (/*popupStatus*/action == 'remove') {
      const APIReturn = await RemoveAccessUserGroup(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (/*popupStatus*/action == 'grant') {
      const APIReturn = await GrantAccessUserGroup(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  async function requestAccessGroupData(UserRoleId) {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      UUR_UserRoleID: UserRoleId
    }
    // console.log(formData)
    const AccessGroupList = await getAccessGroupListForUserRole(formData)
    setData(AccessGroupList);
  }

  const handleItemsPerPageChange = (newItemsPerPage) => {
    console.log(newItemsPerPage);
    setItemsPerPage(newItemsPerPage);
  };

  const handlePageChange = (page) => {
    setCurrentPage(page);
    // Fetch data for the new page
  };
  // useEffect(() => {
  //   requestdata();
  // }, []);

  const [open, setOpen] = useState(false);

  const handleClose = () => {
    setOpen(false);
    requestAccessGroupData(UserRoleId);
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');
  return (
    <>
      <CTabPanel className="p-3" itemKey="groups">
        <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />
        <CCardBody>
          <CSmartTable
            cleaner
            clickableRows
            columns={columnsGroup}
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
export default UserRolePopup_AccessGroup
