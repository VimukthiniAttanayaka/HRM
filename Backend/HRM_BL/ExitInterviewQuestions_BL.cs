using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;
using HRM_DAL.Data;

namespace HRM_BL
{
    public class ExitInterviewQuestions_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_ExitInterviewQuestions(ExitInterviewQuestionsModel item)//ok
        {
            return HRM_DAL.Data.ExitInterviewQuestions_Data.add_new_ExitInterviewQuestions(item);
        }

        public static List<ReturnResponse> modify_ExitInterviewQuestions(ExitInterviewQuestionsModel item)//ok
        {
            return HRM_DAL.Data.ExitInterviewQuestions_Data.modify_ExitInterviewQuestions(item);
        }

        public static List<ReturnResponse> inactivate_ExitInterviewQuestions(InactiveExitInterviewQuestionsModel item)//ok
        {
            return HRM_DAL.Data.ExitInterviewQuestions_Data.inactivate_ExitInterviewQuestions(item);
        }

        public static List<ReturExitInterviewQuestionsModelHead> get_ExitInterviewQuestions_all(GetExitInterviewQuestionsAllModel item)//ok
        {
            return HRM_DAL.Data.ExitInterviewQuestions_Data.get_ExitInterviewQuestions_all(item);
        }

        public static List<ReturExitInterviewQuestionsModelHead> get_ExitInterviewQuestions_single(GetExitInterviewQuestionsSingleModel item)
        {
            return HRM_DAL.Data.ExitInterviewQuestions_Data.get_ExitInterviewQuestions_single(item);
        }

    }
}