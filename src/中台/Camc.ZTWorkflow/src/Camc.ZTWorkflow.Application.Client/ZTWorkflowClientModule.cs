using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Camc.ZTWorkflow
{
    public class ZTWorkflowClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZTWorkflowClientModule).GetAssembly());
        }
    }
}
