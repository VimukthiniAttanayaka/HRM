import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge, CDropdownToggle, CDropdown, CDropdownMenu, CDropdownItem } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import UserRolePopup from './UserRolePopup.js';
// import loadDetails from './UserRolePopup.js';
import { getUserRoleAll } from '../../../apicalls/userrole/get_all_list.js';
import { getUserRoleSingle } from '../../../apicalls/userrole/get_userrole_single.js';
import { UserMenu_DropDowns_All_Selectable, getUserMenuListForAccessGroup } from '../../../apicalls/usermenu/get_all_list.js';
import { getLabelText } from 'src/MultipleLanguageSheets'
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns, headers } from '../../controllers/userrole_controllers.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';

const UserRoleDataGrid = () => {

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

 

  const [UserRoleDetails, setUserRoleDetails] = useState([])
  const [checkAccessGroupListItems, setcheckAccessGroupListItems] = useState([]);
  // const [UserRoleId, setUserRoleId] = useState('')
  const handleChangeId = (event) => {
    setUserRoleId(event.target.value)
  }

  // async function requestDefaultData() {
  //   const formData = {
  //     // UD_StaffID: staffId,
  //     // AUD_notificationToken: token,
  //     UAG_AccessGroupID: ""
  //   }
  //   const AccessGroupList = await requestdata_AccessGroup_SelectBox(formData)
   
  //   setcheckAccessGroupListItems(AccessGroupList);

  // }
  async function loadDetails(item) {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    // const config = {
    //   headers: { Authorization: `Bearer ${auth}` }
    // };

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      EUR_UserRoleID: item
    }

    // const res = fetch(apiUrl + 'UserRole/get_UserRole_single', {
    //   method: 'POST',
    //   headers: { 'Content-Type': 'application/json' },
    //   body: JSON.stringify(formData),
    // })
    //   .then(response => response.json())
    //   .then(json => {
    //     let res1 = JSON.parse(JSON.stringify(json))
    //     setUserRoleDetails(res1[0].UserRole[0]);
    //     handleOpenPopup()
    //   })
    const UserRoleDetails = await getUserRoleSingle(formData)
    // setUserRoleDetails(res1[0].UserRole[0]);
    setcheckAccessGroupListItems(UserRoleDetails.AccessGroups);
     setUserRoleDetails(UserRoleDetails);
    handleOpenPopup()
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
    }
    // setDetails(newDetails)
  }

  // setCustomerId(res1[0].Customer[0].CUS_ID);}
  const apiUrl = process.env.REACT_APP_API_URL;

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
      USR_EmployeeID: 'sedcx'
    }

    const UserRoleDetails = await getUserRoleAll(formData)
    // console.log(UserRoleDetails)
    setData(UserRoleDetails);

    // const res = await fetch(apiUrl + 'UserRole/get_UserRole_all', {
    //   method: 'POST',
    //   headers: { 'Content-Type': 'application/json' },
    //   body: JSON.stringify(formData),
    // })
    //   .then(response => response.json())
    //   .then(json => {
    //     let res1 = JSON.parse(JSON.stringify(json))

    //     const UserRoleDetails = [];
    //     class UserRoleDetail {
    //       constructor(id, UserRole, status, Alotment) {
    //         this.UserRole = UserRole;
    //         this.id = id;
    //         this.alotment = Alotment
    //         if (status == true) { this.status = "Active"; }
    //         else { this.status = "Inactive"; }
    //       }
    //     }

    //     for (let index = 0; index < res1[0].UserRole.length; index++) {
    //       let element = res1[0].UserRole[index];
    //       console.log(element)
    //       UserRoleDetails[index] = new UserRoleDetail(element.LVT_UserRoleID, element.LVT_UserRole, element.LVT_Status, element.LVT_LeaveAlotment);
    //     }

    //     setData(UserRoleDetails);
    //     // setCustomerId(  res1[0].Customer[0].CUS_ID);
    //   })

  }
  useEffect(() => {
    requestdata();
  }, []);


  const [currentItems, setCurrentItems] = useState(data)

  const csvContent = currentItems.map((item) => Object.values(item).join(',')).join('\n')

  const csvCode = 'data:text/csv;charset=utf-8,SEP=,%0A' + encodeURIComponent(csvContent)

  const [visible, setVisible] = useState(false);

  const handleOpenPopup = () => {
    setVisible(true);
  
    // requestDefaultData();
  };

  const handleClosePopup = () => {
    setVisible(false);
    setUserRoleDetails([]);
  };

  return (
    <CCardBody>
      <CRow>
        <CCol>
        <CDropdown>
            <CDropdownToggle color="secondary">Export Data</CDropdownToggle>
            <CDropdownMenu>
              <CDropdownItem><CButton
                color="primary"
                className="mb-2"
                href={csvCode}
                download="userrole.csv"
                target="_blank"
              >
                Download items as .csv
              </CButton></CDropdownItem>
              <CDropdownItem><ExcelExport data={data} fileName="userrole" headers={headers} /></CDropdownItem>
              <CDropdownItem>
                <CSmartGridPDF data={data} headers={headers} filename="userrole" title="userrole" />
              </CDropdownItem>
            </CDropdownMenu>
          </CDropdown>
        </CCol>
        <CCol className='d-flex justify-content-end'>
          <UserRolePopup onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} checkAccessGroupListItems={checkAccessGroupListItems}  UserRoleDetails={UserRoleDetails} />
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
        pagination
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
    </CCardBody>
  )
}

export default UserRoleDataGrid
