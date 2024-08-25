export const dataSource = [
  { label: "Printed By", field: "" },
  { label: "LoggedUser", field: "LoggedUser" },
  { label: "CompanyTitle", field: "CompanyTitle" },
  { label: "PrintedDate", field: "PrintedDate" },
  {
    label: "Header",
    field: "Header",
    children: [
      { label: "id", field: "" },
      { label: "userid", field: "" },
      { label: "username", field: "" },
      { label: "LoggedDateTime", field: "" },
      { label: "UserLogOffTime", field: "" },
      {
        label: "Prices",
        field: "prices",
        children: [
          { label: "Id", field: "id" },
          { label: "Price", field: "price" },
        ],
      },
    ],
  }, {
    label: "Columns",
    field: "Columns",
    children: [{ label: "id", field: "" },
    { label: "userid", field: "" },
    { label: "username", field: "" },
    { label: "LoggedDateTime", field: "" },
    { label: "UserLogOffTime", field: "" },]
  },
  {
    label: "Content",
    field: "content",
    children: [
      { label: "id", field: "id" },
      { label: "userid", field: "userid" },
      { label: "username", field: "username" },
      { label: "LoggedDateTime", field: "LoggedDateTime" },
      { label: "UserLogOffTime", field: "UserLogOffTime" },

      {
        label: "Prices",
        field: "prices",
        children: [
          { label: "Id", field: "id" },
          { label: "Price", field: "price" },
        ],
      },
    ],
  },
  { label: "Copyright", field: "Copyright" },
  // { label: "Footer 2", field: "footer2" },
];
