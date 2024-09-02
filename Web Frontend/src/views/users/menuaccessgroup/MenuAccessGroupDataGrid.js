import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CInputGroup, CInputGroupText, CFormSelect, CBadge } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import MenuAccessGroupPopup from './MenuAccessGroupPopup.js';
// import loadDetails from './MenuAccessGroupPopup.js';
import { getMenuAccessGroupAll } from '../../../apicalls/menuaccessgroup/get_all_list.js';
import { getMenuAccessGroupSingle } from '../../../apicalls/menuaccessgroup/get_menuaccessgroup_single.js';
import { UserMenu_DropDowns_All_Selectable } from '../../../apicalls/usermenu/get_all_list.js';
import { requestdata_AccessGroup_DropDowns_All } from '../../../apicalls/accessgroup/get_all_list.js';


const MenuAccessGroupDataGrid = () => {

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const columns = [
    {
      key: 'MenuAccessGroupID',
      // label: '',
      // filter: false,
      // sorter: false,
    },
    {
      key: 'UserMenuID',
      _style: { width: '20%' },
    },
    {
      key: 'AccessGroupID',
      _style: { width: '20%' },
    },
    {
      key: 'status',
      _style: { width: '20%' }
    },

    {
      key: 'show_details',
      label: '',
      _style: { width: '1%' },
      filter: false,
      sorter: false,
    },
  ];
  const getBadge = (status) => {
    switch (status) {
      case 'Active':
        return 'success'
      case 'Inactive':
        return 'secondary'
      case 'Pending':
        return 'warning'
      case 'Banned':
        return 'danger'
      default:
        return 'primary'
    }
  }

  const [MenuAccessGroupDetails, setMenuAccessGroupDetails] = useState([])
  // const [MenuAccessGroupId, setMenuAccessGroupId] = useState('')
  const handleChangeId = (event) => {
    setMenuAccessGroupId(event.target.value)
  }

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
      UMA_MenuAccessID: item
    }

    // const res = fetch(apiUrl + 'MenuAccessGroup/get_MenuAccessGroup_single', {
    //   method: 'POST',
    //   headers: { 'Content-Type': 'application/json' },
    //   body: JSON.stringify(formData),
    // })
    //   .then(response => response.json())
    //   .then(json => {
    //     let res1 = JSON.parse(JSON.stringify(json))
    //     setMenuAccessGroupDetails(res1[0].MenuAccessGroup[0]);
    //     handleOpenPopup()
    //   })
    const MenuAccessGroupDetails = await getMenuAccessGroupSingle(formData)
    // setMenuAccessGroupDetails(res1[0].MenuAccessGroup[0]);
    setMenuAccessGroupDetails(MenuAccessGroupDetails);
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
    }
    // setDetails(newDetails)
  }

  // setCustomerId(res1[0].Customer[0].CUS_ID);}
  const apiUrl = process.env.REACT_APP_API_URL;

  const [optionsUserMenu, setOptionsUserMenu] = useState([]);
  const [optionsAccessGroup, setOptionsAccessGroup] = useState([]);

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

    const MenuAccessGroupDetails = await getMenuAccessGroupAll(formData)
    // console.log(MenuAccessGroupDetails)
    setData(MenuAccessGroupDetails);


    const AccessGroupDetails = await requestdata_AccessGroup_DropDowns_All(formData)

    setOptionsAccessGroup(AccessGroupDetails);

    const UserMenuDetails = await UserMenu_DropDowns_All_Selectable(formData)

    setOptionsUserMenu(UserMenuDetails);
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
  };

  const handleClosePopup = () => {
    setVisible(false);
    setMenuAccessGroupDetails([]);
  };

  return (
    <CCardBody>
      <CRow>
        <CCol>
          <CButton
            color="primary"
            className="mb-2"
            href={csvCode}
            download="coreui-table-data.csv"
            target="_blank"
          >
            Download current items (.csv)
          </CButton>
        </CCol>
        <CCol>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>User Name</h6>
              </CInputGroupText>
            </CCol>
            <CFormSelect value={optionsUserMenu} onChange={(e) => setOptionsUserMenu(e.target.value)}>
              {optionsUserMenu.map((option) => (
                <option key={option.key} value={option.key}>
                  {option.value}
                </option>
              ))}
            </CFormSelect>
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Access Group</h6>
              </CInputGroupText>
            </CCol>
            <CFormSelect value={optionsAccessGroup} onChange={(e) => setOptionsAccessGroup(e.target.value)}>
              {optionsAccessGroup.map((option) => (
                <option key={option.key} value={option.key}>
                  {option.value}
                </option>
              ))}
            </CFormSelect>
          </CInputGroup>
        </CCol>  <CCol className='d-flex justify-content-end'>
          <MenuAccessGroupPopup onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} MenuAccessGroupDetails={MenuAccessGroupDetails} />
        </CCol>
      </CRow>
      <CSmartTable
        cleaner
        clickableRows
        columns={columns}
        columnFilter
        columnSorter
        footer
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
                  <h4>{item.UserMenu}</h4>
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

export default MenuAccessGroupDataGrid
