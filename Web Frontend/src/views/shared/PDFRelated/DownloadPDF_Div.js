
import React, { useState, useEffect } from 'react'
import { Margin, usePDF, Options } from "react-to-pdf";
import { CCardBody, CButton, CSmartTable, CCollapse, CRow, CCol, CBadge } from '@coreui/react-pro'

const DownloadPDF_Div = ({ targetRef1, filename }) => {

    const { toPDF, targetRef } = usePDF({ filename: 'page.pdf' });

    // useEffect(() => {
    //     requestdata();
    //   }, []);

    return (
        <div>
            <CButton onClick={() => toPDF()}>Download PDF</CButton>
        </div>
    );
};

export default DownloadPDF_Div;
