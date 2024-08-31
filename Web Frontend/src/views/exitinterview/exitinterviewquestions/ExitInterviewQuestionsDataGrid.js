import React, { useState, useEffect, useRef } from 'react'
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge, CDropdownToggle, CDropdown, CDropdownMenu, CDropdownItem } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import ExitInterviewQuestionsPopup from './ExitInterviewQuestionsPopup.js';
import { getExitInterviewQuestionsAll } from '../../../apicalls/exitinterviewquestions/get_all_list.js';
import { getExitInterviewQuestionsSingle } from '../../../apicalls/exitinterviewquestions/get_exitinterviewquestions_single.js';
import { getLabelText } from 'src/MultipleLanguageSheets'
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns, headers } from '../../controllers/exitinterviewquestions_controllers.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';

const ExitInterviewQuestionsDataGrid = () => {
  let templatetype = 'translation_exitinterviewquestions'
  let templatetype_base = 'translation'
  const [details, setDetails] = useState([])
  const [data, setData] = useState([])
  const [popupStatus, setPopupStatus] = useState('create')
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



  const [exitinterviewquestionsDetails, setexitinterviewquestionsDetails] = useState([])

  async function loadDetails(item, action) {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      MDD_exitinterviewquestionsID: item
    }
    const exitinterviewquestionsDetails = await getExitInterviewQuestionsSingle(formData)
    setexitinterviewquestionsDetails(exitinterviewquestionsDetails);
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
  const toggleDetails = (index, action) => {
    console.log(index)
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

  // setCustomerId(res1[0].Customer[0].CUS_ID);}
  const apiUrl = process.env.REACT_APP_API_URL;

  async function requestdata() {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      USR_EmployeeID: 'sedcx'
    }

    const exitinterviewquestionsDetails = await getExitInterviewQuestionsAll(formData)
    setData(exitinterviewquestionsDetails);

  }
  const [visible, setVisible] = useState(false);

  useEffect(() => {
    requestdata();
  }, [visible]);


  const [currentItems, setCurrentItems] = useState(data)

  const csvContent = currentItems.map((item) => Object.values(item).join(',')).join('\n')

  const csvCode = 'data:text/csv;charset=utf-8,SEP=,%0A' + encodeURIComponent(csvContent)

  const handleOpenPopup = () => {
    setVisible(true);
  };

  const handleClosePopup = () => {
    setVisible(false);
    setexitinterviewquestionsDetails([]);
    setPopupStatus('create')
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
                download="exitinterviewquestions.csv"
                target="_blank"
              >
                Download items as .csv
              </CButton></CDropdownItem>
              <CDropdownItem><ExcelExport data={data} fileName="exitinterviewquestions" headers={headers} /></CDropdownItem>
              <CDropdownItem>
                <CSmartGridPDF data={data} headers={headers} filename="exitinterviewquestions" title="exit interview questions" />
              </CDropdownItem>
            </CDropdownMenu>
          </CDropdown>
        </CCol>
        <CCol className='d-flex justify-content-end'>
          <ExitInterviewQuestionsPopup popupStatus={popupStatus} onClose={handleClosePopup} visible={visible} onOpen={handleOpenPopup} exitinterviewquestionsDetails={exitinterviewquestionsDetails} />
        </CCol>
      </CRow>
      <CSmartTable
        // ref={tableRef}
        cleaner
        clickableRows
        columns={columns}
        columnFilter
        onColumnFilterChange={setColumnFilter}
        columnSorter
        // footer
        items={data}
        itemsPerPageSelect
        itemsPerPage={5}
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
                  {getLabelText('Edit', templatetype_base)}
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
                {getLabelText('View', templatetype_base)}
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
                  {getLabelText('Delete', templatetype_base)}
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

export default ExitInterviewQuestionsDataGrid
