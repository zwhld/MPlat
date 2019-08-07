using Abp.AspNetZeroCore;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Camc.MES53.Configuration;
using Camc.MES53.EntityFrameworkCore;

namespace Camc.MES53.Web.Public.Startup
{
    [DependsOn(
        typeof(MES53WebCoreModule)
    )]
    public class MES53WebFrontEndModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MES53WebFrontEndModule(IHostingEnvironment env, MES53EntityFrameworkCoreModule MES53EntityFrameworkCoreModule)
        {
            _appConfiguration = env.GetAppConfiguration();
            MES53EntityFrameworkCoreModule.SkipDbSeed = true;
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpWebCommon().MultiTenancy.DomainFormat = _appConfiguration["App:WebSiteRootAddress"] ?? "http://localhost:45776/";
            Configuration.Modules.AspNetZero().LicenseCode = _appConfiguration["AbpZeroLicenseCode"];

            //Changed AntiForgery token/cookie names to not conflict to the main application while redirections.
            Configuration.Modules.AbpWebCommon().AntiForgery.TokenCookieName = "Public-XSRF-TOKEN";
            Configuration.Modules.AbpWebCommon().AntiForgery.TokenHeaderName = "Public-X-XSRF-TOKEN";

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            Configuration.Navigation.Providers.Add<FrontEndNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MES53WebFrontEndModule).GetAssembly());
        }
    }
}
