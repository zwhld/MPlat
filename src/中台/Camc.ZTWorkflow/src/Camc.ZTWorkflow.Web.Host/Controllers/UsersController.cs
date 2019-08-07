﻿using Abp.AspNetCore.Mvc.Authorization;
using Camc.ZTWorkflow.Authorization;
using Camc.ZTWorkflow.Storage;
using Abp.BackgroundJobs;

namespace Camc.ZTWorkflow.Web.Controllers
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