
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class MailingTypes
    {
        public const string Local = "Local";
        public const string Oversea = "Oversea";
    }

    public class MailTypes
    {
        public const string Courier = "Courier";
        public const string Registered = "Registered";
        public const string Ordinary = "Ordinary";
    }

    public class MailingTypes_TabElements
    {
        public class Courier
        {
            public class Local
            {
                public const string EnableLocalMail = "Enable Local Mail";
            }
            public class Oversea
            {
                public const string EnableOverseaMail = "Enable Oversea Mail";
            }
        }
        public class Registered
        {
            public class Local
            {
                public const string TrackedMail = "Tracked Mail";
                public const string TrackedPackage = "Tracked Package";
                public const string BatchedRecord = "Batched Record";
            }
            public class Oversea
            {
                public const string Type1 = "Type 1";
                public const string Type2 = "Type 2";
            }
        }
        public class Ordinary
        {
            public class Local
            {
                public const string Type1 = "Type 1";
                public const string Type2 = "Type 2";
            }
            public class Oversea
            {
                public const string Type1 = "Type 1";
                public const string Type2 = "Type 2";
            }
        }
    }

    public class MailTypeMapRequestModel
    {
        public string Courier_Local_DefaultName { get; set; } = "";
        public string Courier_OverSea_DefaultName { get; set; } = "";

        public string Registered_Local_DefaultName { get; set; } = "";
        public string Registered_OverSea_DefaultName { get; set; } = "";
        public string Ordinary_Local_DefaultName { get; set; } = "";
        public string Ordinary_OverSea_DefaultName { get; set; } = "";

        public bool Registered_Local_Batched_Record { get; set; } = false;
        public bool Courier_Local_Enable_Local_Mail { get; set; } = false;
        public bool Courier_Oversea_Enable_Oversea_Mail { get; set; } = false;
        public bool Registered_Local_Tracked_Mail { get; set; } = false;
        public bool Registered_Local_Tracked_Package { get; set; } = false;
        public bool Ordinary_Local_Type_1 { get; set; } = false;
        public bool Ordinary_Oversea_Type_1 { get; set; } = false;
        public bool Registered_Oversea_Type_1 { get; set; } = false;
        public bool Ordinary_Local_Type_2 { get; set; } = false;
        public bool Ordinary_Oversea_Type_2 { get; set; } = false;
        public bool Registered_Oversea_Type_2 { get; set; } = false;
    }

    public class MailTypeMapResponceModel
    {
        public List<string> Courier_Local_List { get; set; } = new List<string>() {
            MailingTypes_TabElements.Courier.Local.EnableLocalMail,
        };
        public List<string> Courier_OverSea_List { get; set; } = new List<string>() {
            MailingTypes_TabElements.Courier.Oversea.EnableOverseaMail,
        };
        public List<string> Registered_Local_List { get; set; } = new List<string>() {
            MailingTypes_TabElements.Registered.Local.BatchedRecord,
            MailingTypes_TabElements.Registered.Local.TrackedMail,
            MailingTypes_TabElements.Registered.Local.TrackedPackage };
        public List<string> Registered_OverSea_List { get; set; } = new List<string>() {
            MailingTypes_TabElements.Registered.Oversea.Type1,
            MailingTypes_TabElements.Registered.Oversea.Type2};
        public List<string> Ordinary_Local_List { get; set; } = new List<string>() {
            MailingTypes_TabElements.Ordinary.Local.Type1,
            MailingTypes_TabElements.Ordinary.Local.Type2 };
        public List<string> Ordinary_OverSea_List { get; set; } = new List<string>() {
            MailingTypes_TabElements.Ordinary.Oversea.Type1,
            MailingTypes_TabElements.Ordinary.Oversea.Type2 };

        public string Courier_Local_DefaultName { get; set; } = "";
        public string Courier_OverSea_DefaultName { get; set; } = "";

        public string Registered_Local_DefaultName { get; set; } = "";
        public string Registered_OverSea_DefaultName { get; set; } = "";
        public string Ordinary_Local_DefaultName { get; set; } = "";
        public string Ordinary_OverSea_DefaultName { get; set; } = "";

        public bool Registered_Local_Batched_Record { get; set; } = false;
        public bool Courier_Local_Enable_Local_Mail { get; set; } = false;
        public bool Courier_Oversea_Enable_Oversea_Mail { get; set; } = false;
        public bool Registered_Local_Tracked_Mail { get; set; } = false;
        public bool Registered_Local_Tracked_Package { get; set; } = false;
        public bool Ordinary_Local_Type_1 { get; set; } = false;
        public bool Ordinary_Oversea_Type_1 { get; set; } = false;
        public bool Registered_Oversea_Type_1 { get; set; } = false;
        public bool Ordinary_Local_Type_2 { get; set; } = false;
        public bool Ordinary_Oversea_Type_2 { get; set; } = false;
        public bool Registered_Oversea_Type_2 { get; set; } = false;
    }

    public class MailTypeMapAttributeModel
    {
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string MailType { get; set; }
        public string MailingType { get; set; }
    }

    public class Customer_MailType_MapModel
    {
        public string CUSMTMap_CUS_ID { get; set; }
        public string CUSMTMap_Name { get; set; }
        public string CUSMTMap_Text { get; set; }
        public string CUSMTMap_CreatedBy { get; set; }
        public string CUSMTMap_CreatedDateTime { get; set; }
        public string CUSMTMap_ModifiedBy { get; set; }
        public string CUSMTMap_ModifiedDateTime { get; set; }
        public bool CUSMTMap_IsActive { get; set; }
        public bool CUSMTMap_IsDefault { get; set; }
        public string CUSMTMap_MailType { get; set; }
        public string CUSMTMap_MailingType { get; set; }
    }
}
