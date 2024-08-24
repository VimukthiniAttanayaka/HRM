import React, { useState, useEffect } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import JobRolePopup from './JobRolePopup.js';
import { getJobRoleAll } from '../../../apicalls/jobrole/get_all_list.js';
import { getJobRoleSingle } from '../../../apicalls/jobrole/get_jobrole_single.js';
import { getLabelText } from 'src/MultipleLanguageSheets'
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns } from '../../../controllers/jobrole_controllers.js';


const JobRoleDataGrid = () => {
  let templatetype = 'translation_jobrole'
  let templatetype_base = 'translation'
  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const [popupStatus, setPopupStatus] = useState('create')

  
  const [JobRoleDetails, setJobRoleDetails] = useState([])

  async function loadDetails(item) {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      MDJR_JobRoleID: item
    }
    const JobRoleDetails = await getJobRoleSingle(formData)
    setJobRoleDetails(JobRoleDetails);
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
    // setDetails(newDetails)
  }

  // setCustomerId(res1[0].Customer[0].CUS_ID);}
  const apiUrl = process.env.REACT_APP_API_URL;

  async function requestdata() {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      USR_EmployeeID: 'sedcx', MDJR_JobRoleID: 'sedcx',
      PAGE_NO: currentPage, PAGE_RECORDS_COUNT: itemsPerPage, ColumnSpecialFilter: JSON.stringify(columnFilter)
    }
    console.log(tableFilter);
    const JobRoleDetails = await getJobRoleAll(formData)
    setData(JobRoleDetails);

  }
  const [visible, setVisible] = useState(false);

  useEffect(() => {
    requestdata();
  }, [visible]);

  const [currentItems, setCurrentItems] = useState(data)

  useEffect(() => {
    requestdata();
  }, [currentItems]);


  const csvContent = currentItems.map((item) => Object.values(item).join(',')).join('\n')

  const csvCode = 'data:text/csv;charset=utf-8,SEP=,%0A' + encodeURIComponent(csvContent)

  const handleOpenPopup = () => {
    setVisible(true);
  };

  const handleClosePopup = () => {
    setVisible(false);
    setJobRoleDetails([]);
    setPopupStatus('create')
  };
  const [itemsPerPage, setItemsPerPage] = useState(5); // Default items per page
  const [currentPage, setCurrentPage] = useState(1);
  const [columnFilter, setColumnFilter] = useState([])
  const [tableFilter, setTableFilter] = useState([])
  useEffect(() => {
    // console.log(columnFilter);
    requestdata();
  }, [columnFilter]);

  useEffect(() => {
    requestdata();
  }, [tableFilter]);

  const handleItemsPerPageChange = (newItemsPerPage) => {
    console.log(newItemsPerPage);
    setItemsPerPage(newItemsPerPage);
  };

  const handlePageChange = (page) => {
    setCurrentPage(page);
    // Fetch data for the new page
  };

  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;

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
          <JobRolePopup popupStatus={popupStatus} onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} JobRoleDetails={JobRoleDetails} />
        </CCol>
      </CRow>
      <CSmartTable
        cleaner
        clickableRows
        columns={columns}
        columnFilter//={setColumnFilter}
        onColumnFilterChange={setColumnFilter}
        columnSorter
        // footer
        items={data.Data}
        itemsPerPageSelect
        // itemsPerPage={5}
        itemsPerPage={itemsPerPage}
        onItemsPerPageChange={handleItemsPerPageChange}
        onFilteredItemsChange={setCurrentItems}
        onTableFilterChange={setTableFilter}

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
      {/* <Pagination
        totalItems={100}
        currentPage={currentPage}
        setCurrentPage={handlePageChange}
        itemsPerPage={itemsPerPage}
      /> */}
    </CCardBody>
  )
}

export default JobRoleDataGrid
