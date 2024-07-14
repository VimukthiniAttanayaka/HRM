using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class ContainerDT_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_containerdt(ContainerDTModel item)//ok
        {
            return HRM_DAL.Data.ContainerDT_Data.add_new_containerdt(item);
        }

        public static List<ReturnResponse> modify_containerdt(ContainerDTModel item)//ok
        {
            return HRM_DAL.Data.ContainerDT_Data.modify_containerdt(item);
        }

        public static List<ReturnResponse> inactivate_containerdt(InactiveContainerDTModel item)//ok
        {
            return HRM_DAL.Data.ContainerDT_Data.inactivate_containerdt(item);
        }

        public static List<ReturnContainerDTModelHead> get_containerdt_all(GetContainerDTAllModel item)//ok
        {
            return HRM_DAL.Data.ContainerDT_Data.get_containerdt_all(item);
        }

        public static List<ReturnContainerDTModelHead> get_containerdt_single(GetContainerDTSingleModel item)
        {
            return HRM_DAL.Data.ContainerDT_Data.get_containerdt_single(item);
        }

        public static List<ReturnContainerLTModelHead> get_container_label_types(GetContainerLTAllModel item)
        {
            return HRM_DAL.Data.ContainerDT_Data.get_container_label_types(item);
        }


    }








}








