import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge, CFormSelect } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
import LeaveTypePopup from './LeaveEntitlementPopup.js';
// import loadDetails from './LeaveTypePopup.js';
import { Dropdowns_Employee } from '../../../apicalls/employee/dropdowns.js';
import { getLabelText } from 'src/MultipleLanguageSheets'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns, headers } from '../../controllers/leaveentitlement_controller.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';

const LeaveEntitlementDataGrid = () => {

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const [leaveEntitlementDetails, setLeaveEntitlementDetails] = useState([])
  // const [leaveTypeId, setLeaveTypeId] = useState('')
  const handleChangeId = (event) => {
    setLeaveEntitlementId(event.target.value)
  }

  const loadDetails = (item) => {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    // const config = {
    //   headers: { Authorization: `Bearer ${auth}` }
    // };

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      LVE_LeaveEntitlementID: item
    }

    const res = fetch(apiUrl + 'LeaveEntitlement/get_LeaveEntitlement_single', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })
      .then(response => response.json())
      .then(json => {
        let res1 = JSON.parse(JSON.stringify(json))
        // console.log(res1[0])
        setLeaveEntitlementDetails(res1[0].LeaveEntitlement[0]);
        handleOpenPopup()
      })
  }
  const toggleDetails = (index) => {


    const position = details.indexOf(index)
    let newDetails = details.slice()
    if (position !== -1) {
      newDetails.splice(position, 1)
    } else {
      newDetails = [...details, index]
      // alert(newDetails[newDetails.length - 1])
      // console.log(newDetails[0])
      loadDetails(newDetails[0])
    }
    // setDetails(newDetails)
  }

  // setCustomerId(res1[0].Customer[0].CUS_ID);}
  const apiUrl = process.env.REACT_APP_API_URL;

  const [selectedOptionEmployee, setSelectedOptionEmployee] = useState(null);
  const [optionsEmployee, setOptionsEmployee] = useState([]);

  async function requestdata(employeeID) {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();
    // const config = {
    //   headers: { Authorization: `Bearer ${auth}` }
    // };
    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      LVE_EmployeeID: employeeID
    }
    const res = await fetch(apiUrl + 'LeaveEntitlement/get_LeaveEntitlement_all', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })
      .then(response => response.json())
      .then(json => {
        let res1 = JSON.parse(JSON.stringify(json))

        const LeaveEntitlementDetails = [];
        class LeaveEntitlementDetail {
          constructor(id, leavetype, status, Alotment) {
            this.leavetype = leavetype;
            this.id = id;
            this.alotment = Alotment
            if (status == true) { this.status = "Active"; }
            else { this.status = "Inactive"; }
          }
        }

        // console.log( res1[0].LeaveEntitlement)
        for (let index = 0; index < res1[0].LeaveEntitlement.length; index++) {
          let element = res1[0].LeaveEntitlement[index];
          // console.log(element)
          LeaveEntitlementDetails[index] = new LeaveEntitlementDetail(element.LVE_LeaveEntitlementID, element.LVE_LeaveType, element.LVE_Status, element.LVE_LeaveAlotment);
        }

        setData(LeaveEntitlementDetails);
        // setCustomerId(  res1[0].Customer[0].CUS_ID);
      })

  }

  async function SearchOnClick() {

  }

  async function requestdataLoad() {


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

    const EmployeeDetails = await Dropdowns_Employee(formData)

    setOptionsEmployee(EmployeeDetails);
  }

  useEffect(() => {
    requestdata();
    requestdataLoad();
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
    setLeaveEntitlementDetails([]);
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
          <LeaveTypePopup onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} leaveEntitlementDetails={leaveEntitlementDetails} />
        </CCol>
      </CRow><CRow> <CFormSelect value={selectedOptionEmployee} onChange={(e) => setSelectedOptionEmployee(e.target.value)}>
        {optionsEmployee.map((option) => (
          <option key={option.key} value={option.key}>
            {option.value}
          </option>
        ))}
      </CFormSelect>
        <CButton
          color="primary"
          className="mb-2"
          // href={csvCode}
          // download="coreui-table-data.csv"
          target="_blank"
          onClick={SearchOnClick}
        >
          Search
        </CButton></CRow>
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

export default LeaveEntitlementDataGrid
