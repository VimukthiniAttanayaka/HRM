import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CBadge, CCollapse, } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
const SmartTableDownloadableExample = () => {

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
    const res = await fetch(apiUrl + 'employee/get_employee_all', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })
      .then(response => response.json())
      .then(json => {
        let res1 = JSON.parse(JSON.stringify(json))
        console.log(res1);
        // setCustomerId(res1[0].Customer[0].CUS_ID);
      })
  }
  useEffect(() => {
    // requestdata();
  }, []);


  const [currentItems, setCurrentItems] = useState(data)

  const csvContent = currentItems.map((item) => Object.values(item).join(',')).join('\n')

  const csvCode = 'data:text/csv;charset=utf-8,SEP=,%0A' + encodeURIComponent(csvContent)


  const [details, setDetails] = useState([])
  const columns = [
    {
      key: 'name',
      _style: { width: '40%' },
    },
    'registered',
    { key: 'role', _style: { width: '20%' } },
    { key: 'status', _style: { width: '10%' } },
    { key: 'status', _style: { width: '10%' } },
    {
      key: 'show_details',
      label: '',
      _style: { width: '1%' },
      filter: false,
      sorter: false,
    },
  ]
  const toggleDetails = (index) => {
    const position = details.indexOf(index)
    let newDetails = details.slice()
    if (position !== -1) {
      newDetails.splice(position, 1)
    } else {
      newDetails = [...details, index]
    }
    setDetails(newDetails)
  }

  return (
    <CCardBody>
      <CButton
        color="primary"
        className="mb-2"
        href={csvCode}
        download="coreui-table-data.csv"
        target="_blank"
      >
        Download current items (.csv)
      </CButton>
      <CSmartTable
        columnFilter
        columnSorter
        items={data}
        itemsPerPage={5}
        onFilteredItemsChange={setCurrentItems}
        pagination
        scopedColumns={{
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
                <CCardBody>
                  <h4>{item.username}</h4>
                  <p className="text-body-secondary">User since: {item.registered}</p>
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
      />
    </CCardBody>
  )
}

export default SmartTableDownloadableExample
