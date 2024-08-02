﻿using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class Location_BL 
    {
        private static LogError objError = new LogError();

        public static List<ReturnLocationAllModelHead> get_location_all(GetLocationAllModel item)//ok
        {
            return HRM_DAL.Data.Location_Data.get_location_all(item);
        }
        public static List<ReturnLocationModelHead> get_location_single(GetLocationSingleModel item)
        {
            return HRM_DAL.Data.Location_Data.get_location_single(item);
        }
        public static List<ReturnResponse> add_new_Location(LocationModel item)//ok
        {
            return HRM_DAL.Data.Location_Data.add_new_Location(item);
        }
        public static List<ReturnResponse> modify_Location(LocationModel item)
        {
            return HRM_DAL.Data.Location_Data.modify_Location(item);
        }
        public static List<ReturnResponse> inactivate_Location(InactiveMDLModel item)
        {
            return HRM_DAL.Data.Location_Data.inactivate_Location(item);
        }

    }








}








