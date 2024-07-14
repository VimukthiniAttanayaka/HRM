
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class ContainerDTModel : RequestBaseModel
    {
        [Key]
        public string CT_ID { get; set; }
        public string CT_Name { get; set; }
        public string CT_Description { get; set; }
        public string USER_ID { get; set; }
        public bool CT_Status { get; set; }


    }
    public class ReturnContainerDTModel
    {
        [Key]
        public string CT_ID { get; set; }
        public string CT_Name { get; set; }
        public string CT_Description { get; set; }
        public string CT_Status { get; set; }
        public string USER_ID { get; set; }
        public string CT_CreatedBy { get; set; }
        public string CT_CreatedDateTime { get; set; }
        public string CT_ModifiedBy { get; set; }
        public string CT_ModifiedDateTime { get; set; }
        public string RC { get; set; }
    }

    public class ReturnContainerDTAllModel
    {
        [Key]
        public string CT_ID { get; set; }
        public string CT_Name { get; set; }
        public string CT_Description { get; set; }
        public string CT_Status { get; set; }
        public string RC { get; set; }

    }

    public class InactiveContainerDTModel : RequestBaseModel
    {

        public string CT_ID { get; set; }
        public string USER_ID { get; set; }
    }

    public class GetContainerDTAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string CT_ID { get; set; }
        public string CT_Name { get; set; }
        public string CT_Description { get; set; }
        public string CT_Status { get; set; }

    }

    public class GetContainerLTAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string CLT_ID { get; set; }
        public string CLT_Name { get; set; }
        public string CLT_Description { get; set; }
        public string CLT_Status { get; set; }

    }
    public class GetContainerDTSingleModel : RequestBaseModel
    {

        public string CT_ID { get; set; }

    }

    public class ReturnContainerDTModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnContainerDTModel> ContainerDT { get; set; }


    }
    public class ReturnContainerLTModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnContainerLTModel> ContainerLT { get; set; }


    }
    public class ReturnContainerDTAllModelHead
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnContainerDTAllModel> containerdtall { get; set; }


    }

    public class ReturnContainerLTModel
    {
        [Key]
        public string CLT_ID { get; set; }
        public string CLT_Name { get; set; }
        public string CLT_Description { get; set; }
        public string CLT_Status { get; set; }
        public string USER_ID { get; set; }
        public string CLT_CreatedBy { get; set; }
        public string CLT_CreatedDateTime { get; set; }
        public string CLT_ModifiedBy { get; set; }
        public string CLT_ModifiedDateTime { get; set; }
        public string RC { get; set; }
    }





}
