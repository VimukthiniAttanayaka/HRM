
import React, { useState, useEffect,useRef } from 'react'
import { Margin, usePDF, Options } from "react-to-pdf";
import { jsPDF } from 'jspdf';
import html2canvas from 'html2canvas';
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge } from '@coreui/react-pro'

const CSmartGridPDF = ({ filename }) => {
    const tableRef = useRef(null);
    const { toPDF, targetRef } = usePDF({ filename: filename });//'exitinterviewquestions.pdf'

    
  const handleExportToPDF = () => {
    html2canvas(tableRef.current).then((canvas) => {
      const imgData = canvas.toDataURL('image/png');
      const pdf = new jsPDF();
      pdf.addImage(imgData, 'JPEG', 0, 0);
      pdf.save('exitinterviewquestions.pdf');

    });
  };

    // return (
//         <div>
//              // <CButton color="primary"
//         //     className="mb-2" onClick={handleExportToPDF}>Export to PDF</CButton>
//             <CButton onClick={() => usePDF()}>Download PDF</CButton>
//   </div > 
//      );
     return (
        <div>
            <CButton onClick={() => usePDF()}>Download PDF</CButton>
        </div>
    );

};

export default CSmartGridPDF;
