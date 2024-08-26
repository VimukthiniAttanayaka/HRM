export const data = {
  header1: "Header 1",
  header2: "Header 2",
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
  footer1: "Footer 1",
  footer2: "Footer 2",
};

export class AuditLogModel {
  CompanyTitle;
  LoggedAudit;
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
export class AuditLogModel_Content {
  action;
  description;
  createdBy;
  clientIP;
  createdDateTime;
  sequenceNo;
  module;
  controler;
  actionType;
  actionMap_ID
}
export class AuditLogModel_Title {
  LoggedAudit;
  CompanyTitle;
  PrintedDate;
}
export class AuditLogModel_Header {
  ReportTitle;
}
export class AuditLogModel_CopyRight {
  Copyright;
}
export let ExcelColumnsHeadings = [['id', 'Auditid', 'Auditname', 'loggedin', 'logout']];

export const columns = [
  { key: 'id', title: 'ID', dataIndex: 'id', width: 80 },
  { key: 'Auditid', title: 'Auditid', dataIndex: 'Auditid' },
  { key: 'Auditname', title: 'Auditname', dataIndex: 'Auditname' },
  { key: 'loggedin', title: 'loggedin', dataIndex: 'loggedin' },
  { key: 'logout', title: 'logout', dataIndex: 'logout' }
];