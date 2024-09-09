using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class PerformanceAppriasalQuestions_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnPerformanceAppriasalQuestionsModelHead> get_PerformanceAppriasalQuestions_single(PerformanceAppriasalQuestions model)//ok
        {
            return HRM_DAL.Data.PerformanceAppriasalQuestions_Data.get_PerformanceAppriasalQuestions_single(model);
        }
        public static List<ReturnPerformanceAppriasalQuestionsModelHead> get_PerformanceAppriasalQuestions_all(PerformanceAppriasalQuestionsSearchModel model)//ok
        {
            return HRM_DAL.Data.PerformanceAppriasalQuestions_Data.get_PerformanceAppriasalQuestions_all(model);
        }


        public static List<ReturncustResponse> add_new_PerformanceAppriasalQuestions(PerformanceAppriasalQuestionsModel item)//ok
        {
            return HRM_DAL.Data.PerformanceAppriasalQuestions_Data.add_new_PerformanceAppriasalQuestions(item);
        }

        public static List<ReturncustResponse> modify_PerformanceAppriasalQuestions(PerformanceAppriasalQuestionsModel item)//ok
        {
            return HRM_DAL.Data.PerformanceAppriasalQuestions_Data.modify_PerformanceAppriasalQuestions(item);
        }

        public static List<ReturnResponse> inactivate_PerformanceAppriasalQuestions(InactivePAAQModel item)//ok
        {
            return HRM_DAL.Data.PerformanceAppriasalQuestions_Data.inactivate_PerformanceAppriasalQuestions(item);
        }


    }

}

