export const data = {
  CompanyTitle: "DoashaIT (PVT) LTD",
  LoggedError: "Neelaka",
  PrintedDate: "10/10/2024",
  content: [
    {
      name: "John1",
      surname: "Doe1",
      prices: [
        { id: 1, price: 10 },
        { id: 2, price: 20 },
      ],
    },
    {
      name: "John2",
      surname: "Doe2",
      prices: [
        { id: 3, price: 10 },
        { id: 4, price: 20 },
      ],
    },
    {
      name: "John3",
      surname: "Doe3",
      prices: [
        { id: 5, price: 10 },
        { id: 6, price: 20 },
      ],
    },
  ],
  Copyright: "Copyright @DoashaIT",
  // footer2: "Footer 2",
};

export class ErrorLogModel {
  CompanyTitle;
  LoggedError;
  PrintedDate;
  Copyright;
  content = [
    // { id: 1, name: 'Object 1' },
    // { id: 2, name: 'Object 2' },
    // { id: 2, name: 'Object 2' }
  ];
  titlelist = [
    // [{ value: "Vanilla" }, { value: "Chocolate" }, { value: "" }],
    // [{ value: "Strawberry" }, { value: "Cookies" }, { value: "" }],
    // [{ value: "Strawberry" }, { value: "Cookies" }, { value: "" }]
  ];
  headerlist = [];
  copyrightlist = [];
}
export class ErrorLogModel_Content {
  logid;
  description;  
  errorpage;
  userid;
  datetime;
  loggedip;
  errorref;
}
export class ErrorLogModel_Title {
  LoggedError;
  CompanyTitle;
  PrintedDate;
}
export class ErrorLogModel_Header {
  ReportTitle;
}
export class ErrorLogModel_CopyRight {
  Copyright;
}
export let ExcelColumnsHeadings = [['id', 'Errorid', 'Errorname', 'loggedin', 'logout']];

export const columns = [
  { key: 'id', title: 'ID', dataIndex: 'id', width: 80 },
  { key: 'Errorid', title: 'Errorid', dataIndex: 'Errorid' },
  { key: 'Errorname', title: 'Errorname', dataIndex: 'Errorname' },
  { key: 'loggedin', title: 'loggedin', dataIndex: 'loggedin' },
  { key: 'logout', title: 'logout', dataIndex: 'logout' }
];