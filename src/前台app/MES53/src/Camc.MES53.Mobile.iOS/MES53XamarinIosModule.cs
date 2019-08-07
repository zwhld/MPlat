using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Camc.MES53
{
    [DependsOn(typeof(MES53XamarinSharedModule))]
    public class MES53XamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MES53XamarinIosModule).GetAssembly());
        }
    }
}