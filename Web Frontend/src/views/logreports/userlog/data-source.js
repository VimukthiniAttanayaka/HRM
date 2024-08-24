export const dataSource = [
  { label: "Printed By", field: "" },
  { label: "LoggedUser", field: "LoggedUser" },
  { label: "CompanyTitle", field: "CompanyTitle" },
  { label: "PrintedDate", field: "PrintedDate" }, {
    label: "Content",
    field: "content",
    children: [
      { label: "Name", field: "name" },
      { label: "Surname", field: "surname" },
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
