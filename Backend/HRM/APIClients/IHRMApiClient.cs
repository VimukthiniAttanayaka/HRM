using HRM_DAL.Models;
using System.Threading.Tasks;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Models.ResponceModels;
using System.Collections.Generic;

namespace HRM.APIClients
{
    public interface IHRMApiClient
    {
        Task<(string ErrorMessage, HRMToken.Rootobject AuthenticationTokenMsg)> Get_OAuthToken(Get_OAuthToken_RequestModel model);
      
    }
}
