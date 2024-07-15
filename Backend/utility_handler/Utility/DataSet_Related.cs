using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace utility_handler.Utility
{
    public class DataSet_Related
    {
        public static string DataTable_To_String(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    object[] arr = dr.ItemArray;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        sb.Append(Convert.ToString(arr[i]));
                        sb.Append("|");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return sb.ToString();

        }
        public static string DataRow_To_String(DataRow dr)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    sb.Append(Convert.ToString(arr[i]));
                    sb.Append("|");
                }
            }
            catch (Exception ex)
            {

            }
            return sb.ToString();

        }
    }
}
