using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.MultiTenancy;
using Abp.Runtime.Session;
using Abp.Threading;
using Microsoft.AspNetCore.Identity;

namespace Camc.ZTWorkflow
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class ZTWorkflowAppServiceBase : ApplicationService
    {
      

        protected ZTWorkflowAppServiceBase()
        {
            LocalizationSourceName = ZTWorkflowConsts.LocalizationSourceName;
        }

      
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}