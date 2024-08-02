import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import LocationPopup from './LocationPopup.js';
// import loadDetails from './LocationPopup.js';
import { getLocationAll } from '../../../apicalls/location/get_all_list.js';
import { getLocationSingle } from '../../../apicalls/location/get_location_single.js';

const LocationDataGrid = () => {

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])
  const [popupStatus, setPopupStatus] = useState('create')

  const columns = [
    {
      key: 'id',
      // label: '',
      // filter: false,
      // sorter: false,
      _style: { width: '20%' },
    },
    {
      key: 'Location',
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

  const [LocationDetails, setLocationDetails] = useState([])
  // const [LocationId, setLocationId] = useState('')
  const handleChangeId = (event) => {
    setLocationId(event.target.value)
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
      MDJR_LocationID: item
    }
    const LocationDetails = await getLocationSingle(formData)
    // setLocationDetails(res1[0].Location[0]);
    setLocationDetails(LocationDetails);
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

    const LocationDetails = await getLocationAll(formData)
    // console.log(LocationDetails)
    setData(LocationDetails);

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
    setLocationDetails([]);
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
          <LocationPopup popupStatus={popupStatus} onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} LocationDetails={LocationDetails} />
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
                    toggleEdit(item.id)
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
                  toggleView(item.id)
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
                    toggleDelete(item.id)
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

export default LocationDataGrid
