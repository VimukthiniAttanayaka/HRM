import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import EmployeePopupTab from './EmployeePopupTab'
import { getEmployeeAll } from '../../../apicalls/employee/get_all_list.js';
import { getEmployeeSingle } from '../../../apicalls/employee/get_employee_single.js';

const EmployeeDataGrid = () => {

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])
  const [popupStatus, setPopupStatus] = useState('create')

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
    {
      key: 'view',
      label: '',
      _style: { width: '1%' },
      filter: false,
      sorter: false,
    },
    {
      key: 'delete',
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

  const [EmployeeDetails, setEmployeeDetails] = useState([])

  async function loadDetails(item, action) {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      EME_EmployeeID: item
    }
    const EmployeeDetails = await getEmployeeSingle(formData)
    setEmployeeDetails(EmployeeDetails);
    handleOpenPopup()
  }
  const toggleEdit = (index) => {
    setPopupStatus('edit')
    toggleDetails(index)
  }
  const toggleDelete = (index) => {
    setPopupStatus('delete')
    toggleDetails(index)
  }
  const toggleView = (index) => {
    setPopupStatus('view')
    toggleDetails(index)
  }

  const toggleDetails = (index, action) => {
    const position = details.indexOf(index)
    let newDetails = details.slice()
    if (position !== -1) {
      newDetails.splice(position, 1)
    } else {
      newDetails = [...details, index]
      loadDetails(newDetails[0], action)
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

  }

  const [visible, setVisible] = useState(false);

  useEffect(() => {
    requestdata();
  }, [visible]);


  const [currentItems, setCurrentItems] = useState(data)

  const csvContent = currentItems.map((item) => Object.values(item).join(',')).join('\n')

  const csvCode = 'data:text/csv;charset=utf-8,SEP=,%0A' + encodeURIComponent(csvContent)

  const handleOpenPopup = () => {
    setVisible(true);
  };

  const handleClosePopup = () => {
    setVisible(false);
    setEmployeeDetails([]);
    setPopupStatus('create')
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
          <EmployeePopupTab popupStatus={popupStatus} onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} EmployeeDetails={EmployeeDetails} />
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
                    toggleEdit(item.EME_EmployeeID)
                  }}
                >
                  Edit
                </CButton>
              </td>
            )
          },
          view: (item) => (
            <td>
              <CButton
                color="success"
                variant="outline"
                shape="square"
                size="sm"
                onClick={() => {
                  toggleView(item.EME_EmployeeID)
                }}
              >
                View
              </CButton>
            </td>
          ),
          delete: (item) => (
            <td>
              {item.status == 'Inactive' ? '' :
                <CButton
                  color="danger"
                  variant="outline"
                  shape="square"
                  size="sm"
                  onClick={() => {
                    toggleDelete(item.EME_EmployeeID)
                  }}
                >
                  Delete
                </CButton>
              }
            </td>
          ),
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
