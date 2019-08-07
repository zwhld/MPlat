using Abp.AspNetCore.Mvc.Authorization;
using Camc.ZTWorkflow.Storage;

namespace Camc.ZTWorkflow.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(ITempFileCacheManager tempFileCacheManager) :
            base(tempFileCacheManager)
        {
        }
    }
}