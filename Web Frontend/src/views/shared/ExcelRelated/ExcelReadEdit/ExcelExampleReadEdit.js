import { useState, useEffect } from "react";
import Spreadsheet from "react-spreadsheet";

const ExcelExampleReadEdit = ({ visible, datas }) => {

    // const [visible, setVisible] = useState(false);
    const [data, setData] = useState(
        [
            [{ value: "Vanilla" }, { value: "Chocolate" }, { value: "" }],
            [{ value: "Strawberry" }, { value: "Cookies" }, { value: "" }]
        ]
    );


    // useEffect(() => {
    //     if (datas.length > 0) {
    //         console.log(datas);
    //         setData(datas)
    //     }
    // }, [datas]);

    return <Spreadsheet data={data} onChange={setData} />;
};
export default ExcelExampleReadEdit;