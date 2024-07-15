﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_DAL.DAL.Helper
{
    public class TableResponse<T>
    {
        public TableResponse() { }

        public TableResponse(IEnumerable<T> outList)
        {
            OutList = outList;
        }
        public string Message { get; set; }
        public bool Ok { get; set; }
        public IEnumerable<T> OutList { get; set; }


     

    }
}
