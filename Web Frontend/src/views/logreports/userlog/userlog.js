import React, { useState, useEffect } from 'react'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { ReportDesigner } from "../../../AnkareReport/components/ReportDesigner";
import { ReportRenderer } from "../../../AnkareReport/components/ReportRenderer";
// import { useState } from "react";
// import { layout as defaultLayout } from './layout_json';
import defaultLayout from './layout_json.json';
import { data as defaultData } from './data';
import { dataSource as defaultDataSource } from './data-source';
import { getUserLogReport } from '../../../apicalls/reportdata/userlogreport.js';

function ReportHome() {
  const [designer, setDesigner] = useState();

  const [data, setData] = useState(defaultData);
  const [dataSource, setDataSource] = useState(defaultDataSource);
  // const [layout, setLayout] = useState(defaultLayout);
  const [layout, setLayout] = useState(defaultLayout);

  async function requestdata() {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      EME_EmployeeID: 'sedcx'
    }

    const UserLogReport = await getUserLogReport(formData)
    setData(UserLogReport);

  }
  useEffect(() => {
    requestdata();
  }, []);

  return (
    <div>
      <div style={{
        width: '1100px',
        height: '500px',
        border: '1px solid black',
        margin: '10px auto',
      }}>
        <ReportDesigner
          dataSource={dataSource}
          layout={layout}
          onChange={(e) => {
            // console.log("onchange:", e);

            if (designer) {
              console.clear();
              console.log(designer);
              // alert(designer.toJSON());
              setLayout(designer.toJSON());
            }
          }}
          onCreate={(d) => {
            setDesigner(d);
          }}
        />
      </div>
      <div style={{
        border: '1px solid black',
        width: '1100px',
        margin: 'auto',
      }}>
        <ReportRenderer
          data={data}
          layout={layout}
        />
      </div>
     </div>
  )
}

export default ReportHome
