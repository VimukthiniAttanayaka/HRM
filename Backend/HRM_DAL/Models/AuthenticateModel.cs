using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class AuthenticatedUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserTableID { get; set; }
        public string UserEmail { get; set; }
        public string AuthenticationKey { get; set; }
    }
}