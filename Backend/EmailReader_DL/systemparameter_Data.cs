using MailTrak_DAL.Models;
using System;
using System.Collections.Generic;

namespace EmailReader_DL.Data
{
    public class SystemParameter_Data
    {
        public class PredefinedProperties
        {
            public class ServiceRelated
            {
                public static ReturnSystemPMModel Exceptions_EmailReder_Process_Session1_From()//ok
                {
                    ReturnSystemPMModel tem = new ReturnSystemPMModel();

                    tem = DataAccess.get_system_parameter_single("Exceptions_EmailReder_Process_Session1_From");

                    return tem;

                }

                public static ReturnSystemPMModel Exceptions_EmailReder_Process_Session1_To()//ok
                {
                    ReturnSystemPMModel tem = new ReturnSystemPMModel();

                    tem = DataAccess.get_system_parameter_single("Exceptions_EmailReder_Process_Session1_To");

                    return tem;

                }

                public static ReturnSystemPMModel Exceptions_EmailReder_Process_Session2_From()//ok
                {
                    ReturnSystemPMModel tem = new ReturnSystemPMModel();

                    tem = DataAccess.get_system_parameter_single("Exceptions_EmailReder_Process_Session2_From");

                    return tem;

                }

                public static ReturnSystemPMModel Exceptions_EmailReder_Process_Session2_To()//ok
                {
                    ReturnSystemPMModel tem = new ReturnSystemPMModel();

                    tem = DataAccess.get_system_parameter_single("Exceptions_EmailReder_Process_Session2_To");

                    return tem;

                }

                public static ReturnSystemPMModel Exceptions_EmailReder_Process_Session3_From()//ok
                {
                    ReturnSystemPMModel tem = new ReturnSystemPMModel();

                    tem = DataAccess.get_system_parameter_single("Exceptions_EmailReder_Process_Session3_From");

                    return tem;

                }

                public static ReturnSystemPMModel Exceptions_EmailReder_Process_Session3_To()//ok
                {
                    ReturnSystemPMModel tem = new ReturnSystemPMModel();

                    tem = DataAccess.get_system_parameter_single("Exceptions_EmailReder_Process_Session3_To");

                    return tem;

                }
            }
        }
    }
}






