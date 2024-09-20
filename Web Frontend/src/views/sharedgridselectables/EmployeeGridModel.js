import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CTabs, CBadge, CCollapse, CTabList, CSmartTable, CTabContent, CTabPanel, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CTab, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../staticClass.js';
import { getEmployeeAll } from '../../apicalls/employee/get_all_list.js';
import Pagination from '../shared/Pagination'
import { getBadge } from '../shared/gridviewconstants.js';
import { columns_search } from '../controllers/employee_controllers'
// import { useTable } from 'react-table';

const EmployeeGridModel = ({ open, onClose, loadDetails }) => {

  const [data, setData] = useState([])
  const [details, setDetails] = useState([])
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
    // console.log(newItemsPerPage);
    setItemsPerPage(newItemsPerPage);
  };

  const handlePageChange = (page) => {
    setCurrentPage(page);
    // Fetch data for the new page
  };

  const toggleDetails = (index) => {
    console.log(index)
    const position = details.indexOf(index)
    let newDetails = details.slice()
    if (position !== -1) {
      newDetails.splice(position, 1)
    } else {
      newDetails = [...details, index]
      // console.log(newDetails[0])
      loadDetails(newDetails[0])
    }
    // setDetails(newDetails)
  }
  const apiUrl = process.env.REACT_APP_API_URL;

  async function requestdata() {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      EME_EmployeeID: 'sedcx'
    }

    const EmployeeDetails = await getEmployeeAll(formData)
    setData(EmployeeDetails);

  }

  useEffect(() => {
    requestdata();
  }, [open]);

  const [currentItems, setCurrentItems] = useState(data)


  function useDoubleClick(onDoubleClick) {
    const [doubleClickedRow, setDoubleClickedRow] = useState(null);

    const handleDoubleClick = (row) => {
      setDoubleClickedRow(row);
      onDoubleClick(row);
    };

    return [doubleClickedRow, handleDoubleClick];
  }
  const handleRowDoubleClick = (row) => {
    // Handle row double-click action here
    console.log('Double-clicked row:', row);
  };

  const [doubleClickedRow, handleDoubleClick] = useDoubleClick(handleRowDoubleClick);

  return (
    <> <CModal size='lg'
      scrollable
      alignment="center"
      visible={open}
      onClose={onClose}
      aria-labelledby="TooltipsAndPopoverExample"
      backdrop="static"
    >
      <CModalHeader>
        <CModalTitle id="TooltipsAndPopoverExample">Search Employee</CModalTitle>
      </CModalHeader>
      <CModalBody>
        <CCardBody>
          <CSmartTable
            cleaner
            clickableRows
            columns={columns_search}
            columnFilter
            columnSorter
            // footer
            items={data}
            onColumnFilterChange={setColumnFilter}
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

            onDoubleClick={() => handleDoubleClick(row.original)}
            onSelectedItemsChange={(items) => {
              console.log(items)
            }}
            scopedColumns={{
              status: (item) => (
                <td>
                  <CBadge color={getBadge(item.status)}>{item.status}</CBadge>
                </td>
              ),
              select: (item) => {
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
                      Select
                    </CButton>
                  </td>
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
      </CModalBody>
    </CModal>
    </>
  )
}
export default EmployeeGridModel
