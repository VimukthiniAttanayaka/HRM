import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CInputGroupText, CDatePicker, CInputGroup, CFormInput, CRow, CCol, CBadge, CDropdownToggle, CDropdown, CDropdownMenu, CDropdownItem } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import AttendancePopup from './AttendancePopup'
import { getAttendanceAll } from '../../../apicalls/attendance/get_all_list.js';
import { getAttendanceSingle } from '../../../apicalls/attendance/get_attendance_single.js';
import { getLabelText } from 'src/MultipleLanguageSheets'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns, headers } from '../../controllers/attendance_controllers.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';
import EmployeeGridModel from '../../sharedgridselectables/EmployeeGridModel.js';
import { getEmployeeSingle } from '../../../apicalls/employee/get_employee_single.js';
import { format, parse } from 'date-fns'

const AttendanceDataGrid = () => {
  let templatetype = 'translation_attendance'
  let templatetype_base = 'translation'

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])
  const [AttendanceDetails, setAttendanceDetails] = useState([])
  const [popupStatus, setPopupStatus] = useState('create')

  const [StatusInDB, setStatusInDB] = useState(true)

  const [EmployeeID, setEmployeeID] = useState('')
  const [EmployeeName, setEmployeeName] = useState('')

  const [DateFrom, setDateFrom] = useState(new Date())
  const [DateTo, setDateTo] = useState(new Date())

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

  async function loadDetails(item) {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      EAT_ID: item
    }

    const AttendanceDetails = await getAttendanceSingle(formData)
    setAttendanceDetails(AttendanceDetails);
    setStatusInDB(AttendanceDetails.EAT_Status)
    handleOpenPopup()
  }
  const handleOpenPopup = () => {
    setVisible(true);
  };

  const handleClosePopup = () => {
    setVisible(false);
  };


  const [visible, setVisible] = useState(false);

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
      EAT_EmployeeID: EmployeeID,
      DateFrom: DateFrom.toJSON(),
      DateTo: DateTo.toJSON(),
    }
    const AttendanceDetails = await getAttendanceAll(formData)
    console.log(AttendanceDetails)
    setData(AttendanceDetails);
  }

  async function loadDetails_Employee(item) {
    if (item !== undefined) {
      // console.log(item)
      const token = getJWTToken();
      const staffId = getStaffID();
      const customerId = getCustomerID();

      const formData = {
        // UD_StaffID: staffId,
        // AUD_notificationToken: token,
        EME_EmployeeID: item
      }
      const EmployeeDetails = await getEmployeeSingle(formData)
      // console.log(EmployeeDetails)
      setEmployeeID(EmployeeDetails.EME_EmployeeID)
      setEmployeeName(EmployeeDetails.EME_PrefferedName)
      handleCloseEmp_Popup();
    }
  }
  const [openEmp_Popup, setOpenEmp_Popup] = useState(false);

  const handleCloseEmp_Popup = () => {
    setOpenEmp_Popup(false);
  };

  const EmployeeSearchOnClick = () => {
    // console.log(true)
    setOpenEmp_Popup(true);
  };

  const ClearOnClick = () => {
    setEmployeeID('')
    setEmployeeName('')
  };
  const SearchOnClick = () => {
    requestdata();
  };
  useEffect(() => {
    requestdata();
  }, []);


  const [currentItems, setCurrentItems] = useState(data)

  const csvContent = currentItems.map((item) => Object.values(item).join(',')).join('\n')

  const csvCode = 'data:text/csv;charset=utf-8,SEP=,%0A' + encodeURIComponent(csvContent)

  return (
    <CCardBody>
      <CCol>
        <CInputGroup>
          <CInputGroupText>
            <h6>Employee</h6>
          </CInputGroupText>
          <CFormInput placeholder="EmployeeName" name="EmployeeName" value={EmployeeName} disabled />
          <CButton color="success" onClick={EmployeeSearchOnClick}>{getLabelText('Search', templatetype)}</CButton>
        </CInputGroup>
        <CInputGroup className="mb-3">
          <CCol md={2}>
            <CInputGroupText>
              <h6>DateFrom</h6>
            </CInputGroupText>
          </CCol>

          <CCol md={3}>  {(popupStatus == 'view' || popupStatus == 'delete') ?
            <CFormInput placeholder="DateFrom" name="DateFrom" value={DateFrom}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} /> :
            <CDatePicker placeholder="DateFrom" name="DateFrom" date={DateFrom}
              onDateChange={(date) => { setDateFrom(date) }}
              inputDateParse={(date) => parse(date, 'dd-MMM-yyyy', new Date())}
              inputDateFormat={(date) => format(new Date(date), 'dd-MMM-yyyy')}
            />}</CCol>  <CCol md={2}>
            <CInputGroupText>
              <h6>DateTo</h6>
            </CInputGroupText>
          </CCol>
          <CCol md={3}>   {(popupStatus == 'view' || popupStatus == 'delete') ?
            <CFormInput placeholder="DateTo" name="DateTo" value={DateTo}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} /> :
            <CDatePicker placeholder="DateTo" name="DateTo" date={DateTo}
              onDateChange={(date) => { setDateTo(date) }}
              inputDateParse={(date) => parse(date, 'dd-MMM-yyyy', new Date())}
              inputDateFormat={(date) => format(new Date(date), 'dd-MMM-yyyy')}
            />}</CCol>
        </CInputGroup>
        <EmployeeGridModel open={openEmp_Popup} handleClose={handleCloseEmp_Popup} loadDetails={loadDetails_Employee}></EmployeeGridModel>
      </CCol>
      <CCol>
        <CInputGroup>  <CDropdown>
          <CDropdownToggle color="secondary">Export Data</CDropdownToggle>
          <CDropdownMenu>
            <CDropdownItem><CButton
              color="primary"
              className="mb-2"
              href={csvCode}
              download="attendance.csv"
              target="_blank"
            >
              Download items as .csv
            </CButton></CDropdownItem>
            <CDropdownItem><ExcelExport data={data} fileName="attendance" headers={headers} /></CDropdownItem>
            <CDropdownItem>
              <CSmartGridPDF data={data} headers={headers} filename="attendance" title="attendance" />
            </CDropdownItem>
          </CDropdownMenu>
        </CDropdown>
          <CButton color="success" onClick={ClearOnClick}>{getLabelText('Clear', templatetype)}</CButton>
          <CButton color="success" onClick={SearchOnClick}>{getLabelText('Search', templatetype)}</CButton>
        </CInputGroup>
      </CCol>
      <CCol className='d-flex justify-content-end'>
        <AttendancePopup popupStatus={popupStatus} onClose={handleClosePopup} StatusInDB={StatusInDB} visible={visible} onOpen={handleOpenPopup} AttendanceDetails={AttendanceDetails} />
      </CCol>
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

export default AttendanceDataGrid
