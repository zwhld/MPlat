using Abp.AutoMapper;
using Camc.MES53.Authorization.Users;
using Camc.MES53.Authorization.Users.Dto;
using Camc.MES53.Web.Areas.AppAreaName.Models.Common;

namespace Camc.MES53.Web.Areas.AppAreaName.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}