using Abp.AspNetCore.Mvc.Authorization;
using Camc.MES53.Authorization;
using Camc.MES53.Storage;
using Abp.BackgroundJobs;
using Abp.Authorization;

namespace Camc.MES53.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}