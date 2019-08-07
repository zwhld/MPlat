using Abp.Authorization;
using Camc.MES53.Authorization.Roles;
using Camc.MES53.Authorization.Users;

namespace Camc.MES53.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
