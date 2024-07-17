import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass';
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
    const res = await fetch(apiUrl + 'enployee/get_employee_all', {
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
    requestdata();
  }, []);


  const [currentItems, setCurrentItems] = useState(data)

  const csvContent = currentItems.map((item) => Object.values(item).join(',')).join('\n')

  const csvCode = 'data:text/csv;charset=utf-8,SEP=,%0A' + encodeURIComponent(csvContent)

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
      />
    </CCardBody>
  )
}

export default SmartTableDownloadableExample
