import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import EmployeePopupTab from './EmployeePopupTab'
import { getEmployeeAll } from '../../../apicalls/employee/get_all_list.js';

const EmployeeDataGrid = () => {

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const columns = [
    {
      key: 'EME_EmployeeID',
      label: 'ID',
      filter: false,
      sorter: false,
    },
    {
      key: 'EME_FirstName',
      label: 'Name',
      _style: { width: '20%' },
    },
    {
      key: 'EME_EmployeeType',
      label: 'Employee Type',
      _style: { width: '25%' }
    },
    {
      key: 'EME_PrefferedName',
      label: 'Preffered Name',
      _style: { width: '25%' }
    },
    {
      key: 'EME_ReportingManager',
      label: 'Reporting Manager',
      _style: { width: '25%' }
    },
    {
      key: 'EME_MobileNumber',
      label: 'Mobile Number',
      _style: { width: '25%' }
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
  const toggleDetails = (index) => {


    const position = details.indexOf(index)
    let newDetails = details.slice()
    if (position !== -1) {
      newDetails.splice(position, 1)
    } else {
      newDetails = [...details, index]
      // alert(newDetails[newDetails.length - 1])
      console.log(newDetails)
      handleOpenPopup()
    }
    // setDetails(newDetails)
  }
  const apiUrl = process.env.REACT_APP_API_URL;

  async function requestdata() {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      EME_EmployeeID: 'sedcx'
    }

    const EmployeeDetails = await getEmployeeAll(formData)
    setData(EmployeeDetails);

    console.log(EmployeeDetails)

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
          <EmployeePopupTab onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} />
        </CCol>
      </CRow>
      <CSmartTable
        cleaner
        clickableRows
        columns={columns}
        // columnFilter
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

          // status: (item) => (
          //   <td>
          //     {/* <CBadge color={getBadge(item.status)}>{item.status}</CBadge> */}
          //   </td>
          // ),
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

export default EmployeeDataGrid
