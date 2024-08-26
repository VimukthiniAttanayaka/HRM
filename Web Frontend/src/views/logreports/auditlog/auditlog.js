import { ReportDesigner } from "../../../AnkareReport/components/ReportDesigner";
import { ReportRenderer } from "../../../AnkareReport/components/ReportRenderer";
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import React, { useState, useEffect } from 'react'
// import { layout as defaultLayout } from './layout';
import { data as defaultData, columns as defaultColumns, ExcelColumnsHeadings } from './data';
import { dataSource as defaultDataSource } from './data-source';
import defaultLayout from './layout_json.json';
import { getAuditLogReport } from '../../../apicalls/reportdata/auditlogreport.js';
import ExcelExportReports from '../../shared/ExcelRelated/ExcelExportReports.js';

function ReportHome() {
  const [designer, setDesigner] = useState();

  const [data, setData] = useState(defaultData);
  const [dataList, setDataList] = useState(defaultData);
  const [titleList, setTitleList] = useState(defaultData);
  const [headerList, setHeaderList] = useState(defaultData);
  const [copyrightList, setCopyrightList] = useState(defaultData);
  const [columns, setColumns] = useState(defaultColumns);
  const [dataSource, setDataSource] = useState(defaultDataSource);
  // const [layout, setLayout] = useState(defaultLayout);
  const [layout, setLayout] = useState(defaultLayout);
  const [visible, setVisible] = useState(false);


  async function requestdata() {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      EME_EmployeeID: 'sedcx'
    }

    const AuditLogReport = await getAuditLogReport(formData)
    setData(AuditLogReport);

    // console.log(UserLogReport.titlelist);
    setDataList(AuditLogReport.content);
    setTitleList(AuditLogReport.titlelist);
    setHeaderList(AuditLogReport.headerlist);
    setCopyrightList(AuditLogReport.copyrightlist);
    setVisible(true);
  }
  useEffect(() => {
    requestdata();
  }, []);



  return (
    <div>
      {/* <div style={{
        width: '1100px',
        height: '500px',
        border: '1px solid black',
        margin: '10px auto',
      }}>
        <ReportDesigner
          dataSource={dataSource}
          layout={layout}
          onChange={(e) => {
            console.log("onchange:", e);

            if (designer) {
              console.clear();
              console.log(designer);
              setLayout(designer.toJSON());
            }
          }}
          onCreate={(d) => {
            setDesigner(d);
          }}
        />
      </div> */}
    <ExcelExportReports data={dataList} title={titleList} header={headerList} copyright={copyrightList} columns={ExcelColumnsHeadings} fileName="auditlogreport" />
      <div style={{
        border: '1px solid black',
        width: '1100px',
        margin: 'auto',
      }}>
        <ReportRenderer
          columns={columns}
          data={data}
          layout={layout}
        />
      </div>
    </div>
  )
}

export default ReportHome
