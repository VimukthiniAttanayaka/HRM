import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import DepartmentPopup from './DepartmentPopup.js';
// import loadDetails from './DepartmentPopup.js';
import { getDepartmentAll } from '../../../apicalls/department/get_all_list.js';
import { getDepartmentSingle } from '../../../apicalls/department/get_department_single.js';

const DepartmentDataGrid = () => {

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const columns = [
    {
      key: 'id',
      // label: '',
      // filter: false,
      // sorter: false,
      _style: { width: '20%' },
    },
    {
      key: 'Department',
      _style: { width: '20%' },
    },

    // {
    //   key: 'alotment',
    //   _style: { width: '20%' }
    // },
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

  const [DepartmentDetails, setDepartmentDetails] = useState([])
  // const [DepartmentId, setDepartmentId] = useState('')
  const handleChangeId = (event) => {
    setDepartmentId(event.target.value)
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
      LVT_DepartmentID: item
    }

    // const res = fetch(apiUrl + 'Department/get_Department_single', {
    //   method: 'POST',
    //   headers: { 'Content-Type': 'application/json' },
    //   body: JSON.stringify(formData),
    // })
    //   .then(response => response.json())
    //   .then(json => {
    //     let res1 = JSON.parse(JSON.stringify(json))
    //     setDepartmentDetails(res1[0].Department[0]);
    //     handleOpenPopup()
    //   })
    const DepartmentDetails = await getDepartmentSingle(formData)
    // setDepartmentDetails(res1[0].Department[0]);
    setDepartmentDetails(DepartmentDetails);
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

    const DepartmentDetails = await getDepartmentAll(formData)
    // console.log(DepartmentDetails)
    setData(DepartmentDetails);

    // const res = await fetch(apiUrl + 'Department/get_Department_all', {
    //   method: 'POST',
    //   headers: { 'Content-Type': 'application/json' },
    //   body: JSON.stringify(formData),
    // })
    //   .then(response => response.json())
    //   .then(json => {
    //     let res1 = JSON.parse(JSON.stringify(json))

    //     const DepartmentDetails = [];
    //     class DepartmentDetail {
    //       constructor(id, Department, status, Alotment) {
    //         this.Department = Department;
    //         this.id = id;
    //         this.alotment = Alotment
    //         if (status == true) { this.status = "Active"; }
    //         else { this.status = "Inactive"; }
    //       }
    //     }

    //     for (let index = 0; index < res1[0].Department.length; index++) {
    //       let element = res1[0].Department[index];
    //       console.log(element)
    //       DepartmentDetails[index] = new DepartmentDetail(element.LVT_DepartmentID, element.LVT_Department, element.LVT_Status, element.LVT_LeaveAlotment);
    //     }

    //     setData(DepartmentDetails);
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
    setDepartmentDetails([]);
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
          <DepartmentPopup onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} DepartmentDetails={DepartmentDetails} />
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

export default DepartmentDataGrid
