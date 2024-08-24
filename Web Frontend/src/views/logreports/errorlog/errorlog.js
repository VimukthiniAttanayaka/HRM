import { ReportDesigner } from "../../../AnkareReport/components/ReportDesigner";
import { ReportRenderer } from "../../../AnkareReport/components/ReportRenderer";
import { useState } from "react";
import { layout as defaultLayout } from './layout';
import { data as defaultData } from './data';
import { dataSource as defaultDataSource } from '../../../AnkareReport/data/data-source';
function ReportHome() {
  const [designer, setDesigner] = useState();

  const [data, setData] = useState(defaultData);
  const [dataSource, setDataSource] = useState(defaultDataSource);
  const [layout, setLayout] = useState(defaultLayout);
  return (
    // <div>
    //   <div style={{
    //     width: '800px',
    //     height: '500px',
    //     border: '1px solid black',
    //     margin: '10px auto',
    //   }}>
    //     <ReportDesigner
    //       dataSource={dataSource}
    //       layout={layout}
    //       onChange={(e) => {
    //         console.log("onchange:", e);

    //         if (designer) {
    //           setLayout(designer.toJSON());
    //         }
    //       }}
    //       onCreate={(d) => {
    //         setDesigner(d);
    //       }}
    //     />
    //   </div>
    <div style={{
      border: '1px solid black',
      width: '500px',
      margin: 'auto',
    }}>
      <ReportRenderer
        data={data}
        layout={layout}
      />
    </div>
    // </div>
  )
}

export default ReportHome
