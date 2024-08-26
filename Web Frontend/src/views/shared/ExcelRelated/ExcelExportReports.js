import { useState, useEffect, React } from "react";
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge } from '@coreui/react-pro'
import { saveAs } from 'file-saver';
import { s } from 'xlsx-js-style';

const xlsx = require('xlsx');

export const ExcelExportReports = ({ data, title, columns, fileName, header, copyright }) => {

  const exportToExcel = () => {
    const styles = {
      header: {
        font: { bold: true },
        fill: { fgColor: { rgb: 'FFC000' } }, // Yellow background
      },
      data: {
        alignment: { horizontal: 'center' },
        border: {
          bottom: { style: 'thin', color: { rgb: '000000' } },
        },
      },
    };


    // console.log(data);
    const worksheet = xlsx.utils.json_to_sheet([]);
    // console.log(worksheet);
    const workbook = xlsx.utils.book_new();
    let Heading = [];//[['id', 'name', 'text']];
    //Had to create a new workbook and then add the header
    // xlsx.utils.sheet_add_aoa(worksheet, Heading);

    //Starting in the second row to avoid overriding and skipping headers
    xlsx.utils.sheet_add_json(worksheet, title, { origin: 'A1', skipHeader: true });

    xlsx.utils.sheet_add_json(worksheet, header, { origin: 'A2', skipHeader: true, origin: { r: 1, c: 2 } });
    // xlsx.utils.sheet_add_aoa(worksheet,  [
    //   ['Header 1', 'Header 2', 'Header 3'],
    //   ['Data 1', 'Data 2', 'Data 3'],
    // ], { origin: 'A2', skipHeader: true, origin: { r: 1, c: 2 } });

    // worksheet['A2'].s = styles.header;
    //  worksheet['B2'].s = styles.header;
    // worksheet['A3'].s = styles.header;
  //   worksheet['A2'].s = {
  //     font: {
  //         name: 'arial',
  //         sz: 24,
  //         bold: true,
  //         color: "#F2F2F2"
  //     },
  // }
  
    xlsx.utils.sheet_add_json(worksheet, data, { skipHeader: false, origin: { r: 3, c: 0 } });

    xlsx.utils.sheet_add_json(worksheet, copyright, { origin: 'A3', skipHeader: true, origin: { r: data.length + 6, c: 3 } });

    // console.log(title);
    // console.log(data);
    // xlsx.utils.sheet_add_aoa(worksheet, columns);

    // xlsx.utils.sheet_add_json(worksheet, data, { skipHeader: true, origin: { r: 6, c: 0 } });//, header: ["A", "B", "C"] 

    xlsx.utils.book_append_sheet(workbook, worksheet, 'Sheet1');

    const excelBuffer = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
    const blob = new Blob([excelBuffer], { type: 'application/octet-stream' });
    saveAs(blob, `${fileName}.xlsx`);
  };

  return (
    <CButton color="primary"
      className="mb-2"
      onClick={exportToExcel}>Export to Excel</CButton>
  );
}

export default ExcelExportReports;