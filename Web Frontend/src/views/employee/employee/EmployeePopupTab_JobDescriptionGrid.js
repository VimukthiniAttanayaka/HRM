import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CSmartTable, CBadge, CCollapse, CModal, CTabs, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { getEmployeeJobDescriptionAll } from '../../../apicalls/employeejobdescription/get_all_list.js';
import { getEmployeeJobDescriptionSingle } from '../../../apicalls/employeejobdescription/get_employeejobdescription_single.js';
import EmployeePopupTab_JobDescriptionPopUp from './EmployeePopupTab_JobDescriptionPopUp.js';
import { getBadge } from '../../shared/gridviewconstants.js';

const EmployeePopupTab_JobDescriptionGrid = ({ EmployeeDetails, popupStatus }) => {

  const [details, setDetails] = useState([])
  const [data, setData] = useState([])

  const columns = [
    {
      key: 'id',
      label: 'departmentid',
      filter: true,
      sorter: false,
    },
    {
      key: 'Employeeid',
      _style: { width: '20%' }
    },
    {
      key: 'jobdescriptionid',
      _style: { width: '20%' }
    },
    {
      key: 'status',
      _style: { width: '20%' }
    },
    {
      key: 'show_details',
      label: '',
      _style: { width: '1%' },
      filter: false,
      sorter: false,
    },
  ];

  const toggleDetails = (index) => {


    const position = details.indexOf(index)
    let newDetails = details.slice()
    if (position !== -1) {
      newDetails.splice(position, 1)
    } else {
      newDetails = [...details, index]
      // alert(newDetails[newDetails.length - 1])
      // console.log(newDetails)
      handleOpenPopup1()
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
    const EmployeeJobDescriptionDetails = await getEmployeeJobDescriptionAll(formData)
    // console.log(EmployeeJobDescriptionDetails)
    setData(EmployeeJobDescriptionDetails);
    // const res = await fetch(apiUrl + 'employee/get_employee_all', {
    //   method: 'POST',
    //   headers: { 'Content-Type': 'application/json' },
    //   body: JSON.stringify(formData),
    // })
    //   .then(response => response.json())
    //   .then(json => {
    //     let res1 = JSON.parse(JSON.stringify(json))
    //     console.log(res1);
    //     // setCustomerId(  res1[0].Customer[0].CUS_ID);
    //   })
  }
  useEffect(() => {
    requestdata();
  }, []);


  const [currentItems, setCurrentItems] = useState(data)

  const csvContent = currentItems.map((item) => Object.values(item).join(',')).join('\n')

  const csvCode = 'data:text/csv;charset=utf-8,SEP=,%0A' + encodeURIComponent(csvContent)

  const [visible1, setVisible1] = useState(false);

  const handleOpenPopup1 = () => {
    setVisible1(true);
  };

  const handleClosePopup1 = () => {
    setVisible1(false);
  };

  return (
    <> 
     <CTabPanel className="p-3" itemKey="jobDescription">
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
            <EmployeePopupTab_JobDescriptionPopUp onClose1={handleClosePopup1} visible1={visible1} onOpen1={handleOpenPopup1} />
          </CCol>
        </CRow>
        <CSmartTable
          cleaner
          // clickableRows
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
            // console.log(items)
          }}
          scopedColumns={{
            avatar: (item) => (
              <td>
                {/* <CAvatar src={`/images/avatars/${item.avatar}`} /> */}
              </td>
            ),
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
    </CTabPanel> </>
  )
}
export default EmployeePopupTab_JobDescriptionGrid
