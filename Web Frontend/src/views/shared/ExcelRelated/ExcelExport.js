import { useState, useEffect, React } from "react";
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge } from '@coreui/react-pro'
import { saveAs } from 'file-saver';
const xlsx = require('xlsx');

const ExcelExport = ({ data, columns, fileName }) => {

  const exportToExcel = () => {

    // console.log(data);
    const worksheet = xlsx.utils.json_to_sheet(data);
    // console.log(worksheet);
    const workbook = xlsx.utils.book_new();
    let Heading = [];//[['id', 'name', 'text']];
    //Had to create a new workbook and then add the header
    xlsx.utils.sheet_add_aoa(worksheet, Heading);

    //Starting in the second row to avoid overriding and skipping headers
    xlsx.utils.sheet_add_json(worksheet, data, { origin: 'A2', skipHeader: true });

    xlsx.utils.book_append_sheet(workbook, worksheet, 'Sheet1');
    const excelBuffer = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
    const blob = new Blob([excelBuffer], { type: 'application/octet-stream' });
    saveAs(blob, `${fileName}.xlsx`);
  };

  return (
    <CButton color="primary"
      className="mb-2"
      onClick={exportToExcel}>Download items as Excel</CButton>
  );
}

export default ExcelExport;
