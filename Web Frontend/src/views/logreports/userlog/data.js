export const data = {
  CompanyTitle: "DoashaIT (PVT) LTD",
  LoggedUser: "Neelaka",
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

export class UserLogModel {
  CompanyTitle;
  LoggedUser;
  PrintedDate;
  Copyright;
  content= [
    { id: 1, name: 'Object 1' },
    { id: 2, name: 'Object 2' },
    { id: 2, name: 'Object 2' }
  ];
}
export class UserLogModel_Content{
  id;
  userid;
  username;
  LoggedDateTime;
  UserLogOffTime
}
export const columns = [
  { key: 'id', title: 'ID', dataIndex: 'id', width: 80 },
  { key: 'userid', title: 'userid', dataIndex: 'userid' },
  { key: 'username', title: 'username', dataIndex: 'username' },
  { key: 'LoggedDateTime', title: 'LoggedDateTime', dataIndex: 'LoggedDateTime' },
  { key: 'UserLogOffTime', title: 'UserLogOffTime', dataIndex: 'UserLogOffTime' }
];