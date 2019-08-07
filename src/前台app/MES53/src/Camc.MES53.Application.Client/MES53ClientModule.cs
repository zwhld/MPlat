using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Camc.MES53
{
    public class MES53ClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MES53ClientModule).GetAssembly());
        }
    }
}
