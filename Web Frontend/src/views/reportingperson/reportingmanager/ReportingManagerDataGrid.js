import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge, CDropdownToggle, CDropdown, CDropdownMenu, CDropdownItem } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import ReportingManagerSearchPopup from './ReportingManagerSearchPopup.js';
// import loadDetails from './ReportingManagerPopup.js';
import Pagination from '../../shared/Pagination.js'
import { getReportingManagerAll } from '../../../apicalls/reportingmanager/get_all_list.js';
import { getReportingManagerSingle } from '../../../apicalls/reportingmanager/get_reportingmanager_single.js';

import { getBadge } from '../../shared/gridviewconstants.js';
import { columns, headers } from '../../controllers/reportingmanager_controllers.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';

const ReportingManagerSearchDataGrid = () => {

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const [itemsPerPage, setItemsPerPage] = useState(5); // Default items per page
  const [currentPage, setCurrentPage] = useState(1);
  const [columnFilter, setColumnFilter] = useState([])
  const [tableFilter, setTableFilter] = useState([])

  const [ReportingManagerDetails, setReportingManagerDetails] = useState([])
  // const [ReportingManagerId, setReportingManagerId] = useState('')
  const handleChangeId = (event) => {
    setReportingManagerId(event.target.value)
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
      LVT_ReportingManagerID: item
    }

    const ReportingManagerDetails = await getReportingManagerSingle(formData)
    setReportingManagerDetails(ReportingManagerDetails);
    handleOpenPopup()
  }
  const handleItemsPerPageChange = (newItemsPerPage) => {
    console.log(newItemsPerPage);
    setItemsPerPage(newItemsPerPage);
  };

  const handlePageChange = (page) => {
    setCurrentPage(page);
    // Fetch data for the new page
  };
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

    const ReportingManagerDetails = await getReportingManagerAll(formData)
    // console.log(ReportingManagerDetails)
    setData(ReportingManagerDetails);

    // const res = await fetch(apiUrl + 'ReportingManager/get_ReportingManager_all', {
    //   method: 'POST',
    //   headers: { 'Content-Type': 'application/json' },
    //   body: JSON.stringify(formData),
    // })
    //   .then(response => response.json())
    //   .then(json => {
    //     let res1 = JSON.parse(JSON.stringify(json))

    //     const ReportingManagerDetails = [];
    //     class ReportingManagerDetail {
    //       constructor(id, ReportingManager, status, Alotment) {
    //         this.ReportingManager = ReportingManager;
    //         this.id = id;
    //         this.alotment = Alotment
    //         if (status == true) { this.status = "Active"; }
    //         else { this.status = "Inactive"; }
    //       }
    //     }

    //     for (let index = 0; index < res1[0].ReportingManager.length; index++) {
    //       let element = res1[0].ReportingManager[index];
    //       console.log(element)
    //       ReportingManagerDetails[index] = new ReportingManagerDetail(element.LVT_ReportingManagerID, element.LVT_ReportingManager, element.LVT_Status, element.LVT_LeaveAlotment);
    //     }

    //     setData(ReportingManagerDetails);
    //     // setCustomerId(  res1[0].Customer[0].CUS_ID);
    //   })

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
    setReportingManagerDetails([]);
  };

  return (
    <CCardBody>
      <CRow>
        <CCol>
        <CDropdown>
            <CDropdownToggle color="secondary">Export Data</CDropdownToggle>
            <CDropdownMenu>
              <CDropdownItem><CButton
                color="primary"
                className="mb-2"
                href={csvCode}
                download="reportingmanager.csv"
                target="_blank"
              >
                Download items as .csv
              </CButton></CDropdownItem>
              <CDropdownItem><ExcelExport data={data} fileName="reportingmanager" headers={headers} /></CDropdownItem>
              <CDropdownItem>
                <CSmartGridPDF data={data} headers={headers} filename="reportingmanager" title="reportingmanager" />
              </CDropdownItem>
            </CDropdownMenu>
          </CDropdown>
        </CCol>
        <CCol className='d-flex justify-content-end'>
          <ReportingManagerSearchPopup onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} ReportingManagerDetails={ReportingManagerDetails} />
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
        pagination={<div> <Pagination
          totalItems={data.RC}
          currentPage={currentPage}
          setCurrentPage={handlePageChange}
          itemsPerPage={itemsPerPage}
        /></div>}
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

export default ReportingManagerSearchDataGrid
