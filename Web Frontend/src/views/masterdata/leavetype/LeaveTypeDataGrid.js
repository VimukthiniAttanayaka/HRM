import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import LeaveTypePopup from './LeaveTypePopup.js';
import { getLeaveTypeAll } from '../../../apicalls/leavetype/get_all_list.js';
import { getLeaveTypeSingle } from '../../../apicalls/leavetype/get_leavetype_single.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns, headers } from '../../controllers/leavetype_controllers.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';

const LeaveTypeDataGrid = () => {

  let templatetype = 'translation_leavetype'
  let templatetype_base = 'translation'

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])
  const [popupStatus, setPopupStatus] = useState('create')

  const [StatusInDB, setStatusInDB] = useState(true)

  const [itemsPerPage, setItemsPerPage] = useState(5); // Default items per page
  const [currentPage, setCurrentPage] = useState(1);
  const [columnFilter, setColumnFilter] = useState([])
  const [tableFilter, setTableFilter] = useState([])

  const [LeaveTypeDetails, setLeaveTypeDetails] = useState([])

  // const [leaveTypeId, setLeaveTypeId] = useState('')
  const handleChangeId = (event) => {
    setLeaveTypeId(event.target.value)
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
      MDLT_LeaveTypeID: item
    }
    // console.log(formData)
    const LeaveTypeDetails = await getLeaveTypeSingle(formData)
    // console.log(LeaveTypeDetails)
    // setLeaveTypeDetails(res1[0].LeaveType[0]);
    setLeaveTypeDetails(LeaveTypeDetails);
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
      loadDetails(newDetails[0])
    }
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

    const LeaveTypeDetails = await getLeaveTypeAll(formData)
    // console.log(LeaveTypeDetails)
    setData(LeaveTypeDetails);
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
    requestdata();
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
          <LeaveTypePopup popupStatus={popupStatus} onClose={handleClosePopup} StatusInDB={StatusInDB} visible={visible} onOpen={handleOpenPopup} LeaveTypeDetails={LeaveTypeDetails} />
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

export default LeaveTypeDataGrid
