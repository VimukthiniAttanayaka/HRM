import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import ExternalUserPopup from './ExternalUserPopup.js';
// import loadDetails from './ExternalUserPopup.js';
import { getExternalUserAll } from '../../../apicalls/externaluser/get_all_list.js';
import { getExternalUserSingle } from '../../../apicalls/externaluser/get_externaluser_single.js';

const ExternalUserDataGrid = () => {

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const columns = [
    {
      key: 'UserName',
      // label: '',
      // filter: false,
      // sorter: false,
    },
    {
      key: 'EmailAddress',
      _style: { width: '20%' },
    },{
      key: 'EmployeeID',
      _style: { width: '20%' },
    },

    {
      key: 'MobileNumber',
      _style: { width: '20%' }
    }, {
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

  const [ExternalUserDetails, setExternalUserDetails] = useState([])
  // const [ExternalUserId, setExternalUserId] = useState('')
  const handleChangeId = (event) => {
    setExternalUserId(event.target.value)
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
      UD_UserName: item
    }
console.log(item)
    // const res = fetch(apiUrl + 'ExternalUser/get_ExternalUser_single', {
    //   method: 'POST',
    //   headers: { 'Content-Type': 'application/json' },
    //   body: JSON.stringify(formData),
    // })
    //   .then(response => response.json())
    //   .then(json => {
    //     let res1 = JSON.parse(JSON.stringify(json))
    //     setExternalUserDetails(res1[0].ExternalUser[0]);
    //     handleOpenPopup()
    //   })
    const ExternalUserDetails = await getExternalUserSingle(formData)
    // setExternalUserDetails(res1[0].ExternalUser[0]);
    console.log(ExternalUserDetails)
    setExternalUserDetails(ExternalUserDetails);
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
      console.log(newDetails)
      loadDetails(newDetails[0])
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

    const ExternalUserList = await getExternalUserAll(formData)
    // console.log(ExternalUserList)
    setData(ExternalUserList);

    // const res = await fetch(apiUrl + 'ExternalUser/get_ExternalUser_all', {
    //   method: 'POST',
    //   headers: { 'Content-Type': 'application/json' },
    //   body: JSON.stringify(formData),
    // })
    //   .then(response => response.json())
    //   .then(json => {
    //     let res1 = JSON.parse(JSON.stringify(json))

    //     const ExternalUserDetails = [];
    //     class ExternalUserDetail {
    //       constructor(id, ExternalUser, status, Alotment) {
    //         this.ExternalUser = ExternalUser;
    //         this.id = id;
    //         this.alotment = Alotment
    //         if (status == true) { this.status = "Active"; }
    //         else { this.status = "Inactive"; }
    //       }
    //     }

    //     for (let index = 0; index < res1[0].ExternalUser.length; index++) {
    //       let element = res1[0].ExternalUser[index];
    //       console.log(element)
    //       ExternalUserDetails[index] = new ExternalUserDetail(element.LVT_ExternalUserID, element.LVT_ExternalUser, element.LVT_Status, element.LVT_LeaveAlotment);
    //     }

    //     setData(ExternalUserDetails);
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
  };

  const handleClosePopup = () => {
    setVisible(false);
    setExternalUserDetails([]);
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
        <CCol className='d-flex justify-content-end'>
          <ExternalUserPopup onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} ExternalUserDetails={ExternalUserDetails} />
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
                    toggleDetails(item.UserName)
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

export default ExternalUserDataGrid
