import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import CurrencyPopup from './CurrencyPopup.js/index.js';
// import loadDetails from './CurrencyPopup.js';
import { getCurrencyAll } from '../../../apicalls/currency/get_all_list.js';
import { getCurrencySingle } from '../../../apicalls/currency/get_Currency_single.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const CurrencyDataGrid = () => {
  let templatetype = 'translation_currency'
let templatetype_base = 'translation'
  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const [StatusInDB, setStatusInDB] = useState(true)

  const columns = [
    {
      key: 'id',
      // label: '',
      label:  getLabelText('ID', templatetype),
      // filter: false,
      // sorter: false,
      _style: { width: '20%' },
    },
    {
      key: 'Currency',
      label:  getLabelText('Currency', templatetype),
         _style: { width: '20%' },
    },

    // {
    //   key: 'alotment',
    //   _style: { width: '20%' }
    // },
    {
      key: 'status',
      label:  getLabelText('Status', templatetype),
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

  const [CurrencyDetails, setCurrencyDetails] = useState([])
  // const [CurrencyId, setCurrencyId] = useState('')
  const handleChangeId = (event) => {
    setCurrencyId(event.target.value)
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
      MDCCY_CurrencyID: item
    }

    const CurrencyDetails = await getCurrencySingle(formData)
     setCurrencyDetails(CurrencyDetails);   
     setStatusInDB(CurrencyDetails.UUM_Status)
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

    const CurrencyDetails = await getCurrencyAll(formData)
    // console.log(CurrencyDetails)
    setData(CurrencyDetails);
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
    setCurrencyDetails([]);
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
            {getLabelText('Download current items (.csv)', templatetype_base)}
          </CButton>
        </CCol>
        <CCol className='d-flex justify-content-end'>
          <CurrencyPopup onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} StatusInDB={StatusInDB} CurrencyDetails={CurrencyDetails} />
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

export default CurrencyDataGrid
