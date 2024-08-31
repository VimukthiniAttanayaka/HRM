import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CInputGroupText } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import LeaveSchedulePopup from './LeaveSchedulePopup.js';
import { columns } from '../../controllers/leaveschedule_controller.js'

const LeaveScheduleDataGrid = () => {

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])
  const [leaveScheduleDetails, setLeaveScheduleDetails] = useState([])


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
      LV_LeaveID: item
    }

    const res = fetch(apiUrl + 'leaveschedule/get_leave_single', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })
      .then(response => response.json())
      .then(json => {
        let res1 = JSON.parse(JSON.stringify(json))
        console.log(res1)
        setLeaveScheduleDetails(res1[0].LeaveResponceModelList[0]);
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
      console.log(newDetails)
      // handleOpenPopup()
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
    const res = await fetch(apiUrl + 'leaveschedule/get_leave_all', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })
      .then(response => response.json())
      .then(json => {
        let res1 = JSON.parse(JSON.stringify(json))
        // console.log(res1);
        // setCustomerId(  res1[0].Customer[0].CUS_ID);

        const LeaveScheduleDetails = [];
        class LeaveScheduleDetail {
          constructor(id, entitlement, leavetype, status, startdate, enddate) {
            this.leavetype = leavetype;
            this.id = id;
            this.entitlement = entitlement;
            this.startdate = startdate;
            this.enddate = enddate;
            if (status == true) { this.status = "Active"; }
            else { this.status = "Inactive"; }
          }
        }

        // console.log(res1[0].LeaveGridViewModelList)
        for (let index = 0; index < res1[0].LeaveGridViewModelList.length; index++) {
          let element = res1[0].LeaveGridViewModelList[index];
          // console.log(element)
          LeaveScheduleDetails[index] = new LeaveScheduleDetail(element.LV_LeaveID, element.LV_LeaveEntitlementID, element.LV_LeaveTypeID, element.LVE_Status, element.LV_LeaveStartDate, element.LV_LeaveEndDate);
        }

        setData(LeaveScheduleDetails);
        // setCustomerId(  res1[0].Customer[0].CUS_ID);
      })
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
    setLeaveScheduleDetails([]);
  };

  return (
    <CCardBody>
      <CRow><CCol><CInputGroupText>
        <h6>Annual Leave</h6>
      </CInputGroupText></CCol>
        <CCol><CInputGroupText>Casual Leave</CInputGroupText></CCol>
        <CCol><CInputGroupText>Medical Leave</CInputGroupText></CCol>
        <CCol><CInputGroupText>Lieu Leave</CInputGroupText></CCol>
        <CCol><CInputGroupText>Maternity Leave</CInputGroupText></CCol>
      </CRow>
      <CRow>
        {/* <CCol>
          <CButton
            color="primary"
            className="mb-2"
            href={csvCode}
            download="coreui-table-data.csv"
            target="_blank"
          >
            Download current items (.csv)
          </CButton>
        </CCol> */}
        <CCol className='d-flex justify-content-end'>
          <LeaveSchedulePopup onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} leaveScheduleDetails={leaveScheduleDetails} />
        </CCol>
      </CRow>
      <CSmartTable
        cleaner
        clickableRows
        columns={columns}
        // columnFilter
        // columnSorter
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
          avatar: (item) => (
            <td>
              {/* <CAvatar src={`/images/avatars/${item.avatar}`} /> */}
            </td>
          ),
          status: (item) => (
            <td>
              {/* <CBadge color={getBadge(item.status)}>{item.status}</CBadge> */}
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

export default LeaveScheduleDataGrid
