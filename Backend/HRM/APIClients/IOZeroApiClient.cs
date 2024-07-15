using HRM_DAL.Models;
using System.Threading.Tasks;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Models.ResponceModels;

namespace HRM.APIClients
{
    public interface IKioskiApiClient
    {
        Task<(string ErrorMessage, OZeroToken.Rootobject bag)> Get_OAuthToken(Get_OAuthToken_RequestModel model, string authorization, string requestReferenceID, string RequestType, string SmartKioskvendorID);
        Task<OZero_ReturnResponce> Reset_Password(ResetPassword resetPw, string Authorization, string RequestReferenceID, string RequestType, string SmartKioskvendorID);
        Task<OZero_ReturnResponce> Validate_OAuthToken(Get_OAuthToken_RequestModel model, string authorization, string requestReferenceID, string RequestType, string SmartKioskvendorID);
    }
}
