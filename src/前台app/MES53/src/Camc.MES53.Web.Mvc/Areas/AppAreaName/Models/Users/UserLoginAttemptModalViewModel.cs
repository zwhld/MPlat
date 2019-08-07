using System.Collections.Generic;
using Camc.MES53.Authorization.Users.Dto;

namespace Camc.MES53.Web.Areas.AppAreaName.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}