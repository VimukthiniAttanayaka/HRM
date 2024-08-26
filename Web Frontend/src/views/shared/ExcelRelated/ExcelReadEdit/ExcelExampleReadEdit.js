import { useState, useEffect } from "react";
import Spreadsheet from "react-spreadsheet";

const ExcelExampleReadEdit = ({ visible, datas }) => {

    // const [visible, setVisible] = useState(false);
    const [data, setData] = useState(
        [
            [{ value: "Vanilla" }, { value: "Chocolate" }, { value: "" }],
            [{ value: "Strawberry" }, { value: "Cookies" }, { value: "" }],
            [{ value: "Strawberry1" }, { value: "Cookies1" }, { value: "" }]
        ]
    );

    console.log(visible);
    // useEffect(() => {
    //     setData(datas);
    // }, [visible]);

    return <div className="d-grid">
        {visible == true ? <Spreadsheet data={datas} onChange={setData} /> : <Spreadsheet data={data} onChange={setData} />}
    </div>
        ;
};
export default ExcelExampleReadEdit;