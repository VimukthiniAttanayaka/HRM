// import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import CompanyDataGrid from './Employee_ExcelUploadDataGrid'
import { getLabelText } from 'src/MultipleLanguageSheets'
import ExcelFileReader from '../../shared/ExcelRelated/UploaderReader/ExcelFileReader'
import { getEmployeeAll } from '../../../apicalls/employee/get_all_list.js';
import { getEmployeeSingle } from '../../../apicalls/employee/get_employee_single.js';
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns, headers } from '../../controllers/employee_controllers.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';
import React, { createContext, useContext } from 'react';

window.classtype = 'employees'

const Employee_ExcelUpload = () => {
  let templatetype = 'translation_employee'

  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>Department List</strong> */}
          {getLabelText('Company List', templatetype)}
        </CCardHeader>
        <CCardBody>
        <ExcelFileReader />
          <CompanyDataGrid onOpen={() => handleOpenPopup} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Employee_ExcelUpload
