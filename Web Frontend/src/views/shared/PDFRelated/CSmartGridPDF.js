
import React, { useState, useEffect, useRef } from 'react'
import { Margin, usePDF, Options } from "react-to-pdf";
import { jsPDF } from 'jspdf';
import html2canvas from 'html2canvas';
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge } from '@coreui/react-pro'

import "jspdf-autotable";


import { columns, headers, GetDataList as ExitInterviewQuestions_GetDataList } from '../../../controllers/exitinterviewquestions_controllers.js';

const CSmartGridPDF = ({ filename, data, title, headers }) => {

  const [data1, setData] = useState([])
  const setDataByPage = (filename, data) => {
    if (filename == "exitinterviewquestions") setData(ExitInterviewQuestions_GetDataList(data))
  }

  const handleExportToPDF = () => {

    setDataByPage(filename, data);

    const unit = "pt";
    const size = "A4"; // Use A1, A2, A3 or A4
    const orientation = "portrait"; // portrait or landscape

    const marginLeft = 40;
    const doc = new jsPDF(orientation, unit, size);

    doc.setFontSize(15);

    // const title = "My Awesome Report";
    // const headers = [["id", "Description", "EntryType", "status"]];

    // const data1 = data.map(elt => [elt.id, elt.Description, elt.EntryType, elt.status]);

    let content = {
      startY: 50,
      head: headers,
      body: data1
    };

    doc.text(title.toUpperCase(), marginLeft, 40);
    doc.autoTable(content);
    doc.save(filename + ".pdf")
  };
  return (
    <div>
      <CButton color="primary" className="mb-2" onClick={() => handleExportToPDF()}>Download PDF</CButton>
    </div>
  );

};

export default CSmartGridPDF;
