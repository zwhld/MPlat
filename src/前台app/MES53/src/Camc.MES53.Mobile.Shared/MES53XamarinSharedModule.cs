using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Camc.MES53
{
    [DependsOn(typeof(MES53ClientModule), typeof(AbpAutoMapperModule))]
    public class MES53XamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MES53XamarinSharedModule).GetAssembly());
        }
    }
}