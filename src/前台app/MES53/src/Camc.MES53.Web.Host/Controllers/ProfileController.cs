using Abp.AspNetCore.Mvc.Authorization;
using Camc.MES53.Storage;

namespace Camc.MES53.Web.Controllers
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