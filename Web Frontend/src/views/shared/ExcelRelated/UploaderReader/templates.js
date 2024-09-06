import {EmployeeDetail} from '../../../../apicalls/employee/get_all_list'

export function getColumnsForSheet(slice) {
    let ColumnsList = [];
    class Columns {
        constructor(title, dataIndex, editable) {
            this.title = title.replaceAll(" ", "");
            this.dataIndex = dataIndex.replaceAll(" ", "");
            this.editable = editable;
        }
    }

    slice.map((row, index) => {
        if (row && row !== "undefined") {
            if (index == 0) {
                row.map((column, index1) => {
                    ColumnsList[index1] = new Columns(column, column, false);
                }
                );
                // console.log(ColumnsList);
            }
        }
    });
    return ColumnsList;
}

export function getRowsForColumns(slice, classtype) {
    let ColumnsList = [];
    class Columns {
        constructor(title, dataIndex, editable) {
            this.title = title;
            this.dataIndex = dataIndex;
            this.editable = editable;
        }
    }

    // console.log(slice);
    slice.map((row, index) => {
        if (row && row !== "undefined") {
            if (classtype == "requests") { ColumnsList.push(new requests(index, row[0], row[1], row[2])); }
            if (classtype == "employees") {
                ColumnsList.push(new EmployeeDetail(
                    row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7]
                ));
            }
            // ColumnsList.push({
            //     key: index,
            //     name: row[0],
            //     age: row[1],
            //     gender: row[2]
            // });
        }
    });

    console.log(ColumnsList);
    return ColumnsList;
}

export class requests {
    constructor(index, FullName, Email, Template) {
        this.index = index; this.FullName = FullName; this.Email = Email; this.Template = Template;
    }
}