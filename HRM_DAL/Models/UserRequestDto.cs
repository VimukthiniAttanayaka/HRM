using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class UserRequestDto
    {
        public int isCompleteList { get; set; }
        public List<UserSave> users { get; set; }
    }
}
