using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class container_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_container(ContainerModel item)//ok
        {
            return HRM_DAL.Data.container_Data.add_new_container(item);
        }

        public static List<ReturnResponse> modify_container(ContainerModel item)//ok
        {
            return HRM_DAL.Data.container_Data.modify_container(item);
        }

        public static List<ReturnResponse> inactivate_container(InactiveContainerModel item)//ok
        {
            return HRM_DAL.Data.container_Data.inactivate_container(item);
        }

        public static List<ReturnContainerModelHead> get_container_all(GetContainerAllModel item)//ok
        {
            return HRM_DAL.Data.container_Data.get_container_all(item);
        }

        public static List<ReturnContainerModelHead> get_container_single(GetContainerSingleModel item)
        {
            return HRM_DAL.Data.container_Data.get_container_single(item);
        }



    }








}








