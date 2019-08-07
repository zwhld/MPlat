using System.Threading.Tasks;
using Abp.Authorization.Users;
using Camc.MES53.Authorization.Users;

namespace Camc.MES53.Authorization
{
    public static class UserManagerExtensions
    {
        public static async Task<User> GetAdminAsync(this UserManager userManager)
        {
            return await userManager.FindByNameAsync(AbpUserBase.AdminUserName);
        }
    }
}
