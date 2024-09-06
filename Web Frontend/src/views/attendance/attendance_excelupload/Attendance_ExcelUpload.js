// import React from 'react'
import { CCard, CCardHeader, CCardBody } from '@coreui/react-pro'

import CompanyDataGrid from './Attendance_ExcelUploadDataGrid.js'
import { getLabelText } from 'src/MultipleLanguageSheets'
import ExcelFileReader from '../../shared/ExcelRelated/UploaderReader/ExcelFileReader.js'
import { getAttendanceAll } from '../../../apicalls/attendance/get_all_list.js';
import { getAttendanceSingle } from '../../../apicalls/attendance/get_attendance_single.js';
import Pagination from '../../shared/Pagination.js'
import { getBadge } from '../../shared/gridviewconstants.js';
import { columns, headers } from '../../controllers/attendance_controllers.js';
import ExcelExport from '../../shared/ExcelRelated/ExcelExport.js';
import CSmartGridPDF from '../../shared/PDFRelated/CSmartGridPDF.js';
import React, { createContext, useContext } from 'react';

window.classtype = 'attendance'

const Attendance_ExcelUpload = () => {
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

export default Attendance_ExcelUpload
